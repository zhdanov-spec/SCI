using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZPSoft.GameZone.SCI.Classes.SyncClasses
{
    public class SareaDownloadSyncing : LocalSareaSyncInfo
    {
        readonly string table;
        public SareaDownloadSyncing(LocalSareaSyncInfo sareaSyncInfo, CancellationTokenSource cancelTokenSource)
        {
            lock (GlobalVariable.SyncLocker)
                GlobalVariable.LocalSareaSyncInfo.isDownload = true;
            LogClasses.LogQueue.Enqueue(Constants.Services.SyncMainServer, "Початок отримання данних ", Constants.TypeLog.Green);
            SqlConnection MainServerConnection = new SqlConnection(GlobalVariable.ConnectionStringSync);
            SqlConnection LocalServerConnection = new SqlConnection(GlobalVariable.ConnectionString);
            SyncOperationStatistics syncOperationStatistic;
            Int32 currentDownload = 1;
            foreach (DataRow row in GlobalVariable.Settings.SynchroInfoDownload)
            {
                string scopeName = string.Format("{0}{1}", "TableScope", row["TableSync"]);
                table = row["TableSync"].ToString();
                LogClasses.LogQueue.Enqueue(Constants.Services.SyncMainServer, string.Format("{0} з {1}. Отримання данних з таблиці - {2}", currentDownload, GlobalVariable.Settings.SynchroInfoDownload.Rows.Count, row["TableSync"]), Constants.TypeLog.Green);

                if ((Constants.TypeSyncing)row["TypeSyncing"] == Constants.TypeSyncing.FieldSync)
                {
                    //SqlCommand sqlCommand = new SqlCommand()
                    //{
                    //    //Получим из таблицы источника данные
                    //    Connection = LocalServerConnection,
                    //    CommandType = CommandType.Text,
                    //    CommandText = string.Format("select (case when max(cast({2} as Datetime2 (3) )) is NULL then cast(-53690 as datetime) else max(cast({2} as Datetime2 (3))) end) as updatetime from {0} WITH (NOLOCK) where sareaid={1}", row["TableSync"], sareaSyncInfo.sareaId, row["FieldMonitoring"])
                    //};

                    //try
                    //{
                    //    sqlCommand.Connection.Open();

                    //    DateTime lastTimeSource = (DateTime)sqlCommand.ExecuteScalar();
                    //    sqlCommand.Connection.Close();
                    //    sqlCommand.Connection = mainConnection;
                    //    sqlCommand.CommandText = string.Format("select (case when max(cast({2} as Datetime2 (3) )) is NULL then cast(-53690 as datetime) else max(cast({2} as Datetime2 (3))) end) as updatetime from {0} WITH (NOLOCK) where sareaid={1}", row["TableSync"], sareaSyncInfo.sareaId, row["FieldMonitoring"]);
                    //    sqlCommand.Connection.Open();
                    //    DateTime lastTimeDestination = (DateTime)sqlCommand.ExecuteScalar();
                    //    sqlCommand.Connection.Close();
                    //    if (lastTimeSource > lastTimeDestination)
                    //    {

                    //        sqlCommand.Connection = remoteConnection;
                    //        sqlCommand.CommandText = string.Format("select * from {0} WITH (NOLOCK) where {2}>cast('{1}' as Datetime2 (3)) order by {2}", row["TableSync"], lastTimeDestination.ToString("yyyyMMdd HH:mm:ss.fff"), row["FieldMonitoring"]);
                    //        sqlCommand.Connection.Open();
                    //        SqlDataReader reader = sqlCommand.ExecuteReader();
                    //        List<string> tableFields = GetColumnsName(reader);
                    //        using (SqlConnection destinationConnection = new SqlConnection(GlobalVariable.MainConnectionString))
                    //        {
                    //            // open the connection
                    //            destinationConnection.Open();

                    //            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection.ConnectionString))
                    //            {
                    //                bulkCopy.BatchSize = 500;
                    //                bulkCopy.NotifyAfter = 500;
                    //                foreach (string field in tableFields)
                    //                {
                    //                    bulkCopy.ColumnMappings.Add(field, field);
                    //                }

                    //                bulkCopy.SqlRowsCopied += new SqlRowsCopiedEventHandler(BulkCopy_SqlRowsCopied);
                    //                bulkCopy.DestinationTableName = row["TableSync"].ToString();
                    //                bulkCopy.WriteToServer(reader);
                    //            }
                    //        }
                    //        reader.Close();
                    //        sqlCommand.Connection.Close();
                    //    }
                    //    else
                    //    {
                    //        LogClasses.LogSareaQueue.Enqueue(sareaSyncInfo.sareaId, string.Format("{2} з {3}. Отримано за таблиці {0}, {1} записів", row["TableSync"], 0, currentDownload, GlobalVariable.Settings.SynchroInfoDownload.Rows.Count), Constants.TypeLog.Green);
                    //        LogClasses.LogSareaQueue.Enqueue(GlobalVariable.MainSareaId, string.Format("Додано до таблиці {0}, {1} записів", row["TableSync"], 0), Constants.TypeLog.Green);
                    //    }
                    //}
                    //catch
                    //{
                    //    break;
                    //}

                }
                else if ((Constants.TypeSyncing)row["TypeSyncing"] == Constants.TypeSyncing.SqlSync)
                {
                    SynchronizationHelper SynchronizationHelper = new SynchronizationHelper();
                    SqlSyncProvider sqlSyncProviderMain = SynchronizationHelper.ConfigureSqlSyncProvider(sareaSyncInfo, GlobalVariable.ConnectionStringSync, scopeName);
                    SqlSyncProvider sqlSyncProviderLocal = SynchronizationHelper.ConfigureSqlSyncProvider(sareaSyncInfo, GlobalVariable.ConnectionString, scopeName);

                    RelationalSyncProvider mainRelationalSyncProvider = sqlSyncProviderMain;
                    RelationalSyncProvider localRelationalSyncProvider = sqlSyncProviderLocal;

                    mainRelationalSyncProvider.MemoryDataCacheSize = 1000;
                    localRelationalSyncProvider.MemoryDataCacheSize = 1000;

                    mainRelationalSyncProvider.BatchingDirectory = Path.GetTempPath();
                    localRelationalSyncProvider.BatchingDirectory = Path.GetTempPath();

                    try
                    {
                        syncOperationStatistic = SynchronizationHelper.SynchronizeProviders(sareaSyncInfo, mainRelationalSyncProvider, localRelationalSyncProvider, SyncDirectionOrder.Download);
                        LogClasses.LogQueue.Enqueue(Constants.Services.SyncMainServer, string.Format("{2} з {3}. Отримано з таблиці {0}, {1} записів", row["TableSync"], syncOperationStatistic.DownloadChangesTotal, currentDownload, GlobalVariable.Settings.SynchroInfoDownload.Rows.Count), Constants.TypeLog.Green);
                    }
                    catch
                    {
                        LogClasses.LogQueue.Enqueue(Constants.Services.SyncMainServer, string.Format("Помилка в таблиці {0}", row["TableSync"]), Constants.TypeLog.Red);
                        break;
                    }
                }
                currentDownload++;
            }
            lock (GlobalVariable.SyncLocker)
                GlobalVariable.LocalSareaSyncInfo.isDownload = false;
        }
    }
}

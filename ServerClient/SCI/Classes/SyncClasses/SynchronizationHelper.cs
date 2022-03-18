using Microsoft.Synchronization;
using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPSoft.GameZone.SCI.Classes.SyncClasses
{
    public class SynchronizationHelper
    {
        public SynchronizationHelper()
        {
        }
        public SqlSyncProvider ConfigureSqlSyncProvider(LocalSareaSyncInfo sareaSyncInfo, string connection, string Locate)
        {
            SqlSyncProvider sqlSyncProvider = new SqlSyncProvider()
            {
                ScopeName = Locate,
                Connection = new SqlConnection(connection)
            };
            DbSyncScopeDescription dbSyncScopeDescription = new DbSyncScopeDescription(Locate);
            sqlSyncProvider.CommandTimeout = 10;
            try
            {
                SqlSyncScopeProvisioning sqlSyncScopeProvisioning = new SqlSyncScopeProvisioning((SqlConnection)sqlSyncProvider.Connection);
            }
            catch (Exception ex)
            {
                LogClasses.LogQueue.Enqueue(Constants.Services.SyncMainServer, "Помилка звязку ", Constants.TypeLog.Red);
            }
            //sqlSyncProvider.BatchApplied += new EventHandler<DbBatchAppliedEventArgs>(SynchronizationHelper.ProviderBatchApplied);
            //sqlSyncProvider.BatchSpooled += new EventHandler<DbBatchSpooledEventArgs>(SynchronizationHelper.ProviderBatchSpooled);
            //sqlSyncProvider.ChangesApplied += new EventHandler<DbChangesAppliedEventArgs>(SynchronizationHelper.ProviderChangesApplied);
            //sqlSyncProvider.ApplyChangeFailed += SqlSyncProvider_ApplyChangeFailed;
            //sqlSyncProvider.ChangesSelected += new EventHandler<DbChangesSelectedEventArgs>(this.ServerProviderChangesSelected);
            //sqlSyncProvider.ApplyingChanges += SqlSyncProvider_ApplyingChanges;
            //sqlSyncProvider.ApplyMetadataFailed += SqlSyncProvider_ApplyMetadataFailed;
            //sqlSyncProvider.ChangesSelected += SqlSyncProvider_ChangesSelected;
            //sqlSyncProvider.DbConnectionFailure += SqlSyncProvider_DbConnectionFailure;
            //sqlSyncProvider.SelectingChanges += SqlSyncProvider_SelectingChanges;
            //sqlSyncProvider.SyncPeerOutdated += SqlSyncProvider_SyncPeerOutdated;
            //sqlSyncProvider.SyncProgress += SqlSyncProvider_SyncProgress;

            return sqlSyncProvider;

        }

       

        public SyncOperationStatistics SynchronizeProviders(LocalSareaSyncInfo sareaSyncInfo, RelationalSyncProvider localProvider, RelationalSyncProvider remoteProvider, SyncDirectionOrder direction)
        {
            SyncOrchestrator syncOrchestrator = new SyncOrchestrator()
            {
                LocalProvider = localProvider,
                RemoteProvider = remoteProvider
            };
            ((SqlSyncProvider)syncOrchestrator.LocalProvider).ApplyChangeFailed += new EventHandler<DbApplyChangeFailedEventArgs>(SynchronizationHelper.Packet_ApplyChangeFailed);
            syncOrchestrator.Direction = direction;
            SyncOperationStatistics syncOperationStatistic = null;
            int countTry = 0;
            while (countTry < 5)
            {
                try
                {
                    syncOperationStatistic = syncOrchestrator.Synchronize();
                    break;
                }
                catch
                {
                    countTry++;
                    LogClasses.LogQueue.Enqueue(Constants.Services.SyncMainServer, string.Format("Помилка відправки пакету. Спроба відпарвки - {0}", countTry), Constants.TypeLog.Red);
                }
            }
            return syncOperationStatistic;
        }
        #region Events Function
        private static void Packet_ApplyChangeFailed(object sender, DbApplyChangeFailedEventArgs e)
        {
            if (e.Conflict.Type == DbConflictType.LocalUpdateRemoteUpdate)
            {
                try
                {
                    e.Action = ApplyAction.RetryWithForceWrite;
                }
                catch
                {
                }
            }
            if (e.Conflict.Type == DbConflictType.LocalDeleteRemoteUpdate)
            {
                try
                {
                    e.Action = ApplyAction.RetryWithForceWrite;
                }
                catch
                {
                }
            }
            if (e.Conflict.Type == DbConflictType.ErrorsOccurred)
            {

                EventError(e.Context.DataSet);
            }
        }
       
        #endregion
        #region Logic Function
        private static void EventError(DataSet ds)
        {
            switch (ds.Tables[0].TableName.ToString())
            {
                case "Sessions":
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        try
                        {
                            LogClasses.LogQueue.Enqueue(Constants.Services.SyncMainServer, string.Format("Неможливо записати в таблицю Sessions дані сесії {0} картка {1}", row["IdSession"].ToString(), row["IdCard"].ToString()), Constants.TypeLog.Red);
                        }
                        catch
                        {
                            LogClasses.LogQueue.Enqueue(Constants.Services.SyncMainServer, string.Format("Помилка треба обробити"), Constants.TypeLog.Red);

                        }

                    }
                    break;
                default:
                    LogClasses.LogQueue.Enqueue(Constants.Services.SyncMainServer, "Необробна таблиця" + ds.Tables[0].TableName.ToString(), Constants.TypeLog.Red);
                    break;
            }
        }
        #endregion

    }
}

using Microsoft.Synchronization.Data;
using Microsoft.Synchronization.Data.SqlServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using ZPSoft.GameZone.SGZGlobals.Classes;

namespace ZPSoft.GameZone.SCI.Forms
{
    public partial class SettingsForm : RadForm
    {
        #region Init Function
        public SettingsForm()
        {
            InitializeComponent();
        }
        public void ExecuteCreateFile()
        {
            Classes.GlobalVariable.StrPassword = "";
            Classes.GlobalVariable.StrPasswordSync = "";
            Classes.GlobalVariable.Settings.Clear();
            Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)Constants.DatabaseSettings.SERVER_NAME, "127.0.0.1", "Адрес Сервера");
            Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)Constants.DatabaseSettings.SERVER_BASENAME, "SCI", "Найменування Бази");
            Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)Constants.DatabaseSettings.SERVER_LOGIN, "sa", "Користувач Бази");
            Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)Constants.DatabaseSettings.SERVER_PASSWORD, Crypt.CryptValue(Classes.GlobalVariable.StrPassword), "Пароль Користувача Бази");
            Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)Constants.DatabaseSettings.NODE_POINT, "1", "Ідентифікатор вузла");
            Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)Constants.DatabaseSettings.DEVICES_PORT, "9761", "Порт Каркових Приймачів");
            Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)Constants.DatabaseSettings.SYNC_SERVER_ENABLED, "false", "Підключення серверу синхронізації");
            Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)Constants.DatabaseSettings.SYNC_SERVER_NAME, "127.0.0.1", "Адреса серверу синхронізації");
            Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)Constants.DatabaseSettings.SYNC_SERVER_BASENAME, "geton", "База даних сервера синхронызації");
            Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)Constants.DatabaseSettings.SYNC_SERVER_LOGIN, "login", "Логин бази даних сервера синхронызації");
            Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)Constants.DatabaseSettings.SYNC_SERVER_PASSWORD, Crypt.CryptValue(Classes.GlobalVariable.StrPasswordSync), "Пароль Користувача Бази Сінхронізації");

            Classes.GlobalVariable.Settings.AcceptChanges();
            Classes.GlobalVariable.Settings.WriteXml(Constants.SettingsFileName);


            if (ShowDialog() == DialogResult.OK)
            {
                SaveParams();
            };
            Application.Restart();
        }
        public bool ExecuteSet()
        {
            syncToggleSwitch.Value = Convert.ToBoolean(Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SYNC_SERVER_ENABLED).Value);
            if(syncToggleSwitch.Value)
            {
                LoadMainTable();
                LoadDownloadTable();
                LoadUploadTable();
            }
            syncServerMaskedEditBox.Text = Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SYNC_SERVER_NAME).Value;
            syncBaseNameTextBox.Text = Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SYNC_SERVER_BASENAME).Value;
            syncLoginNameTextBox.Text = Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SYNC_SERVER_LOGIN).Value;


            serverMaskedEditBox.Text = Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SERVER_NAME).Value;
            baseNameTextBox.Text = Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SERVER_BASENAME).Value;
            loginNameTextBox.Text = Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SERVER_LOGIN).Value;
            idNodeTextBox.Text = Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.NODE_POINT).Value;
            devicePortTextBox.Text = Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.DEVICES_PORT).Value;
            Classes.GlobalVariable.StrPassword = Crypt.UncryptValue(Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SERVER_PASSWORD).Value);
            Classes.GlobalVariable.StrPasswordSync = Crypt.UncryptValue(Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SYNC_SERVER_PASSWORD).Value);
            try
            {
                Classes.GlobalVariable.SqlConnection.Open();
                Classes.GlobalVariable.GlobalsDataAdapter.Fill(Classes.GlobalVariable.ServerDataSet);
                if (Classes.GlobalVariable.ServerDataSet.Globals.Count == 0)
                {
                    //Не установленна площадка надо установить
                    new SGZForms.Forms.MessageForm().Execute("Помилка", "Не встановленна площадка серверу");
                }
                else
                {
                    sareaIdTextBox.Text = Classes.GlobalVariable.ServerDataSet.Globals.FindByGlobalsKey("SAREAID").GlobalsValue;
                }
            }
            catch (System.Data.SqlClient.SqlException)
            {
                //Ошибка подключения
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка підключення до бази даних");
                
            }
            finally
            {
                Classes.GlobalVariable.SqlConnection.Close();
            }
            if (ShowDialog() == DialogResult.OK)
            {
                SaveParams();
                return true;
            }
            return false;
        }
        #endregion
        #region Events Function
        private void TestButtonConnection_Click(object sender, EventArgs e)
        {
            Classes.GlobalVariable.SqlConnection = new System.Data.SqlClient.SqlConnection

            {
                ConnectionString = Classes.GlobalVariable.ConnectionString
            };
            SaveParams();
            if(IsServerConnected(Classes.GlobalVariable.ConnectionString))
            {
                new SGZForms.Forms.MessageForm().Execute("Тест підключення", "Підключення до бази данних - вдале");
            }
            else
            {
                new SGZForms.Forms.MessageForm().Execute("Тест підключення", "Помилка підключення до бази данних");
            }
        }
        private void TestButtonConnectionSync_Click(object sender, EventArgs e)
        {
            Classes.GlobalVariable.SqlConnectionSync = new System.Data.SqlClient.SqlConnection

            {
                ConnectionString = Classes.GlobalVariable.ConnectionStringSync
            };
            SaveParams();
            if (IsServerConnected(Classes.GlobalVariable.ConnectionStringSync))
            {
                new SGZForms.Forms.MessageForm().Execute("Тест підключення", "Підключення до віддаленої бази данних - вдале");
            }
            else
            {
                new SGZForms.Forms.MessageForm().Execute("Тест підключення", "Помилка підключення до віддаленої бази данних");
            }
        }
        private void PassTextBox_TextChanged(object sender, EventArgs e)
        {
            Classes.GlobalVariable.StrPassword = passTextBox.Text;
        }
        private void syncPassTextBox_TextChanged(object sender, EventArgs e)
        {
            Classes.GlobalVariable.StrPasswordSync = syncPassTextBox.Text;
        }

        #region Synchro button events
        private void uploadPlusButton_Click(object sender, EventArgs e)
        {
            if (mainGridView.CurrentRow == null) return;
            if (ChekRowInUploadTable(mainGridView.CurrentRow.Cells["TABLE_NAME"].Value.ToString())) return;
            TypeSyncTableForm typeSyncTableForm = new TypeSyncTableForm();
            if (typeSyncTableForm.ExecuteAdd(out Int32 typeSync, out string nameField))
            {
                GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(uploadGridView.MasterView);
                rowInfo.Cells["TableSync"].Value = mainGridView.CurrentRow.Cells["TABLE_NAME"].Value.ToString();
                rowInfo.Cells["TypeSyncing"].Value = typeSync;
                rowInfo.Cells["FieldMonitoring"].Value = nameField;
                uploadGridView.Rows.Add(rowInfo);
            }
        }
        private void uploadMinusButton_Click(object sender, EventArgs e)
        {
            uploadGridView.Rows.Remove(uploadGridView.CurrentRow);
        }
        private void downloadPlusButton_Click(object sender, EventArgs e)
        {
            if (mainGridView.CurrentRow == null) return;
            if (ChekRowInDownloadTable(mainGridView.CurrentRow.Cells["TABLE_NAME"].Value.ToString())) return;
            TypeSyncTableForm typeSyncTableForm = new TypeSyncTableForm();
            if (typeSyncTableForm.ExecuteAdd(out Int32 typeSync, out string nameField))
            {
                GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(downloadGridView.MasterView);
                rowInfo.Cells["TableSync"].Value = mainGridView.CurrentRow.Cells["TABLE_NAME"].Value.ToString();
                rowInfo.Cells["TypeSyncing"].Value = typeSync;
                rowInfo.Cells["FieldMonitoring"].Value = nameField;
                downloadGridView.Rows.Add(rowInfo);
            }
        }
        private void downloadMinusButton_Click(object sender, EventArgs e)
        {
            downloadGridView.Rows.Remove(downloadGridView.CurrentRow);
        }

        private void uploadUpButton_Click(object sender, EventArgs e)
        {
            MoveRowUpload(true);
        }
        private void uploadDownButton_Click(object sender, EventArgs e)
        {
            MoveRowUpload(false);
        }
        private void downloadUpButton_Click(object sender, EventArgs e)
        {
            MoveRowDownload(true);
        }

        private void downloadDownButton_Click(object sender, EventArgs e)
        {
            MoveRowDownload(false);
        }
        private void ProvisionCreateButton_Click(object sender, EventArgs e)
        {
            if (!syncToggleSwitch.Value)
            {
                new SGZForms.Forms.MessageForm().Execute("Неможливо", "Для створення провізій увімкнить синхронізацію");
                return;
            }
            CreateProvision();
        }
        #endregion

        #endregion
        #region Logic Function
        private void CreateProvision()
        {
            SaveParams();
            List<String> synctables = SynchroTables();
            if (!IsServerConnected(Classes.GlobalVariable.ConnectionStringSync))
            {
                new SGZForms.Forms.MessageForm().Execute("Неможливо", "Немає підключення до відаленного сервера");
                return;
            }
            CreateLinkForMainServer(synctables);
            if (!IsServerConnected(Classes.GlobalVariable.ConnectionString))
            {
                new SGZForms.Forms.MessageForm().Execute("Неможливо", "Немає підключення до локального сервера");
                return;
            }
            CreateLinkForLocalServer(synctables);
            

        }
        private void CreateLinkForMainServer(List<String> synctables)
        {
            SqlConnection sqlConnection = new SqlConnection()
            {
                ConnectionString = Classes.GlobalVariable.ConnectionStringSync
            };
            DbSyncScopeDescription descriptionForScope;
            DbSyncTableDescription descriptionForTable;
            SqlSyncScopeProvisioning sqlSyncScopeProvisioning;
            synctables.ForEach(delegate (String synctable)
            {
                descriptionForScope = new DbSyncScopeDescription(string.Format("TableScope{0}", synctable));
                descriptionForTable = SqlSyncDescriptionBuilder.GetDescriptionForTable(synctable, sqlConnection);
                descriptionForScope.Tables.Add(descriptionForTable);
                sqlSyncScopeProvisioning = new SqlSyncScopeProvisioning(sqlConnection, descriptionForScope)
                {
                    CommandTimeout = 3000
                };
                sqlSyncScopeProvisioning.SetCreateTableDefault(DbSyncCreationOption.Skip);
                try
                {
                  
                    Application.DoEvents();
                    sqlSyncScopeProvisioning.Apply();
                  
                }
                catch (DbProvisioningException)
                {
                  //  new SGZForms.Forms.MessageForm().Execute("Створення таблиць провізії", string.Format("Віддалена провізія для таблиці {0} вже існує", synctable));
                }
                catch (Exception)
                {
                    new SGZForms.Forms.MessageForm().Execute("Помилка", string.Format("Cтворення віддаленої провізії для таблиці ", synctable));
                }
            });
        }
        private void CreateLinkForLocalServer(List<String> synctables)
        {
            SqlConnection mainSqlConnection = new SqlConnection()
            {
                ConnectionString = Classes.GlobalVariable.ConnectionStringSync
            };
            SqlConnection localSqlConnection = new SqlConnection()
            {
                ConnectionString = Classes.GlobalVariable.ConnectionString
            };
            DbSyncScopeDescription descriptionForScope;
            SqlSyncScopeProvisioning sqlSyncScopeProvisioning;
            synctables.ForEach(delegate (String synctable)
            {
                descriptionForScope = SqlSyncDescriptionBuilder.GetDescriptionForScope(string.Format("TableScope{0}", synctable), mainSqlConnection);
                sqlSyncScopeProvisioning = new SqlSyncScopeProvisioning(localSqlConnection, descriptionForScope)
                {
                    CommandTimeout = 3000
                };
                try
                {
                    Application.DoEvents();
                    sqlSyncScopeProvisioning.Apply();
                }
                catch (DbProvisioningException)
                {
                    //new SGZForms.Forms.MessageForm().Execute("Створення таблиць провізії", string.Format("Локальна провізія для таблиці {0} вже існує", synctable));
                }
                catch (Exception ex)
                {
                    new SGZForms.Forms.MessageForm().Execute("Помилка", string.Format("Cтворення локальної провізії для таблиці ", synctable));
                }
            });

        }
        private static bool IsServerConnected(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException)
                {
                    return false;
                }
            }
        }
        private void SaveParams()
        {
            Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SERVER_NAME).Value = serverMaskedEditBox.Text;
            Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SYNC_SERVER_NAME).Value = syncServerMaskedEditBox.Text;

            Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SERVER_BASENAME).Value = baseNameTextBox.Text;
            Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SYNC_SERVER_BASENAME).Value = syncBaseNameTextBox.Text;

            Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SERVER_LOGIN).Value = loginNameTextBox.Text;
            Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SYNC_SERVER_LOGIN).Value = syncLoginNameTextBox.Text;

            Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.NODE_POINT).Value = idNodeTextBox.Text;
            Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.DEVICES_PORT).Value = devicePortTextBox.Text;

            Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SERVER_PASSWORD).Value = Crypt.CryptValue(Classes.GlobalVariable.StrPassword);
            Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SYNC_SERVER_PASSWORD).Value = Crypt.CryptValue(Classes.GlobalVariable.StrPasswordSync);

            Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SYNC_SERVER_ENABLED).Value = syncToggleSwitch.Value.ToString();
            if (syncToggleSwitch.Value)
            {
                Int32 sorting = 1;
                Classes.GlobalVariable.Settings.SynchroInfoDownload.Rows.Clear();
                Classes.GlobalVariable.Settings.SynchroInfoUpload.Rows.Clear();
                foreach (GridViewDataRowInfo dataRow in downloadGridView.Rows)
                {
                    Classes.GlobalVariable.Settings.SynchroInfoDownload.AddSynchroInfoDownloadRow(dataRow.Cells["TableSync"].Value.ToString(), sorting, Convert.ToInt32(dataRow.Cells["TypeSyncing"].Value.ToString()), dataRow.Cells["FieldMonitoring"].Value == null ? "" : dataRow.Cells["FieldMonitoring"].Value.ToString());
                    sorting++;
                }
                sorting = 1;
                foreach (GridViewDataRowInfo dataRow in uploadGridView.Rows)
                {
                    Classes.GlobalVariable.Settings.SynchroInfoUpload.AddSynchroInfoUploadRow(dataRow.Cells["TableSync"].Value.ToString(), sorting, Convert.ToInt32(dataRow.Cells["TypeSyncing"].Value.ToString()), dataRow.Cells["FieldMonitoring"].Value == null ? "" : dataRow.Cells["FieldMonitoring"].Value.ToString());
                    sorting++;
                }
            }


            Classes.GlobalVariable.Settings.AcceptChanges();
            Classes.GlobalVariable.Settings.WriteXml(Constants.SettingsFileName);
            try
            {
                Classes.GlobalVariable.SqlConnection.Open();
                Classes.GlobalVariable.GlobalsDataAdapter.Fill(Classes.GlobalVariable.ServerDataSet);
                DataRow dataRow=Classes.GlobalVariable.ServerDataSet.Globals.Rows.Find("SAREAID");
                foreach (DataSets.ServerDataSet.GlobalsRow row in Classes.GlobalVariable.ServerDataSet.Globals.Rows)
                {
                    if (row.GlobalsKey == "SAREAID")
                    {
                        row.GlobalsValue = sareaIdTextBox.Text;
                        break;
                    }
                }
                Classes.GlobalVariable.GlobalsDataAdapter.Update(Classes.GlobalVariable.ServerDataSet);
                
            }
            catch (System.Data.SqlClient.SqlException)
            {
                new SGZForms.Forms.MessageForm().Execute("Тест підключення", "Помилка підключення до бази данних");
            }
            finally
            {
                Classes.GlobalVariable.SqlConnection.Close();
            }
        }
        private void LoadDownloadTable()
        {
            foreach (DataRow row in Classes.GlobalVariable.Settings.SynchroInfoDownload)
            {
                GridViewDataRowInfo gridViewRowInfo = new GridViewDataRowInfo(this.downloadGridView.MasterView);
                gridViewRowInfo.Cells["TableSync"].Value = row["TableSync"];
                gridViewRowInfo.Cells["TypeSyncing"].Value = row["TypeSyncing"];
                gridViewRowInfo.Cells["FieldMonitoring"].Value = row["FieldMonitoring"];
                downloadGridView.Rows.Add(gridViewRowInfo);
            }

        }
        private void LoadUploadTable()
        {
            foreach (DataRow row in Classes.GlobalVariable.Settings.SynchroInfoUpload)
            {
                GridViewDataRowInfo gridViewRowInfo = new GridViewDataRowInfo(this.uploadGridView.MasterView);
                gridViewRowInfo.Cells["TableSync"].Value = row["TableSync"];
                gridViewRowInfo.Cells["TypeSyncing"].Value = row["TypeSyncing"];
                gridViewRowInfo.Cells["FieldMonitoring"].Value = row["FieldMonitoring"];
                uploadGridView.Rows.Add(gridViewRowInfo);

            }

        }
        private void LoadMainTable()
        {
            mainGridView.DataSource = LoadData();
        }
        private DataTable LoadData()
        {
            DataTable dataTable = new DataTable();
            SqlConnection sqlConnection = new SqlConnection()
            {
                ConnectionString = Classes.GlobalVariable.ConnectionStringSync
            };
            SqlCommand sqlCommand = new SqlCommand()
            {
                Connection = sqlConnection,
                CommandType = CommandType.Text,
                CommandText = "SELECT TABLE_NAME " +
                "FROM INFORMATION_SCHEMA.TABLES " +
                "WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = '"+ Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SYNC_SERVER_BASENAME).Value + "' " +
                "and TABLE_NAME NOT LIKE '%_tracking' " +
                "and TABLE_NAME NOT LIKE 'MSpeer_%' " +
                "and TABLE_NAME NOT LIKE 'MSpub_%' " +
                "and TABLE_NAME NOT LIKE 'scope_%' " +
                "and TABLE_NAME NOT LIKE 'schema_%' " +
                "and TABLE_NAME NOT LIKE 'sysarticlecolumns' " +
                "and TABLE_NAME NOT LIKE 'sysarticles' " +
                "and TABLE_NAME NOT LIKE 'sysarticleupdates' " +
                "and TABLE_NAME NOT LIKE 'sysdiagrams' " +
                "and TABLE_NAME NOT LIKE 'syspublications' " +
                "and TABLE_NAME NOT LIKE 'sysreplservers' " +
                "and TABLE_NAME NOT LIKE 'sysschemaarticles' " +
                "and TABLE_NAME NOT LIKE 'syssubscriptions' " +
                "and TABLE_NAME NOT LIKE 'systranschemas' " +
                "order by Table_NAME "
            };
            sqlConnection.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            sqlDataAdapter.Dispose();
            return dataTable;
        }
        private bool ChekRowInUploadTable(string tableString)
        {
            foreach (GridViewDataRowInfo dataRow in uploadGridView.Rows)
            {
                if (dataRow.Cells["TableSync"].Value.ToString() == tableString) return true;
            }
            return false;
        }
        private bool ChekRowInDownloadTable(string tableString)
        {
            foreach (GridViewDataRowInfo dataRow in downloadGridView.Rows)
            {
                if (dataRow.Cells["TableSync"].Value.ToString() == tableString) return true;
            }
            return false;
        }

        private void MoveRowUpload(bool moveUp)
        {
            GridViewRowInfo currentRow = uploadGridView.CurrentRow;
            if (currentRow == null) return;
            int index = moveUp ? currentRow.Index - 1 : currentRow.Index + 1;
            if (index < 0 || index >= uploadGridView.RowCount) return;
            uploadGridView.Rows.Move(index, currentRow.Index);
            uploadGridView.CurrentRow = uploadGridView.Rows[index];
        }

        private void MoveRowDownload(bool moveUp)
        {
            GridViewRowInfo currentRow = downloadGridView.CurrentRow;
            if (currentRow == null) return;
            int index = moveUp ? currentRow.Index - 1 : currentRow.Index + 1;
            if (index < 0 || index >= downloadGridView.RowCount) return;
            downloadGridView.Rows.Move(index, currentRow.Index);
            downloadGridView.CurrentRow = downloadGridView.Rows[index];
        }
        private List<String> SynchroTables()
        {
            List<String> synctables = new List<string>();
            for (int i = 0; i < Classes.GlobalVariable.Settings.SynchroInfoDownload.Rows.Count; i++)
            {
                if ((int)Classes.GlobalVariable.Settings.SynchroInfoDownload.Rows[i]["TypeSyncing"] == (int)Classes.Constants.TypeSyncing.SqlSync)
                    synctables.Add(Classes.GlobalVariable.Settings.SynchroInfoDownload.Rows[i]["TableSync"].ToString());
            }
            for (int i = 0; i < Classes.GlobalVariable.Settings.SynchroInfoUpload.Rows.Count; i++)
            {
                if ((int)Classes.GlobalVariable.Settings.SynchroInfoUpload.Rows[i]["TypeSyncing"] == (int)Classes.Constants.TypeSyncing.SqlSync)
                {
                    if (!synctables.Contains(Classes.GlobalVariable.Settings.SynchroInfoUpload.Rows[i]["TableSync"].ToString()))
                        synctables.Add(Classes.GlobalVariable.Settings.SynchroInfoUpload.Rows[i]["TableSync"].ToString());
                }
            }
            return synctables;
        }


        #endregion


    }
}

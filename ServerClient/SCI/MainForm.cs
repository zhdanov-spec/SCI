using SoftMarket.Globals;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.Remoting;
using System.Threading;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using ZPSoft.GameZone.SGZForms.Forms;
using ZPSoft.GameZone.SCI.Classes.Licensiar;
using ZPSoft.GameZone.SCI.Classes.LogClasses;
using ZPSoft.GameZone.SCI.DataSets;
using ZPSoft.GameZone.SCI.Forms;
using System.ServiceModel;
using ZPSoft.GameZone.SCI.Services.WCFInterfaces;
using ZPSoft.GameZone.SCI.Classes;
using System.Diagnostics;

namespace ZPSoft.GameZone.SCI
{
    public partial class MainForm : RadForm
    {
        #region Init Function
        
        public MainForm()
        {
            ChekVer();

            InitializeComponent();
            
            InitBeforeShow();
        }
        public void ChekVer()
        {
            
            Process MyProc = new Process();
            MyProc.StartInfo.FileName = string.Concat(Application.StartupPath, "\\UGZ.exe ");
            MyProc.StartInfo.Arguments = string.Concat("/", AppDomain.CurrentDomain.FriendlyName);
            try
            {
                MyProc.Start();
            }
            catch
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", string.Format("Відсутня програма для оновлення! Робота не можлива"));
                System.Windows.Forms.Application.ExitThread();
                System.Windows.Forms.Application.Exit();
                System.Environment.Exit(0);

            }
        }

        private void InitAfterShow()
        {
            
            using (WaitingForm wf = new WaitingForm(StartLogQueue, "Запуск потока логування серверу"))
            {
                wf.ShowDialog();
            }
            
            InitServicesGrid();
            if(!ConnectToServer()) Environment.Exit(0);
   

            //Инициализация Remote
            RemoteInitFunction();
            //Инициализация WCF 
            InitWCFService();
            
            StartClientThread();

            StartSyncThread();
            
        }
    
        private void InitBeforeShow()
        {
            Classes.GlobalVariable.ClientInfoLabel = this.ClientInfoLabel;
            Classes.GlobalVariable.ProgramIdentificator = Guid.NewGuid();
            Classes.GlobalVariable.GlobalsDataAdapter = this.GlobalsDataAdapter;
            Classes.GlobalVariable.SareaDataAdapter = this.SareaDataAdapter;
            using (WaitingForm wf = new WaitingForm(LoadSettings, "Завантаження налаштувань"))
            {
                wf.ShowDialog();
            }
            Classes.GlobalVariable.LicenseElement = this.LicenseElement;
            LicClass licClass = new LicClass();
            licClass.InitLicListener();
            PageViewSelector.SelectedPage = PageViewServer;

            deviceGridView.TableElement.RowHeight = 50;
            deviceGridView.TableElement.Font = new Font("Arial", 10f, FontStyle.Bold, GraphicsUnit.Pixel);

        }
        private void StartClientThread()
        {
            ClientLogic.MainClientClass mainClientClass = new ClientLogic.MainClientClass();
            mainClientClass.Start();
        }
        private void StartSyncThread()
        {
            Classes.SyncClasses.SyncThreadClass syncThreadClass = new Classes.SyncClasses.SyncThreadClass();
            syncThreadClass.Init();
        }
        #region WCF Services
        void InitWCFService()
        {

            if (CreateWCFHost())
            {

                InitWCFFunction();
            }

        }
        private bool CreateWCFHost()
        {
            
            ServiceHost wcfHost = new ServiceHost(typeof(AdminService));
            try
            {

                wcfHost.Open();
                LogQueue.Enqueue(Classes.Constants.Services.WCFService, "Створення хоста WCF - вдало", Classes.Constants.TypeLog.Green);
                return true;
            }
            catch (Exception ex)
            {
                Log.Write(ex.ToString(), Log.MessageType.Error, this);
                LogQueue.Enqueue(Classes.Constants.Services.WCFService, "Створення хоста WCF - помилка", Classes.Constants.TypeLog.Red);
                return false;
            }
        }
        private void InitWCFFunction()
        {
            ServiceManager.InitWCF();
        }
        #endregion
        void RemoteInitFunction()
        {
            LogQueue.Enqueue(Classes.Constants.Services.RemotingServices, "Ініціалізація віддаленних інтерфейсів", Classes.Constants.TypeLog.White);
            try
            {
                RemotingConfiguration.Configure(Application.StartupPath + "\\SCI.exe.config", false);
                
                LogQueue.Enqueue(Classes.Constants.Services.RemotingServices, "Ініціалізація віддаленних інтерфейсів - вдало", Classes.Constants.TypeLog.Green);
            }
            catch (Exception)
            {
                LogQueue.Enqueue(Classes.Constants.Services.RemotingServices, "Помилка Ініціалізації віддаленних інтерфейсів", Classes.Constants.TypeLog.Red);
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка Ініціалізації віддаленних інтерфейсів");
            }
        }
        void LoadSettings()
        {
            try
            {
                Classes.GlobalVariable.Settings = new SGZGlobals.DataSets.SettingsDataset();
                Classes.GlobalVariable.Settings.Clear();
                Classes.GlobalVariable.Settings.ReadXml(SGZGlobals.Classes.Constants.SettingsFileName);
                Classes.GlobalVariable.StrPassword = SGZGlobals.Classes.Crypt.UncryptValue(Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes .Constants.DatabaseSettings.SERVER_PASSWORD).Value);
                if (Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.NODE_POINT) == null)
                {
                    Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)SGZGlobals.Classes.Constants.DatabaseSettings.NODE_POINT, "1", "Ідентифікатор вузла");
                    Classes.GlobalVariable.Settings.AcceptChanges();
                    Classes.GlobalVariable.Settings.WriteXml(SGZGlobals.Classes.Constants.SettingsFileName);
                }
                if(Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.DEVICES_PORT)==null)
                {
                    Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)SGZGlobals.Classes.Constants.DatabaseSettings.DEVICES_PORT, "9761", "Порт Каркових Приймачів");
                    Classes.GlobalVariable.Settings.AcceptChanges();
                    Classes.GlobalVariable.Settings.WriteXml(SGZGlobals.Classes.Constants.SettingsFileName);
                }
                if (Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_ENABLED) == null)
                {
                    Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_ENABLED, "false", "Підключення серверу синхронізації");
                    Classes.GlobalVariable.Settings.AcceptChanges();
                    Classes.GlobalVariable.Settings.WriteXml(SGZGlobals.Classes.Constants.SettingsFileName);
                    
                }
                if (Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_NAME) == null)
                {
                    Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_NAME, "127.0.0.1", "Адреса серверу синхронізації");
                    Classes.GlobalVariable.Settings.AcceptChanges();
                    Classes.GlobalVariable.Settings.WriteXml(SGZGlobals.Classes.Constants.SettingsFileName);
                }
                if (Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_BASENAME) == null)
                {
                    Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_BASENAME, "geton", "База даних сервера синхронызації");
                    Classes.GlobalVariable.Settings.AcceptChanges();
                    Classes.GlobalVariable.Settings.WriteXml(SGZGlobals.Classes.Constants.SettingsFileName);
                }
                if (Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_LOGIN) == null)
                {
                    Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_LOGIN, "login", "Логин бази даних сервера синхронызації");
                    Classes.GlobalVariable.Settings.AcceptChanges();
                    Classes.GlobalVariable.Settings.WriteXml(SGZGlobals.Classes.Constants.SettingsFileName);
                }
                if (Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_PASSWORD) == null)
                {
                    Classes.GlobalVariable.StrPasswordSync = "";
                    Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_PASSWORD, SGZGlobals.Classes.Crypt.CryptValue(Classes.GlobalVariable.StrPasswordSync), "Пароль Користувача Бази Сінхронізації");
                    Classes.GlobalVariable.Settings.AcceptChanges();
                    Classes.GlobalVariable.Settings.WriteXml(SGZGlobals.Classes.Constants.SettingsFileName);
                }
                Classes.GlobalVariable.StrPasswordSync = SGZGlobals.Classes.Crypt.UncryptValue(Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_PASSWORD).Value);
            }
            catch (FileNotFoundException)
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Не знайден файл налаштувань.");
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.ExecuteCreateFile();
            }
        }
        void InitServicesGrid()
        {
            serviceGridView.TableElement.RowHeight = 50;
            GridViewDataRowInfo dataRowInfo1 = new GridViewDataRowInfo(serviceGridView.MasterView);
            dataRowInfo1.Cells["ServiceId"].Value = (int)Classes.Constants.Services.RemotingServices;
            dataRowInfo1.Cells["ServiceName"].Value = "Віддалені інтерфейси";
            dataRowInfo1.Cells["ServiceStatus"].Value = Properties.Resources.whiteImage;
            dataRowInfo1.Cells["ServiceLastLog"].Value = "Не задіяно";
            serviceGridView.Rows.Insert((int)Classes.Constants.Services.RemotingServices, dataRowInfo1);

            GridViewDataRowInfo dataRowInfo2 = new GridViewDataRowInfo(serviceGridView.MasterView);
            dataRowInfo2.Cells["ServiceId"].Value = (int)Classes.Constants.Services.WebHost;
            dataRowInfo2.Cells["ServiceName"].Value = "Web Host";
            dataRowInfo2.Cells["ServiceStatus"].Value = Properties.Resources.whiteImage;
            dataRowInfo2.Cells["ServiceLastLog"].Value = "Не задіяно";
            serviceGridView.Rows.Insert((int)Classes.Constants.Services.WebHost, dataRowInfo2);

            GridViewDataRowInfo dataRowInfo3 = new GridViewDataRowInfo(serviceGridView.MasterView);
            dataRowInfo3.Cells["ServiceId"].Value = (int)Classes.Constants.Services.WebApi;
            dataRowInfo3.Cells["ServiceName"].Value = "Web API";
            dataRowInfo3.Cells["ServiceStatus"].Value = Properties.Resources.whiteImage;
            dataRowInfo3.Cells["ServiceLastLog"].Value = "Не задіяно";
            serviceGridView.Rows.Insert((int)Classes.Constants.Services.WebApi, dataRowInfo3);

            GridViewDataRowInfo dataRowInfo4 = new GridViewDataRowInfo(serviceGridView.MasterView);
            dataRowInfo4.Cells["ServiceId"].Value = (int)Classes.Constants.Services.GOIP;
            dataRowInfo4.Cells["ServiceName"].Value = "Телефонні роутери";
            dataRowInfo4.Cells["ServiceStatus"].Value = Properties.Resources.whiteImage;
            dataRowInfo4.Cells["ServiceLastLog"].Value = "Не задіяно";
            serviceGridView.Rows.Insert((int)Classes.Constants.Services.GOIP, dataRowInfo4);

            GridViewDataRowInfo dataRowInfo5 = new GridViewDataRowInfo(serviceGridView.MasterView);
            dataRowInfo5.Cells["ServiceId"].Value = (int)Classes.Constants.Services.MailMonitoring;
            dataRowInfo5.Cells["ServiceName"].Value = "Моніторінг пошти";
            dataRowInfo5.Cells["ServiceStatus"].Value = Properties.Resources.whiteImage;
            dataRowInfo5.Cells["ServiceLastLog"].Value = "Не задіяно";
            serviceGridView.Rows.Insert((int)Classes.Constants.Services.MailMonitoring, dataRowInfo5);

            GridViewDataRowInfo dataRowInfo6 = new GridViewDataRowInfo(serviceGridView.MasterView);
            dataRowInfo6.Cells["ServiceId"].Value = (int)Classes.Constants.Services.WCFService;
            dataRowInfo6.Cells["ServiceName"].Value = "WCF Сервіс";
            dataRowInfo6.Cells["ServiceStatus"].Value = Properties.Resources.whiteImage;
            dataRowInfo6.Cells["ServiceLastLog"].Value = "Не задіяно";
            serviceGridView.Rows.Insert((int)Classes.Constants.Services.WCFService, dataRowInfo6);

            GridViewDataRowInfo dataRowInfo7 = new GridViewDataRowInfo(serviceGridView.MasterView);
            dataRowInfo7.Cells["ServiceId"].Value = (int)Classes.Constants.Services.MobileHost;
            dataRowInfo7.Cells["ServiceName"].Value = "Mobile Host";
            dataRowInfo7.Cells["ServiceStatus"].Value = Properties.Resources.whiteImage;
            dataRowInfo7.Cells["ServiceLastLog"].Value = "Не задіяно";
            serviceGridView.Rows.Insert((int)Classes.Constants.Services.MobileHost, dataRowInfo7);

            GridViewDataRowInfo dataRowInfo8 = new GridViewDataRowInfo(serviceGridView.MasterView);
            dataRowInfo8.Cells["ServiceId"].Value = (int)Classes.Constants.Services.WebApi;
            dataRowInfo8.Cells["ServiceName"].Value = "Mobile API";
            dataRowInfo8.Cells["ServiceStatus"].Value = Properties.Resources.whiteImage;
            dataRowInfo8.Cells["ServiceLastLog"].Value = "Не задіяно";
            serviceGridView.Rows.Insert((int)Classes.Constants.Services.MobileApi, dataRowInfo8);


            GridViewDataRowInfo dataRowInfo9 = new GridViewDataRowInfo(serviceGridView.MasterView);
            dataRowInfo9.Cells["ServiceId"].Value = (int)Classes.Constants.Services.TelegramBot;
            dataRowInfo9.Cells["ServiceName"].Value = "Telegram Bot";
            dataRowInfo9.Cells["ServiceStatus"].Value = Properties.Resources.whiteImage;
            dataRowInfo9.Cells["ServiceLastLog"].Value = "Не задіяно";
            serviceGridView.Rows.Insert((int)Classes.Constants.Services.TelegramBot, dataRowInfo9);

            GridViewDataRowInfo dataRowInfo10 = new GridViewDataRowInfo(serviceGridView.MasterView);
            dataRowInfo10.Cells["ServiceId"].Value = (int)Classes.Constants.Services.SyncMainServer;
            dataRowInfo10.Cells["ServiceName"].Value = "Сінхронізація";
            dataRowInfo10.Cells["ServiceStatus"].Value = Properties.Resources.whiteImage;
            dataRowInfo10.Cells["ServiceLastLog"].Value = "Не задіяно";
            serviceGridView.Rows.Insert((int)Classes.Constants.Services.SyncMainServer, dataRowInfo10);
        }
        bool ConnectToServer()
        {
            Classes.GlobalVariable.ServerDataSet = new ServerDataSet();

            Classes.GlobalVariable.SqlConnection = new System.Data.SqlClient.SqlConnection
            
            {
                ConnectionString = Classes.GlobalVariable.ConnectionString
            };
            if(Classes.GlobalVariable.ConnectionString == "")
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка файлу налаштувань");
                return false;
            }

            
            try
            {
                Classes.GlobalVariable.GlobalsDataAdapter.SelectCommand.Connection =  Classes.GlobalVariable.SqlConnection;
                Classes.GlobalVariable.GlobalsDataAdapter.UpdateCommand.Connection = Classes.GlobalVariable.SqlConnection;
                Classes.GlobalVariable.GlobalsDataAdapter.InsertCommand.Connection = Classes.GlobalVariable.SqlConnection;
                Classes.GlobalVariable.SareaDataAdapter.SelectCommand.Connection = Classes.GlobalVariable.SqlConnection;
                Classes.GlobalVariable.SareaDataAdapter.UpdateCommand.Connection = Classes.GlobalVariable.SqlConnection;
                Classes.GlobalVariable.SareaDataAdapter.InsertCommand.Connection = Classes.GlobalVariable.SqlConnection;

                Classes.GlobalVariable.SqlConnection.Open();
                Classes.GlobalVariable.GlobalsDataAdapter.Fill(Classes.GlobalVariable.ServerDataSet);
                if (Classes.GlobalVariable.ServerDataSet.Globals.Count == 0)
                {
                    //Не установленна площадка надо установить
                    new SGZForms.Forms.MessageForm().Execute("Помилка", "Не встановленна площадка серверу");
                    string sareaId = new SGZForms.Forms.VariableForm().Execute("Задайти площадку(це може бути тільки число)");
                    ServerDataSet.GlobalsRow  globalsRow = Classes.GlobalVariable.ServerDataSet.Globals.NewGlobalsRow();
                    globalsRow.GlobalsValue = sareaId;
                    globalsRow.GlobalsKey = "SAREAID";
                    globalsRow.Description = "ID Майданчика";
                    Classes.GlobalVariable.ServerDataSet.Globals.AddGlobalsRow(globalsRow);


                    ServerDataSet.SareaRow sareaRow = Classes.GlobalVariable.ServerDataSet.Sarea.NewSareaRow();
                    sareaRow.SareaId = Convert.ToInt32(sareaId);
                    sareaRow.SareaName = "Не вказано";
                    sareaRow.Visible = true;
                    Classes.GlobalVariable.ServerDataSet.Sarea.AddSareaRow(sareaRow);


                    SqlTransaction sqlTransaction = Classes.GlobalVariable.SqlConnection.BeginTransaction();

                    Classes.GlobalVariable.GlobalsDataAdapter.UpdateCommand.Transaction = sqlTransaction;
                    Classes.GlobalVariable.GlobalsDataAdapter.InsertCommand.Transaction = sqlTransaction;
                    Classes.GlobalVariable.GlobalsDataAdapter.DeleteCommand.Transaction = sqlTransaction;

                    Classes.GlobalVariable.SareaDataAdapter.UpdateCommand.Transaction = sqlTransaction;
                    Classes.GlobalVariable.SareaDataAdapter.InsertCommand.Transaction = sqlTransaction;
                    Classes.GlobalVariable.SareaDataAdapter.DeleteCommand.Transaction = sqlTransaction;

                    Classes.GlobalVariable.GlobalsDataAdapter.Update(Classes.GlobalVariable.ServerDataSet.Globals.Select("", "", System.Data.DataViewRowState.Added));
                    Classes.GlobalVariable.SareaDataAdapter.Update(Classes.GlobalVariable.ServerDataSet.Sarea.Select("", "", System.Data.DataViewRowState.Added));

                    sqlTransaction.Commit();

                    new SGZForms.Forms.MessageForm().Execute("Увага", "Сервер буде перезавантажено");
                    Application.Restart();




                }
            }
            catch (System.Data.SqlClient.SqlException)
            {

                //Ошибка подключения
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка підключення до серверу бази данних");
                SettingsForm settingsForm = new SettingsForm();
                if (settingsForm.ExecuteSet())
                {
                    new SGZForms.Forms.MessageForm().Execute("Увага", "Сервер буде перезавантажено");
                    Application.Restart();
                }
            }
            catch (Exception ex)
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка підключення до серверу бази данних");
                SettingsForm settingsForm = new SettingsForm();
                if (settingsForm.ExecuteSet())
                {
                    new SGZForms.Forms.MessageForm().Execute("Увага", "Сервер буде перезавантажено");
                    Application.Restart();
                }
            }
            finally
            {
                Classes.GlobalVariable.SqlConnection.Close();
            }
            return true;
        }
        #region Thread Function
        #region Log Thread
        private Thread logObserverThread = null;
        private Thread logDeviceObserverThread = null;
        private delegate void AddToLogDelegate(LogMsg logMsg);
        private delegate void AddToLogDeviceDelegate(LogDeviceMsg logDeviceMsg);
        private void StartLogQueue()
        {
            logObserverThread = new Thread(new ThreadStart(LogObserver))
            {
                IsBackground = true
            };
            logObserverThread.Start();
            logDeviceObserverThread = new Thread(new ThreadStart(LogDeviceObserver))
            {
                IsBackground = true
            };
            logDeviceObserverThread.Start();
        }
        private void LogObserver()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    while (LogQueue.Count > 0)
                        Invoke(new AddToLogDelegate(AddToLog), LogQueue.Dequeue());
                }
                catch (ThreadAbortException ex)
                {
                    MessageBox.Show("Помилка потока логування");
                    Log.Write(ex.ToString(), Log.MessageType.Error, this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка потока логування - інше");
                    Log.Write(ex.ToString(), Log.MessageType.Error, this);
                }
            }
        }
        private void LogDeviceObserver()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    while (LogDeviceQueue.Count > 0)
                        Invoke(new AddToLogDeviceDelegate(AddToDeviceLog), LogDeviceQueue.Dequeue());
                }
                catch (ThreadAbortException)
                {
                    new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка потока логування автоматів");
                }
                catch (Exception)
                {
                    new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка потока логування автоматів - інше");
                }
            }
        }
        private void AddToLog(LogMsg logMsg)
        {
            switch (logMsg.TypeLog)
            {
                case Classes.Constants.TypeLog.Red:
                    serviceGridView.Rows[(int)logMsg.ServiceId].Cells["ServiceStatus"].Value = SCI.Properties.Resources.redImage;
                    break;
                case Classes.Constants.TypeLog.Green:
                    serviceGridView.Rows[(int)logMsg.ServiceId].Cells["ServiceStatus"].Value = SCI.Properties.Resources.greenImage;
                    break;
                case Classes.Constants.TypeLog.White:
                    serviceGridView.Rows[(int)logMsg.ServiceId].Cells["ServiceStatus"].Value = SCI.Properties.Resources.whiteImage;
                    break;
            }
            serviceGridView.MasterTemplate.Rows[(int)logMsg.ServiceId].Cells["ServiceLastLog"].Value = string.Format("{0} - {1}", DateTime.Now.ToString(), logMsg.Message);
            serviceGridView.Refresh();
        }
        private Bitmap ReturnImage(Constants.TypeLog typeLog)
        {
            Bitmap res = SCI.Properties.Resources.whiteImage;
            switch (typeLog)
            {
                case Classes.Constants.TypeLog.Red:
                    res=SCI.Properties.Resources.redImage;
                    break;
                case Classes.Constants.TypeLog.Green:
                    res= SCI.Properties.Resources.greenImage;
                    break;
                case Classes.Constants.TypeLog.White:
                    res =  SCI.Properties.Resources.whiteImage;
                    break;
            }
            return res;

        }
        private void AddToDeviceLog(LogDeviceMsg logDeviceMsg)
        {
            if (logDeviceMsg.IsAdded)
            {
                GridViewDataRowInfo rowInfo = new GridViewDataRowInfo(this.deviceGridView.MasterView);
                rowInfo.Cells["IdDevice"].Value = logDeviceMsg.IdDevice;
                rowInfo.Cells["devicename"].Value = logDeviceMsg.DeviceName;
                rowInfo.Cells["IpAddress"].Value = logDeviceMsg.IPAddress;
                rowInfo.Cells["Status"].Value = ReturnImage(logDeviceMsg.TypeLog);
                rowInfo.Cells["GroupDeviceName"].Value = logDeviceMsg.DeviceGroup;
                rowInfo.Cells["TariffName"].Value = logDeviceMsg.TariffName;
                rowInfo.Cells["ActionTime"].Value = logDeviceMsg.ActionTime;
                rowInfo.Cells["LastLog"].Value = logDeviceMsg.LastAction;
                deviceGridView.Rows.Add(rowInfo);
            }
            else
            {
                foreach (GridViewRowInfo rowInfo in deviceGridView.Rows)
                {
                    if (Convert.ToInt32(rowInfo.Cells["IdDevice"].Value) == logDeviceMsg.IdDevice)
                    {
                        rowInfo.Cells["LastLog"].Value = logDeviceMsg.LastAction;
                        rowInfo.Cells["ActionTime"].Value = logDeviceMsg.ActionTime;
                        rowInfo.Cells["Status"].Value=ReturnImage(logDeviceMsg.TypeLog);
                       
                        break;
                    }

                }
            }
            deviceGridView.Refresh();
            
        }
        #endregion
        #endregion
        #endregion
        #region Events Function
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                MaterialTealTheme theme = new MaterialTealTheme(); 
                ThemeResolutionService.ApplicationThemeName = theme.ThemeName;
            }
            catch { }
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitAfterShow();
        }

        #region Menu Events
        private void MenuItemSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            if (settingsForm.ExecuteSet())
            {
                new SGZForms.Forms.MessageForm().Execute("Увага", "Сервер буде перезавантажено");
                Application.Restart();
            }
        }
        #endregion
        #endregion


    }
}

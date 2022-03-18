using SoftMarket.Globals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using ZPSoft.GameZone.DatabaseComponents;
using ZPSoft.GameZone.SGZAdmin.Classes;
using ZPSoft.GameZone.SGZAdmin.Forms;
using ZPSoft.GameZone.SGZAdmin.ProgramForms;
using ZPSoft.GameZone.SGZDomain;
using ZPSoft.GameZone.SGZGlobals.DataSets;
using System.Runtime.Remoting.Channels;
using System.Diagnostics;

namespace ZPSoft.GameZone.SGZAdmin
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
                new SGZForms.Forms.MessageForm().Execute("Помилка", string.Format("Відсутня програма для оновлення!"));

            }
        }

        private void InitBeforeShow()
        {
            Classes.GlobalVariable.ProgramIdentificator = Guid.NewGuid();
            LoadSettings();
            ConnectToServer();
            LoadData();
            CheckPermissions();
            UpdateMenu();
        }
        private void LoadSettings()
        {
            try
            {
                Classes.GlobalVariable.Settings = new SGZGlobals.DataSets.SettingsDataset();
                Classes.GlobalVariable.Settings.Clear();
                Classes.GlobalVariable.Settings.ReadXml(Classes.Constants.SettingsFileName);
            }
            catch(FileNotFoundException)
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Не знайден файл налаштувань.");
                SettingsForm settingsForm = new SettingsForm();
                settingsForm.ExecuteCreateFile();
                    
            }
        }
        private void ConnectToServer()
        {
            try
            {
                ServiceManager.InitAdministration(GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SERVER_NAME).Value);
                ServiceManager.InitWCF(GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SERVER_NAME).Value);
            }
            catch (ServiceException e)
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка ініціалізації сервису Administration.");
                Log.Write(string.Format("Помилка ініціалізації сервису Administration - {0}",e.ToString()), Log.MessageType.Error, this);

            }
            catch (System.NullReferenceException e)
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "NullReferenceException сервісу Administration.");
                Log.Write(string.Format("NullReferenceException сервісу Administration. - {0}", e.ToString()), Log.MessageType.Error, this);
            }
            
        }
        private void LoadData()
        {
            try
            {
                Classes.GlobalVariable.AdminData = ServiceManager.Administration.GetInfo();
                if(Classes.GlobalVariable.AdminData!=null)
                {
                    GameZoneDataSet.GlobalsRow row = Classes.GlobalVariable.AdminData.Globals.FindByGlobalsKey(SGZGlobals.Classes.Constants.Parameters.SAREAID);

                    if (row == null || row.IsGlobalsValueNull() || string.IsNullOrEmpty(row.GlobalsValue) || int.TryParse(row.GlobalsValue, out int res) == false)
                    {
                        Log.Write("Не задана торговая площадка.", Log.MessageType.Error, this);
                        new SGZForms.Forms.MessageForm().Execute("Помилка", "Не задан ID торгівельного майданчика.");
                    }
                    else
                    {
                        DataSetHolder.SareaId = Convert.ToInt32(row.GlobalsValue);
                    }

                    UpdateMenu();
                }

            }
            catch (System.Net.Sockets.SocketException e)
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка звязвку - SocketException.");
                Log.Write(string.Format("Помилка звязвку - SocketException. - {0}", e.ToString()), Log.MessageType.Error, this);

            }
            catch (System.Runtime.Remoting.RemotingException e)
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка звязвку - RemotingException.");
                Log.Write(string.Format("Помилка звязвку - RemotingException - {0}", e.ToString()), Log.MessageType.Error, this);
            }
            catch (System.Reflection.TargetInvocationException e)
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка звязвку - TargetInvocationException.");
                Log.Write(string.Format("Помилка звязвку - TargetInvocationException - {0}", e.ToString()), Log.MessageType.Error, this);
            }
            catch (SGZGlobals.Classes.Exceptions.TableModule.GeneralException e)
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка звязвку - GeneralException.");
                Log.Write(string.Format("Помилка звязвку - GeneralException - {0}", e.ToString()), Log.MessageType.Error, this);
            }
            catch (ServiceException e)
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка звязвку");
                Log.Write(string.Format("Помилка звязвку - {0}", e.ToString()), Log.MessageType.Error, this);
            }
        }
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
        private void MainTreeView_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            UpdateMenu();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            EditRecord(true);
        }
        #endregion
        #region GUI Functions

        private void UpdateMenu()
        {
            TableModule TableObject = GetTableObject();
            if(TableObject==null)
            {
                InfoGrid.DataSource = null;
                return;
            }
            
            InfoGrid.DataSource = TableObject.GetAllRows();
           
        }
        private void InfoGrid_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            EditRecord(false);
        }
        private void InitCategoryTree(Int32 IdCashierGroup)
        {
            MainTreeView.BeginUpdate();
            MainTreeView.Nodes.Clear();

            RadTreeNode node = new RadTreeNode("Ігрові пристрої");
            node.Tag = Constants.Table.Devices;
            MainTreeView.Nodes.Add(node);
            node = new RadTreeNode("Групи ігрових пристроїв");
            node.Tag = Constants.Table.GroupDevice;
            MainTreeView.Nodes.Add(node);
            node = new RadTreeNode("Станції пристроїв");
            node.Tag = Constants.Table.NodePoints;
            MainTreeView.Nodes.Add(node);
            node = new RadTreeNode("Тарифи");
            node.Tag = Constants.Table.Tariff;
            MainTreeView.Nodes.Add(node);
            node = new RadTreeNode("Тарифні періоди");
            node.Tag = Constants.Table.Periods;
            MainTreeView.Nodes.Add(node);
            node = new RadTreeNode("Вихідні дні");
            node.Tag = Constants.Table.Holiday;
            MainTreeView.Nodes.Add(node);
            node = new RadTreeNode("Схеми знижок");
            node.Tag = Constants.Table.Discount;
            MainTreeView.Nodes.Add(node);
            node = new RadTreeNode("Схеми бонусів");
            node.Tag = Constants.Table.Bonuses;
            MainTreeView.Nodes.Add(node);
            node = new RadTreeNode("Групи клієнтів");
            node.Tag = Constants.Table.GroupUser;
            MainTreeView.Nodes.Add(node);
            node = new RadTreeNode("Користувачі");
            node.Tag = Constants.Table.Cashier;
            MainTreeView.Nodes.Add(node);
            node = new RadTreeNode("Групи користувачів");
            node.Tag = Constants.Table.CashierGroup;
            MainTreeView.Nodes.Add(node);
            node = new RadTreeNode("Загальні налаштування");
            node.Tag = Constants.Table.Globals;
            MainTreeView.Nodes.Add(node);
            node = new RadTreeNode("Каси");
            node.Tag = Constants.Table.CashDesk;
            MainTreeView.Nodes.Add(node);
            
        }
        #endregion
        #region Logic Function
        
        private void IsFirstTimeUse()
        {
            GameZoneDataSet.CashierRow row = Classes.GlobalVariable.AdminData.Cashier.FindByIdCashierSareaId(1, DataSetHolder.SareaId);
            if (row == null)
            {
                new SGZForms.Forms.MessageForm().Execute("Увага!", "Встановлення майстер паролю");
                if (!new SGZForms.Forms.FirstTimeUseForm().Execute(out string password))
                {
                    Environment.Exit(0);
                }
                else
                {
                    InitDataBase initDataBase = new InitDataBase();
                    initDataBase.InitCashierGroup();
                    GlobalVariable.SaveData();
                    initDataBase.InitCashier(password);
                    GlobalVariable.SaveData();
                    initDataBase.InitGroupUser();
                    GlobalVariable.SaveData();
                    initDataBase.InitUsers();
                    GlobalVariable.SaveData();
                    initDataBase.InitGlobals();
                    GlobalVariable.SaveData();
                    new SGZForms.Forms.MessageForm().Execute("Увага!", string.Format("Код користувача - 1{0}Пароль - встановленно",Environment.NewLine));
                    Application.Restart();
                }
            }
            
        }
        private void CheckPermissions()
        {
            if (Classes.GlobalVariable.AdminData != null)
            {
                IsFirstTimeUse();
                if (!new SGZForms.Forms.AuthForm().Execute(out string login,out string password))
                {
                    Environment.Exit(0);
                }
                Cashier cashier = new Cashier(Classes.GlobalVariable.AdminData, null);
                ServiceManager.CashierGroup = -1;
                
                try
                {
                    ServiceManager.CashierGroup = cashier.GetIdGroup(password, Convert.ToInt32(login),out bool superUser);
                    ServiceManager.SuperUser = superUser;
                    if(!superUser)
                        cashier.AuthorizationByPass(password, Convert.ToInt32(login), SGZGlobals.Classes.Constants.Permissions.WorkAdminModule);
                }
                
                catch(SGZGlobals.Classes.Exceptions.TableModule.PermissionException)
                {
                    new SGZForms.Forms.MessageForm().Execute("Помилка", "В доступі відмовленно.");
                    CheckPermissions();

                }
                catch (SGZGlobals.Classes.Exceptions.TableModule.GeneralException)
                {
                    new SGZForms.Forms.MessageForm().Execute("Помилка", "В доступі відмовленно.");
                    CheckPermissions();
                }
                InitCategoryTree(ServiceManager.CashierGroup);
            }
        }
        private TableModule GetTableObject()
        {
            TableModule TableObject = null;
            if (Classes.GlobalVariable.AdminData == null || MainTreeView.Nodes.Count == 0) return null;
            Constants.Table table;
            if (MainTreeView.SelectedNode != null)
            {
                if (!(MainTreeView.SelectedNode.Tag is Constants.Table))
                    return null;
                table = (Constants.Table)MainTreeView.SelectedNode.Tag;
                InfoGrid.TitleText = MainTreeView.SelectedNode.Text;
            }
            else
                return null;
            InfoGrid.MasterTemplate.Columns.Clear();
            switch(table)
            {
                case Constants.Table.Devices:
                    {
                        TableObject = new Devices(Classes.GlobalVariable.AdminData, null);
                        InfoGrid.MasterTemplate.Columns.AddRange(Classes.InfoGridStyle.GetDeviceStyle);
                        break;
                    }
                case Constants.Table.NodePoints:
                    {
                        TableObject = new NodePoints(Classes.GlobalVariable.AdminData, null);
                        InfoGrid.MasterTemplate.Columns.AddRange(Classes.InfoGridStyle.GetNodePointStyle);
                        break;
                    }
                case Constants.Table.GroupDevice:
                    {
                        TableObject = new GroupDevice(Classes.GlobalVariable.AdminData, null);
                        InfoGrid.MasterTemplate.Columns.AddRange(Classes.InfoGridStyle.GetGroupDeviceStyle);
                        break;
                    }
                case Constants.Table.Tariff:
                    {
                        TableObject = new Tariff(Classes.GlobalVariable.AdminData, null);
                        InfoGrid.MasterTemplate.Columns.AddRange(Classes.InfoGridStyle.GetTariffStyle);
                        break;
                    }
                case Constants.Table.Periods:
                    {
                        TableObject = new Periods(Classes.GlobalVariable.AdminData, null);
                        InfoGrid.MasterTemplate.Columns.AddRange(Classes.InfoGridStyle.GetPeriodsStyle);
                        break;
                    }
                case Constants.Table.Holiday:
                    {
                        TableObject = new Holiday(Classes.GlobalVariable.AdminData, null);
                        InfoGrid.MasterTemplate.Columns.AddRange(Classes.InfoGridStyle.GetHolidayStyle);
                        break;
                    }
                case Constants.Table.Discount:
                    {
                        TableObject = new Discount(Classes.GlobalVariable.AdminData, null);
                        InfoGrid.MasterTemplate.Columns.AddRange(Classes.InfoGridStyle.GetDiscountStyle);
                        break;
                    }
                case Constants.Table.GroupUser:
                    {
                        TableObject = new GroupUser(Classes.GlobalVariable.AdminData, null);
                        InfoGrid.MasterTemplate.Columns.AddRange(Classes.InfoGridStyle.GetGroupUserStyle);
                        break;
                    }
                case Constants.Table.Cashier:
                    {
                        TableObject = new Cashier(Classes.GlobalVariable.AdminData, null);
                        InfoGrid.MasterTemplate.Columns.AddRange(Classes.InfoGridStyle.GetCashierStyle);
                        break;
                    }
                case Constants.Table.CashierGroup:
                    {
                        TableObject = new CashierGroup(Classes.GlobalVariable.AdminData, null);
                        InfoGrid.MasterTemplate.Columns.AddRange(Classes.InfoGridStyle.GetCashierGroupStyle);
                        break;
                    }
                case Constants.Table.Globals:
                    {
                        TableObject = new Globals(Classes.GlobalVariable.AdminData, null);
                        InfoGrid.MasterTemplate.Columns.AddRange(Classes.InfoGridStyle.GetGlobalsStyle);
                        break;
                    }
                case Constants.Table.CashDesk:
                    {
                        TableObject = new CashDesk(Classes.GlobalVariable.AdminData, null);
                        InfoGrid.MasterTemplate.Columns.AddRange(Classes.InfoGridStyle.GetCashDeskStyle);
                        break;
                    }
                case Constants.Table.Bonuses:
                    {
                        TableObject = new Bonuses(Classes.GlobalVariable.AdminData, null);
                        InfoGrid.MasterTemplate.Columns.AddRange(Classes.InfoGridStyle.GetBonusesStyle);
                        break;
                    }


            }
            return TableObject;
        }
        private void EditRecord(bool Insert)
        {
            if (Classes.GlobalVariable.AdminData == null || InfoGrid.DataSource == null) return;
            Constants.RowInfo rowInfo = new Constants.RowInfo(Constants.Table.None, null);
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[InfoGrid.DataSource];
            if (currencyManager.Count == 0 && !Insert) return;
            Constants.IEditForm editForm = null;
            Permissions permissions = new Permissions(Classes.GlobalVariable.AdminData, null);
            SGZGlobals.Classes.Constants.PermissionType permission = 0;
            if (((DataView)InfoGrid.DataSource).Table.TableName==Classes.GlobalVariable.AdminData.GroupDevice.TableName)
            {
                editForm = new GroupDeviceForm();
                permission = permissions.GetPermissions(ServiceManager.CashierGroup,SGZGlobals.Classes.Constants.Permissions.GroupDevice);

            }
            if(((DataView)InfoGrid.DataSource).Table.TableName==Classes.GlobalVariable.AdminData.Devices.TableName)
            {
                editForm = new DeviceForm();
                permission = permissions.GetPermissions(ServiceManager.CashierGroup, SGZGlobals.Classes.Constants.Permissions.Devices);
            }
            if(((DataView)InfoGrid.DataSource).Table.TableName==Classes.GlobalVariable.AdminData.Tariff.TableName)
            {
                editForm = new TariffForm();
                permission = permissions.GetPermissions(ServiceManager.CashierGroup, SGZGlobals.Classes.Constants.Permissions.Tariff);
            }
            if(((DataView)InfoGrid.DataSource).Table.TableName==Classes.GlobalVariable.AdminData.NodePoints.TableName)
            {
                editForm = new NodePointForm();
                permission = permissions.GetPermissions(ServiceManager.CashierGroup, SGZGlobals.Classes.Constants.Permissions.NodePoints);
            }
            if(((DataView)InfoGrid.DataSource).Table.TableName==Classes.GlobalVariable.AdminData.Periods.TableName)
            {
                editForm = new PeriodForm();
                permission = permissions.GetPermissions(ServiceManager.CashierGroup, SGZGlobals.Classes.Constants.Permissions.Periods);
            }
            if(((DataView)InfoGrid.DataSource).Table.TableName==Classes.GlobalVariable.AdminData.Holiday.TableName)
            {
                editForm = new HolidayForm();
                permission = permissions.GetPermissions(ServiceManager.CashierGroup, SGZGlobals.Classes.Constants.Permissions.Holiday);
            }
            if(((DataView)InfoGrid.DataSource).Table.TableName==Classes.GlobalVariable.AdminData.Discount.TableName)
            {
                editForm = new DiscountForm();
                permission = permissions.GetPermissions(ServiceManager.CashierGroup, SGZGlobals.Classes.Constants.Permissions.Discount);
            }
            if(((DataView)InfoGrid.DataSource).Table.TableName==Classes.GlobalVariable.AdminData.GroupUser.TableName)
            {
                editForm = new GroupUserForm();
                permission = permissions.GetPermissions(ServiceManager.CashierGroup, SGZGlobals.Classes.Constants.Permissions.GroupUser);
            }
            if (((DataView)InfoGrid.DataSource).Table.TableName == Classes.GlobalVariable.AdminData.Cashier.TableName)
            {
                editForm = new CashierForm();
                permission = permissions.GetPermissions(ServiceManager.CashierGroup, SGZGlobals.Classes.Constants.Permissions.Cashier);
            }
            if (((DataView)InfoGrid.DataSource).Table.TableName == Classes.GlobalVariable.AdminData.CashierGroup.TableName)
            {
                editForm = new CashierGroupForm();
                permission = permissions.GetPermissions(ServiceManager.CashierGroup, SGZGlobals.Classes.Constants.Permissions.CashierGroup);
            }
            if(((DataView)InfoGrid.DataSource).Table.TableName==Classes.GlobalVariable.AdminData.Globals.TableName)
            {
                editForm = new GlobalsForm();
                permission = permissions.GetPermissions(ServiceManager.CashierGroup, SGZGlobals.Classes.Constants.Permissions.Globals);
            }
            if(((DataView)InfoGrid.DataSource).Table.TableName==Classes.GlobalVariable.AdminData.CashDesk.TableName)
            {
                editForm = new CashDeskForm();
                permission = permissions.GetPermissions(ServiceManager.CashierGroup, SGZGlobals.Classes.Constants.Permissions.CashDesk);
            }
            if(((DataView)InfoGrid.DataSource).Table.TableName==Classes.GlobalVariable.AdminData.Bonuses.TableName)
            {
                editForm = new BonusesForm();
                permission = permissions.GetPermissions(ServiceManager.CashierGroup, SGZGlobals.Classes.Constants.Permissions.Bonuses);
            }
            if (editForm!=null)
            {
                if (ServiceManager.SuperUser)
                    permission = SGZGlobals.Classes.Constants.PermissionType.Insert;
                else if ((permission & SGZGlobals.Classes.Constants.PermissionType.Insert) == 0 && Insert)
                    permission = SGZGlobals.Classes.Constants.PermissionType.Insert;
                //return;
                rowInfo = editForm.Execute(currencyManager, Classes.GlobalVariable.AdminData, Insert, permission);
                editForm.Close();
                GlobalVariable.SaveData();

            }
        }
      
      

        #endregion

        
    }
}

using SoftMarket.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZPSoft.GameZone.SCI.Classes;
using ZPSoft.GameZone.SCI.Classes.LogClasses;
using ZPSoft.GameZone.SCI.ClientLogic.MifareClasses;
using ZPSoft.GameZone.SGZGlobals.Classes;
using ZPSoft.GameZone.SGZGlobals.DataSets;

namespace ZPSoft.GameZone.SCI.ClientLogic
{
    public class MainClientClass
    {
        #region Init Function
        Thread programClientThread = null;
        private static MifareService mifareService = new MifareService();
        public void Start()
        {
            if (programClientThread == null)
                programClientThread = new Thread(new ThreadStart(StartProgram));
            if (programClientThread.IsAlive)
            {
                programClientThread.Abort();
                programClientThread.Join();
                programClientThread = new Thread(new ThreadStart(StartProgram));
            }
            try
            {
                programClientThread.IsBackground = true;
                programClientThread.Start();
            }
            catch
            {

            }
            
        }
        private void StartProgram()
        {
            while (!Classes.GlobalVariable.IsOnline)
            {
                try
                {
                    if (ConnectToServer())
                    {
                        if (!LoadData())
                        {

                            Thread.Sleep(5000);
                        }
                    }
                    else
                        Thread.Sleep(5000);
                }
                catch(Exception ex)
                {
                    Log.Write(ex.ToString(), Log.MessageType.Error, this);
                }
            }
            Thread.Sleep(2000);
            InitStation();
        }
        private bool ConnectToServer()
        {
            try
            {
                Classes.ServiceManager.InitPingService(Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SERVER_NAME).Value);
                return true;
            }
            catch
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Ініціалізація Ping Service - помилка");
                return false;
            }
        }
        private bool LoadData()
        {
            try
            {
                GlobalVariable.PointInfo = ServiceManager.PingService.GetNodePointInfo(int.Parse(GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.NODE_POINT).Value));
                foreach (GameZoneDataSet.FreeTableRow row in GlobalVariable.PointInfo.FreeTable.Rows)
                {
                    Int32 idDevice = (int)row["IdDevice"];
                    string deviceName = row["DeviceName"].ToString();
                    string ipAddress = row["IpAddress"].ToString();
                    Classes.Constants.TypeLog typeLog = Classes.Constants.TypeLog.Red;
                    string deviceGroup = row["GroupDeviceName"].ToString();
                    string tariffName = row["TariffName"].ToString();
                    string lastAction = "Додавання до станціх пристроїв";
                    LogDeviceQueue.Enqueue(idDevice, deviceName, ipAddress, typeLog, deviceGroup, tariffName, lastAction, true);
                }
                Classes.GlobalVariable.IsOnline = true;
                
                return true;
            }
            catch (Exception)
            {
                Classes.GlobalVariable.IsOnline = false;
                return false;
            }
        }
        private void InitStation()
        {
            StartService();
        }
        private void StartService()
        {
            try
            {
                mifareService.Start(Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SERVER_NAME).Value, 2005, (ushort)Convert.ToInt32(Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.DEVICES_PORT).Value), Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SERVER_NAME).Value);
            }
            catch(Exception ex)
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", " mifareService StartService");
                Log.Write(ex.ToString(), Log.MessageType.Error, this);
                Environment.Exit(0);
            }
        }
        #endregion
    }
}

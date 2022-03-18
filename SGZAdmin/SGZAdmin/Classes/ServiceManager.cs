using SoftMarket.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Channels;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZPSoft.GameZone.SGZServiceInterfaces;
using ZPSoft.GameZone.SGZWCFInterfaces;
using ZPSoft.GameZone.SGZWCFInterfaces.Classes;

namespace ZPSoft.GameZone.SGZAdmin.Classes
{
    public class ServiceException : Exception
    {
        public ServiceException() : base()
        { }
        public ServiceException(String message) : base(message)
        { }
        public ServiceException(String message, Exception innerException) : base(message, innerException)
        { }
    }

    public class ServiceManager
    {
        private static string serverName;
        private static IAdministration administration = null;
        private static ICashDeskService cashDeskService = null;

        private static int cashierGroup = -1;
        public static int CashierGroup
        {
            get
            {
                return cashierGroup;
            }
            set
            {
                cashierGroup = value;
            }
        }
        private static bool superUser = false;
        public static bool SuperUser
        {
            get
            {
                return superUser;
            }
            set
            {
                superUser = value;
            }
        }


        private static string tMKey = "";
        public static string TMKey
        {
            get
            {
                return tMKey;
            }
            set
            {
                tMKey = value;
            }
        }

        public static IAdministration Administration
        {
            get
            {
                if (administration == null)
                    throw new ServiceException("Сервис удаленного администрирования не инициализирован.");
                return administration;
            }
        }
        public static ICashDeskService CashDeskService
        {
            get
            {
                if (cashDeskService == null)
                    throw new ServiceException("Сервис удаленной продажи не инициализирован.");
                return cashDeskService;
            }
        }
        public static void InitAdministration(string ServerName)
        {
            try
            {
                ServiceManager.serverName = ServerName;
                administration = (IAdministration)Activator.GetObject
                    (typeof(IAdministration), "tcp://" + ServerName + ":2005/Administration");
                

                
            }
            catch (System.Net.Sockets.SocketException e)
            {
                throw new ServiceException(e.Message);
            }
            catch (System.Runtime.Remoting.RemotingException e)
            {
                throw new ServiceException(e.Message);
            }
            catch (System.Reflection.TargetInvocationException err)
            {
                throw new ServiceException(err.InnerException != null ? err.InnerException.Message : err.Message);
            }
        }
        public static void InitWCF(string serverName)
        {
            while (true)
            {
                try
                {

                    var binding = new NetTcpBinding
                    {
                        OpenTimeout = new TimeSpan(0, 0, 30),
                        SendTimeout = new TimeSpan(0, 0, 30),
                        Name = "SCIDualNetBinding"
                    };
                    binding.Security.Mode = SecurityMode.None;
                    var uri = "net.tcp://" + serverName + ":20051/?wsdl";
                    EndpointAddress address = new EndpointAddress(uri);
                    try
                    {
                        var myChannelFactory = new ChannelFactory<IGameZoneService>(binding, address);
                        if (GlobalVariable.WCFClient != null) GlobalVariable.WCFClient = null;
                        GlobalVariable.WCFClient = myChannelFactory.CreateChannel();
                        if (GlobalVariable.Wcfobj != null)
                        {
                            GlobalVariable.Wcfobj.Faulted -= new EventHandler(ChannelFactory_Faulted);
                            GlobalVariable.Wcfobj = null;
                        }
                        GlobalVariable.Wcfobj = (ICommunicationObject)GlobalVariable.WCFClient;
                        GlobalVariable.Wcfobj.Faulted += new EventHandler(ChannelFactory_Faulted);
                        ConnectedUserClass connectedUserClass = new ConnectedUserClass();
                        connectedUserClass = GlobalStaticFunction.GetUserInfo(ConstantsWcf.ServiceTypeEnum.IsAdmin, GlobalVariable.ProgramIdentificator);
                        connectedUserClass.ServiceType = ConstantsWcf.ServiceTypeEnum.IsRobotClient;
                        connectedUserClass.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                        GlobalVariable.WCFClient.ConnectClient(connectedUserClass);
                        PingThreadClass pingThreadClass = new PingThreadClass();
                        pingThreadClass.StartPing();

                        break;
                    }
                    catch (Exception ex)
                    {
                        new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка Створення WCF.");
                        Log.Write(ex, Log.MessageType.Error);
                        SleepCount(5);
                    }
                }
                catch (Exception ex)
                {
                    new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка Створення WCF.");
                    Log.Write(ex, Log.MessageType.Error);
                    SleepCount(5);
                }
            }
        }
        public static void InitCashDeskService(string ServerName)
        {
            try
            {
                ServiceManager.serverName = ServerName;
                object[] url = { new UrlAttribute("tcp://" + ServerName + ":2005") };
                cashDeskService = (ICashDeskService)Activator.CreateInstance(typeof(SGZServiceInterfacesImpl.CashDeskServiceImpl), null, url);
            }
            catch (System.Net.Sockets.SocketException e)
            {
                throw new ServiceException(e.Message);
            }
            catch (System.Runtime.Remoting.RemotingException e)
            {
                throw new ServiceException(e.Message);
            }
            catch (System.Reflection.TargetInvocationException err)
            {
                throw new ServiceException(err.InnerException != null ? err.InnerException.Message : err.Message);
            }
        }
        public static void InitAdministration()
        {
            InitAdministration(ServiceManager.serverName);
        }
        public static void InitCashDeskService()
        {
            InitCashDeskService(ServiceManager.serverName);
        }
        public static void InitWCF()
        {
            InitWCF(ServiceManager.serverName);
        }
        public ServiceManager()
        {
        }
        #region Events Functions
        private static void ChannelFactory_Faulted(object sender, EventArgs e)
        {
            SleepCount(1);
            try
            {
                InitWCF();
            }
            catch
            {

            }
        }

        #endregion
        #region Logic Functions
        private static void SleepCount(int sleepTime)
        {
            int num = 0;
            while (num <= sleepTime * 1000)
            {
                Thread.Sleep(100);
                num += 100;
            }
        }

        #endregion
    }
}

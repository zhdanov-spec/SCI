using SoftMarket.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.Remoting;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZPSoft.GameZone.SCI.Classes.LogClasses;
using ZPSoft.GameZone.SCI.Services.WCFInterfaces;
using ZPSoft.GameZone.SGZServiceInterfaces.PingService;
using ZPSoft.GameZone.SGZWCFInterfaces;
using ZPSoft.GameZone.SGZWCFInterfaces.Classes;

namespace ZPSoft.GameZone.SCI.Classes
{
    public class ServiceException : Exception
    {
        public ServiceException()
        {
        }

        public ServiceException(string message)
            : base(message)
        {
        }

        public ServiceException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
    public class ServiceManager
    {
        private static IPingService pingService = null;
        public static IPingService PingService
        {
            get
            {
                if (pingService == null)
                {
                    throw new ServiceException("Удаленный сервис не инициализирован.(IPingService)");
                }
                return pingService;
            }
        }
        public static void InitPingService(string ServerName)
        {
            try
            {
                pingService = (IPingService)Activator.GetObject(typeof(IPingService), "tcp://" + ServerName + ":2005/PingService");
            }
            catch (SocketException ex)
            {
                throw new ServiceException(ex.Message);
            }
            catch (RemotingException ex)
            {
                throw new ServiceException(ex.Message);
            }
            catch (TargetInvocationException ex)
            {
                throw new ServiceException(ex.Message);
            }
        }

        public static void InitWCF()
        {
            while(true)
            {
                try
                {
                    Application.DoEvents();
                    var binding = new NetTcpBinding
                    {
                        OpenTimeout = new TimeSpan(0, 0, 30),
                        SendTimeout = new TimeSpan(0, 0, 30),
                        Name = "SCIDualNetBinding",
                    };
                    binding.Security.Mode = SecurityMode.None;
                    var uri = "net.tcp://localhost:20051/?wsdl";
                    EndpointAddress address = new EndpointAddress(uri);
                    //Пока колбек не нужен на будующее
                    var myCHannelFactory=new ChannelFactory<IGameZoneService>(binding, address);
                    try
                    {
                        //Понадобится кол бек раскоментировать
                        //var myCHannelFactory = new DuplexChannelFactory<IGameZoneService>(new CallBackInterface(), binding, address);
                        if (GlobalVariable.WCFClient != null) GlobalVariable.WCFClient = null;
                        GlobalVariable.WCFClient = myCHannelFactory.CreateChannel();
                        if (GlobalVariable.Wcfobj != null)
                        {
                            GlobalVariable.Wcfobj.Faulted -= new EventHandler(ChannelFactory_Faulted);
                            GlobalVariable.Wcfobj = null;
                        }
                        GlobalVariable.Wcfobj = (ICommunicationObject)GlobalVariable.WCFClient;
                        GlobalVariable.Wcfobj.Faulted += new EventHandler(ChannelFactory_Faulted);
                        ConnectedUserClass connectedUserClass = new ConnectedUserClass();
                        connectedUserClass = GlobalStaticFunction.GetUserInfo(ConstantsWcf.ServiceTypeEnum.IsServer, GlobalVariable.ProgramIdentificator);
                        connectedUserClass.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                        GlobalVariable.WCFClient.ConnectClient(connectedUserClass);

                        LogQueue.Enqueue(Constants.Services.WCFService, "Підключення WCF клієнта Сервера - вдало", Constants.TypeLog.Green);
                        PingThreadClass pingThreadClass = new PingThreadClass();
                        pingThreadClass.StartPing();
                        break;

                    }
                    catch(Exception ex)
                    {
                        Log.Write(ex.ToString(), Log.MessageType.Error, null);
                        LogQueue.Enqueue(Constants.Services.WCFService, string.Format("Підключення WCF Клієнта Сервера - помилка {0}", ex.ToString()), Constants.TypeLog.Red);
                        SleepCount(5);
                    }
                }
                catch { }
            }
        }
        #region Events Functions
        private static void ChannelFactory_Faulted(object sender, EventArgs e)
        {


            LogQueue.Enqueue(Constants.Services.WCFService, "Перепідключення WCF клієнта Сервера", Constants.TypeLog.White);
            SleepCount(1);
            try
            {
                InitWCF();
            }
            catch
            {
                LogQueue.Enqueue(Constants.Services.WCFService, "Перепідключення WCF клієнта Сервера - помилка", Constants.TypeLog.Red);
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

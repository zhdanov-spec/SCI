using Igroland.GameZone.MifareInterface;
using SoftMarket.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZPSoft.GameZone.SCI.Classes.LogClasses;
using ZPSoft.GameZone.SGZGlobals.DataSets;
using ZPSoft.GameZone.SGZServiceInterfaces;

namespace ZPSoft.GameZone.SCI.ClientLogic.MifareClasses
{
    internal class MifareService
    {
        private IConfirmationPayment confirmationPayment;
        private MifareServer mifareServer = new MifareServer();
        #region Init Function
        public MifareService()
        {
            mifareServer.ClientConnectEvt += MifareServer_ClientConnectEvt;
            mifareServer.ClientDisconnectEvt += MifareServer_ClientDisconnectEvt;
            mifareServer.ErrorEvt += MifareServer_ErrorEvt;
            mifareServer.PacketEvt += MifareServer_PacketEvt;
            mifareServer.ClientWaitingDisconnectEvt += MifareServer_ClientWaitingDisconnectEvt;
        }
        public void Start(string paymentServer,ushort paymentPort,ushort devicePort,string localHostAddres)
        {
            Classes.GlobalVariable.MifareThreadList= new List<MifareDevice>();
            Classes.GlobalVariable.MifareThreadList.Clear();
            CreatePaymentServer(paymentServer, paymentPort);
            Classes.GlobalVariable.ClientInfoLabel.BeginInvoke(new Action((() =>
            {
                Classes.GlobalVariable.ClientInfoLabel.Text = string.Format("Серверу Оплати {0}:{1} - створено", paymentServer,paymentPort);

            })));
            mifareServer.Start(devicePort, localHostAddres);
            Classes.GlobalVariable.ClientInfoLabel.BeginInvoke(new Action((() =>
            {
                Classes.GlobalVariable.ClientInfoLabel.Text = string.Format("Сервіс приладів {0}:{1} - запущено", localHostAddres,devicePort);

            })));
        }
        private void CreatePaymentServer(string paymentServer, ushort paymentPort)
        {
            try
            {
                confirmationPayment = (IConfirmationPayment)Activator.GetObject(typeof(IConfirmationPayment), string.Format("tcp://{0}:{1}/ConfirmationPayment", paymentServer, paymentPort));
            }
            catch (Exception ex)
            {
                Log.Write(ex, (object)this);
                throw;
            }
        }
        #endregion
        #region Events Function
        private void MifareServer_ClientWaitingDisconnectEvt(object sender, MifareConnectEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void MifareServer_PacketEvt(object sender, MifarePacketEventArgs args)
        {
            Int32? idDevice = GetDeviceInfo(args.IPAddress, out int timeDTR, out string deviceName);
            if (idDevice == null)
            {
                mifareServer.Stop(args.IPAddress);
                Classes.GlobalVariable.ClientInfoLabel.BeginInvoke(new Action((() =>
                {
                    Classes.GlobalVariable.ClientInfoLabel.Text = string.Format("Не змогли отримати інформацію по пристрою з адресою {0}", args.IPAddress);

                })));
                return;
            }
            //Collect CardCode
            string hexValue1 = args.Data[0].ToString("X").PadLeft(2, '0');
            string hexValue2 = args.Data[1].ToString("X").PadLeft(2, '0');
            string hexValue3 = args.Data[2].ToString("X").PadLeft(2, '0');
            string hexValue4 = args.Data[3].ToString("X").PadLeft(2, '0');
            int intCardCode = Convert.ToInt32(string.Concat(hexValue1, hexValue2, hexValue3, hexValue4), 16);
            string card = intCardCode.ToString();
            card = card.PadLeft(10, '0');
            if (card.Length != 0 && card != "0000000000")
            {
                CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
                if (ChekTaskMifareDevice(args.IPAddress, true, out cancelTokenSource))
                {
                    cancelTokenSource = new CancellationTokenSource();
                    MifareDevice mifareDevice = new MifareDevice();
                    mifareDevice.ipAddress = args.IPAddress;
                    mifareDevice.mifareDeviceServer = mifareServer;
                    mifareDevice.mifareConfirmation = confirmationPayment;
                    mifareDevice.cancelTokenSource = cancelTokenSource;
                    mifareDevice.idDevice = idDevice.Value;
                    Task<MifareDevice> newResponder = new Task<MifareDevice>(() => new MifareResponder(confirmationPayment, mifareDevice, cancelTokenSource.Token, card, idDevice.Value, timeDTR, deviceName));
                    newResponder.Start();
                    while (true)
                    {
                        if (newResponder.Status == TaskStatus.RanToCompletion)
                            break;

                        Thread.Sleep(5000);
                    }
                    cancelTokenSource = new CancellationTokenSource();

                    //Start New Task
                    cancelTokenSource = new CancellationTokenSource();
                    mifareDevice = new MifareDevice();
                    mifareDevice.ipAddress = args.IPAddress;
                    mifareDevice.mifareDeviceServer = mifareServer;
                    mifareDevice.mifareConfirmation = confirmationPayment;
                    mifareDevice.cancelTokenSource = cancelTokenSource;
                    mifareDevice.idDevice = idDevice.Value; 
                    mifareDevice.NowSendingImage = false;

                    CreateTask(mifareDevice, cancelTokenSource, false);
                }
            }

        }

        private void MifareServer_ErrorEvt(object sender, MifareErrorEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void MifareServer_ClientDisconnectEvt(object sender, MifareConnectEventArgs args)
        {
            throw new NotImplementedException();
        }

        private void MifareServer_ClientConnectEvt(object sender, MifareConnectEventArgs args)
        {
            if (GetIdDeviceByIp(args.IPAddress) == null)
            {
                mifareServer.Stop(args.IPAddress);
            }
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            ChekTaskMifareDevice(args.IPAddress, true, out cancelTokenSource);

            
            //Create class info
            Int32 timeDTR;
            string deviceName;
            Int32? idDevice = GetDeviceInfo(args.IPAddress, out timeDTR, out deviceName);
            if (idDevice == null)
            {
                mifareServer.Stop(args.IPAddress);
                Classes.GlobalVariable.ClientInfoLabel.BeginInvoke(new Action((() =>
                {
                    Classes.GlobalVariable.ClientInfoLabel.Text = string.Format("Не змогли отримати інформацію по пристрою з адресою {0}", args.IPAddress);

                })));
                return;
            }
                
            MifareDevice mifareDevice = new MifareDevice();
            mifareDevice.ipAddress = args.IPAddress;
            mifareDevice.mifareDeviceServer = mifareServer;
            mifareDevice.mifareConfirmation = confirmationPayment;
            mifareDevice.cancelTokenSource = cancelTokenSource;
            mifareDevice.idDevice = idDevice.Value;
            mifareDevice.deviceName = deviceName;
            mifareDevice.NowSendingImage = false;

            CreateTask(mifareDevice, cancelTokenSource, true);
        }
        #endregion

        #region Logic Function
        private Int32? GetIdDeviceByIp(string ipAddress)
        {
            foreach (GameZoneDataSet.FreeTableRow row in Classes.GlobalVariable.PointInfo.FreeTable.Rows)
            {
                if (row["IpAddress"].ToString() == ipAddress)
                    return (int)row["IdDevice"]; 
            }
            Classes.GlobalVariable.ClientInfoLabel.BeginInvoke(new Action((() =>
            {
                Classes.GlobalVariable.ClientInfoLabel.Text = string.Format("Пристрій з адресом {0} не дозволен на цьому вузлі", ipAddress);

            })));
            
            return null;

        }
        private Int32? GetDeviceInfo(string ipAddress, out Int32 timeDTR, out string deviceName)
        {
            timeDTR = 0;
            deviceName = "Не визначено";
            foreach (GameZoneDataSet.FreeTableRow row in Classes.GlobalVariable.PointInfo.FreeTable.Rows)
            {
                if (row["IpAddress"].ToString() == ipAddress)
                {
                    deviceName = row["DeviceName"].ToString();
                    timeDTR = (int)row["TimeDTR"];
                    return (int)row["IdDevice"];
                }
            }
            return null;
        }
        private bool ChekTaskMifareDevice(string ip, bool needRemove, out CancellationTokenSource cancellationToken)
        {

            cancellationToken = new CancellationTokenSource();
            foreach (MifareDevice device in Classes.GlobalVariable.MifareThreadList)
            {
                if (device.ipAddress == ip)
                {
                    cancellationToken = device.cancelTokenSource;
                    if (needRemove)
                    {
                        cancellationToken.Cancel();
                        Classes.GlobalVariable.MifareThreadList.Remove(device);
                        LogDeviceQueue.Enqueue(device.idDevice, null, null, Classes.Constants.TypeLog.Red, null, null, "Зупинка інформаційного потоку", false);
                        
                    }
                    return true;
                }
            }
            return false;

        }
        private void CreateTask(MifareDevice mifareDevice, CancellationTokenSource cancelTokenSource, bool firstConnection)
        {
            lock (Classes.GlobalVariable.MifareThreadList)
                Classes.GlobalVariable.MifareThreadList.Add(mifareDevice);
            Task<MifareDevice> newConnection = new Task<MifareDevice>(() => new MifareChanger(mifareDevice, cancelTokenSource.Token, firstConnection));
            
            newConnection.Start();
            if(firstConnection)
                LogDeviceQueue.Enqueue(mifareDevice.idDevice, null, null, Classes.Constants.TypeLog.Green, null, null, "Підключення до станції", false);
            
        }
        #endregion
    }
}

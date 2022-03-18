using SoftMarket.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZPSoft.GameZone.SCI.Classes;

namespace ZPSoft.GameZone.SCI.ClientLogic.MifareClasses
{
    internal class MifareChanger : MifareDevice
    {
        #region Init Function
        CancellationToken token;
        
        public MifareChanger(MifareDevice mifareDevice, CancellationToken token, bool firstConnection)
        {
            MifareSender mifareSender = new MifareSender();
            try
            {
                this.token = token;
                while(NotCanContinueChange(mifareDevice) && !IsNowSending(mifareDevice) && firstConnection)
                     if (Sleep(1000)) return;
                SetSending(mifareDevice, true);
                if (firstConnection)
                {
                    mifareSender.SendCommand(Constants.CommandImage.SendLogo, mifareDevice.ipAddress,mifareDevice.idDevice, mifareDevice.mifareDeviceServer, mifareDevice.mifareConfirmation, token, null);
                    if (Sleep(4000)) return;
                    mifareSender.SendCommand(Constants.CommandImage.SendPrice, mifareDevice.ipAddress,mifareDevice.idDevice, mifareDevice.mifareDeviceServer, mifareDevice.mifareConfirmation, token, null);
                    if (Sleep(2000)) return;
                }
                while (true)
                {
                    //Разрешение на отправку
                    while (NotCanContinueChange(mifareDevice) && !IsNowSending(mifareDevice))
                    {
                        if (Sleep(1000)) return;
                    }
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    SetSending(mifareDevice, true);
                    mifareSender.SendCommand(Constants.CommandImage.Screen1, mifareDevice.ipAddress, mifareDevice.idDevice, mifareDevice.mifareDeviceServer, mifareDevice.mifareConfirmation, token, null);
                    if (Sleep(3000)) return;
                    mifareSender.SendCommand(Constants.CommandImage.Screen2, mifareDevice.ipAddress, mifareDevice.idDevice, mifareDevice.mifareDeviceServer, mifareDevice.mifareConfirmation, token, null);
                    if (Sleep(3000)) return;
                    mifareSender.SendCommand(Constants.CommandImage.SendPrice, mifareDevice.ipAddress, mifareDevice.idDevice, mifareDevice.mifareDeviceServer, mifareDevice.mifareConfirmation, token, null);
                    if (Sleep(3000)) return;
                    //Ставим текущее время обновления
                    lock (GlobalVariable.MifareThreadList)
                    {
                        GlobalVariable.MifareThreadList.Find(a => a.ipAddress == mifareDevice.ipAddress).LastSendingImage = DateTime.Now;

                    }
                    SetSending(mifareDevice, false);
                }
            }
            catch (Exception ex)
            {
                Log.Write(string.Format("Ошибка в класса MifareChanger -  {0}", ex.ToString()),Log.MessageType.Error,this);
            }

        }
        #endregion
        #region Logic Function
        private bool Sleep(int time)
        {
            DateTime dateTime = DateTime.Now + new TimeSpan(0, 0, 0, 0, time);
            while (DateTime.Now < dateTime)
            {
                if (this.token.IsCancellationRequested)
                {
                    return true;
                }
                Thread.Sleep(50);
            }
            return false;
        }

        private void SetSending(MifareDevice mifareDevice, bool isSending)
        {
            lock (Classes.GlobalVariable.MifareThreadList)
                Classes.GlobalVariable.MifareThreadList.Find(a => a.ipAddress == mifareDevice.ipAddress).NowSendingImage = isSending;
        }
        private bool IsNowSending(MifareDevice mifareDevice)
        {
            lock (Classes.GlobalVariable.MifareThreadList)
            {
                return Classes.GlobalVariable.MifareThreadList.Find(a => a.ipAddress == mifareDevice.ipAddress).NowSendingImage;
            }
        }
        private bool NotCanContinueChange(MifareDevice mifareDevice)
        {
            lock (Classes.GlobalVariable.MifareThreadList)
            {
                Classes.GlobalVariable.MifareThreadList = Classes.GlobalVariable.MifareThreadList.OrderBy(a => a.LastSendingImage).ToList<MifareDevice>();
                List<MifareDevice> tempList = Classes.GlobalVariable.MifareThreadList.Take(1).Where(a => a.NowSendingImage == false).ToList<MifareDevice>();
                MifareDevice tempDevice = tempList.Find(a => a.ipAddress == mifareDevice.ipAddress);
                if (tempDevice != null)
                {
                    return false;
                }
                return true;
            }
        }
        #endregion
    }
}

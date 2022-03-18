using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZPSoft.GameZone.SCI.Classes.LogClasses;
using ZPSoft.GameZone.SGZGlobals.Classes;
using ZPSoft.GameZone.SGZServiceInterfaces;

namespace ZPSoft.GameZone.SCI.ClientLogic.MifareClasses
{
    internal class MifareResponder : MifareDevice
    {
        public MifareResponder(IConfirmationPayment confirmationPayment, MifareDevice mifareDevice, CancellationToken token, string cardId, Int32 clientId, Int32 timeDTR, string deviceName)
        {
            Money restCashCard = new Money(0);
            Money priceDeivce = new Money(0);
            MifareSender mifareSender = new MifareSender();
            bool isConfirmed = false;
            try
            {
                isConfirmed=confirmationPayment.ConfiramtionPayment(cardId, clientId,Constants.ZonePayment.CardSystem, out  priceDeivce, out restCashCard);////.ConfirmationPayment(cardId, clientId, out ostCard, out gamePrice, SoftMarket.GameZone.Globals.Constants.ZonePayment.CardSystem, true, SoftMarket.GameZone.Globals.Constants.ActionPaymentType.GetonDevice);
                if (isConfirmed)
                {
                    LogDeviceQueue.Enqueue(mifareDevice.idDevice, null, null, Classes.Constants.TypeLog.Green, null, null, string.Format("Гра підтверджена. Картка - {0}, ціна - {1}, залишок - {2}", cardId, priceDeivce, restCashCard), false);
                    mifareSender.SendCommand(Classes.Constants.CommandImage.PaydOk, mifareDevice.ipAddress, mifareDevice.idDevice, mifareDevice.mifareDeviceServer, mifareDevice.mifareConfirmation, token, timeDTR);
                }
                else
                {
                    LogDeviceQueue.Enqueue(mifareDevice.idDevice, null, null, Classes.Constants.TypeLog.Green, null, null, string.Format("Гра відхилена. Картка - {0}, ціна - {1}, залишок - {2}", cardId, priceDeivce, restCashCard), false);
                    mifareSender.SendCommand(Classes.Constants.CommandImage.PaydFalse, mifareDevice.ipAddress, mifareDevice.idDevice, mifareDevice.mifareDeviceServer, mifareDevice.mifareConfirmation, token, timeDTR);
                }
            }
            catch (SGZGlobals.Classes.Exceptions.TableModule.GeneralException e)
            {
                LogDeviceQueue.Enqueue(mifareDevice.idDevice, null, null, Classes.Constants.TypeLog.Green, null, null, e.Message, false);
                mifareSender.SendCommand(Classes.Constants.CommandImage.PaydFalse, mifareDevice.ipAddress, mifareDevice.idDevice, mifareDevice.mifareDeviceServer, mifareDevice.mifareConfirmation, token, timeDTR);
            }
            
        }
    }
}

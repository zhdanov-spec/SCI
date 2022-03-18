using Igroland.GameZone.MifareInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZPSoft.GameZone.SGZServiceInterfaces;

namespace ZPSoft.GameZone.SCI.ClientLogic.MifareClasses
{
    public class MifareDevice
    {
        public string ipAddress { get; set; }
        public string deviceName { get; set; }
        public Int32 idDevice { get; set; }
        public MifareServer mifareDeviceServer { get; set; }
        public IConfirmationPayment mifareConfirmation { get; set; }
        public System.Threading.CancellationTokenSource cancelTokenSource { get; set; }
        public DateTime? LastSendingImage { get; set; }
        public bool NowSendingImage { get; set; }

    }
}

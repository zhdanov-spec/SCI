using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPSoft.GameZone.SCI.Classes
{
    internal class Constants
    {
        public enum TypeSyncing
        {
            SqlSync = 0,
            FieldSync = 1
        }
        public enum TypeLog
        {
            White,
            Green,
            Red,
        }
        public enum Services
        {
            None = -1,
            RemotingServices = 0,
            WebHost = 1,
            WebApi = 2,
            GOIP = 3,
            MailMonitoring = 4,
            WCFService = 5,
            MobileHost = 6,
            MobileApi = 7,
            TelegramBot = 8,
            SyncMainServer=9
        }
        public enum WCFEvents
        {
            WCFConnect = 9,
            WCFDisconnect = 10,
            WCFPing = 11,
        }
        public enum CommandImage
        {
            Screen1 = 1,
            Screen2 = 2,
            SendPrice = 3,
            PaydOk = 4,
            SendLogo = 5,
            PaydFalse = 6

        }

    }
}

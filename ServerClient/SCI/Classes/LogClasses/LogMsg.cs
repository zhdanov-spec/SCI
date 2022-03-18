using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPSoft.GameZone.SCI.Classes.LogClasses
{
    internal class LogMsg
    {
        private readonly DateTime actionTime = DateTime.Now;
        private readonly string message;
        private readonly Color color;
        private readonly Constants.TypeLog typeLog;
        private readonly Constants.Services serviceId;
        

        public string Message
        {
            get
            {
                return message;
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }
        }
        public DateTime ActionTime
        {
            get
            {
                return actionTime;
            }
        }
        public Constants.Services ServiceId
        {
            get
            {
                return serviceId;
            }
        }
        public Constants.TypeLog TypeLog
        {
            get
            {
                return typeLog;
            }
        }
        public LogMsg(Constants.Services serviceId, string message, Color color, Constants.TypeLog typeLog)
        {
            this.message = message;
            this.color = color;
            this.serviceId = serviceId;
            this.typeLog = typeLog;
        }
    }
}

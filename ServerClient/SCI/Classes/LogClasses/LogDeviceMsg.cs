using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPSoft.GameZone.SCI.Classes.LogClasses
{
    internal class LogDeviceMsg
    {
        
        private readonly Int32 idDevice;
        public Int32 IdDevice
        {
            get
            {
                return idDevice;
            }
        }
        
        private readonly string deviceName;
        public string DeviceName
        {
            get
            {
                return deviceName;
            }
        }
        private readonly string ipAddress;
        public string IPAddress
        {
            get
            {
                return ipAddress;
            }
        }
        private readonly Color color;
        public Color Color
        {
            get
            {
                return color;
            }
        }
        private readonly Constants.TypeLog typeLog;
        public Constants.TypeLog TypeLog
        {
            get
            {
                return typeLog;
            }
        }
        private readonly string deviceGroup;
        public string DeviceGroup
        {
            get
            {
                return deviceGroup;
            }
        }
        private readonly string tariffName;
        public string TariffName
        {
            get
            {
                return tariffName;
            }
        }
        private readonly DateTime actionTime;
        public DateTime ActionTime
        {
            get
            {
                return actionTime;
            }
        }
        private readonly string lastAction;
        public string LastAction
        {
            get
            {
                return lastAction;
            }
        }
        private readonly bool isAdded;
        public bool IsAdded
        {
            get
            {
                return isAdded;
            }
        }
        public LogDeviceMsg(Int32 idDevice, string deviceName, string ipAddress, Color color, Constants.TypeLog typeLog, string deviceGroup, string tariffName, string lastAction, bool isAdded)
        {
            this.idDevice = idDevice;
            this.deviceName = deviceName;
            this.ipAddress = ipAddress;
            this.color = color;
            this.typeLog = typeLog;
            this.deviceGroup = deviceGroup;
            this.tariffName = tariffName;
            this.actionTime = DateTime.Now;
            this.lastAction = lastAction;
            this.isAdded = isAdded;
        }
    }
}

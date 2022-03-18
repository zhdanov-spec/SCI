using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPSoft.GameZone.SCI.Classes.LogClasses
{
    internal class LogDeviceQueue
    {
        private static readonly Queue msgList = new Queue(256);

        public static int Count
        {
            get
            {
                lock (msgList)
                    return msgList.Count;
            }
        }

        public static void Enqueue(LogDeviceMsg msg)
        {
            try
            {
                lock (msgList)
                    msgList.Enqueue(msg);
            }
            catch (Exception)
            {
                
            }
        }

        public static void Enqueue(Int32 idDevice, string deviceName, string ipAddress, Constants.TypeLog typeLog, string deviceGroup, string tariffName, string lastAction, bool isAdded)
        {
            Color color = new Color();
            switch (typeLog)
            {
                case Constants.TypeLog.Green:
                    color = Color.Green;
                    break;
                case Constants.TypeLog.Red:
                    color = Color.Red;
                    break;
                case Constants.TypeLog.White:
                    color = Color.White;
                    break;
            }
            Enqueue(new LogDeviceMsg(idDevice, deviceName, ipAddress, color, typeLog, deviceGroup, tariffName, lastAction, isAdded));
        }

        public static LogDeviceMsg Dequeue()
        {
            lock (msgList)
                return (LogDeviceMsg)msgList.Dequeue();
        }
    }
}

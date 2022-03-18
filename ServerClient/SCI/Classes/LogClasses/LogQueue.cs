using SoftMarket.Globals;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZPSoft.GameZone.SCI.Classes.LogClasses
{
    internal class LogQueue
    {
        private static readonly Queue msgList = new Queue(256);

        public static int Count
        {
            get
            {
                lock (LogQueue.msgList)
                    return LogQueue.msgList.Count;
            }
        }

        public static void Enqueue(LogMsg msg)
        {
            try
            {
                lock (LogQueue.msgList)
                    LogQueue.msgList.Enqueue(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                Log.Write(ex.ToString(), Log.MessageType.Error, null);
            }
        }

        public static void Enqueue(Constants.Services serviceId, string message, Constants.TypeLog typeLog)
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
            Enqueue(new LogMsg(serviceId, message, color, typeLog));
        }

        public static LogMsg Dequeue()
        {
            lock (msgList)
                return (LogMsg)msgList.Dequeue();
        }
    }
}

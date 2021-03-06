using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZPSoft.GameZone.SCI.Classes
{
    public class PingThreadClass
    {
        private Thread trashThread;
        public PingThreadClass()
        {

        }
        public void StartPing()
        {
            trashThread = null;


            if (trashThread == null)
                trashThread = new Thread(new ThreadStart(StartPingThread));

            if (trashThread.IsAlive)
            {
                trashThread.Abort();
                trashThread.Join();
                trashThread = new Thread(new ThreadStart(StartPingThread));
            }

            try
            {
                trashThread.IsBackground = true;
                trashThread.Start();
            }
            catch (Exception)
            {

            }

        }
        private void StartPingThread()
        {
            while (true)
            {
                try
                {
                    GlobalVariable.WCFClient.PingConnection(GlobalVariable.ProgramIdentificator);

                    //Sleep For 60seconds
                    
                    Thread.Sleep(1000 * 30);
                }
                catch
                {
                    break;
                }
            }
        }
    }
}

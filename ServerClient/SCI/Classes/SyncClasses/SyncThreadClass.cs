using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZPSoft.GameZone.SCI.Classes.LogClasses;

namespace ZPSoft.GameZone.SCI.Classes.SyncClasses
{
    public class SyncThreadClass
    {
        private Thread syncThread = null;
        private static MainSynchro mainSynchro = new MainSynchro();
        public void Init()
        {
            if (!Convert.ToBoolean(Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_ENABLED).Value))
                return;
            GlobalVariable.SyncLocker = new object();
            LogQueue.Enqueue(Constants.Services.SyncMainServer, "Запуск сервісу сінхронізації", Constants.TypeLog.Green);
            syncThread = null;
            if (syncThread == null)
                syncThread = new Thread(new ThreadStart(StartSyncProgram));
            if (syncThread.IsAlive)
            {
                syncThread.Abort();
                syncThread.Join();
                syncThread = new Thread(new ThreadStart(StartSyncProgram));
            }
            try
            {
                syncThread.IsBackground = true;
                syncThread.Start();
                LogQueue.Enqueue(Constants.Services.SyncMainServer, "Запуск сервісу сінхронізації - вдало", Constants.TypeLog.Green);
            }
            catch
            {
                LogQueue.Enqueue(Constants.Services.SyncMainServer, "Помилка запуску сервісу сінхронізації", Constants.TypeLog.Red);
            }
        }
        private void StartSyncProgram()
        {
            mainSynchro.Start();
         
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZPSoft.GameZone.SCI.Classes.SyncClasses
{
    internal class MainSynchro
    {
        #region Init Function
        public void Start()
        {
            GlobalVariable.LocalSareaSyncInfo = new LocalSareaSyncInfo()
            {
                //bases = row.Bases,
                //ipAddress = row.ServerIp,
                //passBases = row.Password,
                //sareaId = row.SareaId,
                //userBases = row.User,
                isDownload = false,
                isUpload = false
            };
            
            while (true)
            {
                LogClasses.LogQueue.Enqueue(Constants.Services.SyncMainServer, "Початок передачі данних", Constants.TypeLog.Green);
                CancellationTokenSource cancelTokenSourceUpload = new CancellationTokenSource();
                CreateTaskUpload(cancelTokenSourceUpload);
                while (NowIsUpload())
                {
                    Sleep(1, false);
                }


                LogClasses.LogQueue.Enqueue(Constants.Services.SyncMainServer, "Початок отримання данних", Constants.TypeLog.Green);
                CancellationTokenSource cancelTokenSourceDownload = new CancellationTokenSource();
                lock (GlobalVariable.SyncLocker)
                    GlobalVariable.LocalSareaSyncInfo.isDownload = true;
                CreateTaskDownload(cancelTokenSourceDownload);
                CreateTaskUpload(cancelTokenSourceUpload);
                while (NowIsDownload())
                {
                    Sleep(1, false);
                }
                LogClasses.LogQueue.Enqueue(Constants.Services.SyncMainServer, "Очікування наступного циклу синхронізації", Constants.TypeLog.White);

                Sleep(1*60*15, false);
               
            }
        }

        #endregion
        #region Logic Functions
        private bool Sleep(int time, bool whatingTimer)
        {
            DateTime dateTime = DateTime.Now + new TimeSpan(0, 0, 0, time);
            while (DateTime.Now < dateTime)
            {
                if (whatingTimer)
                {
                    return true;
                }
                Thread.Sleep(50);
            }
            return false;
        }
        private bool NowIsUpload()
        {
            lock (GlobalVariable.SyncLocker)
            {
                if (GlobalVariable.LocalSareaSyncInfo.isUpload == true)
                    return true;
                else
                    return false;
            }
        }
        private bool NowIsDownload()
        {
            lock (GlobalVariable.SyncLocker)
            {
                if (GlobalVariable.LocalSareaSyncInfo.isDownload == true)

                    return true;
                else
                    return false;
            }
        }
        private void CreateTaskDownload(CancellationTokenSource cancelTokenSource)
        {

            Task<LocalSareaSyncInfo> newConnection = new Task<LocalSareaSyncInfo>(() => new SareaDownloadSyncing(GlobalVariable.LocalSareaSyncInfo, cancelTokenSource));
            newConnection.Start();

        }
        private void CreateTaskUpload(CancellationTokenSource cancelTokenSource)
        {

            Task<LocalSareaSyncInfo> newConnection = new Task<LocalSareaSyncInfo>(() => new SareaUploadSyncing(GlobalVariable.LocalSareaSyncInfo, cancelTokenSource));
            newConnection.Start();

        }
        #endregion
    }
}

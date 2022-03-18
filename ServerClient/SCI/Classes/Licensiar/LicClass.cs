using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ZPSoft.GameZone.SCI.Classes.Licensiar
{
    public class LicClass
    {
        private Thread licListiner = null;

        public bool InitLicListener()
        {

            licListiner = null;
            
            if (licListiner == null)
            {
                licListiner = new Thread(new ThreadStart(StartLicThread));
            }
            if (licListiner.IsAlive)
            {
                licListiner.Abort();
                licListiner.Join();
                licListiner = new Thread(new ThreadStart(StartLicThread));
            }
            try
            {
                licListiner.IsBackground = true;
                licListiner.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private readonly Guard guardLic = new Guard();
        private class Guard
        {
        }
        private void StartLicThread()
        {
            lock (guardLic)
            {
                while (true)
                {
                    string licInfo = GetLic("64cbb593-0999-4d94-8596-8338633b0dd4", "3ea089cf-40fb-4e80-a27b-41f12b9c5fe3", "https://localhost:44364");
                    if (licInfo != null)
                    {
                        GlobalVariable.LicenseParam = JsonConvert.DeserializeObject<ZPSoftLGetter.LicenseInfoModel>(licInfo);
                        if (GlobalVariable.LicenseParam.ProgramLicenses.FirstOrDefault().ProgramLicenseValid < DateTime.Now)
                        {
                            GlobalVariable.LicenseElement.ForeColor = Color.Red;
                            GlobalVariable.LicenseElement.Text = string.Format("Ліцензія була дісна до {0}", GlobalVariable.LicenseParam.ProgramLicenses.FirstOrDefault().ProgramLicenseValid);
                        }
                        else
                        {
                            GlobalVariable.LicenseElement.ForeColor = Color.Black;
                            GlobalVariable.LicenseElement.Text = string.Format("Ліцензія дісна до {0}", GlobalVariable.LicenseParam.ProgramLicenses.FirstOrDefault().ProgramLicenseValid);
                        }
                    }
                    else
                    {
                        GlobalVariable.LicenseElement.Text = string.Format("Не вдалось отримати ліцензію {0}",DateTime.Now.ToString());
                    }
                    Thread.Sleep(10000);
                }
            }
        }
        private string GetLic(string token,string programToken,string webLicServer)
        {
            ZPSoftLGetter.GetLicClass getLicClass = new ZPSoftLGetter.GetLicClass();
            return getLicClass.GetLic(token, programToken,webLicServer,out string status,out bool fromFile);
            
        }

    }
}

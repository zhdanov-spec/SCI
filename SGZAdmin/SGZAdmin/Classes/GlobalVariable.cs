using SoftMarket.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ZPSoft.GameZone.SGZGlobals.DataSets;
using ZPSoft.GameZone.SGZWCFInterfaces;

namespace ZPSoft.GameZone.SGZAdmin.Classes
{
    public sealed class GlobalVariable
    {
        #region DataSet Element
        private static SGZGlobals.DataSets.SettingsDataset settings;
        public static SGZGlobals.DataSets.SettingsDataset Settings
        {
            get
            {
                return settings;
            }
            set
            {
                settings = value;
            }
        }
        private static GameZoneDataSet adminData;
        public static GameZoneDataSet AdminData
        {
            get
            {
                return adminData;
            }
            set
            {
                adminData = value;
            }
        }
        #endregion
        #region WCF Variable
        private static IGameZoneService wcfClient;
        public static IGameZoneService WCFClient
        {
            get { return wcfClient; }
            set { wcfClient = value; }
        }
        private static ICommunicationObject wCFobj;
        public static ICommunicationObject Wcfobj
        {
            get
            {
                return wCFobj;
            }
            set
            {
                wCFobj = value;
            }
        }
        private static Guid programIdentificator;
        public static Guid ProgramIdentificator
        {
            get
            {
                return programIdentificator;
            }
            set
            {
                programIdentificator = value;
            }
        }
        #endregion
        #region Global Saving
        public static void SaveData()
        {

            try
            {
                GameZoneDataSet Changes = (GameZoneDataSet)GlobalVariable.AdminData.GetChanges();
                if (Changes != null)
                {
                    GlobalVariable.WCFClient.SaveAdminData(Changes);
                }
                Classes.GlobalVariable.AdminData.AcceptChanges();
            }
            catch (System.Net.Sockets.SocketException err)
            {
                Log.Write(err, null);
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка зв'язку з сервером");
            }
            catch (System.Runtime.Remoting.RemotingException err)
            {
                Log.Write(err, null);
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка зв'язку з сервером");
            }
            catch (System.Reflection.TargetInvocationException err)
            {
                Log.Write(err, null);
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка зв'язку з сервером");
            }
            catch (SGZGlobals.Classes.Exceptions.TableModule.GeneralException err)
            {
                Log.Write(err, null);
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка зв'язку з сервером");
            }
            catch (System.Data.SqlClient.SqlException err)
            {
                Log.Write(err, null);
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка зв'язку з сервером");
            }
            catch (ServiceException err)
            {
                Log.Write(err, null);
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Помилка зв'язку з сервером");
            }
        }
        #endregion
    }
}

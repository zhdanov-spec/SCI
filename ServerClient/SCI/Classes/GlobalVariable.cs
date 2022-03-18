using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

using ZPSoft.GameZone.SCI.Classes.Licensiar;
using ZPSoft.GameZone.SCI.Classes.SyncClasses;
using ZPSoft.GameZone.SCI.ClientLogic.MifareClasses;
using ZPSoft.GameZone.SGZGlobals.DataSets;
using ZPSoft.GameZone.SGZWCFInterfaces;
using ZPSoft.ZPSoftLGetter;

namespace ZPSoft.GameZone.SCI.Classes
{
    public sealed class  GlobalVariable
    {
        private static LicenseInfoModel licenseParam;
        public static LicenseInfoModel LicenseParam
        {
            get
            {
                return licenseParam;
            }
            set
            {
                licenseParam = value;
            }
        }
        #region Status Strip Element
        private static RadLabelElement licenseElement;
        public static RadLabelElement LicenseElement
        {
            get
            {
                return licenseElement;
            }
            set
            {
                licenseElement = value;
            }
        }
        #endregion
        #region DataSet Element
        private static DataSets.ServerDataSet serverDataSet;
        public static DataSets.ServerDataSet ServerDataSet
        {
            get
            {
                return serverDataSet;
            }
            set
            {
                serverDataSet = value;
            }
        }
        private static SettingsDataset settings;
        public static SettingsDataset Settings
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
        private static string strPassword;
        public static string StrPassword
        {
            get
            {
                return strPassword;
            }
            set
            {
                strPassword = value;
            }
        }
        private static string strPasswordSync;
        public static string StrPasswordSync
        {
            get
            {
                return strPasswordSync;
            }
            set
            {
                strPasswordSync = value;
            }
        }
        private static SqlConnection sqlConnection;
        public static SqlConnection SqlConnection
        {
            get
            {
                return sqlConnection;
            }
            set
            {
                sqlConnection = value;
            }
        }
        private static SqlConnection sqlConnectionSync;
        public static SqlConnection SqlConnectionSync
        {
            get
            {
                return sqlConnectionSync;
            }
            set
            {
                sqlConnectionSync = value;
            }
        }
        private static SqlDataAdapter globalsDataAdapter;
        public static SqlDataAdapter GlobalsDataAdapter
        {
            get
            {
                return globalsDataAdapter;
            }
            set
            {
                globalsDataAdapter = value;
            }
        }
        private static SqlDataAdapter sareaDataAdapter;
        public static SqlDataAdapter SareaDataAdapter
        {
            get
            {
                return sareaDataAdapter;
            }
            set
            {
                sareaDataAdapter = value;
            }
        }
        public static string ConnectionString
        {
            get
            {
                try
                {
                    return string.Format
                    ("workstation id={0};packet size=4096;user id={1};data source={0};persist security info=True;initial catalog={3};password={2}",
                    settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SERVER_NAME).Value,
                    settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SERVER_LOGIN).Value,
                    StrPassword,
                    settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SERVER_BASENAME).Value
                    );
                }
                catch
                {
                    return ""; 
                }
            }
        }
        public static string ConnectionStringSync
        {
            get
            {
                try
                {
                    return string.Format
                    ("workstation id={0};packet size=4096;user id={1};data source={0};persist security info=True;initial catalog={3};password={2}",
                    settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_NAME).Value,
                    settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_LOGIN).Value,
                    StrPasswordSync,
                    settings.DBSettings.FindByKey((int)SGZGlobals.Classes.Constants.DatabaseSettings.SYNC_SERVER_BASENAME).Value
                    );
                }
                catch
                {
                    return "";
                }
            }
        }
        #endregion
        #region Client Function
        private static List<MifareDevice> mifareThreadList;
        public static List<MifareDevice> MifareThreadList
        {
            get
            {
                return mifareThreadList;
            }
            set
            {
                mifareThreadList = value;
            }
        }
        private static RadLabel clientInfoLabel;
        public static RadLabel ClientInfoLabel
        {
            get
            {
                return clientInfoLabel;
            }
            set
            {
                clientInfoLabel = value;
            }
        }
        private static bool isOnline;
        public static bool IsOnline
        {
            get
            {
                return isOnline;
            }
            set { isOnline = value; }
        }
        private static GameZoneDataSet pointInfo;
        public static GameZoneDataSet PointInfo
        {
            get
            {
                return pointInfo;
            }
            set
            {
                pointInfo = value;
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
        #region Synchro Variable 
        private static LocalSareaSyncInfo localSareaSyncInfo;
        public static LocalSareaSyncInfo LocalSareaSyncInfo
        {
            get
            {
                return localSareaSyncInfo;
            }
            set
            {
                localSareaSyncInfo = value;
            }
        }
        private static object syncLocker;
        public static object SyncLocker
        {
            get
            {
                return syncLocker;
            }
            set
            {
                syncLocker = value;
            }
        }
        #endregion
    }
}

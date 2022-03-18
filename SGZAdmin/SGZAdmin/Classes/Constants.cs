using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZPSoft.GameZone.DatabaseComponents;
using ZPSoft.GameZone.SGZGlobals.DataSets;

namespace ZPSoft.GameZone.SGZAdmin.Classes
{
    public class Constants
    {
        public static readonly string SettingsFileName = AppDomain.CurrentDomain.BaseDirectory + "\\SCIAdminConfig.xml";
        public enum Table
        {
            None,
            GroupDevice,
            Devices,
            NodePoints,
            Cashier,
            CashierGroup,
            Permissions,
            Tariff,
            Periods,
            Holiday,
            Discount,
            GroupUser,
            Globals,
            CashDesk,
            Bonuses
        }
        public struct RowInfo
        {
            public RowInfo(Constants.Table sourceTable, object key)
            {
                this.SourceTable = sourceTable;
                this.Key = key;
                this.SareaId = DataSetHolder.SareaId;
            }
            public RowInfo(Constants.Table sourceTable, object key, int sareaId)
            {
                this.SourceTable = sourceTable;
                this.Key = key;
                this.SareaId = sareaId;
            }
            public Constants.Table SourceTable;
            public object Key;
            public int SareaId;
        }
        public interface IEditForm
        {
            RowInfo Execute(System.Windows.Forms.CurrencyManager cm, GameZoneDataSet Info, bool Insert, SGZGlobals.Classes.Constants.PermissionType permission);
            void Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using ZPSoft.GameZone.SGZAdmin.Classes;
using ZPSoft.GameZone.SGZGlobals.Classes;
using ZPSoft.GameZone.SGZGlobals.DataSets;
using static ZPSoft.GameZone.SGZAdmin.Classes.Constants;
using ZPSoft.GameZone.SGZDomain;

namespace ZPSoft.GameZone.SGZAdmin.ProgramForms
{
    public partial class CashierGroupForm : RadForm, IEditForm
    {
        #region Init Function
        public CashierGroupForm()
        {
            InitializeComponent();
        }
        private DataRowView drvDetail;
        private DataView vueDetail;
        private CurrencyManager cm;
        private GameZoneDataSet Info;
        RowInfo rowInfo = new RowInfo(Classes.Constants.Table.None, null);
        public RowInfo Execute(CurrencyManager cm, GameZoneDataSet Info, bool Insert, SGZGlobals.Classes.Constants.PermissionType permission)
        {
            
            this.cm = cm;
            this.Info = Info;
            if (Insert) cm.AddNew();

            drvDetail = (DataRowView)cm.Current;
            vueDetail = drvDetail.DataView;
            if (cm.Count != 1)
                this.BindingContext[vueDetail].Position = cm.Position;

            IdCashierGroup.DataBindings.Add("Text", vueDetail, "IdCashierGroup");
            CashierGroupName.DataBindings.Add("Text", vueDetail, "CashierGroupName");
            EnabledToggleSwitch.DataBindings.Add("Value", this.vueDetail, "Enabled");

            if (Insert)
            {
                int MaxIdCashierGroup = 1;
                foreach (GameZoneDataSet.CashierGroupRow Row in Info.CashierGroup)
                    if (Row.RowState != DataRowState.Deleted && Row.IdCashierGroup > MaxIdCashierGroup) MaxIdCashierGroup = Row.IdCashierGroup;
                drvDetail["IdCashierGroup"] = MaxIdCashierGroup + 1;
                drvDetail["Enabled"] = true;
            }
            GetPermissions();
            if ((int)drvDetail["IdCashierGroup"] == 1 && !ServiceManager.SuperUser)
            {
                ОкButton.Enabled = false;
            }
            if (ShowDialog() == DialogResult.OK)
            {
                SetPermissions();
                cm.EndCurrentEdit();
            }
            else
                cm.CancelCurrentEdit();
            return rowInfo;
        }
        #endregion
        #region Logic Function
        private void GetPermissions()
        {
            int IdGroup = (int)drvDetail["IdCashierGroup"];
            Permissions permissions = new Permissions(Info, null);
            bool needGetPermissions = false;
            foreach (ListViewDataItem item  in PermissionsListBox.Items)
            {
                if (item.Key != null)
                {
                    if (int.TryParse(item.Key.ToString(), out Int32 itemKey))
                    {
                        item.CheckState = (int)permissions.GetPermissions(IdGroup, (SGZGlobals.Classes.Constants.Permissions)itemKey) != 0 ? Telerik.WinControls.Enumerations.ToggleState.On : Telerik.WinControls.Enumerations.ToggleState.Off;
                    }
                }
                else
                {
                    PermissionsListBox.Items.Remove(item);
                    break;
                }
            }
            if (needGetPermissions)
                GetPermissions();
        }
        private SGZGlobals.Classes.Constants.PermissionType SetCashierPermission(ListViewDataItem item)
        {
            SGZGlobals.Classes.Constants.PermissionType type = 0;
            if (item.CheckState== Telerik.WinControls.Enumerations.ToggleState.On)
                type = type | SGZGlobals.Classes.Constants.PermissionType.Enabled;
            return type;

        }
        private void SetPermissions()
        {
            int IdGroup = (int)drvDetail["IdCashierGroup"];
            Permissions permissions = new Permissions(Info, null);
            foreach (ListViewDataItem item in PermissionsListBox.Items)
            {
                if (int.TryParse(item.Key.ToString(), out Int32 itemKey))
                {
                    permissions.SetPermissions(IdGroup, (SGZGlobals.Classes.Constants.Permissions)itemKey, SetCashierPermission(item));
                }
            }
            cm.EndCurrentEdit();
        }
        #endregion

      
    }
}

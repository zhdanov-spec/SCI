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

namespace ZPSoft.GameZone.SGZAdmin.ProgramForms
{
    public partial class GroupUserForm : RadForm, IEditForm
    {
        #region Init Function
        public GroupUserForm()
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
            if (Insert)
            {
                cm.AddNew();
            }
            this.drvDetail = (DataRowView)cm.Current;
            this.vueDetail = this.drvDetail.DataView;
            if (cm.Count != 1)
            {
                this.BindingContext[this.vueDetail].Position = cm.Position;
            }
            IdGroupUser.DataBindings.Add("Text", this.vueDetail, "IdGroupUser");
            GroupUserName.DataBindings.Add("Text", this.vueDetail, "GroupUserName");
            EnabledToggleSwitch.DataBindings.Add("Value", this.vueDetail, "Enabled");

            IdBonus.DataSource = Info.Bonuses;
            IdBonus.DisplayMember = "BonusName";
            IdBonus.ValueMember = "IdBonus";
            IdBonus.DataBindings.Add("SelectedValue", vueDetail, "IdBonus");

            IdDiscount.DataSource = Info.Discount;
            IdDiscount.DisplayMember = "DiscountName";
            IdDiscount.ValueMember = "IdDiscount";
            IdDiscount.DataBindings.Add("SelectedValue", vueDetail, "IdDiscount");

            if (drvDetail["IdDiscount"] is DBNull)
            {
                IdDiscount.Enabled = UseDiscount.IsChecked = false;
            }
            else
            {
                IdDiscount.Enabled = UseDiscount.IsChecked = true;
            }
            if (drvDetail["IdBonus"] is DBNull)
            {
                IdBonus.Enabled=UseBonus.IsChecked = false;
            }
            else
            {
                IdBonus.Enabled = UseBonus.IsChecked = true;
            }
            if (Insert)
            {
                int MaxIdGroupUser = 0;
                foreach (GameZoneDataSet.GroupUserRow row in Info.GroupUser)
                    if (row.RowState != DataRowState.Deleted && row.IdGroupUser > MaxIdGroupUser) MaxIdGroupUser = row.IdGroupUser;
                this.drvDetail["IdGroupUser"] = MaxIdGroupUser + 1;
                this.drvDetail["Enabled"] = true;
            }
            if (ShowDialog() == DialogResult.OK)
            {
                cm.EndCurrentEdit();
            }
            else
                cm.CancelCurrentEdit();
            return rowInfo;
        }
        #endregion
        #region Events Function
        private void UseBonus_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if(UseBonus.IsChecked)
            {
                IdBonus.Enabled = true;
            }
            else
            {
                IdBonus.Enabled = false;
                drvDetail["IdBonus"] = DBNull.Value;
            }
        }
        private void UseDiscount_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {

            if (UseDiscount.IsChecked)
            {
                IdDiscount.Enabled = true;
            }
            else
            {
                IdDiscount.Enabled = false;
                drvDetail["IdDiscount"] = DBNull.Value;
            }
        }

        #endregion
     


    }
}

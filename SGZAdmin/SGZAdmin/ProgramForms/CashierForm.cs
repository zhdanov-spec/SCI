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
using ZPSoft.GameZone.DatabaseComponents;
using ZPSoft.GameZone.SGZAdmin.Classes;
using ZPSoft.GameZone.SGZGlobals.Classes;
using ZPSoft.GameZone.SGZGlobals.DataSets;
using static ZPSoft.GameZone.SGZAdmin.Classes.Constants;

namespace ZPSoft.GameZone.SGZAdmin.ProgramForms
{
    public partial class CashierForm : RadForm, IEditForm
    {
        public CashierForm()
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

            if (!Insert)
            {
                if ((int)drvDetail["IdCashier"] == 1 && !ServiceManager.SuperUser)
                {
                    CashierGroupList.DataSource = Info.CashierGroup;
                    ОкButton.Enabled = false;
                }
                else if ((int)drvDetail["IdCashier"] != 1 && !ServiceManager.SuperUser)
                {
                    CashierGroupList.DataSource = Info.CashierGroup.Where(group => group.IdCashierGroup != 1);
                    CashierGroupList.Enabled = true;
                }
                else if ((int)drvDetail["IdCashier"] == 1 && ServiceManager.SuperUser)
                {
                    CashierGroupList.DataSource = Info.CashierGroup;
                    CashierGroupList.Enabled = false;
                }
                else if ((int)drvDetail["IdCashier"] != 1 && ServiceManager.SuperUser)
                {
                    CashierGroupList.DataSource = Info.CashierGroup.Where(group => group.IdCashierGroup != 1);
                    CashierGroupList.Enabled = true;
                }
            }
            else
            {
                if(!ServiceManager.SuperUser)
                {
                    CashierGroupList.DataSource = Info.CashierGroup.Where(group => group.IdCashierGroup != 1);
                }
                else
                {
                    CashierGroupList.DataSource = Info.CashierGroup;
                }
            }
            IdCashier.DataBindings.Add("Text", this.vueDetail, "IdCashier");
            CashierName.DataBindings.Add("Text", this.vueDetail, "CashierName");
            CashierPassword.DataBindings.Add("Text", this.vueDetail, "CashierPassword");
            EnabledToggleSwitch.DataBindings.Add("Value", this.vueDetail, "Enabled");

            
            CashierGroupList.DisplayMember = "CashierGroupName";
            CashierGroupList.ValueMember = "IdCashierGroup";


            CashierGroupList.DataBindings.Add("SelectedValue", vueDetail, "IdCashierGroup");

            if (Insert)
            {
                int MaxIdCashier = 0;
                foreach (GameZoneDataSet.CashierRow Row in Info.Cashier)
                    if (Row.RowState != DataRowState.Deleted && Row.IdCashier > MaxIdCashier) MaxIdCashier = Row.IdCashier;
                drvDetail["IdCashier"] = MaxIdCashier + 1;
                drvDetail["SareaId"] = DataSetHolder.SareaId;
                drvDetail["Enabled"] = true;
                drvDetail["SuperUser"] = false;
            }
            
            if (ShowDialog() == DialogResult.OK)
            {
                cm.EndCurrentEdit();
            }
            else
                cm.CancelCurrentEdit();
            return rowInfo;
        }
        #region Events Function
        private void SetPasswordButton_Click(object sender, EventArgs e)
        {
            if (new SGZForms.Forms.FirstTimeUseForm().Execute(out string password))
            {
                this.drvDetail["CashierCryptPassword"]= new SGZDomain.SubClasses.OtherLogic().GetHashString(password);
            }
        }
        #endregion
    }
}

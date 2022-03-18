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
    public partial class CashDeskForm : RadForm, IEditForm
    {
        #region Init Function
        public CashDeskForm()
        {
            InitializeComponent();
        }
        private DataRowView drvDetail;
        private DataView vueDetail;
        CurrencyManager cm;
        RowInfo rowInfo = new RowInfo(Classes.Constants.Table.None, null);
        public RowInfo Execute(CurrencyManager cm, GameZoneDataSet Info, bool Insert, SGZGlobals.Classes.Constants.PermissionType permission)
        {
            Binding binding;
            this.cm = cm;
            if (Insert) cm.AddNew();
            drvDetail = (DataRowView)cm.Current;
            vueDetail = drvDetail.DataView;

            if (cm.Count != 1)
                this.BindingContext[vueDetail].Position = cm.Position;
            IdCashDesk.DataBindings.Add("Text", vueDetail, "IdCashDesk");
            CashDeskName.DataBindings.Add("Text", vueDetail, "CashDeskName");
            HeaderLine.DataBindings.Add("Text", vueDetail, "HeaderLine");
            FooterLine.DataBindings.Add("Text", vueDetail, "FooterLine");
            HeaderLineMagazin.DataBindings.Add("Text", vueDetail, "HeaderLineMagazin");
            FooterLineMagazin.DataBindings.Add("Text", vueDetail, "FooterLineMagazin");
            AuthTypeList.DataBindings.Add("SelectedIndex", vueDetail, "AuthType");
            binding = CardDeposit.DataBindings.Add("Text", vueDetail, "CardDeposit");
            binding.Format += new ConvertEventHandler(MoneyToString);
            binding.Parse += new ConvertEventHandler(StringToMoney);
            binding = Tax.DataBindings.Add("Text", vueDetail, "Tax");
            binding.Format += new ConvertEventHandler(MoneyToString);
            binding.Parse += new ConvertEventHandler(StringToMoney);
            EnabledToggleSwitch.DataBindings.Add("Value", this.vueDetail, "Enabled");
            if (Insert)
            {
                int MaxIdCashDesk = 0;
                foreach (GameZoneDataSet.CashDeskRow Row in Info.CashDesk)
                    if (Row.RowState != DataRowState.Deleted && Row.IdCashDesk > MaxIdCashDesk) MaxIdCashDesk = Row.IdCashDesk;
                drvDetail["IdCashDesk"] = MaxIdCashDesk + 1;
                drvDetail["Tax"] = 0;
                drvDetail["Enabled"] = true;
                drvDetail["CardDeposit"] = 0;
                drvDetail["AuthType"] = (int)SGZGlobals.Classes.Constants.AuthType.ByPassword;
                drvDetail["SareaId"] = DataSetHolder.SareaId;

            }
            if (ShowDialog() == DialogResult.OK)
            {
                drvDetail["AuthType"] = AuthTypeList.SelectedIndex;
                cm.EndCurrentEdit();
            }
            else
                cm.CancelCurrentEdit();
            
            return rowInfo;
        }
        #endregion
        #region Events Functions
        private void MoneyToString(object sender, ConvertEventArgs cevent)
        {
            if (cevent.Value is System.DBNull) return;
            cevent.Value = (new Money((int)cevent.Value)).ToString();// + Constants.CurrencyName;
        }
        private void StringToMoney(object sender, ConvertEventArgs cevent)
        {
            cevent.Value = (new Money(float.Parse((string)cevent.Value))).Amount;
            
        }
        #endregion

        private void CashDeskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                drvDetail = (DataRowView)cm.Current;
                for (int Pos = 0; Pos < drvDetail.Row.ItemArray.Length; Pos++)
                {
                    if (drvDetail.Row.ItemArray[Pos] is System.DBNull && !drvDetail.Row.Table.Columns[Pos].AllowDBNull)
                    {
                        new SGZForms.Forms.MessageForm().Execute("Помилка", "Не всі поля введені");
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
    }
}

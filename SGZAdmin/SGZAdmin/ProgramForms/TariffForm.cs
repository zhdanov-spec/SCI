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
    public partial class TariffForm : RadForm, IEditForm
    {
        #region Init Function
        public TariffForm()
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
            Binding binding;
            drvDetail = (DataRowView)cm.Current;
            vueDetail = drvDetail.DataView;
            if (cm.Count != 1)
                this.BindingContext[vueDetail].Position = cm.Position;
            IdTariff.DataBindings.Add("Text", vueDetail, "IdTariff");
            TariffName.DataBindings.Add("Text", vueDetail, "TariffName");

            binding = DefaultPrice.DataBindings.Add("Text", vueDetail, "DefaultPrice");
            binding.Format += new ConvertEventHandler(MoneyToString);
            binding.Parse += new ConvertEventHandler(StringToMoney);

            if (!Insert)
                TariffScaleGrid.DataSource = GetTariffScale();

            if (Insert)
            {
                int MaxIdTariff = 0;
                foreach (GameZoneDataSet.TariffRow Row in Info.Tariff)
                    if (Row.RowState != DataRowState.Deleted && Row.IdTariff > MaxIdTariff) MaxIdTariff = Row.IdTariff;
                drvDetail["IdTariff"] = MaxIdTariff + 1;
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
        #region Logic Function
        private void MoneyToString(object sender, ConvertEventArgs cevent)
        {
            if (cevent.Value is System.DBNull) return;
            cevent.Value = (new Money((int)cevent.Value)).ToString();
        }
        private void StringToMoney(object sender, ConvertEventArgs cevent)
        {
            cevent.Value = (new Money(float.Parse((string)cevent.Value))).Amount;

        }
        private object GetTariffScale()
        {


            var results = from tariffScaleTable in Info.TariffScale.AsEnumerable()
                          join tariffTable in Info.Tariff.AsEnumerable() on (int)tariffScaleTable["IdTariff"] equals (int)tariffTable["IdTariff"]
                          join pariodsTable in Info.Periods.AsEnumerable() on (int)tariffScaleTable["IdPeriod"] equals (int)pariodsTable["IdPeriod"]
                          where tariffScaleTable.IdTariff == (int)drvDetail["IdTariff"]
                          select new
                          {

                              PeriodName = (string)pariodsTable["PeriodName"],
                              IdTariffScale = (int)tariffScaleTable["IdTariffScale"],
                              Price = (int)tariffScaleTable["Price"],
                              DaysOfWeek = (string)SGZDomain.TariffScale.DaysOfWeekToString((SGZGlobals.Classes.Constants.DaysOfWeekType)tariffScaleTable["DaysOfWeek"]),
                              delete = "Видалити"
                          };
            return results;
        }
        #endregion

        #region Events Function
        private void AddTariffScale_Click(object sender, EventArgs e)
        {

            CurrencyManager currencyManager = (CurrencyManager)BindingContext[new DataView(Info.TariffScale, string.Format("IdTariff={0}", drvDetail["IdTariff"]), "", DataViewRowState.CurrentRows)];
            TariffScaleForm tariffScaleForm = new TariffScaleForm();
            
            Visible = false;
            tariffScaleForm.Execute(currencyManager, Info, true, (int)drvDetail["IdTariff"]);
            tariffScaleForm.Close();
            Visible = true;
            TariffScaleGrid.DataSource = GetTariffScale();
        }
        private void TariffScaleGrid_DoubleClick(object sender, EventArgs e)
        {
            if (TariffScaleGrid.CurrentRow == null) return;

            CurrencyManager currencyManager = (CurrencyManager)BindingContext[new DataView(Info.TariffScale, string.Format("IdTariff={0}", drvDetail["IdTariff"]), "", DataViewRowState.CurrentRows)];
            TariffScaleForm tariffScaleForm = new TariffScaleForm();
            Visible = false;
            tariffScaleForm.Execute(currencyManager, Info, false, (int)drvDetail["IdTariff"]);
            tariffScaleForm.Close();
            Visible = true;
            TariffScaleGrid.DataSource = GetTariffScale();
        }
        private void TariffScaleGrid_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            Int32 IdTariffScale = Convert.ToInt32(TariffScaleGrid.CurrentRow.Cells["IdTariffScale"].Value);
            GameZoneDataSet.TariffScaleRow Row = GlobalVariable.AdminData.TariffScale.FindByIdTariffIdTariffScale((int)drvDetail["IdTariff"], IdTariffScale);
            Row.Delete();
            cm.EndCurrentEdit();
            GlobalVariable.SaveData();
            TariffScaleGrid.DataSource = GetTariffScale();
        }
        #endregion


    }
}

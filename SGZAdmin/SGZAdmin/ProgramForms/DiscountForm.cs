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
    public partial class DiscountForm : RadForm, IEditForm
    {
        #region Init function
        public DiscountForm()
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

            IdDiscount.DataBindings.Add("Text", vueDetail, "IdDiscount");
            DiscountName.DataBindings.Add("Text", vueDetail, "DiscountName");
            EnabledToggleSwitch.DataBindings.Add("Value", vueDetail, "OnlyCash");
            if (!Insert)
                DiscountScaleGrid.DataSource = GetDiscountScale();
            if (Insert)
            {
                int MaxIdDiscount = 0;
                foreach (GameZoneDataSet.DiscountRow Row in Info.Discount)
                    if (Row.RowState != DataRowState.Deleted && Row.IdDiscount > MaxIdDiscount) MaxIdDiscount = Row.IdDiscount;
                drvDetail["IdDiscount"] = MaxIdDiscount + 1;
                drvDetail["OnlyCash"] = false;
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
        private object GetDiscountScale()
        {
            var results = from discountscaleTable in Info.DiscountScale.AsEnumerable()
                          join discountTable in Info.Discount.AsEnumerable() on (int)discountscaleTable["IdDiscount"] equals (int)discountTable["IdDiscount"]
                          where discountscaleTable.IdDiscount == (int)drvDetail["IdDiscount"]
                          select new
                          {

                              DiscountDescription = (string)discountscaleTable["DiscountDescription"],
                              IdDiscountScale = (int)discountscaleTable["IdDiscountScale"],
                              SumCount = (int)discountscaleTable["SumCount"],
                              DiscountPercent = (int)discountscaleTable["DiscountPercent"],
                              delete = "Видалити"
                          };
            return results;
        }
        #endregion
        #region Events Function
        private void AddScale_Click(object sender, EventArgs e)
        {
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[new DataView(Info.DiscountScale, string.Format("IdDiscount={0}", drvDetail["IdDiscount"]), "", DataViewRowState.CurrentRows)];

            DiscountScaleForm discountScaleForm = new DiscountScaleForm();
            Visible = false;
            discountScaleForm.Execute(currencyManager, Info,true, (int)drvDetail["IdDiscount"]);
            discountScaleForm.Close();
            Visible = true;
            DiscountScaleGrid.DataSource = GetDiscountScale();
        }
        private void DiscountScaleGrid_DoubleClick(object sender, EventArgs e)
        {
            if (DiscountScaleGrid.CurrentRow == null) return;
            Int32 IdDiscountScale = Convert.ToInt32(DiscountScaleGrid.CurrentRow.Cells["IdDiscountScale"].Value);
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[new DataView(Info.DiscountScale, string.Format("IdDiscountScale={0}", IdDiscountScale), "", DataViewRowState.CurrentRows)];
            DiscountScaleForm discountScaleForm = new DiscountScaleForm();
            Visible = false;
            discountScaleForm.Execute(currencyManager, Info, false, (int)drvDetail["IdDiscount"]);
            discountScaleForm.Close();
            Visible = true;
            DiscountScaleGrid.DataSource = GetDiscountScale();
        }

        #endregion

        private void DiscountScaleGrid_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            Int32 IdDiscountScale = Convert.ToInt32(DiscountScaleGrid.CurrentRow.Cells["IdDiscountScale"].Value);
            GameZoneDataSet.DiscountScaleRow Row = GlobalVariable.AdminData.DiscountScale.FindByIdDiscountIdDiscountScale((int)drvDetail["IdDiscount"], IdDiscountScale);
            Row.Delete();
            cm.EndCurrentEdit();
            GlobalVariable.SaveData();
            DiscountScaleGrid.DataSource = GetDiscountScale();
        }
    }
}

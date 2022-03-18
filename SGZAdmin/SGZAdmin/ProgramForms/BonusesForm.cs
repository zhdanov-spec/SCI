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
    public partial class BonusesForm : RadForm, IEditForm
    {
        #region Init function
        public BonusesForm()
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

            IdBonus.DataBindings.Add("Text", vueDetail, "IdBonus");
            BonusName.DataBindings.Add("Text", vueDetail, "BonusName");
            if (!Insert)
                BonusScaleGrid.DataSource = GetBonusesScale();
            if (Insert)
            {
                int MaxIdBonus = 0;
                foreach (GameZoneDataSet.BonusesRow Row in Info.Bonuses)
                    if (Row.RowState != DataRowState.Deleted && Row.IdBonus > MaxIdBonus) MaxIdBonus = Row.IdBonus;
                drvDetail["IdBonus"] = MaxIdBonus + 1;
             
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
        private object GetBonusesScale()
        {
            var results = from bonusScaleTable in Info.BonusScale.AsEnumerable()
                          join bonusTable in Info.Bonuses.AsEnumerable() on (int)bonusScaleTable["IdBonus"] equals (int)bonusTable["IdBonus"]
                          where bonusScaleTable.IdBonus== (int)drvDetail["IdBonus"]
                          select new
                          {
                              IdBonusScale=(int)bonusScaleTable["IdBonusScale"],
                              Payment = (int)bonusScaleTable["Payment"],
                              SumBonus = (int)bonusScaleTable["SumBonus"],
                              delete = "Видалити"
                          };
            return results;
        }
        #endregion
        #region Events Function
        private void AddScale_Click(object sender, EventArgs e)
        {

            CurrencyManager currencyManager = (CurrencyManager)BindingContext[new DataView(Info.BonusScale, string.Format("IdBonus={0}", drvDetail["IdBonus"]), "", DataViewRowState.CurrentRows)];
            BonusScaleForm bonusScaleForm= new BonusScaleForm();
            Visible = false;
            bonusScaleForm.Execute(currencyManager, Info, true, (int)drvDetail["IdBonus"]);
            bonusScaleForm.Close();
            Visible = true;
            BonusScaleGrid.DataSource = GetBonusesScale();
        }
        private void BonusScaleGrid_DoubleClick(object sender, EventArgs e)
        {
            if (BonusScaleGrid.CurrentRow == null) return;
            Int32 IdBonusScale = Convert.ToInt32(BonusScaleGrid.CurrentRow.Cells["IdBonusScale"].Value);
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[new DataView(Info.BonusScale, string.Format("IdBonusScale={0}", IdBonusScale), "", DataViewRowState.CurrentRows)];
            BonusScaleForm bonusScaleForm = new BonusScaleForm();
            Visible = false;
            bonusScaleForm.Execute(currencyManager, Info, false, (int)drvDetail["IdBonus"]);
            bonusScaleForm.Close();
            Visible = true;
            BonusScaleGrid.DataSource = GetBonusesScale();
        }

        #endregion

        private void BonusScaleGrid_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            Int32 IdBonusScale = Convert.ToInt32(BonusScaleGrid.CurrentRow.Cells["IdBonusScale"].Value);
            GameZoneDataSet.BonusScaleRow Row = GlobalVariable.AdminData.BonusScale.FindByIdBonusIdBonusScale((int)drvDetail["IdBonus"], IdBonusScale);
            Row.Delete();
            cm.EndCurrentEdit();
            GlobalVariable.SaveData();
            BonusScaleGrid.DataSource = GetBonusesScale();
        }
    }
}

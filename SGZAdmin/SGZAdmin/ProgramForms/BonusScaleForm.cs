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

namespace ZPSoft.GameZone.SGZAdmin.ProgramForms
{
    public partial class BonusScaleForm : RadForm
    {
        #region Init Function
        public BonusScaleForm()
        {
            InitializeComponent();
        }
        CurrencyManager cm;
        private DataRowView drvDetail;
        private DataView vueDetail;
        public void Execute(CurrencyManager cm, GameZoneDataSet Info, bool Insert, Int32 IdBonus)
        {
            if (Insert) cm.AddNew();
            drvDetail = (DataRowView)cm.Current;
            vueDetail = drvDetail.DataView;
            this.cm = cm;
            if (cm.Count != 1)
                this.BindingContext[vueDetail].Position = cm.Position;

            Binding binding;

            binding = Payment.DataBindings.Add("Text", vueDetail, "Payment");
            binding.Format += new ConvertEventHandler(MoneyToString);
            binding.Parse += new ConvertEventHandler(StringToMoney);

            binding = SumBonus.DataBindings.Add("Text", vueDetail, "SumBonus");
            binding.Format += new ConvertEventHandler(MoneyToString);
            binding.Parse += new ConvertEventHandler(StringToMoney);

            if (Insert)
            {
                int MaxIdBonusScale = 0;
                foreach (GameZoneDataSet.BonusScaleRow Row in Info.BonusScale)
                    if (Row.RowState != DataRowState.Deleted && Row.IdBonusScale > MaxIdBonusScale) MaxIdBonusScale = Row.IdBonusScale;
                drvDetail["IdBonusScale"] = MaxIdBonusScale + 1;
                drvDetail["IdBonus"] = IdBonus;

            }

            if (ShowDialog() == DialogResult.OK)
            {
                cm.EndCurrentEdit();
            }
            else
            {
                cm.CancelCurrentEdit();
            };
        }
        #endregion
        #region Events Function
        private void MoneyToString(object sender, ConvertEventArgs cevent)
        {
            if (cevent.Value is System.DBNull) return;
            cevent.Value = (new Money((int)cevent.Value)).ToString();
        }
        private void StringToMoney(object sender, ConvertEventArgs cevent)
        {
            cevent.Value = (new Money(float.Parse((string)cevent.Value))).Amount;
        }
        private void BonusScaleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                try
                {
                    drvDetail = (DataRowView)cm.Current;
                    for (int Pos = 0; Pos < drvDetail.Row.ItemArray.Length; Pos++)
                    {
                        if (drvDetail.Row.ItemArray[Pos] is System.DBNull && !drvDetail.Row.Table.Columns[Pos].AllowDBNull)
                        {
                            new SGZForms.Forms.MessageForm().Execute("Помилка!", "Введені не всі поля");

                            e.Cancel = true;
                            return;
                        }
                    }


                    cm.EndCurrentEdit();
                    GlobalVariable.SaveData();
                    e.Cancel = false;

                }
                catch (NullReferenceException)
                {
                    e.Cancel = false;
                }
            }
        }
        #endregion


    }
}

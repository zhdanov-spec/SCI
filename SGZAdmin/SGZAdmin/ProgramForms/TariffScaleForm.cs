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
    public partial class TariffScaleForm : RadForm
    {
        #region Init Functions
        public TariffScaleForm()
        {
            InitializeComponent();
        }
        CurrencyManager cm;
        private DataRowView drvDetail;
        private DataView vueDetail;
        SGZGlobals.Classes.Constants.DaysOfWeekType days;
        public void Execute(CurrencyManager cm, GameZoneDataSet Info,bool Insert,Int32 idTariff)
        {
            if (Insert) cm.AddNew();

            drvDetail = (DataRowView)cm.Current;
            vueDetail = drvDetail.DataView;
            this.cm = cm;
            if (cm.Count != 1)
                this.BindingContext[vueDetail].Position = cm.Position;

            Binding binding;
            binding = Price.DataBindings.Add("Text", vueDetail, "Price");
            binding.Format += new ConvertEventHandler(MoneyToString);
            binding.Parse += new ConvertEventHandler(StringToMoney);

            PeriodsDownList.DataSource = Info.Periods;
            PeriodsDownList.DisplayMember = "PeriodName";
            PeriodsDownList.ValueMember = "IdPeriod";
            PeriodsDownList.DataBindings.Add("SelectedValue", vueDetail, "IdPeriod");
            GameCount.DataBindings.Add("Text", vueDetail, "GameCount");
            EnabledToggleSwitch.DataBindings.Add("Value", vueDetail, "Holiday");

            if (Insert)
            {
                int MaxIdTariffScale = 0;
                foreach (GameZoneDataSet.TariffScaleRow Row in Info.TariffScale)
                    if (Row.RowState != DataRowState.Deleted && Row.IdTariffScale > MaxIdTariffScale) MaxIdTariffScale = Row.IdTariffScale;
                drvDetail["IdTariffScale"] = MaxIdTariffScale + 1;
                drvDetail["IdTariff"] = idTariff;
                drvDetail["GameCount"] = 0;
                drvDetail["Holiday"] = false;

            }
            if (!Insert)
            {
                days = (SGZGlobals.Classes.Constants.DaysOfWeekType)((GameZoneDataSet.TariffScaleRow)drvDetail.Row).DaysOfWeek;
                DaysOfWeek.Text = SGZDomain.TariffScale.DaysOfWeekToString(days);
            }
            if (ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (!CheckTariff())
                        cm.CancelCurrentEdit();
                  
                }

                catch (NullReferenceException)
                {
                    new SGZForms.Forms.MessageForm().Execute("Увага!", "Ця тарифна сітка вже існує");
                    cm.CancelCurrentEdit();
                }
                catch (System.Data.ConstraintException)
                {
                    new SGZForms.Forms.MessageForm().Execute("Увага!", "Ця тарифна сітка вже існує");
                    cm.CancelCurrentEdit();
                }
            }
            else
            {
                cm.CancelCurrentEdit();
            };
        }
        #endregion
        #region Events Function
        private void TariffScaleForm_FormClosing(object sender, FormClosingEventArgs e)
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
                            new SGZForms.Forms.MessageForm().Execute("Помилка!","Введені не всі поля");
                            
                            e.Cancel = true;
                            return;
                        }
                    }
                    
                    if (CheckTariff())
                    {
                        cm.EndCurrentEdit();
                        GlobalVariable.SaveData();
                        e.Cancel = false;
                    }
                    else
                    {
                        cm.CancelCurrentEdit();
                        e.Cancel = true;
                    }
                }
                catch(NullReferenceException)
                {
                    e.Cancel = false;
                }
            }
        }
        private void MoneyToString(object sender, ConvertEventArgs cevent)
        {
            if (cevent.Value is System.DBNull) return;
            cevent.Value = (new Money((int)cevent.Value)).ToString();
        }
        private void StringToMoney(object sender, ConvertEventArgs cevent)
        {
            cevent.Value = (new Money(float.Parse((string)cevent.Value))).Amount;
        }
        private void DaysOfWeekButton_Click(object sender, EventArgs e)
        {
            DaysOfWeekForm daysOfWeekForm = new DaysOfWeekForm();
            days = daysOfWeekForm.Execute(days);
            DaysOfWeek.Text = SGZDomain.TariffScale.DaysOfWeekToString(days);
            drvDetail["DaysOfWeek"] = (int)days;
            daysOfWeekForm.Close();
        }

        #endregion

        #region Logic Function
        private bool CheckTariff()
        {
            try
            {
                SGZDomain.TariffScale tariff = new SGZDomain.TariffScale(GlobalVariable.AdminData, null);
                tariff.CheckTariff(((GameZoneDataSet.TariffScaleRow)drvDetail.Row).IdTariff);
            }
            catch (SGZGlobals.Classes.Exceptions.TableModule.GeneralException ex)
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка!", ex.Message);
                return false;
            }
            return true;
        }
        #endregion


    }
}

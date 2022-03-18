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
    public partial class GlobalsForm : RadForm, IEditForm
    {
        #region Init function
        public GlobalsForm()
        {
            InitializeComponent();
        }
        private DataRowView drvDetail;
        private DataView vueDetail;
        RowInfo rowInfo = new RowInfo(Classes.Constants.Table.None, null);
        public RowInfo Execute(CurrencyManager cm, GameZoneDataSet Info, bool Insert, SGZGlobals.Classes.Constants.PermissionType permission)
        {
            if (Insert)
            {
                new SGZForms.Forms.MessageForm().Execute("Увага!", "Додавання глобальних параметрів неможливе");
                cm.CancelCurrentEdit();
                return rowInfo;

            }
            this.drvDetail = (DataRowView)cm.Current;
            this.vueDetail = this.drvDetail.DataView;
            if(drvDetail["GlobalsKey"].ToString()== "DEFAULTUSER" || drvDetail["GlobalsKey"].ToString() == "SAREAID")
            {
                new SGZForms.Forms.MessageForm().Execute("Увага!", "Корегування цього глобального параметра неможливе");
                cm.CancelCurrentEdit();
                return rowInfo;
            }
            if (cm.Count != 1)
            {
                this.BindingContext[this.vueDetail].Position = cm.Position;
            }
            GlobalsValue.DataBindings.Add("Text", this.vueDetail, "GlobalsValue");
            Description.DataBindings.Add("Text", this.vueDetail, "Description");
            if (ShowDialog() == DialogResult.OK)
            {
                cm.EndCurrentEdit();
            }
            else
                cm.CancelCurrentEdit();
            return rowInfo;
        }
        #endregion
    }
}

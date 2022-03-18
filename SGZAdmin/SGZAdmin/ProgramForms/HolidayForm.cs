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
using ZPSoft.GameZone.SGZGlobals.DataSets;
using static ZPSoft.GameZone.SGZAdmin.Classes.Constants;

namespace ZPSoft.GameZone.SGZAdmin.ProgramForms
{
    public partial class HolidayForm : RadForm, IEditForm
    {
        #region Init Function
        public HolidayForm()
        {
            InitializeComponent();
        }
        private DataRowView drvDetail;
        private DataView vueDetail;
     
        RowInfo rowInfo = new RowInfo(Constants.Table.None, null);
        public RowInfo Execute(CurrencyManager cm, GameZoneDataSet Info, bool Insert, SGZGlobals.Classes.Constants.PermissionType permission)
        {
            monthCalendar.SelectionStart = DateTime.Now;
            monthCalendar.SelectionEnd = DateTime.Now;
            monthCalendar.MinDate = DateTime.Now;
            if (Insert)
            {
                cm.AddNew();
            }
            if (cm.Count != 1)
                BindingContext[vueDetail].Position = cm.Position;
            drvDetail = (DataRowView)cm.Current;
            vueDetail = drvDetail.DataView;
            
            
            if (ShowDialog() == DialogResult.OK)
            {
                if (!Insert)
                {
                    drvDetail["HolidayDate"] = monthCalendar.SelectionStart;
                }
                else
                {
                    drvDetail["HolidayDate"] = monthCalendar.SelectionStart;
                    drvDetail["Visible"] = true;
                }
                cm.EndCurrentEdit();
            }
            else
                cm.CancelCurrentEdit();
            return rowInfo;
        }
        #endregion
    }
}

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

namespace ZPSoft.GameZone.SGZAdmin.ProgramForms
{
    public partial class DaysOfWeekForm : RadForm
    {
        #region Init Function
        public DaysOfWeekForm()
        {
            InitializeComponent();
        }
        public SGZGlobals.Classes.Constants.DaysOfWeekType Execute(SGZGlobals.Classes.Constants.DaysOfWeekType days)
        {

            Sunday.IsChecked = (days & SGZGlobals.Classes.Constants.DaysOfWeekType.Sunday) != 0;
            Monday.IsChecked = (days & SGZGlobals.Classes.Constants.DaysOfWeekType.Monday) != 0;
            Tuesday.IsChecked = (days & SGZGlobals.Classes.Constants.DaysOfWeekType.Tuesday) != 0;
            Wednesday.IsChecked = (days & SGZGlobals.Classes.Constants.DaysOfWeekType.Wednesday) != 0;
            Thursday.IsChecked = (days & SGZGlobals.Classes.Constants.DaysOfWeekType.Thursday) != 0;
            Friday.IsChecked = (days & SGZGlobals.Classes.Constants.DaysOfWeekType.Friday) != 0;
            Saturday.IsChecked = (days & SGZGlobals.Classes.Constants.DaysOfWeekType.Saturday) != 0;

            days = days | SGZGlobals.Classes.Constants.DaysOfWeekType.Sunday;
            if (ShowDialog() == DialogResult.OK)
            {
                days = 0;

                if (Sunday.IsChecked) days = days | SGZGlobals.Classes.Constants.DaysOfWeekType.Sunday;
                if (Monday.IsChecked) days = days | SGZGlobals.Classes.Constants.DaysOfWeekType.Monday;
                if (Tuesday.IsChecked) days = days | SGZGlobals.Classes.Constants.DaysOfWeekType.Tuesday;
                if (Wednesday.IsChecked) days = days | SGZGlobals.Classes.Constants.DaysOfWeekType.Wednesday;
                if (Thursday.IsChecked) days = days | SGZGlobals.Classes.Constants.DaysOfWeekType.Thursday;
                if (Friday.IsChecked) days = days | SGZGlobals.Classes.Constants.DaysOfWeekType.Friday;
                if (Saturday.IsChecked) days = days | SGZGlobals.Classes.Constants.DaysOfWeekType.Saturday;
            }

            return days;
        }
        #endregion
    }
}

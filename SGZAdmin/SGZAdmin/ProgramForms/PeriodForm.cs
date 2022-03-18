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
    public partial class PeriodForm : RadForm, IEditForm
    {
        #region Init Function
        public PeriodForm()
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

            IdPeriod.DataBindings.Add("Text", vueDetail, "IdPeriod");
            PeriodName.DataBindings.Add("Text", vueDetail, "PeriodName");

            if(Insert)
            {
                Int32 MaxIdPeriod = 0;
                foreach(GameZoneDataSet.PeriodsRow row in Info.Periods)
                    if (row.RowState != DataRowState.Deleted && row.IdPeriod > MaxIdPeriod)
                        MaxIdPeriod = row.IdPeriod;
                drvDetail["IdPeriod"] = MaxIdPeriod + 1;
            }
            GetPeriod();
            if (this.ShowDialog() == DialogResult.OK)
            {
                SetPeriod();
                cm.EndCurrentEdit();
            }
            else
                cm.CancelCurrentEdit();
            return rowInfo;
        }
        #endregion
        #region Logic Function
        private void GetPeriod()
        {
            if ((drvDetail["TimeBegin"] is DBNull) || (drvDetail["TimeEnd"] is DBNull))
            {
                drvDetail["TimeBegin"] = new DateTime(2000, 1, 1);
                drvDetail["TimeEnd"] = new DateTime(2000, 1, 1);
            }
            DateTime BeginPeriod = (DateTime)drvDetail["TimeBegin"];
            DateTime EndPeriod = (DateTime)drvDetail["TimeEnd"];
            BeginPeriodHours.Value = BeginPeriod.Hour;
            BeginPeriodMinutes.Value = BeginPeriod.Minute;
            EndPeriodHours.Value = EndPeriod.Hour;
            EndPeriodMinutes.Value = EndPeriod.Minute;
        }
        private void SetPeriod()
        {
            DateTime BeginPeriod = (DateTime)drvDetail["TimeBegin"];
            DateTime EndPeriod = (DateTime)drvDetail["TimeEnd"];
            drvDetail["TimeBegin"] = new DateTime(BeginPeriod.Year, BeginPeriod.Month, BeginPeriod.Day, (int)BeginPeriodHours.Value, (int)BeginPeriodMinutes.Value, 0, 0);
            drvDetail["TimeEnd"] = new DateTime(EndPeriod.Year, EndPeriod.Month, EndPeriod.Day, (int)EndPeriodHours.Value, (int)EndPeriodMinutes.Value, 0, 0);
        }
        #endregion
    }
}

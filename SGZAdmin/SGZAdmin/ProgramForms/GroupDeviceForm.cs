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
    public partial class GroupDeviceForm : RadForm, IEditForm
    {
        #region Init Function
        public GroupDeviceForm()
        {
            InitializeComponent();
        }
        private DataRowView drvDetail;
        private DataView vueDetail;
        private CurrencyManager cm;
        private GameZoneDataSet Info;
        RowInfo rowInfo = new RowInfo(Constants.Table.None, null);
        public RowInfo Execute(CurrencyManager cm, GameZoneDataSet Info, bool Insert, SGZGlobals.Classes.Constants.PermissionType permission)
        {
            this.cm = cm;
            this.Info = Info;
            if (Insert) cm.AddNew();
            drvDetail = (DataRowView)cm.Current;
            vueDetail = drvDetail.DataView;
            if (cm.Count != 1)
                BindingContext[vueDetail].Position = cm.Position;

            IdGroupDevice.DataBindings.Add("Text", vueDetail, "IdGroupDevice");
            GroupDeviceName.DataBindings.Add("Text", vueDetail, "GroupDeviceName");
            if(Insert)
            {
                Int32 maxIdGroupDevice = 0;
                foreach (GameZoneDataSet.GroupDeviceRow row in Info.GroupDevice)
                    if (row.RowState != DataRowState.Deleted && row.IdGroupDevice > maxIdGroupDevice)
                        maxIdGroupDevice = row.IdGroupDevice;
                drvDetail["Visible"] = true;
                drvDetail["IdGroupDevice"] = maxIdGroupDevice + 1;
                drvDetail["SareaId"] = DataSetHolder.SareaId;
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
    }
}

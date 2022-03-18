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

namespace ZPSoft.GameZone.SGZAdmin.ProgramForms
{
    public partial class NodePointDeviceForm : RadForm
    {
        #region Init Function
        public NodePointDeviceForm()
        {
            InitializeComponent();
        }
        private DataRowView drvDetail;
        private DataView vueDetail;
        CurrencyManager cm;
        GameZoneDataSet Info;
        Int32 IdNodePoint;
        public void Execute(CurrencyManager cm, GameZoneDataSet Info, int IdNodePoint)
        {
            this.IdNodePoint = IdNodePoint;
            this.cm = cm;
            this.Info = Info;
            DeviceGridView.DataSource = Info.Devices;

            cm.AddNew();
            drvDetail = (DataRowView)cm.Current;
            vueDetail = drvDetail.DataView;
            

            if (cm.Count != 1)
                this.BindingContext[vueDetail].Position = cm.Position;

            if (this.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cm.EndCurrentEdit();
                    GlobalVariable.SaveData();
                }
                catch (System.Data.ConstraintException)
                {
                    new SGZForms.Forms.MessageForm().Execute("Увага!", "Цей пристрій вже додано на станцію");
                    cm.CancelCurrentEdit();
                }
            }
            else
                cm.CancelCurrentEdit();
        }
        #endregion

        #region Events Function
        private void DeviceGridView_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            drvDetail["IdNodePoint"] = IdNodePoint;
            drvDetail["SareaId"] = DataSetHolder.SareaId;
            drvDetail["COMPort"] = DeviceGridView.CurrentRow.Cells["IdDevice"].Value;
            drvDetail["IdDevice"] = DeviceGridView.CurrentRow.Cells["IdDevice"].Value;
            
            this.DialogResult = DialogResult.OK;

        }
        #endregion
    }
}

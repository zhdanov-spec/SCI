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
using ZPSoft.GameZone.SGZGlobals.Classes;
using ZPSoft.GameZone.SGZGlobals.DataSets;
using static ZPSoft.GameZone.SGZAdmin.Classes.Constants;

namespace ZPSoft.GameZone.SGZAdmin.ProgramForms
{
    public partial class DeviceForm : RadForm, IEditForm
    {
        #region Init Function
        public DeviceForm()
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
            if (Insert)
            {
                cm.AddNew();
            }
            this.drvDetail = (DataRowView)cm.Current;
            this.vueDetail = this.drvDetail.DataView;
            if (cm.Count != 1)
            {
                this.BindingContext[this.vueDetail].Position = cm.Position;
            }
            DeviceTypeLabelSet();
            IdDevice.DataBindings.Add("Text", this.vueDetail, "IdDevice");
            DeviceName.DataBindings.Add("Text", this.vueDetail, "DeviceName");
            Alias.DataBindings.Add("Text", this.vueDetail, "Alias");

            DeviceGroupDownList.DataSource = Info.GroupDevice;
            DeviceGroupDownList.DisplayMember = "GroupDeviceName";
            DeviceGroupDownList.ValueMember = "IdGroupDevice";
            DeviceGroupDownList.DataBindings.Add("SelectedValue", vueDetail, "IdGroupDevice");

            TariffDownList.DataSource = Info.Tariff;
            TariffDownList.DisplayMember = "TariffName";
            TariffDownList.ValueMember = "IdTariff";
            TariffDownList.DataBindings.Add("SelectedValue", vueDetail, "IdTariff");


         
            EnabledToggleSwitch.DataBindings.Add("Value", this.vueDetail, "Enabled");
            if (Insert)
            {
                int MaxIdDevice = 0;
                foreach (GameZoneDataSet.DevicesRow row in Info.Devices)
                    if (row.RowState != DataRowState.Deleted && row.IdDevice > MaxIdDevice) MaxIdDevice = row.IdDevice;
                this.drvDetail["IdDevice"] = MaxIdDevice + 1;
            }
            if (Insert)
            {
                this.drvDetail["Visible"] = true;
                this.drvDetail["Enabled"] = true;
                this.drvDetail["SareaId"] = DataSetHolder.SareaId;
                this.drvDetail["GameTime"] = 0;
                this.drvDetail["TimeDTR"] =100;
                this.drvDetail["IpAddress"] = "127.0.0.1";
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
        #region Events Function
        private void DeviceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (base.DialogResult == DialogResult.OK)
            {
                this.drvDetail = (DataRowView)this.cm.Current;
                int Pos = 0;
                while (Pos < (int)this.drvDetail.Row.ItemArray.Length)
                {
                    if ((!(this.drvDetail.Row.ItemArray[Pos] is DBNull) ? true : this.drvDetail.Row.Table.Columns[Pos].AllowDBNull))
                    {
                        Pos++;
                    }
                    else
                    {
                        new SGZForms.Forms.MessageForm().Execute("Помилка!", string.Format("Не усі поля заповнені ", Environment.NewLine));
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }
        private void SelectDeviceTypeButton_Click(object sender, EventArgs e)
        {
            DeviceTypeForm deviceTypeForm = new DeviceTypeForm();
            drvDetail=deviceTypeForm.Execute(cm, vueDetail);
            DeviceTypeLabelSet();
        }
        #endregion
        #region Logic Function
        private void DeviceTypeLabelSet()
        {
            if (drvDetail["DeviceType"] == DBNull.Value)
            {
                deviceTypeLabel.Text = "Тип Пристрою Не Встановленно";
            }
            else if ((SGZGlobals.Classes.Constants.DeviceType)drvDetail["DeviceType"] == SGZGlobals.Classes.Constants.DeviceType.RemotingDeivice)
            {
                deviceTypeLabel.Text = "Тип Пристрою - Віддалений пристрій";
            }
            else if ((SGZGlobals.Classes.Constants.DeviceType)drvDetail["DeviceType"] == SGZGlobals.Classes.Constants.DeviceType.Attraction)
            {
                deviceTypeLabel.Text = "Тип Пристрою - Атракціон";
            }
            else if ((SGZGlobals.Classes.Constants.DeviceType)drvDetail["DeviceType"] == SGZGlobals.Classes.Constants.DeviceType.Service)
            {
                deviceTypeLabel.Text = "Тип Пристрою - Послуга";
            }
            #endregion

        }
    }
}

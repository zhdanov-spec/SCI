using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
    public partial class NodePointForm : RadForm, IEditForm
    {
        #region Init Function
        public NodePointForm()
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
            IdNodePoint.DataBindings.Add("Text", vueDetail, "IdNodePoint");
            NodePointName.DataBindings.Add("Text", vueDetail, "NodePointName");
            EnabledToggleSwitch.DataBindings.Add("Value", this.vueDetail, "Enabled");
            
            ImagePanelNotWork.DataBindings.Add("BackgroundImage", this.vueDetail, "ImageNotWork",true,DataSourceUpdateMode.OnPropertyChanged,"");
            ImagePanelBlank.DataBindings.Add("BackgroundImage", this.vueDetail, "ImageBlank", true, DataSourceUpdateMode.OnPropertyChanged, "");
            ImagePanelGeneralBlank.DataBindings.Add("BackGroundImage", this.vueDetail, "ImageGeneralBlank", true, DataSourceUpdateMode.OnPropertyChanged, "");
            ImagePanelScreen1.DataBindings.Add("BackGroundImage", this.vueDetail, "ImageScreen1", true, DataSourceUpdateMode.OnPropertyChanged, "");
            ImagePanelScreen2.DataBindings.Add("BackGroundImage", this.vueDetail, "ImageScreen2", true, DataSourceUpdateMode.OnPropertyChanged, "");
            ImagePanelOk.DataBindings.Add("BackGroundImage", this.vueDetail, "ImageOk", true, DataSourceUpdateMode.OnPropertyChanged, "");
            ImagePanelDeny.DataBindings.Add("BackGroundImage", this.vueDetail, "ImageDeny", true, DataSourceUpdateMode.OnPropertyChanged, "");


            if (!Insert)
                NodePointDeviceGrid.DataSource = GetDevices();


            if (Insert)
            {
                int MaxIdNodePoint = 0;
                foreach (GameZoneDataSet.NodePointsRow row in Info.NodePoints)
                    if (row.RowState != DataRowState.Deleted && row.IdNodePoint> MaxIdNodePoint) MaxIdNodePoint= row.IdNodePoint;
                this.drvDetail["IdNodePoint"] = MaxIdNodePoint+ 1;
                this.drvDetail["Enabled"] = true;
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
        private void AddDevice_Click(object sender, EventArgs e)
        {
            
            CurrencyManager currencyManager = (CurrencyManager)BindingContext[new DataView(Info.NodePointDevices, string.Format("IdNodePoint={0}", drvDetail["IdNodePoint"]), "", DataViewRowState.CurrentRows)];
           
            NodePointDeviceForm Form = new NodePointDeviceForm();
            Visible = false;
            Form.Execute(currencyManager, Info, (int)drvDetail["IdNodePoint"]);
            Form.Close();
            Visible = true;
            NodePointDeviceGrid.DataSource = GetDevices();
        }
        private void NodePointDeviceGrid_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            Int32 idDevice = Convert.ToInt32(NodePointDeviceGrid.CurrentRow.Cells["IdDevice"].Value);
            GameZoneDataSet.NodePointDevicesRow Row = GlobalVariable.AdminData.NodePointDevices.FindByCOMPortIdDeviceIdNodePoint(idDevice, idDevice, (int)drvDetail["IdNodePoint"]);
            Row.Delete();
            cm.EndCurrentEdit();
            GlobalVariable.SaveData();
            NodePointDeviceGrid.DataSource = GetDevices();


        }
      
        private void AddImageButton_Click(object sender, EventArgs e)
        {
            RadOpenFileDialog radOpenFileDialog = new RadOpenFileDialog();
            radOpenFileDialog.InitialDirectory = radOpenFileDialog.FileName;
            radOpenFileDialog.MultiSelect = false;
            radOpenFileDialog.Filter = "(*.bmp)|*.bmp";

            if (radOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = radOpenFileDialog.FileName;
                switch ((sender as RadButton).Name)
                {
                    case "ImageButtonNotWork":
                        ImagePanelNotWork.BackgroundImage = Image.FromFile(fileName);
                        drvDetail["ImageNotWork"] = ImageToByteArray(Image.FromFile(fileName));
                        break;
                    case "ImageButtonBlank":
                        ImagePanelBlank.BackgroundImage = Image.FromFile(fileName);
                        drvDetail["ImageBlank"] = ImageToByteArray(Image.FromFile(fileName));
                        break;
                    case "ImageButtonGeneralBlank":
                        ImagePanelGeneralBlank.BackgroundImage = Image.FromFile(fileName);
                        drvDetail["ImageGeneralBlank"] = ImageToByteArray(Image.FromFile(fileName));
                        break;
                    case "ImageButtonScreen1":
                        ImagePanelScreen1.BackgroundImage = Image.FromFile(fileName);
                        drvDetail["ImageScreen1"] = ImageToByteArray(Image.FromFile(fileName));
                        break;
                    case "ImageButtonScreen2":
                        ImagePanelScreen2.BackgroundImage = Image.FromFile(fileName);
                        drvDetail["ImageScreen2"] = ImageToByteArray(Image.FromFile(fileName));
                        break;
                    case "ImageButtonOk":
                        ImagePanelOk.BackgroundImage = Image.FromFile(fileName);
                        drvDetail["ImageOk"] = ImageToByteArray(Image.FromFile(fileName));
                        break;
                    case "ImageButtonDeny":
                        ImagePanelDeny.BackgroundImage = Image.FromFile(fileName);
                        drvDetail["ImageDeny"] = ImageToByteArray(Image.FromFile(fileName));
                        break;
                }

            }


        }
        #endregion
        #region Logic Function
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }
        private object GetDevices()
        {


            var results = from nodeTable in Info.NodePointDevices.AsEnumerable()
                          join deviceTable in Info.Devices.AsEnumerable() on (int)nodeTable["IdDevice"] equals (int)deviceTable["IdDevice"]
                          where nodeTable.IdNodePoint == (int)drvDetail["IdNodePoint"]
                          select new
                          {
                              idDevice = (int)deviceTable["IdDevice"],
                              deviceName = (string)deviceTable["DeviceName"],
                              delete = "Видалити"
                          };
            return results;
        }

        #endregion

       
    }
}

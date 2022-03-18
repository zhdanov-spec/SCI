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
    public partial class DeviceTypeForm : RadForm
    {
        #region Init Function
        public DeviceTypeForm()
        {
            InitializeComponent();
        }
        private DataRowView drvDetail;
        private DataView vueDetail;
        public DataRowView Execute(CurrencyManager cm, DataView vueDetail)
        {

            this.vueDetail = vueDetail;
            this.drvDetail = (DataRowView)cm.Current;
            if (cm.Count != 1)
            {
                this.BindingContext[this.vueDetail].Position = cm.Position;
            }
            IpAddress.DataBindings.Add("Text", this.vueDetail, "IpAddress");
            TimeDTR.DataBindings.Add("Text", this.vueDetail, "TimeDTR");
            GameTime.DataBindings.Add("Text", this.vueDetail, "GameTime");
            if((int)this.drvDetail["GameTime"]==0)
            {
                UnlimTime.IsChecked = true;
            }

            if (this.drvDetail["DeviceType"]==DBNull.Value)
            {
                SetStatePage(SGZGlobals.Classes.Constants.DeviceType.RemotingDeivice);
            }
            else if ((SGZGlobals.Classes.Constants.DeviceType)this.drvDetail["DeviceType"] == SGZGlobals.Classes.Constants.DeviceType.RemotingDeivice)
            {
                SetStatePage(SGZGlobals.Classes.Constants.DeviceType.RemotingDeivice);
            }
            else if ((SGZGlobals.Classes.Constants.DeviceType)this.drvDetail["DeviceType"] == SGZGlobals.Classes.Constants.DeviceType.Attraction)
            {
                SetStatePage(SGZGlobals.Classes.Constants.DeviceType.Attraction);
            }
            else if ((SGZGlobals.Classes.Constants.DeviceType)this.drvDetail["DeviceType"] == SGZGlobals.Classes.Constants.DeviceType.Service)
            {
                SetStatePage(SGZGlobals.Classes.Constants.DeviceType.Service);
            }
            ShowDialog();
            return this.drvDetail;
        }

        #endregion

        #region Logic function
        private void SetStatePage(SGZGlobals.Classes.Constants.DeviceType deviceType)
        {

            foreach (Control control in MainPageView.Controls)
            {
                if(control is RadPageViewPage)
                {
                    (control as RadPageViewPage).Item.Visibility= Telerik.WinControls.ElementVisibility.Collapsed;
                }
            }
            if(deviceType==SGZGlobals.Classes.Constants.DeviceType.RemotingDeivice)
            {
                PageViewRemotingDeivice.Item.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                MainPageView.SelectedPage = PageViewRemotingDeivice;
                drvDetail["DeviceType"] = (int)SGZGlobals.Classes.Constants.DeviceType.RemotingDeivice;
                RadioRemotingDeivice.IsChecked = true;
                return;
            }
            else if(deviceType == SGZGlobals.Classes.Constants.DeviceType.Attraction)
            {
                PageViewAttraction.Item.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                MainPageView.SelectedPage= PageViewAttraction;
                drvDetail["DeviceType"] = (int)SGZGlobals.Classes.Constants.DeviceType.Attraction;
                RadioAttraction.IsChecked = true;
                return;
            }
            else if (deviceType == SGZGlobals.Classes.Constants.DeviceType.Service)
            {
                PageViewService.Item.Visibility = Telerik.WinControls.ElementVisibility.Visible;
                MainPageView.SelectedPage = PageViewService;
                drvDetail["DeviceType"] = (int)SGZGlobals.Classes.Constants.DeviceType.Service;
                RadioService.IsChecked = true;
                return;
            }
        }
        #endregion
        #region Events Function
        private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if(RadioRemotingDeivice.IsChecked)
            {
                SetStatePage(SGZGlobals.Classes.Constants.DeviceType.RemotingDeivice);
            }
            else if(RadioAttraction.IsChecked)
            {
                SetStatePage(SGZGlobals.Classes.Constants.DeviceType.Attraction);
            }
            else if(RadioService.IsChecked)
            {
                SetStatePage(SGZGlobals.Classes.Constants.DeviceType.Service);
            }
        }
        private void UnlimTime_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if(UnlimTime.IsChecked)
            {
                UnlimTime.Text = "Гра Безлімітна";
                GameTime.Text = "0";
                GameTime.Visible = false;
            }
            else
            {
                UnlimTime.Text = "Гра За Часом";
                GameTime.Text = "0";
                GameTime.Visible = true;
            }
        }
        #endregion


    }
}

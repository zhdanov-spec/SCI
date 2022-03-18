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
using Telerik.WinControls;
using Telerik.WinControls.Themes;

namespace ZPSoft.GameZone.SGZForms.Forms
{
    public partial class WaitingForm : RadForm
    {
        public Action Worker { get; set; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MaterialTealTheme theme = new MaterialTealTheme();
            ThemeResolutionService.ApplicationThemeName = theme.ThemeName;
            Task.Factory.StartNew(Worker).ContinueWith(t => { this.Close(); }, TaskScheduler.FromCurrentSynchronizationContext());

        }
        public WaitingForm(Action worker, string text)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.AllowTransparency = true;
            this.BackColor = Color.AliceBlue;//цвет фона  
            this.TransparencyKey = this.BackColor;//он же будет заменен на прозрачный цвет

            if (worker == null)
                throw new ArgumentNullException();
            Worker = worker;
            textLabel.Text = text;
            radWaitingBar1.StartWaiting();

        }
    }
}

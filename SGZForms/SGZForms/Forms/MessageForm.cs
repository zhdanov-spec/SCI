using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace ZPSoft.GameZone.SGZForms.Forms
{
    public partial class MessageForm : RadForm
    {
        #region Init Function
        public MessageForm()
        {
            InitializeComponent();
        }
        public void Execute(string caption,string text)
        {
            CaptionLabel.Text = caption;
            InfoLabel.Text= text;
            this.TopMost = true;
            ShowDialog();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                MaterialTealTheme theme = new MaterialTealTheme();
                ThemeResolutionService.ApplicationThemeName = theme.ThemeName;
            }
            catch { }
        }
        #endregion
        

    }
}

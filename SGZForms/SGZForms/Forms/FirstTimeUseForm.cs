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
    public partial class FirstTimeUseForm : RadForm
    {
        #region Init function
        public FirstTimeUseForm()
        {
            InitializeComponent();
        }
        public bool Execute(out string password)
        {
            ОКButton.Enabled = false;
            password = "";
            if (ShowDialog() == DialogResult.OK)
            {
                password = PassTextBox.Text;
                return true;
            }
            else
                return false;
        }
        #endregion
        #region Events Function
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

       
        private void PassTextBox_TextChanged(object sender, EventArgs e)
        {
            if (PassTextBox.Text == RepeatPassTextBox.Text && PassTextBox.Text.Length > 0)
                ОКButton.Enabled = true;
            else
                ОКButton.Enabled = false;
        }
    }
}

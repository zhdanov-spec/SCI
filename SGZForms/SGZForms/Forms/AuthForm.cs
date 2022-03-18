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
    public partial class AuthForm : RadForm
    {
        #region Init Function
        public AuthForm()
        {
            InitializeComponent();
            ОКButton.Enabled = false;
        }
        public bool Execute(out string login,out string password)
        {
            login = "";
            password = "";
            if (ShowDialog() == DialogResult.OK)
            {
                login = LoginTextBox.Text;
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

        private void LoginTextBox_TextChanged(object sender, EventArgs e)
        {
            if (LoginTextBox.Text.Length == 0)
                ОКButton.Enabled = false;
            else
                ОКButton.Enabled = true;
                
        }
    }
}

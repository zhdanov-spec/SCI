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
    public partial class QuestionForm : RadForm
    {
        #region Init Function
        public QuestionForm()
        {
            InitializeComponent();
        }
        public DialogResult Execute(string caption, string text)
        {
            CaptionLabel.Text = caption;
            InfoLabel.Text = text;
            this.TopMost = true;

            if (ShowDialog() == DialogResult.Yes)
                return DialogResult.Yes;
            else
                return DialogResult.No;
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

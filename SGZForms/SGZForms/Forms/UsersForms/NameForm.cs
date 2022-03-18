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

namespace ZPSoft.GameZone.SGZForms.Forms.UsersForms
{
    public partial class NameForm : RadForm
    {
        #region Init Function
        bool res = false;
        public NameForm()
        {
            InitializeComponent();
        }
        public bool Execute(string caption,string oldName, out string name)
        {
            CaptionLabel.Text = caption;
            if (oldName != null)
                NameLabel.Text = oldName;
            else
                NameLabel.Text = "";
            ShowDialog();
            name = NameLabel.Text;
            
            return res;
        }
        #endregion
        #region Events Function
        private void NameForm_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(e.KeyValue.ToString());
            char letter = new MainClass().GetKeyLetter(e.KeyValue);
            if (letter == '~') return;
            if (letter == 'Q')
            {
                res = false;
                Close();
            }
            else if (letter == 'E')
            {

                if (NameLabel.Text.Length > 0)
                {
                    res = true;
                    Close();
                }
                else
                {
                    new SGZForms.Forms.MessageForm().Execute("Помилка", "Введіть значення, або скасуйте операцію");
                }
            }
            else if (letter == 'D')
            {
                DellLetter();
            }
            else
            {
                AddLetter(letter);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MaterialTealTheme theme = new MaterialTealTheme();
            ThemeResolutionService.ApplicationThemeName = theme.ThemeName;
            this.BackColor = Color.FromArgb(128, 203, 196);

        }
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (NameLabel.Text.Length>0)
            {
                res = true;
                Close();
            }
            else
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Введіть значення, або скасуйте операцію");
            }

        }

        private void CnlButton_Click(object sender, EventArgs e)
        {
            res = false;
            Close();
        }

        #endregion
        #region Logic Function
        private void DellLetter()
        {
            if(NameLabel.Text.Length>0)
                NameLabel.Text = NameLabel.Text.Substring(0, NameLabel.Text.Length - 1);
        }
        private void AddLetter(char letter)
        {
            if (NameLabel.Text.Length < 51)
                NameLabel.Text += letter;
        }
        #endregion


    }
}

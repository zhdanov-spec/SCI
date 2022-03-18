using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace ZPSoft.GameZone.SGZForms.Forms.UsersForms
{
    public partial class PhoneForm : RadForm
    {
        #region Init Function
        bool res = false;
        public PhoneForm()
        {
            InitializeComponent();
        }
        public bool Execute(string caption,out string phone)
        {
            CaptionLabel.Text = caption;
            ShowDialog();
            if (this.res)
                phone = PhoneLabel.Text;
            else
                phone = null;
            
            return this.res;
        }
        #endregion
        #region Events Function
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            MaterialTealTheme theme = new MaterialTealTheme();
            ThemeResolutionService.ApplicationThemeName = theme.ThemeName;
          
        }
        private void PhoneForm_KeyDown(object sender, KeyEventArgs e)
        {
            char letter = new MainClass().GetKey(e.KeyValue);
            if (letter == ' ') return;
            if (letter == ',') return;
            if (letter == 'Q')
            {
                res = false;
                Close();
            }
            else if (letter == 'E')
            {
                if (ChekPhone())
                {
                    res = true;
                    Close();
                }
                else
                {
                    new SGZForms.Forms.MessageForm().Execute("Помилка", "Телефон не вірний");
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
        private void CnlButton_Click(object sender, EventArgs e)
        {
            res = false;
            Close();
        }
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (ChekPhone())
            {
                res = true;
                Close();
            }
            else
            {
                new SGZForms.Forms.MessageForm().Execute("Помилка", "Телефон не вірний");
            }
        }
        #endregion
        #region Logic Function
        private bool ChekPhone()
        {
            string resultString = string.Join(string.Empty, Regex.Matches(PhoneLabel.Text, @"\d+").OfType<Match>().Select(m => m.Value));
            if (resultString.Length == 10)
                return true;
            else
                return false;
        }
        private void AddLetter(char letter)
        {
            Int32 indexChar = PhoneLabel.Text.IndexOf('X');
            if(indexChar!=-1)
                PhoneLabel.Text = ReplaceCharInString(PhoneLabel.Text, indexChar, letter);
        }
        public String ReplaceCharInString(String str, int index, Char newSymb)
        {
            return str.Remove(index, 1).Insert(index, newSymb.ToString());
        }
        private void DellLetter()
        {
            Int32 lastIndex = 0;
            for(int index=0;index < PhoneLabel.Text.Length;index++)
            {
                char value = PhoneLabel.Text[index];
                if(char.IsDigit(value))
                {
                    lastIndex = index;
                }
            }
            if(lastIndex!=0)
            {
                PhoneLabel.Text = ReplaceCharInString(PhoneLabel.Text, lastIndex, 'X');
            }
           
        }


        #endregion

       
    }
}

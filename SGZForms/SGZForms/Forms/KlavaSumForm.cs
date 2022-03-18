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
using ZPSoft.GameZone.SGZGlobals.Classes;

namespace ZPSoft.GameZone.SGZForms.Forms
{
    public partial class KlavaSumForm : RadForm
    {
        #region Init Function
        Constants.KlavaType KlavaType;
        bool res = false;
        Money cardCoast;
        int maxSum = 50000;
        public KlavaSumForm()
        {
            InitializeComponent();
            KlavaType = Constants.KlavaType.None;
            cardCoast = new Money(0);
        }
        
        public bool ExecuteSmenaAction(out Money sum)
        {
            
            KlavaType = ZPSoft.GameZone.SGZGlobals.Classes.Constants.KlavaType.SmenaAction;
            InfoLabel.Visible = false;
            ShowDialog();
            sum = new Money(float.Parse(SumLabel.Text));
            return this.res;
        }
        public bool ExecuteSmenaAction(int maxSum,out Money sum)
        {
            this.maxSum = maxSum;
            KlavaType = ZPSoft.GameZone.SGZGlobals.Classes.Constants.KlavaType.SmenaAction;
            InfoLabel.Visible = false;
            ShowDialog();
            sum = new Money(float.Parse(SumLabel.Text));
            return this.res;
        }
        public bool ExecuteCardOut(out Money sum,Money cardCoast)
        {
            KlavaType = ZPSoft.GameZone.SGZGlobals.Classes.Constants.KlavaType.CardAction;
            this.cardCoast = cardCoast;
            InfoLabel.Text = string.Format("Буде зараховано{0}За Картку-{1}{0}На Картку-{2}", Environment.NewLine, new Money(0), new Money(0));
            ShowDialog();
            sum = new Money(float.Parse(SumLabel.Text))-cardCoast;
            
            return this.res;
        }
        public bool ExecuteTikcet(out Int32 sum)
        {
            KlavaType = ZPSoft.GameZone.SGZGlobals.Classes.Constants.KlavaType.TicketAction;
            ButtonSeparator.Enabled = false;
            InfoLabel.Visible = false;
            ShowDialog();
            sum = int.Parse(SumLabel.Text);
            return this.res;
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
                foreach(var control in LayoutPanelMainKey.Controls)
                {
                    if (control is RadButton button)
                    {
                        ((RadButtonElement)button.GetChildAt(0)).Font = new Font("Microsoft Sans Serif", 40.25F);
                    }
                }
                ((RadButtonElement)ButtonOK.GetChildAt(0)).Font= new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
                ((RadButtonElement)CnlButton.GetChildAt(0)).Font= new System.Drawing.Font("Microsoft Sans Serif", 30.25F);
                SumLabel.Select();
                SumLabel.Text = "0";
            }
            catch { }
        }
        private void KlavaSumForm_KeyDown(object sender, KeyEventArgs e)
        {
            char letter = new MainClass().GetKey(e.KeyValue);
            if (letter == ' ')
                return;
            if (letter == 'Q')
            {
                res = false;
                Close();
            }
            else if (letter == 'E')
            {
                res = true;
                Close();
            }
            else if (letter == 'D')
            {
                DellLetter();
            }
            else if (letter == ',' && KlavaType != ZPSoft.GameZone.SGZGlobals.Classes.Constants.KlavaType.TicketAction)
            {
                AddComa();
            }
            else
            {
                AddLetter(letter);
            }
            if(KlavaType==ZPSoft.GameZone.SGZGlobals.Classes.Constants.KlavaType.CardAction)
            {
                if ((new Money(float.Parse(SumLabel.Text)) - cardCoast) >= new Money(0))
                    InfoLabel.Text = string.Format("Буде зараховано{0}За Картку-{1}{0}На Картку-{2}", Environment.NewLine, cardCoast, new Money(float.Parse(SumLabel.Text)) - cardCoast);
                else
                    InfoLabel.Text = string.Format("Буде зараховано{0}За Картку-{1}{0}На Картку-{2}", Environment.NewLine, new Money(0), new Money(0));

            }

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            AddLetter(Convert.ToChar(((RadButton)sender).Text));
        }
        private void ButtonBackSpace_Click(object sender, EventArgs e)
        {
            DellLetter();
        }
        private void ButtonSeparator_Click(object sender, EventArgs e)
        {
            AddComa();
        }
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            res = true;
            Close();
        }
        #endregion
        #region Logic Function
    
        private void DellLetter()
        {
            if (SumLabel.Text.Length == 1)
            {
                SumLabel.Text = "0";
                return;
            }
            else
            {
                SumLabel.Text = SumLabel.Text.Substring(0, SumLabel.Text.Length - 1);
            }
        }
        private void AddComa()
        {
            if (SumLabel.Text.IndexOf(',') != -1) return;
            SumLabel.Text += ",";
        }
        private void AddLetter(char letter)
        {
            if (IsMax(letter) && SumLabel.Text.IndexOf(',')==-1) return;
            if(SumLabel.Text.IndexOf(',')!=-1)
            {
                string[] splitString = SumLabel.Text.Split(',');
                if (splitString[1].Length == 2) return;
            }
            double text = Convert.ToDouble(SumLabel.Text += letter.ToString());
            SumLabel.Text = text.ToString();
            
        }
        private bool IsMax(char digit)
        {
            if (digit == ',') return false;
            string[] splitstring = SumLabel.Text.Split(',');
            if (Convert.ToInt32(splitstring[0]+digit) > maxSum)
                return true;
            else
                return false;
        }


        #endregion

       
    }
}

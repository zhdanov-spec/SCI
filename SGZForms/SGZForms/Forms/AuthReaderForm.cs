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
    public partial class AuthReaderForm : RadForm
    {
        #region Init Function
        Timer ReaderTimer;
        ZPSoft.GameZone.Devices.InputDevices.CardReaders.ICardReader CardReader;
        string card = "";
        bool res = false;
        public AuthReaderForm()
        {
            InitializeComponent();
        }
        public bool Execute(ZPSoft.GameZone.Devices.InputDevices.CardReaders.ICardReader CardReader,out string card)
        {
            this.CardReader = CardReader;
            ReaderTimer = new Timer
            {
                Interval = 500
            };
            ReaderTimer.Tick += ReaderTimer_Tick;
            ReaderTimer.Enabled = true;
            ShowDialog();
            ReaderTimer.Enabled = false;
            ReaderTimer.Tick -= ReaderTimer_Tick;
            card = this.card;
            return res;

        }
        public bool Execute()
        {
            ShowDialog();
            return res;
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
                this.TransparencyKey = BackColor;
                this.TopMost = true;
            }
            catch { }
        }
        private void ReaderTimer_Tick(object sender, EventArgs e)
        {
            if (CardReader != null)
            {
                card = CardReader.GetCardId;
                if (card != "")
                {

                    CardReader.GetCardId = "";
                    res = true;
                    Close();
                }
            }

        }
        private void CnlButton_Click(object sender, EventArgs e)
        {
            res = false;
            Close();
        }
        private void AuthReaderForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==27)
            {
                res = false;
                Close();
            }
        }
        #endregion



    }
}

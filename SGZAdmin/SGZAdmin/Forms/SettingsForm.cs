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
using ZPSoft.GameZone.SGZGlobals.Classes;

namespace ZPSoft.GameZone.SGZAdmin.Forms
{
    public partial class SettingsForm : RadForm
    {
        #region Init Function
        public SettingsForm()
        {
            InitializeComponent();
        }
        public void ExecuteCreateFile()
        {
            Classes.GlobalVariable.Settings.Clear();
            Classes.GlobalVariable.Settings.DBSettings.AddDBSettingsRow((int)Constants.DatabaseSettings.SERVER_NAME, "127.0.0.1", "Адрес Сервера");
            Classes.GlobalVariable.Settings.AcceptChanges();
            Classes.GlobalVariable.Settings.WriteXml(Classes.Constants.SettingsFileName);


            if (ShowDialog() == DialogResult.OK)
            {
                SaveParams();
                new SGZForms.Forms.MessageForm().Execute("Увага", "Сервер буде перезавантажено");
                Application.Restart();
            };
        }
        public bool ExecuteSet()
        {
            serverMaskedEditBox.Text = Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SERVER_NAME).Value;
            if (ShowDialog() == DialogResult.OK)
            {
                SaveParams();
                return true;
            }
            return false;
        }

        #endregion
        #region Logic Function
        private void SaveParams()
        {
            Classes.GlobalVariable.Settings.DBSettings.FindByKey((int)Constants.DatabaseSettings.SERVER_NAME).Value = serverMaskedEditBox.Text;
            Classes.GlobalVariable.Settings.AcceptChanges();
            Classes.GlobalVariable.Settings.WriteXml(Constants.SettingsFileName);
        }
        #endregion
    }
}

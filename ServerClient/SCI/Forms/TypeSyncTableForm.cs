using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ZPSoft.GameZone.SCI.Forms
{
    public partial class TypeSyncTableForm : Telerik.WinControls.UI.RadForm
    {
        #region Init Function
        public TypeSyncTableForm()
        {
            InitializeComponent();
        }

        public bool ExecuteEdit(Int32 typeSync, string nameField, out Int32 typeSyncOut, out string nameFieldOut)
        {
            nameFieldOut = nameField;
            typeSyncOut = typeSync;
            typeDropDownList.SelectedIndex = typeSyncOut;
            if (ShowDialog() == DialogResult.OK)
                return true;
            else
                return false;
        }
        public bool ExecuteAdd(out Int32 typeSyncOut, out string nameFieldOut)
        {
            typeDropDownList.SelectedIndex = (int)Classes.Constants.TypeSyncing.SqlSync;
            if (ShowDialog() == DialogResult.OK)
            {
                typeSyncOut = typeDropDownList.SelectedIndex;
                nameFieldOut = fieldTextBox.Text;
                return true;
            }
            else
            {
                typeSyncOut = 0;
                nameFieldOut = "";
                return false;
            }

        }
        #endregion
        #region Events Function
        private void TypeDropDownList_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if ((Classes.Constants.TypeSyncing)typeDropDownList.SelectedIndex == Classes.Constants.TypeSyncing.SqlSync)
            {
                fieldTextBox.Enabled = false;
            }
            else
            {
                fieldTextBox.Enabled = true;
            }
        }
        #endregion
    }
}


namespace ZPSoft.GameZone.SCI.Forms
{
    partial class TypeSyncTableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.RadListDataItem radListDataItem3 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem4 = new Telerik.WinControls.UI.RadListDataItem();
            this.typeDropDownList = new Telerik.WinControls.UI.RadDropDownList();
            this.fieldTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.okButton = new Telerik.WinControls.UI.RadButton();
            this.cancelButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.typeDropDownList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.okButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // typeDropDownList
            // 
            this.typeDropDownList.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.typeDropDownList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            radListDataItem3.Text = "Sync SQL";
            radListDataItem3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            radListDataItem4.Text = "Sync By Field";
            radListDataItem4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.typeDropDownList.Items.Add(radListDataItem3);
            this.typeDropDownList.Items.Add(radListDataItem4);
            this.typeDropDownList.Location = new System.Drawing.Point(180, 26);
            this.typeDropDownList.Name = "typeDropDownList";
            this.typeDropDownList.Size = new System.Drawing.Size(180, 27);
            this.typeDropDownList.TabIndex = 0;
            this.typeDropDownList.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.TypeDropDownList_SelectedIndexChanged);
            // 
            // fieldTextBox
            // 
            this.fieldTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldTextBox.Location = new System.Drawing.Point(180, 70);
            this.fieldTextBox.Name = "fieldTextBox";
            this.fieldTextBox.Size = new System.Drawing.Size(180, 27);
            this.fieldTextBox.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel1.Location = new System.Drawing.Point(38, 26);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(105, 25);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Тип таблицы";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel2.Location = new System.Drawing.Point(12, 72);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(131, 25);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Поле сравнения";
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(12, 116);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(110, 32);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "ОК";
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(250, 116);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(110, 32);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            // 
            // TypeSyncTableForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(375, 160);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.fieldTextBox);
            this.Controls.Add(this.typeDropDownList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TypeSyncTableForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TypeSyncTableForm";
            ((System.ComponentModel.ISupportInitialize)(this.typeDropDownList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fieldTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.okButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cancelButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadDropDownList typeDropDownList;
        private Telerik.WinControls.UI.RadTextBox fieldTextBox;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton okButton;
        private Telerik.WinControls.UI.RadButton cancelButton;
    }
}

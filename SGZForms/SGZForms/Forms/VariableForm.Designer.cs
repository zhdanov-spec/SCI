namespace ZPSoft.GameZone.SGZForms.Forms
{
    partial class VariableForm
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
            this.PanelText = new Telerik.WinControls.UI.RadPanel();
            this.VariableTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.CaptionLabel = new Telerik.WinControls.UI.RadLabel();
            this.OkButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.PanelText)).BeginInit();
            this.PanelText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariableTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptionLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelText
            // 
            this.PanelText.Controls.Add(this.VariableTextBox);
            this.PanelText.Controls.Add(this.CaptionLabel);
            this.PanelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelText.Location = new System.Drawing.Point(5, 5);
            this.PanelText.Name = "PanelText";
            this.PanelText.Padding = new System.Windows.Forms.Padding(5);
            this.PanelText.Size = new System.Drawing.Size(681, 292);
            this.PanelText.TabIndex = 1;
            this.PanelText.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VariableTextBox
            // 
            this.VariableTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VariableTextBox.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VariableTextBox.Location = new System.Drawing.Point(5, 100);
            this.VariableTextBox.Name = "VariableTextBox";
            this.VariableTextBox.Size = new System.Drawing.Size(671, 48);
            this.VariableTextBox.TabIndex = 1;
            this.VariableTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CaptionLabel
            // 
            this.CaptionLabel.AutoSize = false;
            this.CaptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CaptionLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CaptionLabel.ForeColor = System.Drawing.Color.Red;
            this.CaptionLabel.Location = new System.Drawing.Point(5, 5);
            this.CaptionLabel.Name = "CaptionLabel";
            this.CaptionLabel.Size = new System.Drawing.Size(671, 95);
            this.CaptionLabel.TabIndex = 0;
            this.CaptionLabel.Text = "radLabel1";
            this.CaptionLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OkButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkButton.Location = new System.Drawing.Point(5, 297);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(681, 65);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "ОК";
            // 
            // VariableForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 367);
            this.Controls.Add(this.PanelText);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VariableForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VariableForm";
            ((System.ComponentModel.ISupportInitialize)(this.PanelText)).EndInit();
            this.PanelText.ResumeLayout(false);
            this.PanelText.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VariableTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptionLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel PanelText;
        private Telerik.WinControls.UI.RadLabel CaptionLabel;
        private Telerik.WinControls.UI.RadTextBox VariableTextBox;
        private Telerik.WinControls.UI.RadButton OkButton;
    }
}
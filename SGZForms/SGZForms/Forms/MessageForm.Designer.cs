namespace ZPSoft.GameZone.SGZForms.Forms
{
    partial class MessageForm
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
            this.OkButton = new Telerik.WinControls.UI.RadButton();
            this.CaptionLabel = new Telerik.WinControls.UI.RadLabel();
            this.InfoLabel = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.PanelText)).BeginInit();
            this.PanelText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OkButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptionLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelText
            // 
            this.PanelText.Controls.Add(this.InfoLabel);
            this.PanelText.Controls.Add(this.CaptionLabel);
            this.PanelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelText.Location = new System.Drawing.Point(5, 5);
            this.PanelText.Name = "PanelText";
            this.PanelText.Padding = new System.Windows.Forms.Padding(5);
            this.PanelText.Size = new System.Drawing.Size(605, 228);
            this.PanelText.TabIndex = 0;
            this.PanelText.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OkButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkButton.Location = new System.Drawing.Point(5, 233);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(605, 65);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "ОК";
            // 
            // CaptionLabel
            // 
            this.CaptionLabel.AutoSize = false;
            this.CaptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CaptionLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CaptionLabel.ForeColor = System.Drawing.Color.Red;
            this.CaptionLabel.Location = new System.Drawing.Point(5, 5);
            this.CaptionLabel.Name = "CaptionLabel";
            this.CaptionLabel.Size = new System.Drawing.Size(595, 58);
            this.CaptionLabel.TabIndex = 0;
            this.CaptionLabel.Text = "radLabel1";
            this.CaptionLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = false;
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoLabel.Location = new System.Drawing.Point(5, 63);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(595, 160);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.Text = "radLabel2";
            this.InfoLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 303);
            this.Controls.Add(this.PanelText);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageForm";
            ((System.ComponentModel.ISupportInitialize)(this.PanelText)).EndInit();
            this.PanelText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OkButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptionLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InfoLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel PanelText;
        private Telerik.WinControls.UI.RadButton OkButton;
        private Telerik.WinControls.UI.RadLabel InfoLabel;
        private Telerik.WinControls.UI.RadLabel CaptionLabel;
    }
}
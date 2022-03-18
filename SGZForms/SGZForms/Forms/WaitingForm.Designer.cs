namespace ZPSoft.GameZone.SGZForms.Forms
{
    partial class WaitingForm
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
            this.textLabel = new Telerik.WinControls.UI.RadLabel();
            this.radWaitingBar1 = new Telerik.WinControls.UI.RadWaitingBar();
            this.dotsSpinnerWaitingBarIndicatorElement1 = new Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement();
            ((System.ComponentModel.ISupportInitialize)(this.textLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = false;
            this.textLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLabel.Location = new System.Drawing.Point(0, 133);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(302, 78);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "radLabel1";
            this.textLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // radWaitingBar1
            // 
            this.radWaitingBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radWaitingBar1.Location = new System.Drawing.Point(0, 0);
            this.radWaitingBar1.Name = "radWaitingBar1";
            this.radWaitingBar1.Size = new System.Drawing.Size(302, 133);
            this.radWaitingBar1.TabIndex = 1;
            this.radWaitingBar1.Text = "radWaitingBar1";
            this.radWaitingBar1.WaitingIndicators.Add(this.dotsSpinnerWaitingBarIndicatorElement1);
            this.radWaitingBar1.WaitingSpeed = 100;
            this.radWaitingBar1.WaitingStyle = Telerik.WinControls.Enumerations.WaitingBarStyles.DotsSpinner;
            // 
            // dotsSpinnerWaitingBarIndicatorElement1
            // 
            this.dotsSpinnerWaitingBarIndicatorElement1.Name = "dotsSpinnerWaitingBarIndicatorElement1";
            // 
            // WaitingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 211);
            this.Controls.Add(this.radWaitingBar1);
            this.Controls.Add(this.textLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WaitingForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WaitForm";
            ((System.ComponentModel.ISupportInitialize)(this.textLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radWaitingBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel textLabel;
        private Telerik.WinControls.UI.RadWaitingBar radWaitingBar1;
        private Telerik.WinControls.UI.DotsSpinnerWaitingBarIndicatorElement dotsSpinnerWaitingBarIndicatorElement1;
    }
}
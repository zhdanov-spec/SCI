namespace ZPSoft.GameZone.SGZForms.Forms
{
    partial class QuestionForm
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
            this.InfoLabel = new Telerik.WinControls.UI.RadLabel();
            this.CaptionLabel = new Telerik.WinControls.UI.RadLabel();
            this.YesButton = new Telerik.WinControls.UI.RadButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NoButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.PanelText)).BeginInit();
            this.PanelText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptionLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YesButton)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NoButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelText
            // 
            this.PanelText.Controls.Add(this.InfoLabel);
            this.PanelText.Controls.Add(this.tableLayoutPanel1);
            this.PanelText.Controls.Add(this.CaptionLabel);
            this.PanelText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelText.Location = new System.Drawing.Point(5, 5);
            this.PanelText.Name = "PanelText";
            this.PanelText.Padding = new System.Windows.Forms.Padding(5);
            this.PanelText.Size = new System.Drawing.Size(613, 323);
            this.PanelText.TabIndex = 0;
            this.PanelText.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InfoLabel
            // 
            this.InfoLabel.AutoSize = false;
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoLabel.Location = new System.Drawing.Point(5, 63);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(603, 188);
            this.InfoLabel.TabIndex = 1;
            this.InfoLabel.Text = "radLabel2";
            this.InfoLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CaptionLabel
            // 
            this.CaptionLabel.AutoSize = false;
            this.CaptionLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CaptionLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CaptionLabel.ForeColor = System.Drawing.Color.Red;
            this.CaptionLabel.Location = new System.Drawing.Point(5, 5);
            this.CaptionLabel.Name = "CaptionLabel";
            this.CaptionLabel.Size = new System.Drawing.Size(603, 58);
            this.CaptionLabel.TabIndex = 0;
            this.CaptionLabel.Text = "radLabel1";
            this.CaptionLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // YesButton
            // 
            this.YesButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.YesButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.YesButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YesButton.Location = new System.Drawing.Point(3, 3);
            this.YesButton.Name = "YesButton";
            this.YesButton.Size = new System.Drawing.Size(295, 61);
            this.YesButton.TabIndex = 1;
            this.YesButton.Text = "ТАК";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.NoButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.YesButton, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 251);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(603, 67);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // NoButton
            // 
            this.NoButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.NoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NoButton.Location = new System.Drawing.Point(304, 3);
            this.NoButton.Name = "NoButton";
            this.NoButton.Size = new System.Drawing.Size(296, 61);
            this.NoButton.TabIndex = 2;
            this.NoButton.Text = "НІ";
            // 
            // QuestionForm
            // 
            this.AcceptButton = this.YesButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 333);
            this.Controls.Add(this.PanelText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "QuestionForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuestionForm";
            ((System.ComponentModel.ISupportInitialize)(this.PanelText)).EndInit();
            this.PanelText.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InfoLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptionLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YesButton)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NoButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadPanel PanelText;
        private Telerik.WinControls.UI.RadButton YesButton;
        private Telerik.WinControls.UI.RadLabel InfoLabel;
        private Telerik.WinControls.UI.RadLabel CaptionLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadButton NoButton;
    }
}
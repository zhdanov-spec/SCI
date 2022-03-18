namespace ZPSoft.GameZone.SGZForms.Forms.UsersForms
{
    partial class PhoneForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CnlButton = new Telerik.WinControls.UI.RadButton();
            this.ButtonOK = new Telerik.WinControls.UI.RadButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CaptionLabel = new Telerik.WinControls.UI.RadLabel();
            this.PhoneLabel = new Telerik.WinControls.UI.RadLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonOK)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CaptionLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.CnlButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonOK, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 203);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(556, 73);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // CnlButton
            // 
            this.CnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CnlButton.Location = new System.Drawing.Point(281, 3);
            this.CnlButton.Name = "CnlButton";
            this.CnlButton.Size = new System.Drawing.Size(272, 67);
            this.CnlButton.TabIndex = 5;
            this.CnlButton.Text = "Скасувати";
            this.CnlButton.Click += new System.EventHandler(this.CnlButton_Click);
            // 
            // ButtonOK
            // 
            this.ButtonOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonOK.Location = new System.Drawing.Point(3, 3);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(272, 67);
            this.ButtonOK.TabIndex = 4;
            this.ButtonOK.Text = "ОК";
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.PhoneLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.CaptionLabel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(556, 198);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // CaptionLabel
            // 
            this.CaptionLabel.AutoSize = false;
            this.CaptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CaptionLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CaptionLabel.ForeColor = System.Drawing.Color.Red;
            this.CaptionLabel.Location = new System.Drawing.Point(3, 3);
            this.CaptionLabel.Name = "CaptionLabel";
            this.CaptionLabel.Size = new System.Drawing.Size(550, 93);
            this.CaptionLabel.TabIndex = 1;
            this.CaptionLabel.Text = "radLabel1";
            this.CaptionLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = false;
            this.PhoneLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PhoneLabel.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhoneLabel.ForeColor = System.Drawing.Color.Black;
            this.PhoneLabel.Location = new System.Drawing.Point(3, 102);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(550, 93);
            this.PhoneLabel.TabIndex = 2;
            this.PhoneLabel.Text = "(XXX) XXX-XXXX";
            this.PhoneLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // PhoneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 281);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "PhoneForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhoneForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PhoneForm_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonOK)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CaptionLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadButton CnlButton;
        private Telerik.WinControls.UI.RadButton ButtonOK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadLabel CaptionLabel;
        private Telerik.WinControls.UI.RadLabel PhoneLabel;
    }
}
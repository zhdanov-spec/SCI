namespace ZPSoft.GameZone.SGZForms.Forms.UsersForms
{
    partial class NameForm
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
            this.NameLabel = new Telerik.WinControls.UI.RadLabel();
            this.CaptionLabel = new Telerik.WinControls.UI.RadLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonOK)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NameLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptionLabel)).BeginInit();
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 284);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 73F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(603, 73);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // CnlButton
            // 
            this.CnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CnlButton.Location = new System.Drawing.Point(304, 3);
            this.CnlButton.Name = "CnlButton";
            this.CnlButton.Size = new System.Drawing.Size(296, 67);
            this.CnlButton.TabIndex = 5;
            this.CnlButton.TabStop = false;
            this.CnlButton.Text = "Скасувати";
            this.CnlButton.Click += new System.EventHandler(this.CnlButton_Click);
            // 
            // ButtonOK
            // 
            this.ButtonOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonOK.Location = new System.Drawing.Point(3, 3);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(295, 67);
            this.ButtonOK.TabIndex = 4;
            this.ButtonOK.TabStop = false;
            this.ButtonOK.Text = "ОК";
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.NameLabel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.CaptionLabel, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(603, 279);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = false;
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.ForeColor = System.Drawing.Color.Black;
            this.NameLabel.Location = new System.Drawing.Point(3, 142);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(597, 134);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "ПЕТЯ";
            this.NameLabel.TextAlignment = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CaptionLabel
            // 
            this.CaptionLabel.AutoSize = false;
            this.CaptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CaptionLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CaptionLabel.ForeColor = System.Drawing.Color.White;
            this.CaptionLabel.Location = new System.Drawing.Point(3, 3);
            this.CaptionLabel.Name = "CaptionLabel";
            this.CaptionLabel.Size = new System.Drawing.Size(597, 133);
            this.CaptionLabel.TabIndex = 1;
            this.CaptionLabel.Text = "radLabel1";
            this.CaptionLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(203)))), ((int)(((byte)(196)))));
            this.ClientSize = new System.Drawing.Size(613, 362);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NameForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NameForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameForm_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ButtonOK)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NameLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CaptionLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadButton CnlButton;
        private Telerik.WinControls.UI.RadButton ButtonOK;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadLabel NameLabel;
        private Telerik.WinControls.UI.RadLabel CaptionLabel;
    }
}
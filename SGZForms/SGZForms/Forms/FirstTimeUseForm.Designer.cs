namespace ZPSoft.GameZone.SGZForms.Forms
{
    partial class FirstTimeUseForm
    {
        /// <summary>
        /// Required designer variable.
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
            this.PassTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.RepeatPassTextBox = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.ОКButton = new Telerik.WinControls.UI.RadButton();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CnlButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.PassTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatPassTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ОКButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // PassTextBox
            // 
            this.PassTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.PassTextBox.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PassTextBox.Location = new System.Drawing.Point(302, 59);
            this.PassTextBox.Name = "PassTextBox";
            this.PassTextBox.Size = new System.Drawing.Size(249, 48);
            this.PassTextBox.TabIndex = 0;
            this.PassTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PassTextBox.TextChanged += new System.EventHandler(this.PassTextBox_TextChanged);
            // 
            // RepeatPassTextBox
            // 
            this.RepeatPassTextBox.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RepeatPassTextBox.Location = new System.Drawing.Point(302, 113);
            this.RepeatPassTextBox.Name = "RepeatPassTextBox";
            this.RepeatPassTextBox.Size = new System.Drawing.Size(249, 48);
            this.RepeatPassTextBox.TabIndex = 1;
            this.RepeatPassTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RepeatPassTextBox.TextChanged += new System.EventHandler(this.PassTextBox_TextChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel1.Location = new System.Drawing.Point(146, 58);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(150, 49);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Password";
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel2.Location = new System.Drawing.Point(20, 113);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(276, 49);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Confirm Password";
            // 
            // ОКButton
            // 
            this.ОКButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ОКButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ОКButton.Location = new System.Drawing.Point(3, 223);
            this.ОКButton.Name = "ОКButton";
            this.ОКButton.Size = new System.Drawing.Size(293, 50);
            this.ОКButton.TabIndex = 4;
            this.ОКButton.Text = "ОК";
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.tableLayoutPanel1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanel1.Location = new System.Drawing.Point(5, 5);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(598, 276);
            this.radPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.CnlButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ОКButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.PassTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RepeatPassTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.radLabel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radLabel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(598, 276);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // CnlButton
            // 
            this.CnlButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CnlButton.Location = new System.Drawing.Point(302, 223);
            this.CnlButton.Name = "CnlButton";
            this.CnlButton.Size = new System.Drawing.Size(293, 50);
            this.CnlButton.TabIndex = 5;
            this.CnlButton.Text = "Скасувати";
            // 
            // FirstTimeUseForm
            // 
            this.AcceptButton = this.ОКButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 286);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FirstTimeUseForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FirstTimeUseForm";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.PassTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatPassTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ОКButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBox PassTextBox;
        private Telerik.WinControls.UI.RadTextBox RepeatPassTextBox;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton ОКButton;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadButton CnlButton;
    }
}
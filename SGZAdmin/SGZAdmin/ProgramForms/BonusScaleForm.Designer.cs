namespace ZPSoft.GameZone.SGZAdmin.ProgramForms
{
    partial class BonusScaleForm
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CnlButton = new Telerik.WinControls.UI.RadButton();
            this.ОкButton = new Telerik.WinControls.UI.RadButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.SumBonus = new Telerik.WinControls.UI.RadTextBox();
            this.Payment = new Telerik.WinControls.UI.RadTextBox();
            this.DiscountName = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ОкButton)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SumBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Payment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.CnlButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ОкButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 116);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(439, 53);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // CnlButton
            // 
            this.CnlButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CnlButton.Location = new System.Drawing.Point(222, 3);
            this.CnlButton.Name = "CnlButton";
            this.CnlButton.Size = new System.Drawing.Size(214, 47);
            this.CnlButton.TabIndex = 1;
            this.CnlButton.Text = "Скасувати";
            // 
            // ОкButton
            // 
            this.ОкButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ОкButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ОкButton.Location = new System.Drawing.Point(3, 3);
            this.ОкButton.Name = "ОкButton";
            this.ОкButton.Size = new System.Drawing.Size(213, 47);
            this.ОкButton.TabIndex = 0;
            this.ОкButton.Text = "Ок";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.SumBonus, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Payment, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.DiscountName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radLabel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(439, 111);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // SumBonus
            // 
            this.SumBonus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SumBonus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SumBonus.Location = new System.Drawing.Point(222, 58);
            this.SumBonus.MaxLength = 50;
            this.SumBonus.Name = "SumBonus";
            this.SumBonus.Size = new System.Drawing.Size(209, 27);
            this.SumBonus.TabIndex = 2;
            this.SumBonus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Payment
            // 
            this.Payment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Payment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Payment.Location = new System.Drawing.Point(222, 8);
            this.Payment.MaxLength = 50;
            this.Payment.Name = "Payment";
            this.Payment.Size = new System.Drawing.Size(209, 27);
            this.Payment.TabIndex = 1;
            this.Payment.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DiscountName
            // 
            this.DiscountName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscountName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DiscountName.Location = new System.Drawing.Point(113, 58);
            this.DiscountName.Name = "DiscountName";
            this.DiscountName.Size = new System.Drawing.Size(103, 25);
            this.DiscountName.TabIndex = 2;
            this.DiscountName.Text = "Сума Бонуса";
            this.DiscountName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel1.Location = new System.Drawing.Point(71, 8);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(145, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Сума Поповнення";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // BonusScaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 174);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BonusScaleForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Бонус";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BonusScaleForm_FormClosing);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ОкButton)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SumBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Payment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DiscountName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadButton CnlButton;
        private Telerik.WinControls.UI.RadButton ОкButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadTextBox SumBonus;
        private Telerik.WinControls.UI.RadTextBox Payment;
        private Telerik.WinControls.UI.RadLabel DiscountName;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
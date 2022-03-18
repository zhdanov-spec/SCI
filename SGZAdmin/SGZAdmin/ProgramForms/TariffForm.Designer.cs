namespace ZPSoft.GameZone.SGZAdmin.ProgramForms
{
    partial class TariffForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.MainPageView = new Telerik.WinControls.UI.RadPageView();
            this.PageViewPageGeneral = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DefaultPrice = new Telerik.WinControls.UI.RadTextBox();
            this.TariffName = new Telerik.WinControls.UI.RadTextBox();
            this.IdTariff = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.PageViewPageScale = new Telerik.WinControls.UI.RadPageViewPage();
            this.TariffScaleGrid = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.AddTariffScale = new Telerik.WinControls.UI.RadButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CnlButton = new Telerik.WinControls.UI.RadButton();
            this.ОкButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.MainPageView)).BeginInit();
            this.MainPageView.SuspendLayout();
            this.PageViewPageGeneral.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TariffName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdTariff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.PageViewPageScale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TariffScaleGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TariffScaleGrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AddTariffScale)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ОкButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPageView
            // 
            this.MainPageView.Controls.Add(this.PageViewPageGeneral);
            this.MainPageView.Controls.Add(this.PageViewPageScale);
            this.MainPageView.DefaultPage = this.PageViewPageGeneral;
            this.MainPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPageView.Location = new System.Drawing.Point(5, 5);
            this.MainPageView.Name = "MainPageView";
            this.MainPageView.SelectedPage = this.PageViewPageGeneral;
            this.MainPageView.Size = new System.Drawing.Size(627, 308);
            this.MainPageView.TabIndex = 0;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.MainPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            // 
            // PageViewPageGeneral
            // 
            this.PageViewPageGeneral.Controls.Add(this.tableLayoutPanel1);
            this.PageViewPageGeneral.ItemSize = new System.Drawing.SizeF(125F, 28F);
            this.PageViewPageGeneral.Location = new System.Drawing.Point(10, 37);
            this.PageViewPageGeneral.Name = "PageViewPageGeneral";
            this.PageViewPageGeneral.Size = new System.Drawing.Size(606, 260);
            this.PageViewPageGeneral.Text = "Загальна Інформація";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.DefaultPrice, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.TariffName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.IdTariff, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.radLabel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.radLabel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.radLabel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 260);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // DefaultPrice
            // 
            this.DefaultPrice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DefaultPrice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DefaultPrice.Location = new System.Drawing.Point(306, 175);
            this.DefaultPrice.MaxLength = 50;
            this.DefaultPrice.Name = "DefaultPrice";
            this.DefaultPrice.Size = new System.Drawing.Size(297, 82);
            this.DefaultPrice.TabIndex = 11;
            this.DefaultPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TariffName
            // 
            this.TariffName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TariffName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TariffName.Location = new System.Drawing.Point(306, 89);
            this.TariffName.MaxLength = 50;
            this.TariffName.Name = "TariffName";
            this.TariffName.Size = new System.Drawing.Size(297, 80);
            this.TariffName.TabIndex = 10;
            this.TariffName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // IdTariff
            // 
            this.IdTariff.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IdTariff.Location = new System.Drawing.Point(306, 3);
            this.IdTariff.Name = "IdTariff";
            this.IdTariff.Size = new System.Drawing.Size(70, 25);
            this.IdTariff.TabIndex = 9;
            this.IdTariff.Text = "IdDevice";
            // 
            // radLabel1
            // 
            this.radLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel1.Location = new System.Drawing.Point(218, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(82, 25);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Id Тарифа";
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel2.Location = new System.Drawing.Point(187, 89);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(113, 25);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Назва Тарифа";
            // 
            // radLabel3
            // 
            this.radLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel3.Location = new System.Drawing.Point(111, 175);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(189, 25);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Ціна За Замовчуванням";
            // 
            // PageViewPageScale
            // 
            this.PageViewPageScale.Controls.Add(this.TariffScaleGrid);
            this.PageViewPageScale.Controls.Add(this.radPanel1);
            this.PageViewPageScale.ItemSize = new System.Drawing.SizeF(90F, 28F);
            this.PageViewPageScale.Location = new System.Drawing.Point(10, 37);
            this.PageViewPageScale.Name = "PageViewPageScale";
            this.PageViewPageScale.Size = new System.Drawing.Size(606, 260);
            this.PageViewPageScale.Text = "Тарифна Сітка";
            // 
            // TariffScaleGrid
            // 
            this.TariffScaleGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.TariffScaleGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.TariffScaleGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TariffScaleGrid.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.TariffScaleGrid.ForeColor = System.Drawing.Color.Black;
            this.TariffScaleGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TariffScaleGrid.Location = new System.Drawing.Point(0, 49);
            // 
            // 
            // 
            this.TariffScaleGrid.MasterTemplate.AllowAddNewRow = false;
            this.TariffScaleGrid.MasterTemplate.AllowDeleteRow = false;
            this.TariffScaleGrid.MasterTemplate.AllowEditRow = false;
            this.TariffScaleGrid.MasterTemplate.AutoGenerateColumns = false;
            this.TariffScaleGrid.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "IdTariffScale";
            gridViewTextBoxColumn5.HeaderText = "IdTariffScale";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "IdTariffScale";
            gridViewTextBoxColumn5.Width = 386;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "PeriodName";
            gridViewTextBoxColumn6.HeaderText = "Період";
            gridViewTextBoxColumn6.MinWidth = 200;
            gridViewTextBoxColumn6.Name = "PeriodName";
            gridViewTextBoxColumn6.Width = 201;
            gridViewTextBoxColumn7.DataType = typeof(double);
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Price";
            gridViewTextBoxColumn7.FormatString = "{0:#\',\'##}";
            gridViewTextBoxColumn7.HeaderText = "Ціна";
            gridViewTextBoxColumn7.MaxWidth = 100;
            gridViewTextBoxColumn7.MinWidth = 100;
            gridViewTextBoxColumn7.Name = "Price";
            gridViewTextBoxColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn7.Width = 100;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "DaysOfWeek";
            gridViewTextBoxColumn8.HeaderText = "Дні тижня";
            gridViewTextBoxColumn8.MaxWidth = 150;
            gridViewTextBoxColumn8.MinWidth = 150;
            gridViewTextBoxColumn8.Name = "DaysOfWeek";
            gridViewTextBoxColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn8.Width = 150;
            gridViewCommandColumn2.EnableExpressionEditor = false;
            gridViewCommandColumn2.FieldName = "Delete";
            gridViewCommandColumn2.HeaderText = "Дія";
            gridViewCommandColumn2.Name = "Delete";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.Width = 157;
            this.TariffScaleGrid.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewCommandColumn2});
            this.TariffScaleGrid.MasterTemplate.EnableGrouping = false;
            this.TariffScaleGrid.MasterTemplate.ShowRowHeaderColumn = false;
            this.TariffScaleGrid.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.TariffScaleGrid.Name = "TariffScaleGrid";
            this.TariffScaleGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TariffScaleGrid.Size = new System.Drawing.Size(606, 211);
            this.TariffScaleGrid.TabIndex = 7;
            this.TariffScaleGrid.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.TariffScaleGrid_CommandCellClick);
            this.TariffScaleGrid.DoubleClick += new System.EventHandler(this.TariffScaleGrid_DoubleClick);
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.AddTariffScale);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Margin = new System.Windows.Forms.Padding(5);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Padding = new System.Windows.Forms.Padding(2);
            this.radPanel1.Size = new System.Drawing.Size(606, 49);
            this.radPanel1.TabIndex = 6;
            // 
            // AddTariffScale
            // 
            this.AddTariffScale.Location = new System.Drawing.Point(5, 6);
            this.AddTariffScale.Name = "AddTariffScale";
            this.AddTariffScale.Size = new System.Drawing.Size(158, 29);
            this.AddTariffScale.TabIndex = 0;
            this.AddTariffScale.Text = "Додати cітку";
            this.AddTariffScale.Click += new System.EventHandler(this.AddTariffScale_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.CnlButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ОкButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 313);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(627, 53);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // CnlButton
            // 
            this.CnlButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CnlButton.Location = new System.Drawing.Point(316, 3);
            this.CnlButton.Name = "CnlButton";
            this.CnlButton.Size = new System.Drawing.Size(308, 47);
            this.CnlButton.TabIndex = 1;
            this.CnlButton.Text = "Скасувати";
            // 
            // ОкButton
            // 
            this.ОкButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ОкButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ОкButton.Location = new System.Drawing.Point(3, 3);
            this.ОкButton.Name = "ОкButton";
            this.ОкButton.Size = new System.Drawing.Size(307, 47);
            this.ОкButton.TabIndex = 0;
            this.ОкButton.Text = "Ок";
            // 
            // TariffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 371);
            this.Controls.Add(this.MainPageView);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TariffForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тариф";
            ((System.ComponentModel.ISupportInitialize)(this.MainPageView)).EndInit();
            this.MainPageView.ResumeLayout(false);
            this.PageViewPageGeneral.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DefaultPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TariffName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IdTariff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.PageViewPageScale.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TariffScaleGrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TariffScaleGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AddTariffScale)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ОкButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView MainPageView;
        private Telerik.WinControls.UI.RadPageViewPage PageViewPageGeneral;
        private Telerik.WinControls.UI.RadPageViewPage PageViewPageScale;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadButton CnlButton;
        private Telerik.WinControls.UI.RadButton ОкButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel IdTariff;
        private Telerik.WinControls.UI.RadTextBox DefaultPrice;
        private Telerik.WinControls.UI.RadTextBox TariffName;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadButton AddTariffScale;
        private Telerik.WinControls.UI.RadGridView TariffScaleGrid;
    }
}
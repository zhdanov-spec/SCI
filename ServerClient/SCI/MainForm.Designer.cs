namespace ZPSoft.GameZone.SCI
{
    partial class MainForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn3 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn4 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new Telerik.WinControls.UI.RadMenu();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            this.MenuItemSettings = new Telerik.WinControls.UI.RadMenuItem();
            this.serviceGridView = new Telerik.WinControls.UI.RadGridView();
            this.radStatusStrip1 = new Telerik.WinControls.UI.RadStatusStrip();
            this.LicenseElement = new Telerik.WinControls.UI.RadLabelElement();
            this.PageViewSelector = new Telerik.WinControls.UI.RadPageView();
            this.PageViewServer = new Telerik.WinControls.UI.RadPageViewPage();
            this.PageViewClient = new Telerik.WinControls.UI.RadPageViewPage();
            this.deviceGridView = new Telerik.WinControls.UI.RadGridView();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ClientInfoLabel = new Telerik.WinControls.UI.RadLabel();
            this.GlobalsDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlDeleteCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlInsertCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlSelectCommand1 = new System.Data.SqlClient.SqlCommand();
            this.sqlUpdateCommand1 = new System.Data.SqlClient.SqlCommand();
            this.SareaDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
            this.sqlCommand25 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand26 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand27 = new System.Data.SqlClient.SqlCommand();
            this.sqlCommand28 = new System.Data.SqlClient.SqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.MainMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceGridView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageViewSelector)).BeginInit();
            this.PageViewSelector.SuspendLayout();
            this.PageViewServer.SuspendLayout();
            this.PageViewClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.deviceGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceGridView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.radPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientInfoLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.radMenuItem2});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1051, 20);
            this.MainMenu.TabIndex = 0;
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "Файл";
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.MenuItemSettings});
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "Опції";
            // 
            // MenuItemSettings
            // 
            this.MenuItemSettings.Name = "MenuItemSettings";
            this.MenuItemSettings.Text = "Налаштування";
            this.MenuItemSettings.Click += new System.EventHandler(this.MenuItemSettings_Click);
            // 
            // serviceGridView
            // 
            this.serviceGridView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.serviceGridView.Cursor = System.Windows.Forms.Cursors.Default;
            this.serviceGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.serviceGridView.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.serviceGridView.ForeColor = System.Drawing.Color.Black;
            this.serviceGridView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.serviceGridView.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.serviceGridView.MasterTemplate.AllowAddNewRow = false;
            this.serviceGridView.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.serviceGridView.MasterTemplate.AllowColumnReorder = false;
            this.serviceGridView.MasterTemplate.AllowDeleteRow = false;
            this.serviceGridView.MasterTemplate.AllowDragToGroup = false;
            this.serviceGridView.MasterTemplate.AllowEditRow = false;
            this.serviceGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.HeaderText = "ServiceId";
            gridViewTextBoxColumn11.IsVisible = false;
            gridViewTextBoxColumn11.Name = "ServiceId";
            gridViewTextBoxColumn11.Width = 328;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.HeaderText = "Назва Сервісу";
            gridViewTextBoxColumn12.MaxWidth = 200;
            gridViewTextBoxColumn12.Name = "ServiceName";
            gridViewTextBoxColumn12.Width = 192;
            gridViewImageColumn3.HeaderText = "Статус";
            gridViewImageColumn3.Name = "ServiceStatus";
            gridViewImageColumn3.Width = 48;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.HeaderText = "Остання подія сервісу";
            gridViewTextBoxColumn13.Name = "ServiceLastLog";
            gridViewTextBoxColumn13.Width = 791;
            this.serviceGridView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewImageColumn3,
            gridViewTextBoxColumn13});
            this.serviceGridView.MasterTemplate.EnableSorting = false;
            this.serviceGridView.MasterTemplate.ShowRowHeaderColumn = false;
            this.serviceGridView.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.serviceGridView.Name = "serviceGridView";
            this.serviceGridView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.serviceGridView.ShowGroupPanel = false;
            this.serviceGridView.Size = new System.Drawing.Size(1030, 431);
            this.serviceGridView.TabIndex = 2;
            // 
            // radStatusStrip1
            // 
            this.radStatusStrip1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.LicenseElement});
            this.radStatusStrip1.Location = new System.Drawing.Point(0, 499);
            this.radStatusStrip1.Name = "radStatusStrip1";
            this.radStatusStrip1.Size = new System.Drawing.Size(1051, 26);
            this.radStatusStrip1.TabIndex = 2;
            // 
            // LicenseElement
            // 
            this.LicenseElement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.LicenseElement.BorderHighlightColor = System.Drawing.Color.White;
            this.LicenseElement.Name = "LicenseElement";
            this.radStatusStrip1.SetSpring(this.LicenseElement, false);
            this.LicenseElement.Text = "Очікування ліцензіі";
            this.LicenseElement.TextWrap = true;
            // 
            // PageViewSelector
            // 
            this.PageViewSelector.Controls.Add(this.PageViewServer);
            this.PageViewSelector.Controls.Add(this.PageViewClient);
            this.PageViewSelector.DefaultPage = this.PageViewServer;
            this.PageViewSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageViewSelector.Location = new System.Drawing.Point(0, 20);
            this.PageViewSelector.Name = "PageViewSelector";
            this.PageViewSelector.SelectedPage = this.PageViewClient;
            this.PageViewSelector.Size = new System.Drawing.Size(1051, 479);
            this.PageViewSelector.TabIndex = 0;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageViewSelector.GetChildAt(0))).ShowItemPinButton = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageViewSelector.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageViewSelector.GetChildAt(0))).ItemAlignment = Telerik.WinControls.UI.StripViewItemAlignment.Near;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageViewSelector.GetChildAt(0))).StripAlignment = Telerik.WinControls.UI.StripViewAlignment.Top;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.PageViewSelector.GetChildAt(0))).ShowItemCloseButton = false;
            // 
            // PageViewServer
            // 
            this.PageViewServer.Controls.Add(this.serviceGridView);
            this.PageViewServer.ItemSize = new System.Drawing.SizeF(54F, 28F);
            this.PageViewServer.Location = new System.Drawing.Point(10, 37);
            this.PageViewServer.Name = "PageViewServer";
            this.PageViewServer.Size = new System.Drawing.Size(1030, 431);
            this.PageViewServer.Text = "Сервер";
            // 
            // PageViewClient
            // 
            this.PageViewClient.Controls.Add(this.deviceGridView);
            this.PageViewClient.Controls.Add(this.radPanel1);
            this.PageViewClient.ItemSize = new System.Drawing.SizeF(48F, 28F);
            this.PageViewClient.Location = new System.Drawing.Point(10, 37);
            this.PageViewClient.Name = "PageViewClient";
            this.PageViewClient.Size = new System.Drawing.Size(1030, 431);
            this.PageViewClient.Text = "Клієнт";
            // 
            // deviceGridView
            // 
            this.deviceGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deviceGridView.Location = new System.Drawing.Point(0, 42);
            // 
            // 
            // 
            this.deviceGridView.MasterTemplate.AllowAddNewRow = false;
            this.deviceGridView.MasterTemplate.AllowCellContextMenu = false;
            this.deviceGridView.MasterTemplate.AllowEditRow = false;
            this.deviceGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn14.HeaderText = "№";
            gridViewTextBoxColumn14.MaxWidth = 50;
            gridViewTextBoxColumn14.MinWidth = 50;
            gridViewTextBoxColumn14.Name = "IdDevice";
            gridViewTextBoxColumn14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn15.HeaderText = "Автомат";
            gridViewTextBoxColumn15.MaxWidth = 250;
            gridViewTextBoxColumn15.MinWidth = 250;
            gridViewTextBoxColumn15.Name = "devicename";
            gridViewTextBoxColumn15.Width = 250;
            gridViewTextBoxColumn16.HeaderText = "IP";
            gridViewTextBoxColumn16.MaxWidth = 150;
            gridViewTextBoxColumn16.MinWidth = 150;
            gridViewTextBoxColumn16.Name = "IpAddress";
            gridViewTextBoxColumn16.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn16.Width = 150;
            gridViewImageColumn4.HeaderText = "Статус";
            gridViewImageColumn4.MaxWidth = 75;
            gridViewImageColumn4.MinWidth = 75;
            gridViewImageColumn4.Name = "Status";
            gridViewImageColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewImageColumn4.Width = 75;
            gridViewTextBoxColumn17.HeaderText = "Группа Автоматів";
            gridViewTextBoxColumn17.MaxWidth = 150;
            gridViewTextBoxColumn17.MinWidth = 150;
            gridViewTextBoxColumn17.Name = "GroupDeviceName";
            gridViewTextBoxColumn17.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn17.Width = 150;
            gridViewTextBoxColumn18.HeaderText = "Тариф";
            gridViewTextBoxColumn18.MaxWidth = 150;
            gridViewTextBoxColumn18.MinWidth = 150;
            gridViewTextBoxColumn18.Name = "TariffName";
            gridViewTextBoxColumn18.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn18.Width = 150;
            gridViewTextBoxColumn18.WrapText = true;
            gridViewTextBoxColumn19.HeaderText = "Час Події";
            gridViewTextBoxColumn19.MaxWidth = 150;
            gridViewTextBoxColumn19.MinWidth = 150;
            gridViewTextBoxColumn19.Name = "ActionTime";
            gridViewTextBoxColumn19.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn19.Width = 150;
            gridViewTextBoxColumn20.HeaderText = "Остання подія";
            gridViewTextBoxColumn20.Name = "LastLog";
            gridViewTextBoxColumn20.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewTextBoxColumn20.Width = 61;
            gridViewTextBoxColumn20.WrapText = true;
            this.deviceGridView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewImageColumn4,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20});
            this.deviceGridView.MasterTemplate.EnableGrouping = false;
            this.deviceGridView.MasterTemplate.ShowRowHeaderColumn = false;
            this.deviceGridView.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.deviceGridView.Name = "deviceGridView";
            this.deviceGridView.ShowGroupPanel = false;
            this.deviceGridView.ShowRowErrors = false;
            this.deviceGridView.Size = new System.Drawing.Size(1030, 389);
            this.deviceGridView.TabIndex = 23;
            // 
            // radPanel1
            // 
            this.radPanel1.Controls.Add(this.tableLayoutPanel1);
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(1030, 42);
            this.radPanel1.TabIndex = 24;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ClientInfoLabel, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1030, 42);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ClientInfoLabel
            // 
            this.ClientInfoLabel.AutoSize = false;
            this.ClientInfoLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientInfoLabel.Location = new System.Drawing.Point(518, 3);
            this.ClientInfoLabel.Name = "ClientInfoLabel";
            this.ClientInfoLabel.Size = new System.Drawing.Size(509, 36);
            this.ClientInfoLabel.TabIndex = 0;
            this.ClientInfoLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GlobalsDataAdapter
            // 
            this.GlobalsDataAdapter.DeleteCommand = this.sqlDeleteCommand1;
            this.GlobalsDataAdapter.InsertCommand = this.sqlInsertCommand1;
            this.GlobalsDataAdapter.SelectCommand = this.sqlSelectCommand1;
            this.GlobalsDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Globals", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("GlobalsValue", "GlobalsValue"),
                        new System.Data.Common.DataColumnMapping("GlobalsKey", "GlobalsKey"),
                        new System.Data.Common.DataColumnMapping("Description", "Description")})});
            this.GlobalsDataAdapter.UpdateCommand = this.sqlUpdateCommand1;
            // 
            // sqlDeleteCommand1
            // 
            this.sqlDeleteCommand1.CommandText = resources.GetString("sqlDeleteCommand1.CommandText");
            this.sqlDeleteCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@IsNull_GlobalsValue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GlobalsValue", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_GlobalsValue", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GlobalsValue", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_GlobalsKey", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GlobalsKey", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Description", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Description", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlInsertCommand1
            // 
            this.sqlInsertCommand1.CommandText = resources.GetString("sqlInsertCommand1.CommandText");
            this.sqlInsertCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@GlobalsValue", System.Data.SqlDbType.VarChar, 0, "GlobalsValue"),
            new System.Data.SqlClient.SqlParameter("@GlobalsKey", System.Data.SqlDbType.VarChar, 0, "GlobalsKey"),
            new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 0, "Description")});
            // 
            // sqlSelectCommand1
            // 
            this.sqlSelectCommand1.CommandText = "SELECT        Globals.*\r\nFROM            Globals";
            // 
            // sqlUpdateCommand1
            // 
            this.sqlUpdateCommand1.CommandText = resources.GetString("sqlUpdateCommand1.CommandText");
            this.sqlUpdateCommand1.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@GlobalsValue", System.Data.SqlDbType.VarChar, 0, "GlobalsValue"),
            new System.Data.SqlClient.SqlParameter("@GlobalsKey", System.Data.SqlDbType.VarChar, 0, "GlobalsKey"),
            new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.VarChar, 0, "Description"),
            new System.Data.SqlClient.SqlParameter("@IsNull_GlobalsValue", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "GlobalsValue", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_GlobalsValue", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GlobalsValue", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_GlobalsKey", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "GlobalsKey", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Description", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Description", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Description", System.Data.DataRowVersion.Original, null)});
            // 
            // SareaDataAdapter
            // 
            this.SareaDataAdapter.DeleteCommand = this.sqlCommand25;
            this.SareaDataAdapter.InsertCommand = this.sqlCommand26;
            this.SareaDataAdapter.SelectCommand = this.sqlCommand27;
            this.SareaDataAdapter.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "Sarea", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("SareaId", "SareaId"),
                        new System.Data.Common.DataColumnMapping("SareaName", "SareaName"),
                        new System.Data.Common.DataColumnMapping("IdCity", "IdCity"),
                        new System.Data.Common.DataColumnMapping("Visible", "Visible")})});
            this.SareaDataAdapter.UpdateCommand = this.sqlCommand28;
            // 
            // sqlCommand25
            // 
            this.sqlCommand25.CommandText = resources.GetString("sqlCommand25.CommandText");
            this.sqlCommand25.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@Original_SareaId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SareaId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_SareaName", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SareaName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_IdCity", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IdCity", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_IdCity", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IdCity", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Visible", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Visible", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Visible", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Visible", System.Data.DataRowVersion.Original, null)});
            // 
            // sqlCommand26
            // 
            this.sqlCommand26.CommandText = "INSERT INTO [Sarea] ([SareaId], [SareaName], [IdCity], [Visible]) VALUES (@SareaI" +
    "d, @SareaName, @IdCity, @Visible);\r\nSELECT SareaId, SareaName, IdCity, Visible F" +
    "ROM Sarea WHERE (SareaId = @SareaId)";
            this.sqlCommand26.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@SareaId", System.Data.SqlDbType.Int, 0, "SareaId"),
            new System.Data.SqlClient.SqlParameter("@SareaName", System.Data.SqlDbType.VarChar, 0, "SareaName"),
            new System.Data.SqlClient.SqlParameter("@IdCity", System.Data.SqlDbType.Int, 0, "IdCity"),
            new System.Data.SqlClient.SqlParameter("@Visible", System.Data.SqlDbType.Bit, 0, "Visible")});
            // 
            // sqlCommand27
            // 
            this.sqlCommand27.CommandText = "SELECT        Sarea.*\r\nFROM            Sarea";
            // 
            // sqlCommand28
            // 
            this.sqlCommand28.CommandText = resources.GetString("sqlCommand28.CommandText");
            this.sqlCommand28.Parameters.AddRange(new System.Data.SqlClient.SqlParameter[] {
            new System.Data.SqlClient.SqlParameter("@SareaId", System.Data.SqlDbType.Int, 0, "SareaId"),
            new System.Data.SqlClient.SqlParameter("@SareaName", System.Data.SqlDbType.VarChar, 0, "SareaName"),
            new System.Data.SqlClient.SqlParameter("@IdCity", System.Data.SqlDbType.Int, 0, "IdCity"),
            new System.Data.SqlClient.SqlParameter("@Visible", System.Data.SqlDbType.Bit, 0, "Visible"),
            new System.Data.SqlClient.SqlParameter("@Original_SareaId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SareaId", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@Original_SareaName", System.Data.SqlDbType.VarChar, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "SareaName", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_IdCity", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "IdCity", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_IdCity", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "IdCity", System.Data.DataRowVersion.Original, null),
            new System.Data.SqlClient.SqlParameter("@IsNull_Visible", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, ((byte)(0)), ((byte)(0)), "Visible", System.Data.DataRowVersion.Original, true, null, "", "", ""),
            new System.Data.SqlClient.SqlParameter("@Original_Visible", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "Visible", System.Data.DataRowVersion.Original, null)});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 525);
            this.Controls.Add(this.PageViewSelector);
            this.Controls.Add(this.radStatusStrip1);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Server-Client Card Zone";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.MainMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serviceGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radStatusStrip1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PageViewSelector)).EndInit();
            this.PageViewSelector.ResumeLayout(false);
            this.PageViewServer.ResumeLayout(false);
            this.PageViewClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.deviceGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.radPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ClientInfoLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadMenu MainMenu;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadGridView serviceGridView;
        private Telerik.WinControls.UI.RadStatusStrip radStatusStrip1;
        private Telerik.WinControls.UI.RadPageView PageViewSelector;
        private Telerik.WinControls.UI.RadPageViewPage PageViewServer;
        private Telerik.WinControls.UI.RadPageViewPage PageViewClient;
        private Telerik.WinControls.UI.RadLabelElement LicenseElement;
        private System.Data.SqlClient.SqlDataAdapter GlobalsDataAdapter;
        private System.Data.SqlClient.SqlCommand sqlDeleteCommand1;
        private System.Data.SqlClient.SqlCommand sqlInsertCommand1;
        private System.Data.SqlClient.SqlCommand sqlSelectCommand1;
        private System.Data.SqlClient.SqlCommand sqlUpdateCommand1;
        private Telerik.WinControls.UI.RadGridView deviceGridView;
        private Telerik.WinControls.UI.RadPanel radPanel1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
        private Telerik.WinControls.UI.RadMenuItem MenuItemSettings;
        private System.Data.SqlClient.SqlDataAdapter SareaDataAdapter;
        private System.Data.SqlClient.SqlCommand sqlCommand25;
        private System.Data.SqlClient.SqlCommand sqlCommand26;
        private System.Data.SqlClient.SqlCommand sqlCommand27;
        private System.Data.SqlClient.SqlCommand sqlCommand28;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadLabel ClientInfoLabel;
    }
}


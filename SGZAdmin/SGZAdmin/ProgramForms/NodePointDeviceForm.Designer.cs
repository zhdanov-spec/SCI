namespace ZPSoft.GameZone.SGZAdmin.ProgramForms
{
    partial class NodePointDeviceForm
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radPanel1 = new Telerik.WinControls.UI.RadPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CnlButton = new Telerik.WinControls.UI.RadButton();
            this.DeviceGridView = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceGridView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanel1
            // 
            this.radPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radPanel1.Location = new System.Drawing.Point(0, 0);
            this.radPanel1.Name = "radPanel1";
            this.radPanel1.Size = new System.Drawing.Size(908, 61);
            this.radPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.CnlButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 433);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(908, 53);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // CnlButton
            // 
            this.CnlButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CnlButton.Location = new System.Drawing.Point(3, 3);
            this.CnlButton.Name = "CnlButton";
            this.CnlButton.Size = new System.Drawing.Size(902, 47);
            this.CnlButton.TabIndex = 1;
            this.CnlButton.Text = "Скасувати";
            // 
            // DeviceGridView
            // 
            this.DeviceGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceGridView.Location = new System.Drawing.Point(0, 61);
            // 
            // 
            // 
            this.DeviceGridView.MasterTemplate.AllowAddNewRow = false;
            this.DeviceGridView.MasterTemplate.AllowCellContextMenu = false;
            this.DeviceGridView.MasterTemplate.AllowColumnChooser = false;
            this.DeviceGridView.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.DeviceGridView.MasterTemplate.AllowColumnReorder = false;
            this.DeviceGridView.MasterTemplate.AllowColumnResize = false;
            this.DeviceGridView.MasterTemplate.AllowDeleteRow = false;
            this.DeviceGridView.MasterTemplate.AllowDragToGroup = false;
            this.DeviceGridView.MasterTemplate.AllowEditRow = false;
            this.DeviceGridView.MasterTemplate.AllowRowHeaderContextMenu = false;
            this.DeviceGridView.MasterTemplate.AllowRowResize = false;
            this.DeviceGridView.MasterTemplate.AutoGenerateColumns = false;
            this.DeviceGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn3.FieldName = "IdDevice";
            gridViewTextBoxColumn3.HeaderText = "IdDevice";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "IdDevice";
            gridViewTextBoxColumn3.Width = 303;
            gridViewTextBoxColumn4.FieldName = "DeviceName";
            gridViewTextBoxColumn4.HeaderText = "Назва Пристрою";
            gridViewTextBoxColumn4.Name = "DeviceName";
            gridViewTextBoxColumn4.Width = 454;
            gridViewCommandColumn2.DefaultText = "Обрати";
            gridViewCommandColumn2.FieldName = "SelectItem";
            gridViewCommandColumn2.HeaderText = "Дія";
            gridViewCommandColumn2.Name = "SelectItem";
            gridViewCommandColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 454;
            this.DeviceGridView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCommandColumn2});
            this.DeviceGridView.MasterTemplate.EnableGrouping = false;
            this.DeviceGridView.MasterTemplate.ShowRowHeaderColumn = false;
            this.DeviceGridView.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.DeviceGridView.Name = "DeviceGridView";
            this.DeviceGridView.ShowGroupPanel = false;
            this.DeviceGridView.Size = new System.Drawing.Size(908, 372);
            this.DeviceGridView.TabIndex = 3;
            this.DeviceGridView.CommandCellClick += new Telerik.WinControls.UI.CommandCellClickEventHandler(this.DeviceGridView_CommandCellClick);
            // 
            // NodePointDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 486);
            this.Controls.Add(this.DeviceGridView);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.radPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NodePointDeviceForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Обрання пристрою для додавання до станції пристроїв ";
            ((System.ComponentModel.ISupportInitialize)(this.radPanel1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel radPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadButton CnlButton;
        private Telerik.WinControls.UI.RadGridView DeviceGridView;
    }
}
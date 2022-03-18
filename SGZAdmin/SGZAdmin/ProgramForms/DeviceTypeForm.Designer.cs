namespace ZPSoft.GameZone.SGZAdmin.ProgramForms
{
    partial class DeviceTypeForm
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
            this.RadioRemotingDeivice = new Telerik.WinControls.UI.RadRadioButton();
            this.RadioAttraction = new Telerik.WinControls.UI.RadRadioButton();
            this.RadioService = new Telerik.WinControls.UI.RadRadioButton();
            this.MainPageView = new Telerik.WinControls.UI.RadPageView();
            this.PageViewRemotingDeivice = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.IpAddress = new Telerik.WinControls.UI.RadTextBox();
            this.TimeDTR = new Telerik.WinControls.UI.RadTextBox();
            this.PageViewAttraction = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.UnlimTime = new Telerik.WinControls.UI.RadToggleButton();
            this.GameTime = new Telerik.WinControls.UI.RadTextBox();
            this.PageViewService = new Telerik.WinControls.UI.RadPageViewPage();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.CnlButton = new Telerik.WinControls.UI.RadButton();
            this.ОкButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.RadioRemotingDeivice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioAttraction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioService)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPageView)).BeginInit();
            this.MainPageView.SuspendLayout();
            this.PageViewRemotingDeivice.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IpAddress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDTR)).BeginInit();
            this.PageViewAttraction.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnlimTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameTime)).BeginInit();
            this.PageViewService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ОкButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // RadioRemotingDeivice
            // 
            this.RadioRemotingDeivice.AutoSize = false;
            this.RadioRemotingDeivice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.RadioRemotingDeivice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioRemotingDeivice.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RadioRemotingDeivice.Location = new System.Drawing.Point(3, 3);
            this.RadioRemotingDeivice.Name = "RadioRemotingDeivice";
            this.RadioRemotingDeivice.RadioCheckAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.RadioRemotingDeivice.Size = new System.Drawing.Size(180, 48);
            this.RadioRemotingDeivice.TabIndex = 0;
            this.RadioRemotingDeivice.Text = "Віддалений пристрій";
            this.RadioRemotingDeivice.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.RadioRemotingDeivice.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.RadioRemotingDeivice.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
            // 
            // RadioAttraction
            // 
            this.RadioAttraction.AutoSize = false;
            this.RadioAttraction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioAttraction.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RadioAttraction.Location = new System.Drawing.Point(189, 3);
            this.RadioAttraction.Name = "RadioAttraction";
            this.RadioAttraction.RadioCheckAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.RadioAttraction.Size = new System.Drawing.Size(180, 48);
            this.RadioAttraction.TabIndex = 1;
            this.RadioAttraction.TabStop = false;
            this.RadioAttraction.Text = "Атракціон";
            this.RadioAttraction.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.RadioAttraction.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
            // 
            // RadioService
            // 
            this.RadioService.AutoSize = false;
            this.RadioService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioService.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RadioService.Location = new System.Drawing.Point(375, 3);
            this.RadioService.Name = "RadioService";
            this.RadioService.RadioCheckAlignment = System.Drawing.ContentAlignment.BottomCenter;
            this.RadioService.Size = new System.Drawing.Size(181, 48);
            this.RadioService.TabIndex = 2;
            this.RadioService.TabStop = false;
            this.RadioService.Text = "Послуга";
            this.RadioService.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.RadioService.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
            // 
            // MainPageView
            // 
            this.MainPageView.Controls.Add(this.PageViewRemotingDeivice);
            this.MainPageView.Controls.Add(this.PageViewAttraction);
            this.MainPageView.Controls.Add(this.PageViewService);
            this.MainPageView.DefaultPage = this.PageViewRemotingDeivice;
            this.MainPageView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPageView.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainPageView.Location = new System.Drawing.Point(5, 59);
            this.MainPageView.Name = "MainPageView";
            this.MainPageView.SelectedPage = this.PageViewAttraction;
            this.MainPageView.Size = new System.Drawing.Size(559, 187);
            this.MainPageView.TabIndex = 3;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.MainPageView.GetChildAt(0))).StripButtons = Telerik.WinControls.UI.StripViewButtons.None;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.MainPageView.GetChildAt(0))).ShowItemCloseButton = false;
            // 
            // PageViewRemotingDeivice
            // 
            this.PageViewRemotingDeivice.Controls.Add(this.tableLayoutPanel3);
            this.PageViewRemotingDeivice.ItemSize = new System.Drawing.SizeF(349F, 35F);
            this.PageViewRemotingDeivice.Location = new System.Drawing.Point(10, 44);
            this.PageViewRemotingDeivice.Name = "PageViewRemotingDeivice";
            this.PageViewRemotingDeivice.Size = new System.Drawing.Size(538, 132);
            this.PageViewRemotingDeivice.Text = "Налаштування Для Віддаленного Пристрою";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.radLabel5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.radLabel7, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.IpAddress, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.TimeDTR, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(538, 132);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // radLabel5
            // 
            this.radLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel5.Location = new System.Drawing.Point(186, 3);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(80, 25);
            this.radLabel5.TabIndex = 6;
            this.radLabel5.Text = "IP Адреса";
            // 
            // radLabel7
            // 
            this.radLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel7.Location = new System.Drawing.Point(91, 69);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(175, 25);
            this.radLabel7.TabIndex = 13;
            this.radLabel7.Text = "Час Замкнення Рідера";
            // 
            // IpAddress
            // 
            this.IpAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IpAddress.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IpAddress.Location = new System.Drawing.Point(272, 3);
            this.IpAddress.MaxLength = 15;
            this.IpAddress.Name = "IpAddress";
            this.IpAddress.Size = new System.Drawing.Size(263, 27);
            this.IpAddress.TabIndex = 12;
            this.IpAddress.Text = "127.0.0.1";
            this.IpAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TimeDTR
            // 
            this.TimeDTR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TimeDTR.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimeDTR.Location = new System.Drawing.Point(272, 69);
            this.TimeDTR.MaxLength = 50;
            this.TimeDTR.Name = "TimeDTR";
            this.TimeDTR.Size = new System.Drawing.Size(263, 27);
            this.TimeDTR.TabIndex = 14;
            this.TimeDTR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PageViewAttraction
            // 
            this.PageViewAttraction.Controls.Add(this.tableLayoutPanel4);
            this.PageViewAttraction.ItemSize = new System.Drawing.SizeF(249F, 35F);
            this.PageViewAttraction.Location = new System.Drawing.Point(10, 44);
            this.PageViewAttraction.Name = "PageViewAttraction";
            this.PageViewAttraction.Size = new System.Drawing.Size(538, 132);
            this.PageViewAttraction.Text = "Налаштування Для Атракціону";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.UnlimTime, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.GameTime, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(538, 132);
            this.tableLayoutPanel4.TabIndex = 18;
            // 
            // UnlimTime
            // 
            this.UnlimTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnlimTime.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UnlimTime.Location = new System.Drawing.Point(3, 3);
            this.UnlimTime.Name = "UnlimTime";
            this.UnlimTime.Size = new System.Drawing.Size(532, 60);
            this.UnlimTime.TabIndex = 16;
            this.UnlimTime.Text = "Гра Безлімітна";
            this.UnlimTime.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.UnlimTime_ToggleStateChanged);
            // 
            // GameTime
            // 
            this.GameTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameTime.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GameTime.Location = new System.Drawing.Point(3, 69);
            this.GameTime.Name = "GameTime";
            this.GameTime.NullText = "Введіть час гри(в хвилинах)";
            this.GameTime.Size = new System.Drawing.Size(532, 60);
            this.GameTime.TabIndex = 17;
            this.GameTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PageViewService
            // 
            this.PageViewService.Controls.Add(this.radLabel1);
            this.PageViewService.ItemSize = new System.Drawing.SizeF(226F, 35F);
            this.PageViewService.Location = new System.Drawing.Point(10, 44);
            this.PageViewService.Name = "PageViewService";
            this.PageViewService.Size = new System.Drawing.Size(538, 132);
            this.PageViewService.Text = "Налаштування Для Послуги";
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel1.Location = new System.Drawing.Point(0, 0);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(538, 132);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Налаштувань Немає";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.RadioRemotingDeivice, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.RadioAttraction, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RadioService, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(559, 54);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.CnlButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.ОкButton, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 246);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(559, 53);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // CnlButton
            // 
            this.CnlButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CnlButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CnlButton.Location = new System.Drawing.Point(282, 3);
            this.CnlButton.Name = "CnlButton";
            this.CnlButton.Size = new System.Drawing.Size(274, 47);
            this.CnlButton.TabIndex = 1;
            this.CnlButton.Text = "Скасувати";
            // 
            // ОкButton
            // 
            this.ОкButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ОкButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ОкButton.Location = new System.Drawing.Point(3, 3);
            this.ОкButton.Name = "ОкButton";
            this.ОкButton.Size = new System.Drawing.Size(273, 47);
            this.ОкButton.TabIndex = 0;
            this.ОкButton.Text = "Ок";
            // 
            // DeviceTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 304);
            this.Controls.Add(this.MainPageView);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceTypeForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Тип Пристрою";
            ((System.ComponentModel.ISupportInitialize)(this.RadioRemotingDeivice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioAttraction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RadioService)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainPageView)).EndInit();
            this.MainPageView.ResumeLayout(false);
            this.PageViewRemotingDeivice.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IpAddress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeDTR)).EndInit();
            this.PageViewAttraction.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UnlimTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameTime)).EndInit();
            this.PageViewService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CnlButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ОкButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadRadioButton RadioRemotingDeivice;
        private Telerik.WinControls.UI.RadRadioButton RadioAttraction;
        private Telerik.WinControls.UI.RadRadioButton RadioService;
        private Telerik.WinControls.UI.RadPageView MainPageView;
        private Telerik.WinControls.UI.RadPageViewPage PageViewRemotingDeivice;
        private Telerik.WinControls.UI.RadPageViewPage PageViewAttraction;
        private Telerik.WinControls.UI.RadPageViewPage PageViewService;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Telerik.WinControls.UI.RadButton CnlButton;
        private Telerik.WinControls.UI.RadButton ОкButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox IpAddress;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadTextBox TimeDTR;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Telerik.WinControls.UI.RadToggleButton UnlimTime;
        private Telerik.WinControls.UI.RadTextBox GameTime;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
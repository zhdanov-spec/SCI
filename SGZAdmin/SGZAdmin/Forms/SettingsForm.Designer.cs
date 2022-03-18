namespace ZPSoft.GameZone.SGZAdmin.Forms
{
    partial class SettingsForm
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
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.PageViewConnect = new Telerik.WinControls.UI.RadPageViewPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.serverMaskedEditBox = new Telerik.WinControls.UI.RadTextBox();
            this.OkButton = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.PageViewConnect.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverMaskedEditBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.PageViewConnect);
            this.radPageView1.DefaultPage = this.PageViewConnect;
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
            this.radPageView1.Location = new System.Drawing.Point(5, 5);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.PageViewConnect;
            this.radPageView1.Size = new System.Drawing.Size(782, 520);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.ViewMode = Telerik.WinControls.UI.PageViewMode.NavigationView;
            ((Telerik.WinControls.UI.RadPageViewNavigationViewElement)(this.radPageView1.GetChildAt(0))).ItemSizeMode = ((Telerik.WinControls.UI.PageViewItemSizeMode)((Telerik.WinControls.UI.PageViewItemSizeMode.EqualWidth | Telerik.WinControls.UI.PageViewItemSizeMode.EqualHeight)));
            ((Telerik.WinControls.Primitives.ImagePrimitive)(this.radPageView1.GetChildAt(0).GetChildAt(3).GetChildAt(1).GetChildAt(0))).AutoSize = true;
            // 
            // PageViewConnect
            // 
            this.PageViewConnect.Controls.Add(this.tableLayoutPanel1);
            this.PageViewConnect.Image = global::ZPSoft.GameZone.SGZAdmin.Properties.Resources.server;
            this.PageViewConnect.ItemSize = new System.Drawing.SizeF(74F, 74F);
            this.PageViewConnect.Location = new System.Drawing.Point(75, 30);
            this.PageViewConnect.Name = "PageViewConnect";
            this.PageViewConnect.Size = new System.Drawing.Size(706, 489);
            this.PageViewConnect.Text = "Підключення";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.radLabel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.serverMaskedEditBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(706, 489);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // radLabel2
            // 
            this.radLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radLabel2.Location = new System.Drawing.Point(201, 3);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(149, 26);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "Адрес Сервера";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            // 
            // serverMaskedEditBox
            // 
            this.serverMaskedEditBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.serverMaskedEditBox.Location = new System.Drawing.Point(356, 3);
            this.serverMaskedEditBox.Name = "serverMaskedEditBox";
            this.serverMaskedEditBox.Size = new System.Drawing.Size(236, 31);
            this.serverMaskedEditBox.TabIndex = 7;
            this.serverMaskedEditBox.Text = "127.0.0.1";
            this.serverMaskedEditBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.serverMaskedEditBox.ThemeName = "Windows8";
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.OkButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OkButton.Location = new System.Drawing.Point(5, 525);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(782, 65);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "ОК";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 595);
            this.Controls.Add(this.radPageView1);
            this.Controls.Add(this.OkButton);
            this.Name = "SettingsForm";
            this.Padding = new System.Windows.Forms.Padding(5);
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Налаштування";
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.PageViewConnect.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.serverMaskedEditBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OkButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage PageViewConnect;
        private Telerik.WinControls.UI.RadButton OkButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox serverMaskedEditBox;
    }
}
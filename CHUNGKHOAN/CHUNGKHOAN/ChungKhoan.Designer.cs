namespace CHUNGKHOAN
{
    partial class ChungKhoan
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.maCP = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.duMua = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.giam2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.kLm2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.giam1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.kLm1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.khopLenh = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.giaKhop = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.kLKhop = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.duBan = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.giaB1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.kLB1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.giaB2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.kLB2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gridControl2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(752, 100);
            this.panel1.TabIndex = 0;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(752, 100);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(752, 235);
            this.panel2.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(752, 235);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1,
            this.gridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.maCP,
            this.duMua,
            this.khopLenh,
            this.duBan});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // maCP
            // 
            this.maCP.AppearanceHeader.Options.UseTextOptions = true;
            this.maCP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.maCP.Caption = "Ma CP";
            this.maCP.Name = "maCP";
            this.maCP.OptionsBand.FixedWidth = true;
            this.maCP.VisibleIndex = 0;
            // 
            // duMua
            // 
            this.duMua.AppearanceHeader.Options.UseTextOptions = true;
            this.duMua.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.duMua.Caption = "DƯ MUA";
            this.duMua.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.giam2,
            this.kLm2,
            this.giam1,
            this.kLm1});
            this.duMua.Name = "duMua";
            this.duMua.VisibleIndex = 1;
            this.duMua.Width = 280;
            // 
            // giam2
            // 
            this.giam2.AppearanceHeader.Options.UseTextOptions = true;
            this.giam2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.giam2.Caption = "Giá 2";
            this.giam2.Name = "giam2";
            this.giam2.VisibleIndex = 0;
            this.giam2.Width = 68;
            // 
            // kLm2
            // 
            this.kLm2.AppearanceHeader.Options.UseTextOptions = true;
            this.kLm2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.kLm2.Caption = "KL 2";
            this.kLm2.Name = "kLm2";
            this.kLm2.VisibleIndex = 1;
            this.kLm2.Width = 68;
            // 
            // giam1
            // 
            this.giam1.AppearanceHeader.Options.UseTextOptions = true;
            this.giam1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.giam1.Caption = "Giá 1";
            this.giam1.Name = "giam1";
            this.giam1.VisibleIndex = 2;
            this.giam1.Width = 68;
            // 
            // kLm1
            // 
            this.kLm1.AppearanceHeader.Options.UseTextOptions = true;
            this.kLm1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.kLm1.Caption = "KL 1";
            this.kLm1.Name = "kLm1";
            this.kLm1.VisibleIndex = 3;
            this.kLm1.Width = 76;
            // 
            // khopLenh
            // 
            this.khopLenh.AppearanceHeader.Options.UseTextOptions = true;
            this.khopLenh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.khopLenh.Caption = "KHỚP LỆNH";
            this.khopLenh.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.giaKhop,
            this.kLKhop});
            this.khopLenh.Name = "khopLenh";
            this.khopLenh.VisibleIndex = 2;
            this.khopLenh.Width = 185;
            // 
            // giaKhop
            // 
            this.giaKhop.AppearanceHeader.Options.UseTextOptions = true;
            this.giaKhop.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.giaKhop.Caption = "Giá Khớp";
            this.giaKhop.Name = "giaKhop";
            this.giaKhop.VisibleIndex = 0;
            this.giaKhop.Width = 90;
            // 
            // kLKhop
            // 
            this.kLKhop.AppearanceHeader.Options.UseTextOptions = true;
            this.kLKhop.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.kLKhop.Caption = "KL Khớp";
            this.kLKhop.Name = "kLKhop";
            this.kLKhop.VisibleIndex = 1;
            this.kLKhop.Width = 95;
            // 
            // duBan
            // 
            this.duBan.AppearanceHeader.Options.UseTextOptions = true;
            this.duBan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.duBan.Caption = "DƯ BÁN";
            this.duBan.Children.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.giaB1,
            this.kLB1,
            this.giaB2,
            this.kLB2});
            this.duBan.Name = "duBan";
            this.duBan.VisibleIndex = 3;
            this.duBan.Width = 225;
            // 
            // giaB1
            // 
            this.giaB1.AppearanceHeader.Options.UseTextOptions = true;
            this.giaB1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.giaB1.Caption = "Giá 1";
            this.giaB1.Name = "giaB1";
            this.giaB1.VisibleIndex = 0;
            this.giaB1.Width = 51;
            // 
            // kLB1
            // 
            this.kLB1.AppearanceHeader.Options.UseTextOptions = true;
            this.kLB1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.kLB1.Caption = "KL 1";
            this.kLB1.Name = "kLB1";
            this.kLB1.VisibleIndex = 1;
            this.kLB1.Width = 51;
            // 
            // giaB2
            // 
            this.giaB2.AppearanceHeader.Options.UseTextOptions = true;
            this.giaB2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.giaB2.Caption = "Giá 2";
            this.giaB2.Name = "giaB2";
            this.giaB2.VisibleIndex = 2;
            this.giaB2.Width = 51;
            // 
            // kLB2
            // 
            this.kLB2.AppearanceHeader.Options.UseTextOptions = true;
            this.kLB2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.kLB2.Caption = "KL 2";
            this.kLB2.Name = "kLB2";
            this.kLB2.VisibleIndex = 3;
            this.kLB2.Width = 72;
            // 
            // ChungKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 335);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ChungKhoan";
            this.Text = "ChungKhoan";
            this.Load += new System.EventHandler(this.ChungKhoan_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand maCP;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand duMua;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand giam2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand kLm2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand giam1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand kLm1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand khopLenh;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand giaKhop;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand kLKhop;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand duBan;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand giaB1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand kLB1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand giaB2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand kLB2;
    }
}
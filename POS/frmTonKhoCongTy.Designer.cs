namespace POS
{
    partial class frmTonKhoCongTy
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTonKhoCongTy));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl1 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl2 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl3 = new DevExpress.XtraBars.BarDockControl();
            this.barDockControl4 = new DevExpress.XtraBars.BarDockControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BARCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LG_DAU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LG_NHAPMUA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LG_NHAPNB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LG_XUATNB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LG_XUATSI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LG_BANLE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LG_CUOI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TRIGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TIEN_CUOI = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnExport,
            this.btnThoat});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 2;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExport, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoat, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnExport
            // 
            this.btnExport.Caption = "Export Excel";
            this.btnExport.Id = 0;
            this.btnExport.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.Image")));
            this.btnExport.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExport.ImageOptions.LargeImage")));
            this.btnExport.Name = "btnExport";
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 1;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Name = "btnThoat";
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1321, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 654);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1321, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 624);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1321, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 624);
            // 
            // barDockControl1
            // 
            this.barDockControl1.CausesValidation = false;
            this.barDockControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControl1.Location = new System.Drawing.Point(0, 30);
            this.barDockControl1.Manager = this.barManager1;
            this.barDockControl1.Size = new System.Drawing.Size(0, 624);
            // 
            // barDockControl2
            // 
            this.barDockControl2.CausesValidation = false;
            this.barDockControl2.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControl2.Location = new System.Drawing.Point(1321, 30);
            this.barDockControl2.Manager = this.barManager1;
            this.barDockControl2.Size = new System.Drawing.Size(0, 624);
            // 
            // barDockControl3
            // 
            this.barDockControl3.CausesValidation = false;
            this.barDockControl3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControl3.Location = new System.Drawing.Point(0, 654);
            this.barDockControl3.Manager = this.barManager1;
            this.barDockControl3.Size = new System.Drawing.Size(1321, 0);
            // 
            // barDockControl4
            // 
            this.barDockControl4.CausesValidation = false;
            this.barDockControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControl4.Location = new System.Drawing.Point(0, 30);
            this.barDockControl4.Manager = this.barManager1;
            this.barDockControl4.Size = new System.Drawing.Size(1321, 0);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 30);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1321, 624);
            this.gridControl1.TabIndex = 12;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BARCODE,
            this.TENHH,
            this.DVT,
            this.LG_DAU,
            this.LG_NHAPMUA,
            this.LG_NHAPNB,
            this.LG_XUATNB,
            this.LG_XUATSI,
            this.LG_BANLE,
            this.LG_CUOI,
            this.TRIGIA,
            this.TIEN_CUOI});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // BARCODE
            // 
            this.BARCODE.Caption = "BARCODE";
            this.BARCODE.FieldName = "BARCODE";
            this.BARCODE.MaxWidth = 120;
            this.BARCODE.MinWidth = 120;
            this.BARCODE.Name = "BARCODE";
            this.BARCODE.Visible = true;
            this.BARCODE.VisibleIndex = 0;
            this.BARCODE.Width = 120;
            // 
            // TENHH
            // 
            this.TENHH.Caption = "TÊN HH";
            this.TENHH.FieldName = "TENHH";
            this.TENHH.MaxWidth = 250;
            this.TENHH.MinWidth = 250;
            this.TENHH.Name = "TENHH";
            this.TENHH.Visible = true;
            this.TENHH.VisibleIndex = 1;
            this.TENHH.Width = 250;
            // 
            // DVT
            // 
            this.DVT.Caption = "ĐVT";
            this.DVT.FieldName = "DVT";
            this.DVT.MaxWidth = 70;
            this.DVT.MinWidth = 70;
            this.DVT.Name = "DVT";
            this.DVT.Visible = true;
            this.DVT.VisibleIndex = 2;
            this.DVT.Width = 70;
            // 
            // LG_DAU
            // 
            this.LG_DAU.Caption = "TỒN ĐẦU";
            this.LG_DAU.FieldName = "LG_DAU";
            this.LG_DAU.MaxWidth = 90;
            this.LG_DAU.MinWidth = 90;
            this.LG_DAU.Name = "LG_DAU";
            this.LG_DAU.Visible = true;
            this.LG_DAU.VisibleIndex = 3;
            this.LG_DAU.Width = 90;
            // 
            // LG_NHAPMUA
            // 
            this.LG_NHAPMUA.Caption = "NHẬP MUA";
            this.LG_NHAPMUA.FieldName = "LG_NHAPMUA";
            this.LG_NHAPMUA.MaxWidth = 90;
            this.LG_NHAPMUA.MinWidth = 90;
            this.LG_NHAPMUA.Name = "LG_NHAPMUA";
            this.LG_NHAPMUA.Visible = true;
            this.LG_NHAPMUA.VisibleIndex = 4;
            this.LG_NHAPMUA.Width = 90;
            // 
            // LG_NHAPNB
            // 
            this.LG_NHAPNB.Caption = "NHẬP NB";
            this.LG_NHAPNB.FieldName = "LG_NHAPNB";
            this.LG_NHAPNB.MaxWidth = 80;
            this.LG_NHAPNB.MinWidth = 80;
            this.LG_NHAPNB.Name = "LG_NHAPNB";
            this.LG_NHAPNB.Visible = true;
            this.LG_NHAPNB.VisibleIndex = 5;
            this.LG_NHAPNB.Width = 80;
            // 
            // LG_XUATNB
            // 
            this.LG_XUATNB.Caption = "XUẤT NB";
            this.LG_XUATNB.FieldName = "LG_XUATNB";
            this.LG_XUATNB.MaxWidth = 80;
            this.LG_XUATNB.MinWidth = 80;
            this.LG_XUATNB.Name = "LG_XUATNB";
            this.LG_XUATNB.Visible = true;
            this.LG_XUATNB.VisibleIndex = 6;
            this.LG_XUATNB.Width = 80;
            // 
            // LG_XUATSI
            // 
            this.LG_XUATSI.Caption = "XUẤT SỈ";
            this.LG_XUATSI.FieldName = "LG_XUATSI";
            this.LG_XUATSI.MaxWidth = 80;
            this.LG_XUATSI.MinWidth = 80;
            this.LG_XUATSI.Name = "LG_XUATSI";
            this.LG_XUATSI.Visible = true;
            this.LG_XUATSI.VisibleIndex = 7;
            this.LG_XUATSI.Width = 80;
            // 
            // LG_BANLE
            // 
            this.LG_BANLE.Caption = "XUẤT BL";
            this.LG_BANLE.FieldName = "LG_BANLE";
            this.LG_BANLE.MaxWidth = 80;
            this.LG_BANLE.MinWidth = 80;
            this.LG_BANLE.Name = "LG_BANLE";
            this.LG_BANLE.Visible = true;
            this.LG_BANLE.VisibleIndex = 8;
            this.LG_BANLE.Width = 80;
            // 
            // LG_CUOI
            // 
            this.LG_CUOI.Caption = "TỒN CUỐI";
            this.LG_CUOI.FieldName = "LG_CUOI";
            this.LG_CUOI.MaxWidth = 90;
            this.LG_CUOI.MinWidth = 90;
            this.LG_CUOI.Name = "LG_CUOI";
            this.LG_CUOI.Visible = true;
            this.LG_CUOI.VisibleIndex = 9;
            this.LG_CUOI.Width = 90;
            // 
            // TRIGIA
            // 
            this.TRIGIA.Caption = "ĐƠN GIÁ";
            this.TRIGIA.FieldName = "TRIGIA";
            this.TRIGIA.MaxWidth = 100;
            this.TRIGIA.MinWidth = 100;
            this.TRIGIA.Name = "TRIGIA";
            this.TRIGIA.Visible = true;
            this.TRIGIA.VisibleIndex = 10;
            this.TRIGIA.Width = 100;
            // 
            // TIEN_CUOI
            // 
            this.TIEN_CUOI.Caption = "THÀNH TIỀN";
            this.TIEN_CUOI.FieldName = "TIEN_CUOI";
            this.TIEN_CUOI.MaxWidth = 150;
            this.TIEN_CUOI.MinWidth = 150;
            this.TIEN_CUOI.Name = "TIEN_CUOI";
            this.TIEN_CUOI.Visible = true;
            this.TIEN_CUOI.VisibleIndex = 11;
            this.TIEN_CUOI.Width = 150;
            // 
            // frmTonKhoCongTy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 674);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControl1);
            this.Controls.Add(this.barDockControl2);
            this.Controls.Add(this.barDockControl3);
            this.Controls.Add(this.barDockControl4);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmTonKhoCongTy";
            this.Text = "frmTonKhoCongTy";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnExport;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraBars.BarDockControl barDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControl2;
        private DevExpress.XtraBars.BarDockControl barDockControl3;
        private DevExpress.XtraBars.BarDockControl barDockControl4;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn BARCODE;
        private DevExpress.XtraGrid.Columns.GridColumn TENHH;
        private DevExpress.XtraGrid.Columns.GridColumn DVT;
        private DevExpress.XtraGrid.Columns.GridColumn LG_DAU;
        private DevExpress.XtraGrid.Columns.GridColumn LG_NHAPMUA;
        private DevExpress.XtraGrid.Columns.GridColumn LG_NHAPNB;
        private DevExpress.XtraGrid.Columns.GridColumn LG_XUATNB;
        private DevExpress.XtraGrid.Columns.GridColumn LG_XUATSI;
        private DevExpress.XtraGrid.Columns.GridColumn LG_BANLE;
        private DevExpress.XtraGrid.Columns.GridColumn LG_CUOI;
        private DevExpress.XtraGrid.Columns.GridColumn TRIGIA;
        private DevExpress.XtraGrid.Columns.GridColumn TIEN_CUOI;
    }
}
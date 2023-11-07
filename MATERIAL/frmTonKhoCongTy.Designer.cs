namespace MATERIAL
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
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gcTonKho = new DevExpress.XtraGrid.GridControl();
            this.gvTonKho = new DevExpress.XtraGrid.Views.Grid.GridView();
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnXem = new DevExpress.XtraEditors.SimpleButton();
            this.cboCongTy = new System.Windows.Forms.ComboBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dtChonKy = new System.Windows.Forms.DateTimePicker();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
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
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Disabled.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.BarAppearance.Disabled.Options.UseFont = true;
            this.bar2.BarAppearance.Hovered.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.BarAppearance.Hovered.Options.UseFont = true;
            this.bar2.BarAppearance.Normal.Font = new System.Drawing.Font("Constantia", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.BarAppearance.Normal.Options.UseFont = true;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExport, "", false, true, false, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            this.btnExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExport_ItemClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Caption = "Thoát";
            this.btnThoat.Id = 1;
            this.btnThoat.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThoat.ImageOptions.SvgImage")));
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoat_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(1117, 25);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 561);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1117, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 25);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 536);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1117, 25);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 536);
            // 
            // gcTonKho
            // 
            this.gcTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcTonKho.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcTonKho.Location = new System.Drawing.Point(0, 71);
            this.gcTonKho.MainView = this.gvTonKho;
            this.gcTonKho.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcTonKho.MenuManager = this.barManager1;
            this.gcTonKho.Name = "gcTonKho";
            this.gcTonKho.Size = new System.Drawing.Size(1117, 490);
            this.gcTonKho.TabIndex = 4;
            this.gcTonKho.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvTonKho});
            // 
            // gvTonKho
            // 
            this.gvTonKho.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
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
            this.gvTonKho.DetailHeight = 284;
            this.gvTonKho.GridControl = this.gcTonKho;
            this.gvTonKho.Name = "gvTonKho";
            this.gvTonKho.OptionsEditForm.PopupEditFormWidth = 686;
            this.gvTonKho.OptionsFind.AlwaysVisible = true;
            this.gvTonKho.OptionsView.ShowFooter = true;
            // 
            // BARCODE
            // 
            this.BARCODE.AppearanceCell.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BARCODE.AppearanceCell.Options.UseFont = true;
            this.BARCODE.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BARCODE.AppearanceHeader.Options.UseFont = true;
            this.BARCODE.Caption = "BARCODE";
            this.BARCODE.FieldName = "BARCODE";
            this.BARCODE.MaxWidth = 103;
            this.BARCODE.MinWidth = 103;
            this.BARCODE.Name = "BARCODE";
            this.BARCODE.Visible = true;
            this.BARCODE.VisibleIndex = 0;
            this.BARCODE.Width = 103;
            // 
            // TENHH
            // 
            this.TENHH.AppearanceCell.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TENHH.AppearanceCell.Options.UseFont = true;
            this.TENHH.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TENHH.AppearanceHeader.Options.UseFont = true;
            this.TENHH.Caption = "TÊN HH";
            this.TENHH.FieldName = "TENHH";
            this.TENHH.MaxWidth = 214;
            this.TENHH.MinWidth = 214;
            this.TENHH.Name = "TENHH";
            this.TENHH.Visible = true;
            this.TENHH.VisibleIndex = 1;
            this.TENHH.Width = 214;
            // 
            // DVT
            // 
            this.DVT.AppearanceCell.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DVT.AppearanceCell.Options.UseFont = true;
            this.DVT.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DVT.AppearanceHeader.Options.UseFont = true;
            this.DVT.Caption = "ĐVT";
            this.DVT.FieldName = "DVT";
            this.DVT.MaxWidth = 60;
            this.DVT.MinWidth = 60;
            this.DVT.Name = "DVT";
            this.DVT.Visible = true;
            this.DVT.VisibleIndex = 2;
            this.DVT.Width = 60;
            // 
            // LG_DAU
            // 
            this.LG_DAU.AppearanceCell.Font = new System.Drawing.Font("Constantia", 8F);
            this.LG_DAU.AppearanceCell.Options.UseFont = true;
            this.LG_DAU.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LG_DAU.AppearanceHeader.Options.UseFont = true;
            this.LG_DAU.Caption = "TỒN ĐẦU";
            this.LG_DAU.FieldName = "LG_DAU";
            this.LG_DAU.MaxWidth = 69;
            this.LG_DAU.MinWidth = 69;
            this.LG_DAU.Name = "LG_DAU";
            this.LG_DAU.Visible = true;
            this.LG_DAU.VisibleIndex = 3;
            this.LG_DAU.Width = 69;
            // 
            // LG_NHAPMUA
            // 
            this.LG_NHAPMUA.AppearanceCell.Font = new System.Drawing.Font("Constantia", 8F);
            this.LG_NHAPMUA.AppearanceCell.Options.UseFont = true;
            this.LG_NHAPMUA.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Bold);
            this.LG_NHAPMUA.AppearanceHeader.Options.UseFont = true;
            this.LG_NHAPMUA.Caption = "NHẬP MUA";
            this.LG_NHAPMUA.FieldName = "LG_NHAPMUA";
            this.LG_NHAPMUA.MaxWidth = 77;
            this.LG_NHAPMUA.MinWidth = 77;
            this.LG_NHAPMUA.Name = "LG_NHAPMUA";
            this.LG_NHAPMUA.Visible = true;
            this.LG_NHAPMUA.VisibleIndex = 4;
            this.LG_NHAPMUA.Width = 77;
            // 
            // LG_NHAPNB
            // 
            this.LG_NHAPNB.AppearanceCell.Font = new System.Drawing.Font("Constantia", 8F);
            this.LG_NHAPNB.AppearanceCell.Options.UseFont = true;
            this.LG_NHAPNB.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Bold);
            this.LG_NHAPNB.AppearanceHeader.Options.UseFont = true;
            this.LG_NHAPNB.Caption = "NHẬP NB";
            this.LG_NHAPNB.FieldName = "LG_NHAPNB";
            this.LG_NHAPNB.MaxWidth = 69;
            this.LG_NHAPNB.MinWidth = 69;
            this.LG_NHAPNB.Name = "LG_NHAPNB";
            this.LG_NHAPNB.Visible = true;
            this.LG_NHAPNB.VisibleIndex = 5;
            this.LG_NHAPNB.Width = 69;
            // 
            // LG_XUATNB
            // 
            this.LG_XUATNB.AppearanceCell.Font = new System.Drawing.Font("Constantia", 8F);
            this.LG_XUATNB.AppearanceCell.Options.UseFont = true;
            this.LG_XUATNB.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Bold);
            this.LG_XUATNB.AppearanceHeader.Options.UseFont = true;
            this.LG_XUATNB.Caption = "XUẤT NB";
            this.LG_XUATNB.FieldName = "LG_XUATNB";
            this.LG_XUATNB.MaxWidth = 69;
            this.LG_XUATNB.MinWidth = 69;
            this.LG_XUATNB.Name = "LG_XUATNB";
            this.LG_XUATNB.Visible = true;
            this.LG_XUATNB.VisibleIndex = 6;
            this.LG_XUATNB.Width = 69;
            // 
            // LG_XUATSI
            // 
            this.LG_XUATSI.AppearanceCell.Font = new System.Drawing.Font("Constantia", 8F);
            this.LG_XUATSI.AppearanceCell.Options.UseFont = true;
            this.LG_XUATSI.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Bold);
            this.LG_XUATSI.AppearanceHeader.Options.UseFont = true;
            this.LG_XUATSI.Caption = "XUẤT SỈ";
            this.LG_XUATSI.FieldName = "LG_XUATSI";
            this.LG_XUATSI.MaxWidth = 69;
            this.LG_XUATSI.MinWidth = 69;
            this.LG_XUATSI.Name = "LG_XUATSI";
            this.LG_XUATSI.Visible = true;
            this.LG_XUATSI.VisibleIndex = 7;
            this.LG_XUATSI.Width = 69;
            // 
            // LG_BANLE
            // 
            this.LG_BANLE.AppearanceCell.Font = new System.Drawing.Font("Constantia", 8F);
            this.LG_BANLE.AppearanceCell.Options.UseFont = true;
            this.LG_BANLE.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Bold);
            this.LG_BANLE.AppearanceHeader.Options.UseFont = true;
            this.LG_BANLE.Caption = "XUẤT BL";
            this.LG_BANLE.FieldName = "LG_BANLE";
            this.LG_BANLE.MaxWidth = 69;
            this.LG_BANLE.MinWidth = 69;
            this.LG_BANLE.Name = "LG_BANLE";
            this.LG_BANLE.Visible = true;
            this.LG_BANLE.VisibleIndex = 8;
            this.LG_BANLE.Width = 69;
            // 
            // LG_CUOI
            // 
            this.LG_CUOI.AppearanceCell.Font = new System.Drawing.Font("Constantia", 8F);
            this.LG_CUOI.AppearanceCell.Options.UseFont = true;
            this.LG_CUOI.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Bold);
            this.LG_CUOI.AppearanceHeader.Options.UseFont = true;
            this.LG_CUOI.Caption = "TỒN CUỐI";
            this.LG_CUOI.FieldName = "LG_CUOI";
            this.LG_CUOI.MaxWidth = 77;
            this.LG_CUOI.MinWidth = 77;
            this.LG_CUOI.Name = "LG_CUOI";
            this.LG_CUOI.Visible = true;
            this.LG_CUOI.VisibleIndex = 9;
            this.LG_CUOI.Width = 77;
            // 
            // TRIGIA
            // 
            this.TRIGIA.AppearanceCell.Font = new System.Drawing.Font("Constantia", 8F);
            this.TRIGIA.AppearanceCell.Options.UseFont = true;
            this.TRIGIA.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Bold);
            this.TRIGIA.AppearanceHeader.Options.UseFont = true;
            this.TRIGIA.Caption = "ĐƠN GIÁ";
            this.TRIGIA.FieldName = "TRIGIA";
            this.TRIGIA.MaxWidth = 103;
            this.TRIGIA.MinWidth = 103;
            this.TRIGIA.Name = "TRIGIA";
            this.TRIGIA.Visible = true;
            this.TRIGIA.VisibleIndex = 10;
            this.TRIGIA.Width = 103;
            // 
            // TIEN_CUOI
            // 
            this.TIEN_CUOI.AppearanceCell.Font = new System.Drawing.Font("Constantia", 8F);
            this.TIEN_CUOI.AppearanceCell.Options.UseFont = true;
            this.TIEN_CUOI.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 8F, System.Drawing.FontStyle.Bold);
            this.TIEN_CUOI.AppearanceHeader.Options.UseFont = true;
            this.TIEN_CUOI.Caption = "THÀNH TIỀN";
            this.TIEN_CUOI.FieldName = "TIEN_CUOI";
            this.TIEN_CUOI.MaxWidth = 129;
            this.TIEN_CUOI.MinWidth = 129;
            this.TIEN_CUOI.Name = "TIEN_CUOI";
            this.TIEN_CUOI.Visible = true;
            this.TIEN_CUOI.VisibleIndex = 11;
            this.TIEN_CUOI.Width = 129;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnXem);
            this.panelControl1.Controls.Add(this.cboCongTy);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.dtChonKy);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 25);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1117, 46);
            this.panelControl1.TabIndex = 9;
            // 
            // btnXem
            // 
            this.btnXem.Appearance.Font = new System.Drawing.Font("Constantia", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.Appearance.Options.UseFont = true;
            this.btnXem.Location = new System.Drawing.Point(984, 9);
            this.btnXem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(81, 24);
            this.btnXem.TabIndex = 8;
            this.btnXem.Text = "Xem";
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cboCongTy
            // 
            this.cboCongTy.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCongTy.FormattingEnabled = true;
            this.cboCongTy.Location = new System.Drawing.Point(572, 9);
            this.cboCongTy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cboCongTy.Name = "cboCongTy";
            this.cboCongTy.Size = new System.Drawing.Size(354, 25);
            this.cboCongTy.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(410, 11);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(124, 17);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Công Ty/Chi Nhánh";
            // 
            // dtChonKy
            // 
            this.dtChonKy.CustomFormat = "dd/MM/yyyy";
            this.dtChonKy.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtChonKy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtChonKy.Location = new System.Drawing.Point(145, 10);
            this.dtChonKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtChonKy.Name = "dtChonKy";
            this.dtChonKy.Size = new System.Drawing.Size(163, 25);
            this.dtChonKy.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(75, 13);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(55, 18);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Chọn kỳ";
            // 
            // frmTonKhoCongTy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 561);
            this.Controls.Add(this.gcTonKho);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmTonKhoCongTy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Theo Dõi Tồn Kho Công Ty";
            this.Load += new System.EventHandler(this.frmTonKhoCongTy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnExport;
        private DevExpress.XtraBars.BarButtonItem btnThoat;
        private DevExpress.XtraGrid.GridControl gcTonKho;
        private DevExpress.XtraGrid.Views.Grid.GridView gvTonKho;
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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnXem;
        private System.Windows.Forms.ComboBox cboCongTy;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.DateTimePicker dtChonKy;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}
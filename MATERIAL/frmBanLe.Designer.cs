namespace MATERIAL
{
    partial class frmBanLe
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gcChiTiet = new DevExpress.XtraGrid.GridControl();
            this.gvChiTiet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BARCODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENHH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SOLUONG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DONGIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CHIETKHAU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.THANHTIEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.STT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnInBill = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnChietKhau = new DevExpress.XtraEditors.SimpleButton();
            this.btnTraHang = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Location = new System.Drawing.Point(556, 86);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(8, 8);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // gcChiTiet
            // 
            this.gcChiTiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcChiTiet.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gcChiTiet.Location = new System.Drawing.Point(0, 0);
            this.gcChiTiet.MainView = this.gvChiTiet;
            this.gcChiTiet.Margin = new System.Windows.Forms.Padding(2);
            this.gcChiTiet.Name = "gcChiTiet";
            this.gcChiTiet.Size = new System.Drawing.Size(872, 299);
            this.gcChiTiet.TabIndex = 1;
            this.gcChiTiet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChiTiet});
            // 
            // gvChiTiet
            // 
            this.gvChiTiet.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BARCODE,
            this.TENHH,
            this.DVT,
            this.SOLUONG,
            this.DONGIA,
            this.CHIETKHAU,
            this.THANHTIEN,
            this.STT});
            this.gvChiTiet.DetailHeight = 280;
            this.gvChiTiet.GridControl = this.gcChiTiet;
            this.gvChiTiet.Name = "gvChiTiet";
            this.gvChiTiet.OptionsEditForm.PopupEditFormWidth = 640;
            this.gvChiTiet.OptionsView.ShowFooter = true;
            this.gvChiTiet.OptionsView.ShowGroupPanel = false;
            this.gvChiTiet.RowHeight = 20;
            this.gvChiTiet.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvChiTiet_CellValueChanged);
            this.gvChiTiet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gvChiTiet_KeyDown);
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
            this.TENHH.Caption = "TÊN HÀNG HÓA";
            this.TENHH.FieldName = "TENHH";
            this.TENHH.MaxWidth = 250;
            this.TENHH.MinWidth = 250;
            this.TENHH.Name = "TENHH";
            this.TENHH.OptionsColumn.AllowEdit = false;
            this.TENHH.Visible = true;
            this.TENHH.VisibleIndex = 1;
            this.TENHH.Width = 250;
            // 
            // DVT
            // 
            this.DVT.Caption = "ĐVT";
            this.DVT.FieldName = "DVT";
            this.DVT.MaxWidth = 50;
            this.DVT.MinWidth = 50;
            this.DVT.Name = "DVT";
            this.DVT.OptionsColumn.AllowEdit = false;
            this.DVT.Visible = true;
            this.DVT.VisibleIndex = 2;
            this.DVT.Width = 50;
            // 
            // SOLUONG
            // 
            this.SOLUONG.Caption = "SỐ LƯỢNG";
            this.SOLUONG.DisplayFormat.FormatString = "{0:N0}";
            this.SOLUONG.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.SOLUONG.FieldName = "SOLUONG";
            this.SOLUONG.MaxWidth = 100;
            this.SOLUONG.MinWidth = 100;
            this.SOLUONG.Name = "SOLUONG";
            this.SOLUONG.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SOLUONG", "{0:N0}")});
            this.SOLUONG.Visible = true;
            this.SOLUONG.VisibleIndex = 3;
            this.SOLUONG.Width = 100;
            // 
            // DONGIA
            // 
            this.DONGIA.Caption = "ĐƠN GIÁ";
            this.DONGIA.DisplayFormat.FormatString = "{0:N0}";
            this.DONGIA.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.DONGIA.FieldName = "DONGIA";
            this.DONGIA.MaxWidth = 120;
            this.DONGIA.MinWidth = 120;
            this.DONGIA.Name = "DONGIA";
            this.DONGIA.OptionsColumn.AllowEdit = false;
            this.DONGIA.Visible = true;
            this.DONGIA.VisibleIndex = 4;
            this.DONGIA.Width = 120;
            // 
            // CHIETKHAU
            // 
            this.CHIETKHAU.Caption = "CHIẾT KHẤU";
            this.CHIETKHAU.FieldName = "CHIETKHAU";
            this.CHIETKHAU.MaxWidth = 120;
            this.CHIETKHAU.MinWidth = 120;
            this.CHIETKHAU.Name = "CHIETKHAU";
            this.CHIETKHAU.OptionsColumn.AllowEdit = false;
            this.CHIETKHAU.Visible = true;
            this.CHIETKHAU.VisibleIndex = 5;
            this.CHIETKHAU.Width = 120;
            // 
            // THANHTIEN
            // 
            this.THANHTIEN.Caption = "THÀNH TIỀN";
            this.THANHTIEN.DisplayFormat.FormatString = "{0:N0}";
            this.THANHTIEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.THANHTIEN.FieldName = "THANHTIEN";
            this.THANHTIEN.MaxWidth = 150;
            this.THANHTIEN.MinWidth = 150;
            this.THANHTIEN.Name = "THANHTIEN";
            this.THANHTIEN.OptionsColumn.AllowEdit = false;
            this.THANHTIEN.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "THANHTIEN", "{0:N0}")});
            this.THANHTIEN.Visible = true;
            this.THANHTIEN.VisibleIndex = 6;
            this.THANHTIEN.Width = 150;
            // 
            // STT
            // 
            this.STT.Caption = "STT";
            this.STT.FieldName = "STT";
            this.STT.Name = "STT";
            this.STT.OptionsColumn.AllowEdit = false;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 30F);
            this.txtBarcode.Location = new System.Drawing.Point(89, 320);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(306, 56);
            this.txtBarcode.TabIndex = 2;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarCode_KeyDown);
            // 
            // btnInBill
            // 
            this.btnInBill.Location = new System.Drawing.Point(427, 320);
            this.btnInBill.Name = "btnInBill";
            this.btnInBill.Size = new System.Drawing.Size(95, 56);
            this.btnInBill.TabIndex = 3;
            this.btnInBill.Text = "In Bill";
            this.btnInBill.Click += new System.EventHandler(this.btnInBill_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(528, 320);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(95, 56);
            this.btnLuu.TabIndex = 4;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnChietKhau
            // 
            this.btnChietKhau.Location = new System.Drawing.Point(629, 320);
            this.btnChietKhau.Name = "btnChietKhau";
            this.btnChietKhau.Size = new System.Drawing.Size(95, 56);
            this.btnChietKhau.TabIndex = 5;
            this.btnChietKhau.Text = "Chiết khấu";
            this.btnChietKhau.Click += new System.EventHandler(this.btnChietKhau_Click);
            // 
            // btnTraHang
            // 
            this.btnTraHang.Location = new System.Drawing.Point(730, 320);
            this.btnTraHang.Name = "btnTraHang";
            this.btnTraHang.Size = new System.Drawing.Size(95, 56);
            this.btnTraHang.TabIndex = 6;
            this.btnTraHang.Text = "Trả hàng";
            this.btnTraHang.Click += new System.EventHandler(this.btnTraHang_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MATERIAL.Properties.Resources.bar_code;
            this.pictureBox2.Location = new System.Drawing.Point(13, 320);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(70, 56);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // frmBanLe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 427);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.gcChiTiet);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnTraHang);
            this.Controls.Add(this.btnChietKhau);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnInBill);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmBanLe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phiếu bán lẻ";
            this.Load += new System.EventHandler(this.frmBanLe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.Columns.GridColumn BARCODE;
        private DevExpress.XtraGrid.Columns.GridColumn TENHH;
        private DevExpress.XtraGrid.Columns.GridColumn DVT;
        private DevExpress.XtraGrid.Columns.GridColumn SOLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn DONGIA;
        private DevExpress.XtraGrid.Columns.GridColumn CHIETKHAU;
        private DevExpress.XtraGrid.Columns.GridColumn THANHTIEN;
        private DevExpress.XtraGrid.Columns.GridColumn STT;
        private System.Windows.Forms.TextBox txtBarcode;
        private DevExpress.XtraEditors.SimpleButton btnInBill;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnChietKhau;
        private DevExpress.XtraEditors.SimpleButton btnTraHang;
        private System.Windows.Forms.PictureBox pictureBox1;
        public DevExpress.XtraGrid.GridControl gcChiTiet;
        public DevExpress.XtraGrid.Views.Grid.GridView gvChiTiet;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
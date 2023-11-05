namespace POS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnTraHang = new DevExpress.XtraEditors.SimpleButton();
            this.btnChietKhau = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnInBill = new DevExpress.XtraEditors.SimpleButton();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.pictureBox1);
            this.panelControl1.Controls.Add(this.btnTraHang);
            this.panelControl1.Controls.Add(this.btnChietKhau);
            this.panelControl1.Controls.Add(this.btnLuu);
            this.panelControl1.Controls.Add(this.btnInBill);
            this.panelControl1.Controls.Add(this.txtBarcode);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 380);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(918, 100);
            this.panelControl1.TabIndex = 0;
            // 
            // btnTraHang
            // 
            this.btnTraHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTraHang.ImageOptions.Image")));
            this.btnTraHang.Location = new System.Drawing.Point(733, 21);
            this.btnTraHang.Name = "btnTraHang";
            this.btnTraHang.Size = new System.Drawing.Size(95, 56);
            this.btnTraHang.TabIndex = 11;
            this.btnTraHang.Text = "Trả hàng";
            this.btnTraHang.Click += new System.EventHandler(this.btnTraHang_Click);
            // 
            // btnChietKhau
            // 
            this.btnChietKhau.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChietKhau.ImageOptions.Image")));
            this.btnChietKhau.Location = new System.Drawing.Point(632, 21);
            this.btnChietKhau.Name = "btnChietKhau";
            this.btnChietKhau.Size = new System.Drawing.Size(95, 56);
            this.btnChietKhau.TabIndex = 10;
            this.btnChietKhau.Text = "Chiết khấu";
            this.btnChietKhau.Click += new System.EventHandler(this.btnChietKhau_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLuu.ImageOptions.Image")));
            this.btnLuu.Location = new System.Drawing.Point(531, 21);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(95, 56);
            this.btnLuu.TabIndex = 9;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnInBill
            // 
            this.btnInBill.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInBill.ImageOptions.Image")));
            this.btnInBill.Location = new System.Drawing.Point(430, 21);
            this.btnInBill.Name = "btnInBill";
            this.btnInBill.Size = new System.Drawing.Size(95, 56);
            this.btnInBill.TabIndex = 8;
            this.btnInBill.Text = "In Bill";
            this.btnInBill.Click += new System.EventHandler(this.btnInBill_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 30F);
            this.txtBarcode.Location = new System.Drawing.Point(92, 21);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(306, 56);
            this.txtBarcode.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::POS.Properties.Resources.bar_code;
            this.pictureBox1.Location = new System.Drawing.Point(5, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // gcChiTiet
            // 
            this.gcChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcChiTiet.Location = new System.Drawing.Point(0, 0);
            this.gcChiTiet.MainView = this.gvChiTiet;
            this.gcChiTiet.Name = "gcChiTiet";
            this.gcChiTiet.Size = new System.Drawing.Size(918, 380);
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
            this.gvChiTiet.OptionsBehavior.Editable = false;
            this.gvChiTiet.OptionsEditForm.PopupEditFormWidth = 640;
            this.gvChiTiet.OptionsView.ShowGroupPanel = false;
            this.gvChiTiet.RowHeight = 20;
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
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 480);
            this.Controls.Add(this.gcChiTiet);
            this.Controls.Add(this.panelControl1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChiTiet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.SimpleButton btnTraHang;
        private DevExpress.XtraEditors.SimpleButton btnChietKhau;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnInBill;
        private System.Windows.Forms.TextBox txtBarcode;
        private DevExpress.XtraGrid.GridControl gcChiTiet;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChiTiet;
        private DevExpress.XtraGrid.Columns.GridColumn BARCODE;
        private DevExpress.XtraGrid.Columns.GridColumn TENHH;
        private DevExpress.XtraGrid.Columns.GridColumn DVT;
        private DevExpress.XtraGrid.Columns.GridColumn SOLUONG;
        private DevExpress.XtraGrid.Columns.GridColumn DONGIA;
        private DevExpress.XtraGrid.Columns.GridColumn CHIETKHAU;
        private DevExpress.XtraGrid.Columns.GridColumn THANHTIEN;
        private DevExpress.XtraGrid.Columns.GridColumn STT;
    }
}
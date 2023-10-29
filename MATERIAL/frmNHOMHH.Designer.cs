﻿namespace MATERIAL
{
    partial class frmNHOMHH
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnThem = new System.Windows.Forms.ToolStripButton();
            this.btnSua = new System.Windows.Forms.ToolStripButton();
            this.btnXoa = new System.Windows.Forms.ToolStripButton();
            this.btnLuu = new System.Windows.Forms.ToolStripButton();
            this.btnBoQua = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.gcDanhSach = new DevExpress.XtraGrid.GridControl();
            this.gvDanhSach = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IDNHOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TENNHOM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grcThongTinDV = new DevExpress.XtraEditors.GroupControl();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.GHICHU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcThongTinDV)).BeginInit();
            this.grcThongTinDV.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.MediumTurquoise;
            this.toolStrip1.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnThem,
            this.btnSua,
            this.btnXoa,
            this.btnLuu,
            this.btnBoQua,
            this.btnThoat});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(3);
            this.toolStrip1.Size = new System.Drawing.Size(1017, 69);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnThem
            // 
            this.btnThem.Image = global::MATERIAL.Properties.Resources.icon_add1;
            this.btnThem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThem.Name = "btnThem";
            this.btnThem.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnThem.Size = new System.Drawing.Size(70, 60);
            this.btnThem.Text = "Thêm";
            this.btnThem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Image = global::MATERIAL.Properties.Resources.icon_sua;
            this.btnSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSua.Name = "btnSua";
            this.btnSua.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnSua.Size = new System.Drawing.Size(62, 60);
            this.btnSua.Text = "Sửa";
            this.btnSua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Image = global::MATERIAL.Properties.Resources.icon_xoa;
            this.btnXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnXoa.Size = new System.Drawing.Size(63, 60);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Image = global::MATERIAL.Properties.Resources.icon_save;
            this.btnLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLuu.Size = new System.Drawing.Size(64, 60);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnBoQua
            // 
            this.btnBoQua.Image = global::MATERIAL.Properties.Resources.icon_boqua;
            this.btnBoQua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBoQua.Size = new System.Drawing.Size(84, 60);
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnThoat.Image = global::MATERIAL.Properties.Resources.icon_out2;
            this.btnThoat.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Margin = new System.Windows.Forms.Padding(610, 1, 0, 2);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(52, 60);
            this.btnThoat.Text = "toolStripButton6";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // gcDanhSach
            // 
            this.gcDanhSach.Dock = System.Windows.Forms.DockStyle.Top;
            this.gcDanhSach.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcDanhSach.Location = new System.Drawing.Point(0, 69);
            this.gcDanhSach.MainView = this.gvDanhSach;
            this.gcDanhSach.Name = "gcDanhSach";
            this.gcDanhSach.Size = new System.Drawing.Size(1017, 402);
            this.gcDanhSach.TabIndex = 4;
            this.gcDanhSach.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvDanhSach});
            // 
            // gvDanhSach
            // 
            this.gvDanhSach.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IDNHOM,
            this.TENNHOM,
            this.GHICHU});
            this.gvDanhSach.GridControl = this.gcDanhSach;
            this.gvDanhSach.Name = "gvDanhSach";
            this.gvDanhSach.OptionsView.ShowGroupPanel = false;
            this.gvDanhSach.Click += new System.EventHandler(this.gvDanhSach_Click);
            // 
            // IDNHOM
            // 
            this.IDNHOM.AppearanceCell.Font = new System.Drawing.Font("Constantia", 11F);
            this.IDNHOM.AppearanceCell.Options.UseFont = true;
            this.IDNHOM.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IDNHOM.AppearanceHeader.Options.UseFont = true;
            this.IDNHOM.Caption = "IDNHOM";
            this.IDNHOM.FieldName = "IDNHOM";
            this.IDNHOM.MinWidth = 25;
            this.IDNHOM.Name = "IDNHOM";
            this.IDNHOM.Width = 226;
            // 
            // TENNHOM
            // 
            this.TENNHOM.AppearanceCell.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TENNHOM.AppearanceCell.Options.UseFont = true;
            this.TENNHOM.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TENNHOM.AppearanceHeader.Options.UseFont = true;
            this.TENNHOM.Caption = "TÊN NHÓM HÀNG HÓA";
            this.TENNHOM.FieldName = "TENNHOM";
            this.TENNHOM.MinWidth = 25;
            this.TENNHOM.Name = "TENNHOM";
            this.TENNHOM.Visible = true;
            this.TENNHOM.VisibleIndex = 0;
            this.TENNHOM.Width = 343;
            // 
            // grcThongTinDV
            // 
            this.grcThongTinDV.Appearance.BackColor = System.Drawing.Color.White;
            this.grcThongTinDV.Appearance.Options.UseBackColor = true;
            this.grcThongTinDV.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.grcThongTinDV.AppearanceCaption.BorderColor = System.Drawing.Color.MediumTurquoise;
            this.grcThongTinDV.AppearanceCaption.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grcThongTinDV.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.grcThongTinDV.AppearanceCaption.Options.UseBackColor = true;
            this.grcThongTinDV.AppearanceCaption.Options.UseBorderColor = true;
            this.grcThongTinDV.AppearanceCaption.Options.UseFont = true;
            this.grcThongTinDV.AppearanceCaption.Options.UseForeColor = true;
            this.grcThongTinDV.Controls.Add(this.txtGhiChu);
            this.grcThongTinDV.Controls.Add(this.labelControl1);
            this.grcThongTinDV.Controls.Add(this.txtTen);
            this.grcThongTinDV.Controls.Add(this.labelControl3);
            this.grcThongTinDV.Dock = System.Windows.Forms.DockStyle.Top;
            this.grcThongTinDV.Location = new System.Drawing.Point(0, 471);
            this.grcThongTinDV.Name = "grcThongTinDV";
            this.grcThongTinDV.Size = new System.Drawing.Size(1017, 292);
            this.grcThongTinDV.TabIndex = 5;
            this.grcThongTinDV.Text = "Thông Tin Xuất Xứ";
            // 
            // txtTen
            // 
            this.txtTen.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTen.Location = new System.Drawing.Point(251, 55);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(339, 29);
            this.txtTen.TabIndex = 13;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(47, 62);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(169, 22);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "Tên Nhóm Hàng Hóa";
            // 
            // GHICHU
            // 
            this.GHICHU.AppearanceCell.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GHICHU.AppearanceCell.Options.UseFont = true;
            this.GHICHU.AppearanceHeader.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GHICHU.AppearanceHeader.Options.UseFont = true;
            this.GHICHU.Caption = "GHI CHÚ";
            this.GHICHU.FieldName = "GHICHU";
            this.GHICHU.MinWidth = 25;
            this.GHICHU.Name = "GHICHU";
            this.GHICHU.Visible = true;
            this.GHICHU.VisibleIndex = 1;
            this.GHICHU.Width = 644;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGhiChu.Location = new System.Drawing.Point(251, 119);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(339, 29);
            this.txtGhiChu.TabIndex = 15;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Constantia", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(47, 126);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 22);
            this.labelControl1.TabIndex = 14;
            this.labelControl1.Text = "Ghi Chú";
            // 
            // frmNHOMHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 763);
            this.Controls.Add(this.grcThongTinDV);
            this.Controls.Add(this.gcDanhSach);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNHOMHH";
            this.Text = "frmNHOMHH";
            this.Load += new System.EventHandler(this.frmNHOMHH_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDanhSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grcThongTinDV)).EndInit();
            this.grcThongTinDV.ResumeLayout(false);
            this.grcThongTinDV.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnThem;
        private System.Windows.Forms.ToolStripButton btnSua;
        private System.Windows.Forms.ToolStripButton btnXoa;
        private System.Windows.Forms.ToolStripButton btnLuu;
        private System.Windows.Forms.ToolStripButton btnBoQua;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private DevExpress.XtraGrid.GridControl gcDanhSach;
        private DevExpress.XtraGrid.Views.Grid.GridView gvDanhSach;
        private DevExpress.XtraGrid.Columns.GridColumn IDNHOM;
        private DevExpress.XtraGrid.Columns.GridColumn TENNHOM;
        private DevExpress.XtraEditors.GroupControl grcThongTinDV;
        private System.Windows.Forms.TextBox txtTen;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn GHICHU;
        private System.Windows.Forms.TextBox txtGhiChu;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
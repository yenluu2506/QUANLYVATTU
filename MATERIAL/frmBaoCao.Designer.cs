namespace MATERIAL
{
    partial class frmBaoCao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaoCao));
            this.splBaoCao = new DevExpress.XtraEditors.SplitContainerControl();
            this.lstDanhSach = new DevExpress.XtraEditors.ImageListBoxControl();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            this.btnThucHien = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splBaoCao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splBaoCao.Panel1)).BeginInit();
            this.splBaoCao.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splBaoCao.Panel2)).BeginInit();
            this.splBaoCao.Panel2.SuspendLayout();
            this.splBaoCao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstDanhSach)).BeginInit();
            this.SuspendLayout();
            // 
            // splBaoCao
            // 
            this.splBaoCao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splBaoCao.Location = new System.Drawing.Point(0, 0);
            this.splBaoCao.Name = "splBaoCao";
            // 
            // splBaoCao.splBaoCao_Panel1
            // 
            this.splBaoCao.Panel1.Controls.Add(this.lstDanhSach);
            this.splBaoCao.Panel1.Text = "Panel1";
            // 
            // splBaoCao.splBaoCao_Panel2
            // 
            this.splBaoCao.Panel2.Controls.Add(this.btnDong);
            this.splBaoCao.Panel2.Controls.Add(this.btnThucHien);
            this.splBaoCao.Panel2.Text = "Panel2";
            this.splBaoCao.Size = new System.Drawing.Size(812, 545);
            this.splBaoCao.SplitterPosition = 291;
            this.splBaoCao.TabIndex = 0;
            // 
            // lstDanhSach
            // 
            this.lstDanhSach.Appearance.Font = new System.Drawing.Font("Constantia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDanhSach.Appearance.Options.UseFont = true;
            this.lstDanhSach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDanhSach.Location = new System.Drawing.Point(0, 0);
            this.lstDanhSach.Name = "lstDanhSach";
            this.lstDanhSach.Size = new System.Drawing.Size(291, 545);
            this.lstDanhSach.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.Appearance.Font = new System.Drawing.Font("Constantia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Appearance.Options.UseFont = true;
            this.btnDong.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDong.ImageOptions.SvgImage")));
            this.btnDong.Location = new System.Drawing.Point(257, 451);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(133, 47);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // btnThucHien
            // 
            this.btnThucHien.Appearance.Font = new System.Drawing.Font("Constantia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThucHien.Appearance.Options.UseFont = true;
            this.btnThucHien.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnThucHien.ImageOptions.SvgImage")));
            this.btnThucHien.Location = new System.Drawing.Point(78, 451);
            this.btnThucHien.Name = "btnThucHien";
            this.btnThucHien.Size = new System.Drawing.Size(133, 47);
            this.btnThucHien.TabIndex = 0;
            this.btnThucHien.Text = "Thực hiện";
            this.btnThucHien.Click += new System.EventHandler(this.btnThucHien_Click);
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(812, 545);
            this.Controls.Add(this.splBaoCao);
            this.Name = "frmBaoCao";
            this.Text = "Báo Cáo";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splBaoCao.Panel1)).EndInit();
            this.splBaoCao.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splBaoCao.Panel2)).EndInit();
            this.splBaoCao.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splBaoCao)).EndInit();
            this.splBaoCao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lstDanhSach)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splBaoCao;
        private DevExpress.XtraEditors.ImageListBoxControl lstDanhSach;
        private DevExpress.XtraEditors.SimpleButton btnDong;
        private DevExpress.XtraEditors.SimpleButton btnThucHien;
    }
}
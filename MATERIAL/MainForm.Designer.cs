namespace MATERIAL
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnBarcode = new System.Windows.Forms.ToolStripButton();
            this.btnBaoCao = new System.Windows.Forms.ToolStripButton();
            this.btnTinhTon = new System.Windows.Forms.ToolStripButton();
            this.btnThoat = new System.Windows.Forms.ToolStripButton();
            this.lblHTQLVT = new System.Windows.Forms.ToolStripLabel();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.navMain = new DevExpress.XtraNavBar.NavBarControl();
            this.lagreImage = new System.Windows.Forms.ImageList(this.components);
            this.smallImage = new System.Windows.Forms.ImageList(this.components);
            this.chartDanhThuNhom = new DevExpress.XtraCharts.ChartControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.chartDanhThuNhom2 = new DevExpress.XtraCharts.ChartControl();
            this.chartDanhThuNhom3 = new DevExpress.XtraCharts.ChartControl();
            this.chartDanhThuNhom4 = new DevExpress.XtraCharts.ChartControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDanhThuNhom)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDanhThuNhom2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDanhThuNhom3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDanhThuNhom4)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightGreen;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBarcode,
            this.btnBaoCao,
            this.btnTinhTon,
            this.btnThoat,
            this.lblHTQLVT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1077, 58);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnBarcode
            // 
            this.btnBarcode.ForeColor = System.Drawing.Color.Black;
            this.btnBarcode.Image = global::MATERIAL.Properties.Resources.bar_code;
            this.btnBarcode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBarcode.Name = "btnBarcode";
            this.btnBarcode.Size = new System.Drawing.Size(70, 55);
            this.btnBarcode.Text = "Barcode";
            this.btnBarcode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBarcode.Click += new System.EventHandler(this.btnBarcode_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.ForeColor = System.Drawing.Color.Black;
            this.btnBaoCao.Image = global::MATERIAL.Properties.Resources.icon_baocao1;
            this.btnBaoCao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(71, 55);
            this.btnBaoCao.Text = "Báo Cáo";
            this.btnBaoCao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // btnTinhTon
            // 
            this.btnTinhTon.ForeColor = System.Drawing.Color.Black;
            this.btnTinhTon.Image = global::MATERIAL.Properties.Resources.icon_thoat;
            this.btnTinhTon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTinhTon.Name = "btnTinhTon";
            this.btnTinhTon.Size = new System.Drawing.Size(74, 55);
            this.btnTinhTon.Text = "Tính tồn";
            this.btnTinhTon.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnTinhTon.Click += new System.EventHandler(this.btnTinhTon_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.ForeColor = System.Drawing.Color.Black;
            this.btnThoat.Image = global::MATERIAL.Properties.Resources.icon_thoat;
            this.btnThoat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(55, 55);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // lblHTQLVT
            // 
            this.lblHTQLVT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.lblHTQLVT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblHTQLVT.Font = new System.Drawing.Font("Constantia", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHTQLVT.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblHTQLVT.Margin = new System.Windows.Forms.Padding(280, 1, 0, 2);
            this.lblHTQLVT.Name = "lblHTQLVT";
            this.lblHTQLVT.Size = new System.Drawing.Size(342, 55);
            this.lblHTQLVT.Text = "HỆ THỐNG QUẢN LÝ KHO VẬT TƯ";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Appearance.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.splitContainerControl1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 58);
            this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.navMain);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1077, 556);
            this.splitContainerControl1.SplitterPosition = 195;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // navMain
            // 
            this.navMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.navMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navMain.Font = new System.Drawing.Font("Constantia", 12F);
            this.navMain.LargeImages = this.lagreImage;
            this.navMain.Location = new System.Drawing.Point(0, 0);
            this.navMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.navMain.Name = "navMain";
            this.navMain.OptionsNavPane.ExpandedWidth = 195;
            this.navMain.Size = new System.Drawing.Size(195, 556);
            this.navMain.SmallImages = this.smallImage;
            this.navMain.TabIndex = 0;
            this.navMain.Text = "navBarControl1";
            this.navMain.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navMain_LinkClicked);
            // 
            // lagreImage
            // 
            this.lagreImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("lagreImage.ImageStream")));
            this.lagreImage.TransparentColor = System.Drawing.Color.Transparent;
            this.lagreImage.Images.SetKeyName(0, "menu.png");
            this.lagreImage.Images.SetKeyName(1, "9044648_import_export_icon.png");
            // 
            // smallImage
            // 
            this.smallImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImage.ImageStream")));
            this.smallImage.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImage.Images.SetKeyName(0, "icon_point.png");
            // 
            // chartDanhThuNhom
            // 
            this.chartDanhThuNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDanhThuNhom.Legend.LegendID = -1;
            this.chartDanhThuNhom.Location = new System.Drawing.Point(3, 3);
            this.chartDanhThuNhom.Name = "chartDanhThuNhom";
            this.chartDanhThuNhom.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartDanhThuNhom.Size = new System.Drawing.Size(430, 272);
            this.chartDanhThuNhom.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.chartDanhThuNhom4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartDanhThuNhom3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.chartDanhThuNhom, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartDanhThuNhom2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(872, 556);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // chartDanhThuNhom2
            // 
            this.chartDanhThuNhom2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDanhThuNhom2.Legend.LegendID = -1;
            this.chartDanhThuNhom2.Location = new System.Drawing.Point(439, 3);
            this.chartDanhThuNhom2.Name = "chartDanhThuNhom2";
            this.chartDanhThuNhom2.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartDanhThuNhom2.Size = new System.Drawing.Size(430, 272);
            this.chartDanhThuNhom2.TabIndex = 1;
            // 
            // chartDanhThuNhom3
            // 
            this.chartDanhThuNhom3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDanhThuNhom3.Legend.LegendID = -1;
            this.chartDanhThuNhom3.Location = new System.Drawing.Point(3, 281);
            this.chartDanhThuNhom3.Name = "chartDanhThuNhom3";
            this.chartDanhThuNhom3.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartDanhThuNhom3.Size = new System.Drawing.Size(430, 272);
            this.chartDanhThuNhom3.TabIndex = 2;
            // 
            // chartDanhThuNhom4
            // 
            this.chartDanhThuNhom4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDanhThuNhom4.Legend.LegendID = -1;
            this.chartDanhThuNhom4.Location = new System.Drawing.Point(439, 281);
            this.chartDanhThuNhom4.Name = "chartDanhThuNhom4";
            this.chartDanhThuNhom4.SeriesSerializable = new DevExpress.XtraCharts.Series[0];
            this.chartDanhThuNhom4.Size = new System.Drawing.Size(430, 272);
            this.chartDanhThuNhom4.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 614);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDanhThuNhom)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDanhThuNhom2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDanhThuNhom3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDanhThuNhom4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnBarcode;
        private System.Windows.Forms.ToolStripButton btnBaoCao;
        private System.Windows.Forms.ToolStripButton btnThoat;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraNavBar.NavBarControl navMain;
        private System.Windows.Forms.ImageList lagreImage;
        private System.Windows.Forms.ImageList smallImage;
        private System.Windows.Forms.ToolStripLabel lblHTQLVT;
        private System.Windows.Forms.ToolStripButton btnTinhTon;
        private DevExpress.XtraCharts.ChartControl chartDanhThuNhom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraCharts.ChartControl chartDanhThuNhom4;
        private DevExpress.XtraCharts.ChartControl chartDanhThuNhom3;
        private DevExpress.XtraCharts.ChartControl chartDanhThuNhom2;
    }
}


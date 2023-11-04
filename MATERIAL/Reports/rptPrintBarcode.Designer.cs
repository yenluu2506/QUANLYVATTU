namespace MATERIAL.Reports
{
    partial class rptPrintBarcode
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.xr_BarCode = new DevExpress.XtraReports.UI.XRBarCode();
            this.xrTen = new DevExpress.XtraReports.UI.XRLabel();
            this.xrGia = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 68.33334F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrGia,
            this.xrTen,
            this.xr_BarCode});
            this.Detail.HeightF = 138.3333F;
            this.Detail.Name = "Detail";
            // 
            // xr_BarCode
            // 
            this.xr_BarCode.LocationFloat = new DevExpress.Utils.PointFloat(50.83333F, 23.00001F);
            this.xr_BarCode.Name = "xr_BarCode";
            this.xr_BarCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 10, 0, 0, 96F);
            this.xr_BarCode.SizeF = new System.Drawing.SizeF(200F, 75F);
            this.xr_BarCode.Symbology = code128Generator1;
            // 
            // xrTen
            // 
            this.xrTen.LocationFloat = new DevExpress.Utils.PointFloat(50.83333F, 0F);
            this.xrTen.Multiline = true;
            this.xrTen.Name = "xrTen";
            this.xrTen.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrTen.SizeF = new System.Drawing.SizeF(200F, 23F);
            this.xrTen.Text = "xrTen";
            // 
            // xrGia
            // 
            this.xrGia.LocationFloat = new DevExpress.Utils.PointFloat(50.83333F, 98.00001F);
            this.xrGia.Multiline = true;
            this.xrGia.Name = "xrGia";
            this.xrGia.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.xrGia.SizeF = new System.Drawing.SizeF(200F, 23F);
            this.xrGia.Text = "xrGia";
            // 
            // rptPrintBarcode
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail});
            this.Font = new DevExpress.Drawing.DXFont("Arial", 9.75F);
            this.Margins = new DevExpress.Drawing.DXMargins(100F, 100F, 68.33334F, 100F);
            this.Version = "23.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRLabel xrGia;
        private DevExpress.XtraReports.UI.XRLabel xrTen;
        private DevExpress.XtraReports.UI.XRBarCode xr_BarCode;
    }
}

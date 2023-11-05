using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace MATERIAL.Reports
{
    public partial class rptPrintBarcode : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPrintBarcode()
        {
            InitializeComponent();
            xrTen.DataBindings.Add("Text", this.DataSource, "TENHH");
            xr_BarCode.DataBindings.Add("Text", this.DataSource, "BARCODE");
            xrGia.DataBindings.Add("Text", this.DataSource, "DONGIA");
        }

    }
}

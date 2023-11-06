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
            xrTen.DataBindings.Add("Text", this.DataSource, "TENTAT");
            xr_BarCode.DataBindings.Add("Text", this.DataSource, "BARCODE");
            xrGia.DataBindings.Add("Text", this.DataSource, "DONGIA");
        }

        private void xrGia_BeforePrint(object sender, CancelEventArgs e)
        {
            XRLabel label = new XRLabel();
            string fileName = label.DataBindings[0].DataMember;
            double value = Convert.ToDouble(GetCurrentColumnValue(fileName));
            if (value == 0)
            {
                label.Text = "0";
            }
            else
            {
                label.Text = string.Format("Giá: {0:N0} đ", value);
            }
        }
    }
}

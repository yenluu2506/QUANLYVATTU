using BusinesssLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using MATERIAL.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATERIAL
{
    public partial class frmInBarcode : DevExpress.XtraEditors.XtraForm
    {
        public frmInBarcode()
        {
            InitializeComponent();
        }
        NHOMHH _nhom;
        HANGHOA _hanghoa;
        List<obj_PRINTBARCODE> lst;

        private void frmInBarcode_Load(object sender, EventArgs e)
        {
            _nhom = new NHOMHH();
            _hanghoa = new HANGHOA();
            lst = new List<obj_PRINTBARCODE>();
            loadNhom();
            cboNhom.SelectedIndexChanged += CboNhom_SelectedIndexChanged;
            loadDanhMuc();
        }

        private void CboNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDanhMuc();
        }
        void loadDanhMuc()
        {
            gcDanhMuc.DataSource = _hanghoa.getDanhMucInBarcode(int.Parse(cboNhom.SelectedValue.ToString()));
        }
        void loadNhom()
        {
            cboNhom.DataSource = _nhom.getAll();
            cboNhom.DisplayMember = "TENNHOM";
            cboNhom.ValueMember = "IDNHOM";
        }
        private void btnInBarcode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            List<obj_PRINTBARCODE> lst1 = new List<obj_PRINTBARCODE>();
            obj_PRINTBARCODE obj;
            for (int i = 0; i < gvDanhMuc.RowCount; i++)
            {
                if (gvDanhMuc.GetRowCellValue(i, "SOTEM") != null)
                {
                    for(int j=0; j<int.Parse(gvDanhMuc.GetRowCellValue(i, "SOTEM").ToString()) ; j++)
                    {
                        obj = new obj_PRINTBARCODE();
                        obj.BARCODE = gvDanhMuc.GetRowCellValue(i, "BARCODE").ToString();
                        obj.TENHH = gvDanhMuc.GetRowCellValue(i, "TENHH").ToString();
                        obj.TENTAT = gvDanhMuc.GetRowCellValue(i, "TENTAT").ToString();
                        obj.DONGIA = double.Parse(gvDanhMuc.GetRowCellValue(i, "DONGIA").ToString());
                        lst1.Add(obj);
                    }
                }
            }

            rptPrintBarcode rpt = new rptPrintBarcode();
            rpt.DataSource = lst1;
            rpt.ShowPreviewDialog();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
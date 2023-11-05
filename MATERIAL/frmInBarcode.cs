﻿using BusinesssLayer;
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
            rptPrintBarcode rpt = new rptPrintBarcode();
            rpt.DataSource = lst;
            rpt.ShowPreviewDialog();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}
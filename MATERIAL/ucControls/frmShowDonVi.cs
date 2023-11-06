using BusinesssLayer;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATERIAL.ucControls
{
    public partial class frmShowDonVi : DevExpress.XtraEditors.XtraForm
    {
        public frmShowDonVi()
        {
            InitializeComponent();
        }
        public frmShowDonVi(TextBox txtDonVi)
        {
            InitializeComponent();
            this._txtDonVi = txtDonVi;
        }
        TextBox _txtDonVi;
        DONVI _donvi;
        CONGTY _congty;
        private void frmShowDonVi_Load(object sender, EventArgs e)
        {
            CONGTY _congty = new CONGTY();
            _donvi = new DONVI();
            loadCongTy();
            loadDonVi();
            cboCongTy.SelectedIndexChanged += CboCongTy_SelectedIndexChanged;
            cboCongTy.SelectedValue = myFunctions._macty;
        }

        private void CboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDonVi();
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void loadCongTy()
        {
            cboCongTy.DataSource = _congty.getAll();
            cboCongTy.DisplayMember = "TENCTY";
            cboCongTy.ValueMember = "MACTY";
        }

        void loadDonVi()
        {
            gcDanhSach.DataSource = _donvi.getAll(cboCongTy.SelectedValue.ToString());
            gvDanhSach.OptionsBehavior.Editable = false;
        }
    }
}
using BusinesssLayer;
using DevExpress.XtraEditors;
<<<<<<< HEAD
using MATERIAL.MyFunctions;
=======
>>>>>>> d171d2e404948165d09d9b901876e18effaa02a8
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
<<<<<<< HEAD
            this._txtDonVi=txtDonVi;
=======
            this._txtDonVi = txtDonVi;
>>>>>>> d171d2e404948165d09d9b901876e18effaa02a8
        }
        TextBox _txtDonVi;
        DONVI _donvi;
        CONGTY _congty;
<<<<<<< HEAD

        private void btnXacNhan_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowDonVi_Load(object sender, EventArgs e)
        {
            CONGTY _congty = new CONGTY();
            _donvi=new DONVI();
=======
        private void frmShowDonVi_Load(object sender, EventArgs e)
        {
            CONGTY _congty = new CONGTY();
            _donvi = new DONVI();
>>>>>>> d171d2e404948165d09d9b901876e18effaa02a8
            loadCongTy();
            loadDonVi();
            cboCongTy.SelectedIndexChanged += CboCongTy_SelectedIndexChanged;
            cboCongTy.SelectedValue = myFunctions._macty;
        }

        private void CboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDonVi();
        }

<<<<<<< HEAD
=======
        private void btnThucHien_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
>>>>>>> d171d2e404948165d09d9b901876e18effaa02a8
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
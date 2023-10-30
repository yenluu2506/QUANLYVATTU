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

namespace MATERIAL
{
    public partial class frmNhapMua : DevExpress.XtraEditors.XtraForm
    {
        public frmNhapMua()
        {
            InitializeComponent();
        }
        CONGTY _congty;
        DONVI _donvi;
        NHACUNGCAP _nhaCC;
        private void frmNhapMua_Load(object sender, EventArgs e)
        {
            _congty = new CONGTY();
            _donvi = new DONVI();
            _nhaCC = new NHACUNGCAP();
            showHideControl(true);
            _enabled(false);
            loadCongTy();
            loadKho();
            cboCongTy.SelectedIndexChanged += CboCongTy_SelectedIndexChanged;
            loadDonVi();
            loadNhaCC();
            cboCongTy.SelectedValue = "CT01";
        }

        private void CboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDonVi();
            loadKho();
        }

        void loadCongTy()
        {
            cboCongTy.DataSource = _congty.getAll();
            cboCongTy.DisplayMember = "TENCTY";
            cboCongTy.ValueMember = "MACTY";
        }
        void loadDonVi()
        {
            cboDonVi.DataSource = _donvi.getKhoByCty(cboCongTy.SelectedValue.ToString());
            cboDonVi.DisplayMember = "TENDVI";
            cboDonVi.ValueMember = "MADVI";
        }
        void loadKho()
        {
            cboKho.DataSource = _donvi.getKhoByCty(cboCongTy.SelectedValue.ToString());
            cboKho.DisplayMember = "TENDVI";
            cboKho.ValueMember = "MADVI";
        }

        void loadNhaCC()
        {
            cboNhaCC.DataSource = _nhaCC.getAll();
            cboNhaCC.DisplayMember = "TENNCC";
            cboNhaCC.ValueMember = "MANCC";
        }

        void _enabled(bool t)
        {
            txtGhiChu.Enabled = t;
            cboTrangThai.Enabled = t;
            cboDonVi.Enabled = t;
            cboNhaCC.Enabled = t;
            dpNgay.Enabled = t;
        }

        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
        }
        void _reset()
        {
            txtSoPhieu.Text = "";
            txtGhiChu.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
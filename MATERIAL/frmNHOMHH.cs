using BusinesssLayer;
using DataLayer;
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
    public partial class frmNHOMHH : DevExpress.XtraEditors.XtraForm
    {
        public frmNHOMHH()
        {
            InitializeComponent();
        }

        NHOMHH _nhomHH;
        bool _them;
        int _idNhom;

        private void frmNHOMHH_Load(object sender, EventArgs e)
        {
            _nhomHH = new NHOMHH();
            showHideControl(true);
            _enabled(false);
            //txtMa.Enabled = false;
            loadData();
        }

        void _enabled(bool t)
        {
            txtTen.Enabled = t;
            txtGhiChu.Enabled = t;
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
            //txtMa.Text = "";
            txtTen.Text = "";
            txtGhiChu.Text = "";
        }

        void loadData()
        {
            gcDanhSach.DataSource = _nhomHH.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            showHideControl(false);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _nhomHH.delete(_idNhom);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_NHOMHH nhomHH = new tb_NHOMHH();
                nhomHH.TENNHOM = txtTen.Text;
                nhomHH.GHICHU = txtGhiChu.Text;
                _nhomHH.add(nhomHH);
            }
            else
            {
                tb_NHOMHH nhomHH = _nhomHH.getItem(_idNhom);
                nhomHH.TENNHOM = txtTen.Text;
                nhomHH.GHICHU = txtGhiChu.Text;
                _nhomHH.update(nhomHH);
            }
            _them = false;
            loadData();
            _enabled(false);
            showHideControl(true);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enabled(false);
            loadData();
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _idNhom = (int)gvDanhSach.GetFocusedRowCellValue("IDNHOM");
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENNHOM").ToString();
                txtGhiChu.Text = gvDanhSach.GetFocusedRowCellValue("GHICHU").ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
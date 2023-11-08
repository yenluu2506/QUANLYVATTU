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
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        public frmKhachHang()
        {
            InitializeComponent();
        }
        KHACHHANG _khachhang;
        bool _them;
        string _idkh;

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            _khachhang = new KHACHHANG();
            showHideControl(true);
            _enabled(false);
            txtMa.Enabled = false;
            loadData();
        }
        void _enabled(bool t)
        {
            txtTen.Enabled = t;
            txtDienThoai.Enabled = t;
            txtEmail.Enabled = t;
            txtDiaChi.Enabled = t;
            txtMST.Enabled = t;
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
            txtMa.Text = "";
            txtTen.Text = "";
            txtDienThoai.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            txtMST.Text = "";
        }
        void loadData()
        {
            gcDanhSach.DataSource = _khachhang.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();
            txtMa.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            showHideControl(false);
            txtMa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _khachhang.delete(_idkh);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_KHACHHANG kh = new tb_KHACHHANG();
                kh.IDKH = txtMa.Text;
                kh.HOTEN = txtTen.Text;
                kh.DIACHI = txtDiaChi.Text;
                kh.DIENTHOAI = txtDienThoai.Text;
                kh.EMAIL = txtEmail.Text;
                kh.MST = txtMST.Text;
                _khachhang.add(kh);
            }
            else
            {
                tb_KHACHHANG kh = _khachhang.getInfoKH(_idkh);
                kh.HOTEN = txtTen.Text;
                kh.DIACHI = txtDiaChi.Text;
                kh.DIENTHOAI = txtDienThoai.Text;
                kh.EMAIL = txtEmail.Text;
                kh.MST = txtMST.Text;
                _khachhang.update(kh);
            }
            _them = false;
            loadData();
            _enabled(false);
            showHideControl(true);
            txtMa.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enabled(false);
            txtMa.Enabled = false;
            loadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _idkh = gvDanhSach.GetFocusedRowCellValue("IDKH").ToString();
                txtMa.Text = gvDanhSach.GetFocusedRowCellValue("IDKH").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("HOTEN").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DIENTHOAI").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("EMAIL").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DIACHI").ToString();
                txtMST.Text = gvDanhSach.GetFocusedRowCellValue("MST").ToString();
            }
        }
    }
}
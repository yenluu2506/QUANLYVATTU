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
    public partial class frmNHACUNGCAP : DevExpress.XtraEditors.XtraForm
    {
        public frmNHACUNGCAP()
        {
            InitializeComponent();
        }

        NHACUNGCAP _ncc;
        bool _them;
        string _mancc;

        private void frmNHACUNGCAP_Load(object sender, EventArgs e)
        {
            _ncc = new NHACUNGCAP();
            showHideControl(true);
            _enabled(false);
            loadData();
            txtMaNCC.Enabled = false;
        }

        void _enabled(bool t)
        {
            txtTen.Enabled = t;
            txtDienThoai.Enabled = t;
            txtFax.Enabled = t;
            txtEmail.Enabled = t;
            txtDiaChi.Enabled = t;
            dtpCreateDate.Enabled = t;
            chkDisable.Enabled = t;
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
            txtTen.Text = "";
            txtDienThoai.Text = "";
            txtFax.Text = "";
            txtEmail.Text = "";
            txtDiaChi.Text = "";
            dtpCreateDate.Value = DateTime.Now;
            chkDisable.Checked = false;
        }
        void loadData()
        {
            gcDanhSach.DataSource = _ncc.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();
            txtMaNCC.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            showHideControl(false);
            txtMaNCC.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _ncc.delete(_mancc);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNCC.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhà cung cấp?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
            if (_them)
            {
                tb_NHACUNGCAP ncc = new tb_NHACUNGCAP();
                ncc.MANCC = txtMaNCC.Text;
                ncc.TENNCC = txtTen.Text;
                ncc.DIACHI = txtDiaChi.Text;
                ncc.DIENTHOAI = txtDienThoai.Text;
                ncc.FAX = txtFax.Text;
                ncc.EMAIL = txtEmail.Text;
                ncc.CREATED_DATE = dtpCreateDate.Value;
                ncc.DISABLED = chkDisable.Checked;
                _ncc.add(ncc);
            }
            else
            {
                tb_NHACUNGCAP ncc = _ncc.getItem(_mancc);
                ncc.TENNCC = txtTen.Text;
                ncc.DIACHI = txtDiaChi.Text;
                ncc.DIENTHOAI = txtDienThoai.Text;
                ncc.FAX = txtFax.Text;
                ncc.EMAIL = txtEmail.Text;
                ncc.CREATED_DATE = dtpCreateDate.Value;
                ncc.DISABLED = chkDisable.Checked;
                _ncc.update(ncc);
            }
            _them = false;
            loadData();
            _enabled(false);
            showHideControl(true);
            txtMaNCC.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enabled(false);
            loadData();
            txtMaNCC.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _mancc = gvDanhSach.GetFocusedRowCellValue("MANCC").ToString();
                txtMaNCC.Text = gvDanhSach.GetFocusedRowCellValue("MANCC").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENNCC").ToString();
                txtDienThoai.Text = gvDanhSach.GetFocusedRowCellValue("DIENTHOAI").ToString();
                txtFax.Text = gvDanhSach.GetFocusedRowCellValue("FAX").ToString();
                txtEmail.Text = gvDanhSach.GetFocusedRowCellValue("EMAIL").ToString();
                txtDiaChi.Text = gvDanhSach.GetFocusedRowCellValue("DIACHI").ToString();
                dtpCreateDate.Text = gvDanhSach.GetFocusedRowCellValue("CREATE_DATE").ToString();
                chkDisable.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
            }
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "DISABLED" && bool.Parse(e.CellValue.ToString()) == true)
            {
                Image img = Properties.Resources.del_Icon_x16;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }
    }
}
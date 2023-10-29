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
    public partial class frmXUATXU : DevExpress.XtraEditors.XtraForm
    {
        public frmXUATXU()
        {
            InitializeComponent();
        }

        XUATXU _xuatxu;
        bool _them;
        int _id;

        private void frmXUATXU_Load(object sender, EventArgs e)
        {
            _xuatxu = new XUATXU();
            showHideControl(true);
            _enabled(false);
            //txtMa.Enabled = false;
            loadData();
        }

        void _enabled(bool t)
        {
            txtTen.Enabled = t;
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
        }

        void loadData()
        {
            gcDanhSach.DataSource = _xuatxu.getAll();
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
                _xuatxu.delete(_id);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_XUATXU xuatxu = new tb_XUATXU();
                xuatxu.TEN = txtTen.Text;
                _xuatxu.add(xuatxu);
            }
            else
            {
                tb_XUATXU xuatxu = _xuatxu.getItem(_id);
                xuatxu.TEN = txtTen.Text;
                _xuatxu.update(xuatxu);
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TEN").ToString();
            }
        }
    }
}
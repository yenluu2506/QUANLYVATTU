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
    public partial class frmDONVITINH : DevExpress.XtraEditors.XtraForm
    {
        public frmDONVITINH()
        {
            InitializeComponent();
        }

        DONVITINH _dvt;
        bool _them;
        int _id;

        private void frmDONVITINH_Load(object sender, EventArgs e)
        {
            _dvt = new DONVITINH();
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
            gcDanhSach.DataSource = _dvt.getAll();
            gvDanhSach.OptionsBehavior.Editable = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            _them = true;
            showHideControl(false);
            _enabled(true);
            _reset();
            //txtMa.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            _them = false;
            _enabled(true);
            showHideControl(false);
            //txtMa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _dvt.delete(_id);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_DVT dvt = new tb_DVT();
                // Kiểm tra xem txtMa.Text có giá trị hợp lệ hay không
                //if (int.TryParse(txtMa.Text, out int intValue))
                //{
                //    // Nếu chuyển đổi thành công, gán giá trị intValue cho dvt.ID
                //    dvt.ID = intValue;
                //}
                //else
                //{
                //    // Xử lý trường hợp không thể chuyển đổi thành công (giá trị không phải là số nguyên)
                //    // Ví dụ: Hiển thị thông báo lỗi cho người dùng
                //    MessageBox.Show("Giá trị không hợp lệ. Vui lòng nhập số nguyên.");
                //}
                dvt.TEN = txtTen.Text;
                _dvt.add(dvt);
            }
            else
            {
                tb_DVT dvt = _dvt.getItem(_id);
                dvt.TEN = txtTen.Text;
                _dvt.update(dvt);
            }
            _them = false;
            loadData();
            _enabled(false);
            showHideControl(true);
            //txtMa.Enabled = false;
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            showHideControl(true);
            _enabled(false);
            //txtMa.Enabled = false;
            loadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        //{
        //    if (e.Column.Name == "DISABLED" && bool.Parse(e.CellValue.ToString()) == true)
        //    {
        //        Image img = Properties.Resources.del_Icon_x16;
        //        e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
        //        e.Handled = true;
        //    }
        //}

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            //if (gvDanhSach.RowCount > 0)
            //{
            //    _id = gvDanhSach.GetFocusedRowCellValue("ID").ToString();
            //    txtMa.Text = gvDanhSach.GetFocusedRowCellValue("ID").ToString();
            //    txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TEN").ToString();
            //}

            if (gvDanhSach.RowCount > 0)
            {
                //object idValue = gvDanhSach.GetFocusedRowCellValue("ID");

                //if (idValue != null)
                //{
                //    string idString = idValue.ToString();
                //    if (int.TryParse(idString, out int id))
                //    {
                //        _id = id;
                //        txtMa.Text = id.ToString(); // Set the text box with the integer value as a string
                //    }
                //    else
                //    {
                //        // Xử lý tình huống khi giá trị "ID" không thể chuyển đổi thành số nguyên hợp lệ.
                //        MessageBox.Show("Giá trị 'ID' không phải là số nguyên hợp lệ.");
                //        // Bạn có thể thực hiện các hành động khác, chẳng hạn như xóa dữ liệu, yêu cầu người dùng nhập lại, hoặc làm gì đó phù hợp với ứng dụng của bạn.
                //    }
                //}
                //else
                //{
                //    // Xử lý tình huống khi giá trị "ID" là null.
                //    // Ví dụ: có thể đặt _id và txtMa.Text thành giá trị mặc định hoặc xóa nội dung trong trường hợp này.
                //    _id = 0; // Đặt giá trị mặc định hoặc theo yêu cầu của bạn.
                //    txtMa.Text = string.Empty; // Xóa nội dung text box.
                //}
                _id = (int)gvDanhSach.GetFocusedRowCellValue("ID");
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TEN").ToString();
            }

        }
    }
}
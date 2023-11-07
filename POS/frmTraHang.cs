using BusinesssLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS
{
    public partial class frmTraHang : DevExpress.XtraEditors.XtraForm
    {
        public frmTraHang()
        {
            InitializeComponent();
        }

        public frmTraHang(List<obj_CHUNGTU_CT> lstChungTu, GridControl gcChiTiet)
        {
            InitializeComponent();
            this._lstChungTuCT = lstChungTu;
            this._gcChiTiet = gcChiTiet;
        }

        List<obj_CHUNGTU_CT> _lstChungTuCT;
        GridControl _gcChiTiet;
        private void frmTraHang_Load(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            obj_CHUNGTU_CT obj;
            var item = _lstChungTuCT.FirstOrDefault(x => x.BARCODE == txtBarcode.Text);
            if (item != null)
            {
                obj = new obj_CHUNGTU_CT();
                obj.BARCODE = item.BARCODE;
                obj.TENHH = item.TENHH;
                obj.DVT = item.DVT;
                obj.SOLUONG = int.Parse("-" + txtSoLuong.Text);
                obj.DONGIA = item.DONGIA;
                obj.THANHTIEN = obj.SOLUONG * obj.DONGIA;
                if (item.SOLUONG < int.Parse(txtSoLuong.Text))
                {
                    MessageBox.Show("Số lượng trả không được lớn hơn số lượng mua.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                _lstChungTuCT.Add(obj);
                _gcChiTiet.DataSource = _lstChungTuCT.ToList();
            }
            else
            {
                MessageBox.Show("Mã hàng không có trong đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
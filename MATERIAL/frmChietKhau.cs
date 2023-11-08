using BusinesssLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using MATERIAL.MyFunctions;
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
    public partial class frmChietKhau : DevExpress.XtraEditors.XtraForm
    {
        public frmChietKhau()
        {
            InitializeComponent();
        }

        string chietkhau;
        public frmChietKhau(GridView gvChiTiet)
        {
            InitializeComponent();
            this._gvChiTiet = gvChiTiet;
        }

        GridView _gvChiTiet;
        private void frmChietKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

            if (myFunctions.sIsNumber(txtChietKhau.Text))
            {
                chietkhau = txtChietKhau.Text;
               for (int i = 0; i < _gvChiTiet.RowCount; i++)
                {
                    _gvChiTiet.SetRowCellValue(i, "CHIETKHAU", txtChietKhau.Text);
                    _gvChiTiet.SetRowCellValue(i, "THANHTIEN", double.Parse(_gvChiTiet.GetRowCellValue(i, "DONGIA").ToString()) * double.Parse(_gvChiTiet.GetRowCellValue(i, "SOLUONG").ToString()) * (1 - double.Parse(txtChietKhau.Text) / 100));
                }
               this.Close();

            }
            else
            {
                MessageBox.Show("Chiết khấu phải là số.", "Thông báo");
            }
        }
    }
}
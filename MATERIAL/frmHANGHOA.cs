using BusinesssLayer;
using DataLayer;
using DevExpress.XtraCharts.Heatmap.Native;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel=Microsoft.Office.Interop.Excel;

namespace MATERIAL
{
    public partial class frmHANGHOA : DevExpress.XtraEditors.XtraForm
    {
        public frmHANGHOA()
        {
            InitializeComponent();
        }

        tb_SYS_USER _User;
        int _right;
        HANGHOA _hanghoa;
        bool _them;
        string _barcode;
        NHACUNGCAP _nhacc;
        DONVITINH _dvt;
        NHOMHH _nhomHH;
        SYS_SEQUENCE _sysSeq;
        tb_SYS_SEQUENCE _seq;
        XUATXU _xuatxu;
        List<obj_HANGHOA> _lstHH = new List<obj_HANGHOA> ();

        private void frmHANGHOA_Load(object sender, EventArgs e)
        {
            _nhacc = new NHACUNGCAP();
            _dvt = new DONVITINH();
            _nhomHH = new NHOMHH();
            _xuatxu = new XUATXU();
            _hanghoa = new HANGHOA();
            _sysSeq = new SYS_SEQUENCE();
            showHideControl(true);
            _enabled(false);

            loadNhom();//đưa lên trên loaddata() là
            loadNhaCC();
            loadDVT();
            loadXuatXu();
            loadData();
            cboNhom.SelectedIndexChanged += cboNhom_SelectedIndexChanged;
        }

        void loadNhom()
        {
            cboNhom.DisplayMember = "TENNHOM";
            cboNhom.ValueMember = "IDNHOM";
            cboNhom.DataSource = _nhomHH.getAll();
        }
        private void cboNhom_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }
        void loadNhaCC()
        {
            cboNhaCC.DataSource = _nhacc.getAll();
            cboNhaCC.DisplayMember = "TENNCC";
            cboNhaCC.ValueMember = "MANCC";
        }

        void loadDVT()
        {
            cboDVT.DataSource = _dvt.getAll();
            cboDVT.DisplayMember = "TEN";
            cboDVT.ValueMember = "ID";
        }
        void loadXuatXu()
        {
            cboXuatXu.DataSource = _xuatxu.getAll();
            cboXuatXu.DisplayMember = "TEN";
            cboXuatXu.ValueMember = "ID";
        }
        void _enabled(bool t)
        {
            txtTen.Enabled = t;
            txtTenTat.Enabled = t;
            txtMoTa.Enabled = t;
            cboDVT.Enabled = t;
            spGia.Enabled = t;
            cboNhaCC.Enabled = t;
            cboXuatXu.Enabled = t;
            chkDisabled.Enabled = t;
        }

        void showHideControl(bool t)
        {
            btnThem.Visible = t;
            btnSua.Visible = t;
            btnXoa.Visible = t;
            btnThoat.Visible = t;
            btnLuu.Visible = !t;
            btnBoQua.Visible = !t;
            btnExport.Visible = t;
        }

        void _reset()
        {
            txtBarcode.Text = "";
            txtTen.Text = "";
            txtTenTat.Text = "";
            txtMoTa.Text = "";
        }
        void loadData()
        {
            gcDanhSach.DataSource = _hanghoa.getListByNhom(int.Parse(Convert.ToString(cboNhom.SelectedValue)));
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstHH = _hanghoa.getListByNhomFull(int.Parse(Convert.ToString(cboNhom.SelectedValue)));
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
                _hanghoa.delete(_barcode);
            }
            loadData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (_them)
            {
                tb_HANGHOA hh = new tb_HANGHOA();
                _seq = _sysSeq.getItem("HH@" + DateTime.Now.Year.ToString() + "@" + cboNhom.SelectedValue.ToString());
                if (_seq == null)
                {
                    _seq = new tb_SYS_SEQUENCE();
                    _seq.SEQNAME = "HH@" + DateTime.Now.Year.ToString() + "@" + cboNhom.SelectedValue.ToString();
                    _seq.SEQVALUE = 1;
                    _sysSeq.add(_seq);
                }
                hh.BARCODE = BarcodeEAN13.BuildEan13(DateTime.Now.Year.ToString() + cboNhom.SelectedValue.ToString() + _seq.SEQVALUE.Value.ToString("0000000"));
                hh.TENHH = txtTen.Text;
                hh.TENTAT = txtTenTat.Text;
                hh.IDNHOM = int.Parse(cboNhom.SelectedValue.ToString());
                hh.MOTA = txtMoTa.Text;
                hh.MANCC = cboNhaCC.SelectedValue.ToString();
                hh.MAXX = int.Parse(cboXuatXu.SelectedValue.ToString());
                hh.DVT = cboDVT.Text;
                hh.DISABLED = chkDisabled.Checked;
                hh.CREATED_DATE = DateTime.Now;
                hh.CREATED_BY = 1;
                hh.DONGIA = float.Parse(spGia.Text);
                var _hh = _hanghoa.add(hh);
                txtBarcode.Text = _hh.BARCODE;
                _sysSeq.update(_seq);
            }
            else
            {
                tb_HANGHOA hh = _hanghoa.getItem(_barcode);
                hh.TENHH = txtTen.Text;
                hh.TENTAT = txtTenTat.Text;
                hh.IDNHOM = int.Parse(cboNhom.SelectedValue.ToString());
                hh.MOTA = txtMoTa.Text;
                hh.MANCC = cboNhaCC.SelectedValue.ToString();
                hh.MAXX = int.Parse(cboXuatXu.SelectedValue.ToString());
                hh.DVT = cboDVT.Text;
                hh.DISABLED = chkDisabled.Checked;
                hh.DONGIA = float.Parse(spGia.Text);
                var _hh = _hanghoa.update(hh);
                txtBarcode.Text = _hh.BARCODE;
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
                _barcode = gvDanhSach.GetFocusedRowCellValue("BARCODE").ToString();
                txtBarcode.Text = gvDanhSach.GetFocusedRowCellValue("BARCODE").ToString();
                txtTen.Text = gvDanhSach.GetFocusedRowCellValue("TENHH").ToString();
                txtTenTat.Text = gvDanhSach.GetFocusedRowCellValue("TENTAT").ToString();
                txtMoTa.Text = gvDanhSach.GetFocusedRowCellValue("MOTA").ToString();
                cboNhaCC.SelectedValue = gvDanhSach.GetFocusedRowCellValue("MANCC");
                cboXuatXu.SelectedValue = gvDanhSach.GetFocusedRowCellValue("MAXX");
                cboDVT.Text = gvDanhSach.GetFocusedRowCellValue("DVT").ToString();
                spGia.Text = gvDanhSach.GetFocusedRowCellValue("DONGIA").ToString();
                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());
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

        private void spGia_Validating(object sender, CancelEventArgs e)
        {
            //SpinEdit spinEdit = (SpinEdit)sender;
            //int enteredValue = Convert.ToInt32(spinEdit.EditValue);

            //if (enteredValue <= 0)
            //{
            //    e.Cancel = true;
            //    spinEdit.ErrorText = "Không được nhập số âm.";
            //}
        }

        private void spGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' && ((SpinEdit)sender).Text.Length == 0)
            {
                e.Handled = true;
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn nhập ký tự không phải là số hoặc điều khiển
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            _export();
        }

        void _export()
        {
            string tenFile = "";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel 2000-2003 (.xls) | *.xls|Excel 2007 or higher (.xlsx) |*.xlsx"; //Xet dinh dang mac dinh cho file
            if(saveFile.ShowDialog() == DialogResult.OK)
            {
                SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
                tenFile = saveFile.FileName;
            }
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
            Excel._Worksheet sheet = null;

            try
            {
                sheet = wb.ActiveSheet;
                //Dat ten sheet
                sheet.Name = "DM " + cboNhom.Text;
                sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 12]].Merge();
                //canh le text
                sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //Border
                sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 12]].BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic);
                sheet.Cells[1, 1].Value = "DANH MỤC " + cboNhom.Text.ToUpper();
                sheet.Cells[1, 1].Font.Size = 20;
                sheet.Cells[2, 1].Value = "BARCODE";
                sheet.Cells[2, 2].Value = "TÊN HÀNG HÓA";
                sheet.Cells[2, 3].Value = "TÊN TẮT";
                sheet.Cells[2, 4].Value = "ĐVT";
                sheet.Cells[2, 5].Value = "TRỊ GIÁ";
                sheet.Cells[2, 6].Value = "MÔ TẢ";
                sheet.Cells[2, 7].Value = "MÃ NHÓM";
                sheet.Cells[2, 8].Value = "TÊN NHÓM";
                sheet.Cells[2, 9].Value = "MÃ NCC";
                sheet.Cells[2, 10].Value = "TÊN NCC";
                sheet.Cells[2, 11].Value = "MÃ XX";
                sheet.Cells[2, 12].Value = "XUẤT XỨ";

                //xuat du lieu
                for (int i = 1; i <= _lstHH.Count; i++)
                {
                    sheet.Cells[i + 2, 1].Value = _lstHH.ElementAt(i - 1).BARCODE;
                    sheet.Cells[i + 2, 2].Value = _lstHH.ElementAt(i - 1).TENHH;
                    sheet.Cells[i + 2, 3].Value = _lstHH.ElementAt(i - 1).TENTAT;
                    sheet.Cells[i + 2, 4].Value = _lstHH.ElementAt(i - 1).DVT;
                    sheet.Cells[i + 2, 5].Value = _lstHH.ElementAt(i - 1).DONGIA;
                    sheet.Cells[i + 2, 6].Value = _lstHH.ElementAt(i - 1).MOTA;
                    sheet.Cells[i + 2, 7].Value = _lstHH.ElementAt(i - 1).IDNHOM;
                    sheet.Cells[i + 2, 8].Value = _lstHH.ElementAt(i - 1).TENNHOM;
                    sheet.Cells[i + 2, 9].Value = _lstHH.ElementAt(i - 1).MANCC;
                    sheet.Cells[i + 2, 10].Value = _lstHH.ElementAt(i - 1).TENNCC;
                    sheet.Cells[i + 2, 11].Value = _lstHH.ElementAt(i - 1).MAXX;
                    sheet.Cells[i + 2, 12].Value = _lstHH.ElementAt(i - 1).TENXX;
                }
                //Save vao file
                wb.SaveAs(tenFile);
            }
            catch(Exception ex)
            {
                SplashScreenManager.CloseForm();
                MessageBox.Show(ex.ToString(), "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                wb.Close();
                app.Quit();
                releaseObject(wb);
                releaseObject(app);
                SplashScreenManager.CloseForm();
                MessageBox.Show("Xuất File thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch(Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
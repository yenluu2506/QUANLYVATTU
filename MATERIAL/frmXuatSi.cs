using BusinesssLayer;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraSplashScreen;
using MATERIAL.MyFunctions;
using MATERIAL.MyPopup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MATERIAL
{
    public partial class frmXuatSi : DevExpress.XtraEditors.XtraForm
    {
        public frmXuatSi()
        {
            InitializeComponent();
        }

        public frmXuatSi(tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
        }

        tb_SYS_USER _user;
        int _right;
        bool _them;
        bool _sua;
        List<string> _lstBarcode;
        string err = "";
        List<_TRANGTHAI> _trangthai;
        CONGTY _congty;
        DONVI _donvi;
        CHUNGTU _chungtu;
        CHUNGTU_CT _chungtuct;
        SYS_SEQUENCE _sequence;
        HANGHOA _hanghoa;
        KHACHHANG _khachhang;
        BindingSource _bdChungTuCT;
        BindingSource _bdChungTu;
        Guid _khoa;
        tb_SYS_SEQUENCE _seq;
        List<tb_CHUNGTU> _lstChungTu;
        bool _isImport;
        Guid pKhoa;

        private void frmXuatSi_Load(object sender, EventArgs e)
        {
            _isImport = false;
            _lstBarcode = new List<string>();
            _congty = new CONGTY();
            _donvi = new DONVI();
            _chungtu = new CHUNGTU();
            _chungtuct = new CHUNGTU_CT();
            _hanghoa = new HANGHOA();
            _khachhang = new KHACHHANG();
            _sequence = new SYS_SEQUENCE();
            _bdChungTuCT = new BindingSource();
            _bdChungTu = new BindingSource();

            dtTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtDenNgay.Value = DateTime.Now;

            _bdChungTu.PositionChanged += _bdChungTu_PositionChanged; ;
            loadCongTy();
            cboCongTy.SelectedValue = myFunctions._macty;
            cboCongTy.SelectedIndexChanged += CboCongTy_SelectedIndexChanged; ;

            _trangthai = _TRANGTHAI.getList();
            cboTrangThai.DataSource = _trangthai;
            cboTrangThai.DisplayMember = "_display";
            cboTrangThai.ValueMember = "_value";

            
            loadDonVi();
            loadDonViXuat();
            loadKhachHang();
            if (myFunctions._madvi == "~")
            {
                cboDonVi.SelectedValue = "CTKHO1";
            }
            else
            {
                cboDonVi.SelectedValue = myFunctions._madvi;
            }
            _lstChungTu = _chungtu.getList(3, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboDonVi.SelectedValue.ToString());
            _bdChungTu.DataSource = _lstChungTu;
            gcDanhSach.DataSource = _bdChungTu;

            xuatThongTin();
            cboDonVi.SelectedIndexChanged += CboDonVi_SelectedIndexChanged; ;
            //cboKho.SelectedIndexChanged += CboKho_SelectedIndexChanged;
            showHideControl(true);
            contextMenuChiTiet.Enabled = false;
            _disabled(true);
        }

        void loadCongTy()
        {
            cboCongTy.DataSource = _congty.getAll();
            cboCongTy.DisplayMember = "TENCTY";
            cboCongTy.ValueMember = "MACTY";
        }
        void _enabledButton(bool t)
        {
            btnBoQua.Enabled = t;
            btnIn.Enabled = t;
            btnSua.Enabled = t;
            btnXoa.Enabled = t;
            btnThem.Enabled = t;
        }
        void load_gridData()
        {
            string madvi;
            if (cboDonVi.SelectedValue != null)
            {
                madvi = cboDonVi.SelectedValue.ToString();
                _enabledButton(true);
            }
            else
            {
                madvi = "";
                _enabledButton(false);
            }
            _lstChungTu = _chungtu.getList(3, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), madvi);
            _bdChungTu.DataSource = _lstChungTu;
            gcDanhSach.DataSource = _bdChungTu;
        }
        void loadDonVi()
        {
            var _lstkho = _donvi.getAll(cboCongTy.SelectedValue.ToString());

            cboDonVi.DataSource = _lstkho;
            cboDonVi.DisplayMember = "TENDVI";
            cboDonVi.ValueMember = "MADVI";
            if (_lstkho.Count == 0)
            {
                loadDonViXuat();
                cboDonVi.Text = "";
                cboDonViXuat.SelectedIndex = cboDonVi.SelectedIndex;
                load_gridData();
            }
            else
            {
                loadDonViXuat();
                //cboDonVi.SelectedIndex = 0;
                cboDonViXuat.SelectedValue = cboDonVi.SelectedValue;
                load_gridData();
            }
        }
        void loadDonViXuat()
        {
            cboDonViXuat.DataSource = _donvi.getAll(cboCongTy.SelectedValue.ToString());
            cboDonViXuat.DisplayMember = "TENDVI";
            cboDonViXuat.ValueMember = "MADVI";
        }
        void loadKhachHang()
        {
            lkKhachHang.Properties.DataSource = _khachhang.getAll();
            lkKhachHang.Properties.DisplayMember = "HOTEN";
            lkKhachHang.Properties.ValueMember = "IDKH";
        }
        void showHideControl(bool kt)
        {
            btnLuu.Visible = !kt;
            btnIn.Visible = !kt;
            btnThem.Visible = kt;
            btnSua.Visible = kt;
            btnXoa.Visible = kt;
        }

        void _edControl(bool t)
        {
            txtGhiChu.Enabled = t;
            cboTrangThai.Enabled = t;
            cboDonViXuat.Enabled = t;
            lkKhachHang.Enabled = t;
            dtNgay.Enabled = t;
        }

        void _disabled(bool t)
        {
            gvDanhSach.OptionsBehavior.Editable = !t;
            gvChiTiet.OptionsBehavior.Editable = !t;
            contextMenuChiTiet.Enabled = !t;
            txtGhiChu.Enabled = !t;
        }

        void _reset()
        {
            txtSoPhieu.Text = "";
            txtGhiChu.Text = "";
        }

        private void CboDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_gridData();
        }

        private void CboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDonVi();
        }

        private void _bdChungTu_PositionChanged(object sender, EventArgs e)
        {
            if (!_them)
            {
                xuatThongTin();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("Không có quyền thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            cboDonViXuat.SelectedValue = cboDonVi.SelectedValue;
            _bdChungTuCT.DataSource = _chungtuct.getListByKhoaFull(_khoa);
            gcChiTiet.DataSource = _bdChungTuCT;
            gvChiTiet.AddNewRow();
            tabChungTu.SelectedTabPage = pageChiTiet;
            gvChiTiet.OptionsBehavior.Editable = true;
            contextMenuChiTiet.Enabled = true;
            _them = true;
            _sua = false;
            showHideControl(false);
            _edControl(true);
            _reset();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("Không có quyền thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                tb_CHUNGTU current = (tb_CHUNGTU)_bdChungTu.Current;
                if (current.TRANGTHAI == 1)
                {
                    _them = false;
                    _sua = true;
                    showHideControl(false);
                    _edControl(true);
                    tabChungTu.SelectedTabPage = pageChiTiet;
                    tabChungTu.TabPages[0].PageEnabled = false;
                    gvChiTiet.OptionsBehavior.Editable = true;
                    contextMenuChiTiet.Enabled = true;
                    cboDonVi.Enabled = false;
                    if (gvChiTiet.RowCount == 0)
                    {
                        List<V_CHUNGTU_CT> _lstChitiet = new List<V_CHUNGTU_CT>();
                        _bdChungTu.DataSource = _lstChitiet;
                        gcChiTiet.DataSource = _bdChungTu;
                        gvChiTiet.AddNewRow();
                        gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "STT", 1);
                    }
                }
                else
                {
                    MessageBox.Show("Không được phép chỉnh sửa chứng từ đã hoàn tất", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;

                }
            }
            _bdChungTuCT.DataSource = _chungtuct.getListByKhoaFull(_khoa);
            gcChiTiet.DataSource = _bdChungTuCT;
            gvChiTiet.AddNewRow();
            tabChungTu.SelectedTabPage = pageChiTiet;
            gvChiTiet.OptionsBehavior.Editable = true;
            contextMenuChiTiet.Enabled = true;
            _them = true;
            _sua = false;
            showHideControl(false);
            _edControl(true);
            _reset();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("Không có quyền thao tác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn hủy phiếu này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tb_CHUNGTU current = (tb_CHUNGTU)_bdChungTu.Current;
                    int index = _bdChungTu.Position;
                    _chungtu.delete(current.KHOA, _user.IDUSER);
                    gvDanhSach.SetRowCellValue(index, "DELETED_BY", 0);
                    //lblXoa.Visible = true;
                }
                else
                    return;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            luuThongTin();
            _them = false;
            _sua = false;
            gvChiTiet.OptionsBehavior.Editable = false;
            contextMenuChiTiet.Enabled = false;
            tabChungTu.TabPages[0].PageEnabled = true;
            showHideControl(true);
            _edControl(false);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void mnXoaDong_Click(object sender, EventArgs e)
        {
            int index = 0;
            if (gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "BARCODE") != null)
            {
                if (_them)
                    gvChiTiet.DeleteSelectedRows();
                else
                {
                    index = gvChiTiet.FocusedRowHandle;
                    _lstBarcode.Add(gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "BARCODE").ToString());
                    gvChiTiet.DeleteSelectedRows();
                }
                if (gvChiTiet.RowCount == 0)
                {
                    gvChiTiet.AddNewRow();
                    gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "STT", 1);
                }
                else
                {
                    for (int i = 0; i < gvChiTiet.RowCount; i++)
                    {
                        gvChiTiet.FocusedRowHandle = i;
                        gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "STT", i + 1);
                    }
                }
                gvChiTiet.FocusedRowHandle = index;
            }
            else
            {
                MessageBox.Show("Chưa chọn mẫu tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void mnXoaChiTiet_Click(object sender, EventArgs e)
        {
            _lstBarcode.Clear();
            for (int i = gvChiTiet.RowCount; i >= 0; i--)
            {
                _lstBarcode.Add(gvChiTiet.GetRowCellValue(i, "BARCODE").ToString());
                gvChiTiet.DeleteRow(i);
            }
            gvChiTiet.AddNewRow();
            gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "STT", 1);
        }

        private void mnImportExcel_Click(object sender, EventArgs e)
        {
            importExcel();
        }

        void importExcel()
        {
            string filename = "";
            List<errExport> err = new List<errExport>();
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "Excel 2000-2003 (.xls)|*.xls|Excel 2007 (.xlsx)|*.xlsx";
            if (op.ShowDialog() == DialogResult.OK)
            {
                SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
                _isImport = true;
                List<string> s = new List<string>();
                List<string> _exist = new List<string>();
                if (gvChiTiet.RowCount > 1)
                {
                    if (gvChiTiet.GetRowCellValue(gvChiTiet.RowCount - 1, "TENHH") != null)
                    {
                        for (int i = 0; i < gvChiTiet.RowCount; i++)
                        {
                            _exist.Add(gvChiTiet.GetRowCellValue(i, "BARCODE").ToString());
                        }
                    }
                    else
                    {
                        for (int i = 0; i < gvChiTiet.RowCount - 1; i++)
                        {
                            _exist.Add(gvChiTiet.GetRowCellValue(i, "BARCODE").ToString());
                        }
                    }
                }
                filename = op.FileName;
                //đọc file excel tạo đối tượng excel
                Excel.Application app = new Excel.Application();
                //Kết nối với tập tin Excell
                Excel.Workbook wb = app.Workbooks.Open(filename);
                List<obj_CHUNGTU_CT> lstCTCT = new List<obj_CHUNGTU_CT>();
                try
                {
                    //Kết nối với sheet cần đọc
                    Excel._Worksheet sheet = wb.Sheets["Sheet1"];
                    //Giới hạn đọc từ dòng cột nào đến dòng cột nào
                    Excel.Range range = sheet.UsedRange;
                    double tongdong = range.Rows.Count;
                    for (float i = 2; i <= range.Rows.Count; i++)
                    {
                        tb_HANGHOA hh = _hanghoa.getItem(range.Cells[i, 1].Value.ToString());
                        if (hh == null)
                        {
                            errExport _err = new errExport();
                            _err._barcode = range.Cells[i, 1].Value.ToString();
                            _err._soluong = int.Parse(range.Cells[i, 2].Value.ToString());
                            _err._errcode = "Barcode không tồn tại";
                            err.Add(_err);
                            continue;
                        }
                        else
                        {
                            if (_exist.Find(x => x.Equals(hh.BARCODE)) != null)
                            {
                                errExport _err = new errExport();
                                _err._barcode = range.Cells[i, 1].Value.ToString();
                                _err._soluong = int.Parse(range.Cells[i, 2].Value.ToString());
                                _err._errcode = "Trùng Barcode";
                                err.Add(_err);
                                continue;
                            }
                            else
                            {
                                s.Add(range.Cells[i, 1].Value.ToString() + "," + range.Cells[i, 2].Value.ToString());
                                _exist.Add(range.Cells[i, 1].Value.ToString());
                            }
                        }
                    }
                    //releaseObject(sheet)
                    foreach (string _validItem in s)
                    {
                        string[] item = _validItem.Split(',');
                        string _BARCODE = item[0].ToString();
                        double _soluong = double.Parse(item[1].ToString());
                        obj_HANGHOA _h = _hanghoa.getItemFull(_BARCODE);
                        if (gvChiTiet.RowCount > 1)
                        {
                            int mautin = gvChiTiet.RowCount;
                            gvChiTiet.SelectRow(mautin - 1);
                            if (gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "TENHH") == null)
                            {
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "STT", mautin);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "BARCODE", _h.BARCODE);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "DVT", _h.DVT);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "TENHH", _h.TENHH);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "SOLUONG", _soluong);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "DONGIA", _h.DONGIA);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "THANHTIEN", _h.DONGIA * _soluong);
                            }
                            else
                            {
                                gvChiTiet.AddNewRow();
                                gvChiTiet.SelectRow(mautin);
                                mautin++;
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "STT", mautin);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "BARCODE", _h.BARCODE);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "DVT", _h.DVT);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "TENHH", _h.TENHH);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "SOLUONG", _soluong);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "DONGIA", _h.DONGIA);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "THANHTIEN", _h.DONGIA * _soluong);
                            }
                        }
                        else
                        {
                            if (gvChiTiet.RowCount == 0)
                                gvChiTiet.AddNewRow();
                            int mautin = gvChiTiet.RowCount;
                            gvChiTiet.SelectRow(mautin - 1);
                            if (gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "TENHH") == null)
                            {
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "STT", mautin);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "BARCODE", _h.BARCODE);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "DVT", _h.DVT);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "TENHH", _h.TENHH);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "SOLUONG", _soluong);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "DONGIA", _h.DONGIA);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "THANHTIEN", _h.DONGIA * _soluong);
                            }
                            else
                            {
                                gvChiTiet.AddNewRow();
                                gvChiTiet.SelectRow(mautin);
                                mautin++;
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "STT", mautin);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "BARCODE", _h.BARCODE);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "DVT", _h.DVT);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "TENHH", _h.TENHH);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "SOLUONG", _soluong);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "DONGIA", _h.DONGIA);
                                gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "THANHTIEN", _h.DONGIA * _soluong);
                            }
                        }
                    }
                    gvChiTiet.AddNewRow();
                    gvChiTiet.SelectRow(gvChiTiet.RowCount - 1);
                    gvChiTiet.DeleteSelectedRows();
                    _isImport = false;
                }
                catch (Exception ex)
                {

                    app.Workbooks.Close();
                    SplashScreenManager.CloseForm(false);
                    MessageBox.Show("Import không thành công kiểm tra lại đường dẫn và định dạng tệp. Lỗi: " + ex.Message, "Thông báo");
                }
                finally
                {
                    wb.Close();
                    app.Quit();
                    releaseObject(wb);
                    releaseObject(app);
                }
            }
            //Xuất mã lỗi ra excel
            if (err.Count != 0)
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
                Excel._Worksheet sheet = null;
                try
                {
                    sheet = wb.ActiveSheet;
                    //Đặt tên sheet
                    sheet.Name = "Lỗi";
                    //Gôm 7 cột thành 1 cột
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 3]].Merge();
                    //Canh lề text
                    sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    //border
                    sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 3]].BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic);
                    sheet.Cells[1, 1].Value = "LỖI IMPORT";
                    sheet.Cells[1, 1].Font.Size = 20;
                    sheet.Cells[2, 1].Value = "BARCODE";
                    sheet.Cells[2, 2].Value = "SỐ LƯỢNG";
                    sheet.Cells[2, 3].Value = "LỖI";
                    //int iDong = _lstHH.Count;
                    //Xuất dữ liệu ra file và tương tác progressbar
                    for (int i = 1; i <= err.Count; i++)
                    {
                        sheet.Cells[i + 2, 1].Value = err.ElementAt(i - 1)._barcode;
                        sheet.Cells[i + 2, 2].Value = err.ElementAt(i - 1)._soluong;
                        sheet.Cells[i + 2, 3].Value = err.ElementAt(i - 1)._errcode;
                    }

                    //Save vào file xuất
                    string t = System.IO.Path.GetDirectoryName(filename) + @"\" + System.IO.Path.GetFileNameWithoutExtension(filename) + "_log.xlsx";
                    if (File.Exists(t))
                        File.Delete(t);
                    wb.SaveAs(t);

                }
                catch (Exception ex)
                {
                    SplashScreenManager.CloseForm(false);
                    MessageBox.Show(ex.ToString(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    wb.Close();
                    app.Quit();
                    releaseObject(wb);
                    releaseObject(app);
                    SplashScreenManager.CloseForm(false);

                }
                MessageBox.Show("Có lỗi phát sinh trong quá trình import. Xem chi tiết trong file log.", "Lỗi import", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SplashScreenManager.CloseForm(false);
                MessageBox.Show("Import dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            XuatReport("PHIEU_XUATSI", "Phiếu xuất sỉ");
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            _them = false;
            _sua = false;
            showHideControl(true);
            _reset();
            _edControl(false);
            xuatThongTin();
            tabChungTu.TabPages[0].PageEnabled = true;
            tabChungTu.SelectedTabPage = pageDanhSach;
            gvChiTiet.OptionsBehavior.Editable = false;
            contextMenuChiTiet.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void ChungTuCT_Info(tb_CHUNGTU chungtu)
        {
            _chungtuct.deleteAll(chungtu.KHOA);
            for (int i = 0; i < gvChiTiet.RowCount; i++)
            {
                if (gvChiTiet.GetRowCellValue(i, "TENHH") == null)
                    gvChiTiet.DeleteRow(i);
                else
                {
                    tb_CHUNGTU_CT _ct = new tb_CHUNGTU_CT();
                    _ct.KHOACT = Guid.Parse(Guid.NewGuid().ToString().ToUpper());
                    _ct.KHOA = chungtu.KHOA;
                    _ct.STT = i + 1;
                    _ct.NGAY = dtNgay.Value;
                    _ct.BARCODE = gvChiTiet.GetRowCellValue(i, "BARCODE").ToString();
                    _ct.SOLUONG = int.Parse(gvChiTiet.GetRowCellValue(i, "SOLUONG").ToString());
                    _ct.DONGIA = double.Parse(gvChiTiet.GetRowCellValue(i, "DONGIA").ToString());
                    if(gvChiTiet.GetRowCellValue(i, "CHIETKHAU") != null)
                        _ct.CHIETKHAU = int.Parse(gvChiTiet.GetRowCellValue(i, "CHIETKHAU").ToString());
                    _ct.THANHTIEN = double.Parse(gvChiTiet.GetRowCellValue(i, "THANHTIEN").ToString());
                    _chungtuct.add(_ct);
                }
            }
        }

        private void luuThongTin()
        {
            err = "";
            tb_CHUNGTU ctu;
            if (gvChiTiet.RowCount == 0)
            {
                err += "Chi tiết phiếu xuất không được rỗng. \r\n";
                MessageBox.Show("Chi tiết phiếu xuất không được rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gvChiTiet.RowCount == 1 && gvChiTiet.GetRowCellValue(0, "BARCODE") == null)
            {
                err += "Chi tiết phiếu xuất không được rỗng. \r\n";
                MessageBox.Show("Chi tiết phiếu xuất không được rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_them)
            {
                ctu = new tb_CHUNGTU();
                ChungTu_Info(ctu);
                var resultCTu = _chungtu.add(ctu);
                ChungTuCT_Info(resultCTu);
                _sequence.update(_seq);
                ChungTuCT_Info(resultCTu);
                _bdChungTu.Add(resultCTu);
                _bdChungTu.MoveLast();
            }
            else
            {
                ctu = (tb_CHUNGTU)_bdChungTu.Current;
                //string sct = _vChungtu.SCT;
                ctu = _chungtu.getItem(ctu.KHOA);
                ChungTu_Info(ctu);
                var resultCTu = _chungtu.update(ctu);
                ChungTuCT_Info(resultCTu);
                _lstChungTu = null;
                _lstChungTu = _chungtu.getList(3, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboDonVi.SelectedValue.ToString());

                _bdChungTu.DataSource = _lstChungTu;
                gvDanhSach.ClearSorting();
                gvDanhSach.RefreshData();
                var obj = _bdChungTu.List.OfType<tb_CHUNGTU>().ToList().Find(c => c.SCT == resultCTu.SCT);
                _bdChungTu.Position = _bdChungTu.IndexOf(obj);
            }
            xuatThongTin();
            _them = false;
            tabChungTu.SelectedTabPage = pageDanhSach;
        }

        void xuatThongTin()
        {
            tb_CHUNGTU current = (tb_CHUNGTU)_bdChungTu.Current;
            if (current != null)
            {
                pKhoa = current.KHOA;
                dtNgay.Value = current.NGAY.Value;
                txtSoPhieu.Text = current.SCT;
                txtGhiChu.Text = current.GHICHU;
                txtChietKhau.Text = current.CHIETKHAU.ToString();
                loadDonViXuat();
                cboDonViXuat.SelectedValue = current.MADVI;
                if(current.MADVI2 != null)
                    lkKhachHang.EditValue = current.MADVI2;

                cboTrangThai.SelectedValue = current.TRANGTHAI;
                if (current.DELETED_BY != null)
                {
                    //lblXoa.Visible = true;
                    btnXoa.Enabled = false;
                    toolStrip1.Refresh();
                }
                else
                {
                    //lblXoa.Visible = false;
                    btnXoa.Enabled = true;
                    toolStrip1.Refresh();

                }
                _bdChungTuCT.DataSource = _chungtuct.getListByKhoaFull(current.KHOA);
                gcChiTiet.DataSource = _bdChungTuCT;
                for (int i = 0; i < gvChiTiet.RowCount; i++)
                {
                    gvChiTiet.SetRowCellValue(i, "STT", i + 1);
                }
            }
            else
            {
                _bdChungTuCT.DataSource = null;
                gcChiTiet.DataSource = _bdChungTuCT;
            }
        }

        void ChungTu_Info(tb_CHUNGTU chungtu)
        {
            double _TONGCONG = 0;
            tb_DONVI dvi = _donvi.getItem(cboDonViXuat.SelectedValue.ToString());
            _seq = _sequence.getItem("XSI@" + DateTime.Today.Year.ToString() + "@" + dvi.KYHIEU);
            if (_seq == null)
            {
                _seq = new tb_SYS_SEQUENCE();
                _seq.SEQNAME = "XSI@" + DateTime.Today.Year.ToString() + "@" + dvi.KYHIEU;
                _seq.SEQVALUE = 1;
                _sequence.add(_seq);
            }
            if (_them)
            {
                chungtu.KHOA = Guid.NewGuid();
                chungtu.NGAY = dtNgay.Value;
                chungtu.SCT = _seq.SEQVALUE.Value.ToString("000000") + @"/" + DateTime.Today.Year.ToString().Substring(2, 2) + @"/XSI/" + dvi.KYHIEU;
                chungtu.CREATED_BY = _user.IDUSER;
                chungtu.CREATED_DATE = DateTime.Now;
            }
            chungtu.LCT = 3;
            if (txtChietKhau.Text == "")
                chungtu.CHIETKHAU = null;
            else
                chungtu.CHIETKHAU = int.Parse(txtChietKhau.Text);
            chungtu.MACTY = cboCongTy.SelectedValue.ToString();
            chungtu.MADVI = cboDonViXuat.SelectedValue.ToString();
            if(lkKhachHang.EditValue != null)
                chungtu.MADVI2 = lkKhachHang.EditValue.ToString();
            chungtu.TRANGTHAI = int.Parse(cboTrangThai.SelectedValue.ToString());
            chungtu.GHICHU = txtGhiChu.Text;
            chungtu.SOLUONG = int.Parse(gvChiTiet.Columns["SOLUONG"].SummaryItem.SummaryValue.ToString());
            for (int i = 0; i < gvChiTiet.RowCount; i++)
            {
                if (gvChiTiet.GetRowCellValue(i, "TENHH") == null)
                {
                    gvChiTiet.DeleteRow(i);
                    goto NEXT;
                }
                else
                {
                    _TONGCONG += double.Parse(gvChiTiet.GetRowCellValue(i, gvChiTiet.Columns["THANHTIEN"]).ToString());
                }
            }
        NEXT:
            chungtu.TONGTIEN = _TONGCONG;
            chungtu.UPDATED_BY = _user.IDUSER;
            chungtu.UPDATED_DATE = DateTime.Now;
        }

        private void XuatReport(string _reportName, string _tieude)
        {
            if (pKhoa != null)
            {
                Form frm = new Form();
                CrystalReportViewer Crv = new CrystalReportViewer();
                Crv.ShowGroupTreeButton = false;
                Crv.ShowParameterPanelButton = false;
                Crv.ToolPanelView = ToolPanelViewType.None;
                TableLogOnInfo Thongtin;
                ReportDocument doc = new ReportDocument();
                doc.Load(Application.StartupPath + "\\Reports\\" + _reportName + @".rpt");
                Thongtin = doc.Database.Tables[0].LogOnInfo;
                Thongtin.ConnectionInfo.ServerName = myFunctions._srv;
                Thongtin.ConnectionInfo.DatabaseName = myFunctions._db;
                Thongtin.ConnectionInfo.UserID = myFunctions._us;
                Thongtin.ConnectionInfo.Password = myFunctions._pw;
                doc.Database.Tables[0].ApplyLogOnInfo(Thongtin);
                try
                {
                    doc.SetParameterValue("khoa", "{" + pKhoa.ToString() + "}");
                    Crv.Dock = DockStyle.Fill;
                    Crv.ReportSource = doc;
                    frm.Controls.Add(Crv);
                    Crv.Refresh();
                    frm.Text = _tieude;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void gvChiTiet_KeyDown(object sender, KeyEventArgs e)
        {
            if (gvChiTiet.OptionsBehavior.Editable)
            {
                _isImport = false;
                if (e.KeyData == Keys.Down)
                {
                    if (int.Parse(gvChiTiet.FocusedRowHandle.ToString()) == (gvChiTiet.RowCount - 1))
                    {
                        if (gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "TENHH") != null)
                        {
                            gvChiTiet.AddNewRow();
                        }
                    }
                }
                if (e.KeyData == Keys.Up)
                {
                    if (int.Parse(gvChiTiet.FocusedRowHandle.ToString()) == (gvChiTiet.RowCount - 1))
                    {
                        if ((gvChiTiet.FocusedValue == null && gvChiTiet.RowCount > 1) || (gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "TENHH") == null && gvChiTiet.RowCount > 1))
                        {
                            gvChiTiet.DeleteSelectedRows();
                        }
                    }
                }
            }
            else
                e.Handled = false;
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "TRANGTHAI")
            {
                if (e.CellValue.ToString() == "1")
                    e.DisplayText = "Chưa hoàn tất";
                else
                    e.DisplayText = "Đã hoàn tất";
            }
            if (e.Column.Name == "DELETED_BY" && e.CellValue != null)
            {
                Image img = Properties.Resources.del_Icon_x16;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }

        private void gvChiTiet_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

            if (!_isImport)
            {
                if (e.Column.FieldName == "BARCODE")
                {
                    if (gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "BARCODE").ToString().IndexOf(".") == 0)
                    {
                        _isImport = true;
                        frmDanhMuc _popDM = new frmDanhMuc(gvChiTiet, gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "BARCODE").ToString());
                        _popDM.BringToFront();
                        _popDM.ShowDialog();
                    }
                    else
                    {
                        tb_HANGHOA hh = _hanghoa.getItem(e.Value.ToString());
                        if (hh != null)
                        {
                            if (_hanghoa.checkExist(hh.BARCODE))
                            {
                                List<string> s = new List<string>();
                                if (gvChiTiet.RowCount > 1)
                                {
                                    for (int i = 0; i < gvChiTiet.RowCount - 1; i++)
                                    {
                                        s.Add(gvChiTiet.GetRowCellValue(i, "BARCODE").ToString());
                                    }
                                    if (s.Find(x => x.Equals(e.Value.ToString())) != null)
                                    {
                                        MessageBox.Show("Mã này đã có trong lưới nhập liệu.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return;
                                    }
                                    else
                                    {
                                        gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "TENHH", hh.TENHH);
                                        gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "DVT", hh.DVT);
                                        gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "SOLUONG", 1);
                                        gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "DONGIA", hh.DONGIA);
                                        gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "THANHTIEN", hh.DONGIA);
                                        gvChiTiet.UpdateTotalSummary();
                                    }
                                }
                                else
                                {
                                    gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "TENHH", hh.TENHH);
                                    gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "DVT", hh.DVT);
                                    gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "SOLUONG", 1);
                                    gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "DONGIA", hh.DONGIA);
                                    gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "THANHTIEN", hh.DONGIA);
                                    gvChiTiet.UpdateTotalSummary();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Mã tài sản này đã được nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mã tài sản này không chính xác.Kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }

                        gvChiTiet.RefreshData();
                    }
                }

                //Thay đổi số lượng
                if (e.Column.FieldName == "SOLUONG")
                {
                    if (gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "TENHH") != null)
                    {
                        if (myFunctions.sIsNumber(e.Value.ToString()))
                        {
                            double _soluong = double.Parse(e.Value.ToString());
                            if (_soluong != 0)
                            {
                                tb_HANGHOA hh = _hanghoa.getItem(gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "BARCODE").ToString());
                                if (gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "DONGIA") != null)
                                {
                                    double _trigiaTT = double.Parse(gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "DONGIA").ToString());
                                    gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "THANHTIEN", _trigiaTT * _soluong);
                                }
                                else
                                {
                                    gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "THANHTIEN", 0);
                                }
                                gvChiTiet.UpdateTotalSummary();
                            }
                            else
                            {
                                MessageBox.Show("Số lượng tài sản không thể bằng 0", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Số lượng phải là số.", "Thông báo");
                        }
                    }
                    else
                    {
                        return;
                    }
                    gvChiTiet.RefreshData();

                }

            }
        }

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                tabChungTu.SelectedTabPage = pageChiTiet;
            }
        }

        private void tabChungTu_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (_sua == false && tabChungTu.SelectedTabPage == pageChiTiet)
            {
                gvChiTiet.OptionsBehavior.Editable = false;
            }
        }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (cboDonVi.SelectedValue != null)
                {
                    _lstChungTu = _chungtu.getList(3, dtTuNgay.Value, dtDenNgay.Value, cboDonVi.SelectedValue.ToString());
                    _bdChungTu.DataSource = _lstChungTu;
                    xuatThongTin();
                }
                
            }
        }

        private void dtTuNgay_Leave(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (cboDonVi.SelectedValue != null)
                {
                    _lstChungTu = _chungtu.getList(3, dtTuNgay.Value, dtDenNgay.Value, cboDonVi.SelectedValue.ToString());
                    _bdChungTu.DataSource = _lstChungTu;
                    xuatThongTin();
                }
            }

        }

        private void dtDenNgay_Leave(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void dtNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dtNgay.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgay.Value = DateTime.Now;
                return;
            }
        }

        private void dtNgay_Leave(object sender, EventArgs e)
        {
            if (dtNgay.Value > DateTime.Now)
            {
                MessageBox.Show("Ngày không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgay.Value = DateTime.Now;
                return;
            }
        }

        bool cal(Int32 _Width, DevExpress.XtraGrid.Views.Grid.GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        private void gvDanhSach_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gvDanhSach.IsGroupRow(e.RowHandle))
            {
                if (e.Info.IsRowIndicator)
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1;
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gvDanhSach); }));
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1));
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gvDanhSach); }));
            }
        }

        private void gvChiTiet_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gvChiTiet.IsGroupRow(e.RowHandle))
            {
                if (e.Info.IsRowIndicator)
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1;
                        e.Info.DisplayText = (e.RowHandle + 1).ToString();
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gvChiTiet); }));
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1));
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gvChiTiet); }));
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

            if (!myFunctions.sIsNumber(txtChietKhau.Text)){
                MessageBox.Show("Chiết khấu nhập vào phải là số nguyên");
                return;
            }

            for (int i = 0; i < gvChiTiet.RowCount; i++)
            {
                gvChiTiet.SetRowCellValue(i, "CHIETKHAU", txtChietKhau.Text);
                gvChiTiet.SetRowCellValue(i, "THANHTIEN", (int.Parse(gvChiTiet.GetRowCellValue(i, "DONGIA").ToString()) * (1 - double.Parse(txtChietKhau.Text) / 100)));
            }
        }

        private void gvChiTiet_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.InRow && _sua)
            {
                GridView view = sender as GridView;
                view.FocusedRowHandle = e.HitInfo.RowHandle;
                contextMenuChiTiet.Show(view.GridControl, e.Point);
            }
        }
    }
}
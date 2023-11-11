using BusinesssLayer;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.TextEditController.Win32;
using MATERIAL.MyFunctions;
using MATERIAL.MyPopup;
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
    public partial class frmBanLe : DevExpress.XtraEditors.XtraForm
    {
        public frmBanLe()
        {
            InitializeComponent();
        }

        public frmBanLe(tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
        }

        bool _them = true;
        string chietkhau;
        tb_SYS_USER _user;
        int _right;
        CONGTY _congty;
        DONVI _donvi;
        CHUNGTU _chungtu;
        CHUNGTU_CT _chungtuct;
        SYS_SEQUENCE _sequence;
        HANGHOA _hanghoa;
        tb_SYS_SEQUENCE _seq;
        List<obj_CHUNGTU_CT> lstChungTuCT;
        Guid pKhoa;
        TONKHO _tonkho;
        bool _isImport;
        string madvi;
        List<string> _lstBarcode;
        private void frmBanLe_Load(object sender, EventArgs e)
        {
            _isImport = false;
            _congty = new CONGTY();
            _donvi = new DONVI();
            _chungtu = new CHUNGTU();
            _chungtuct = new CHUNGTU_CT();
            _hanghoa = new HANGHOA();
            _sequence = new SYS_SEQUENCE();
            lstChungTuCT = new List<obj_CHUNGTU_CT>();
            _tonkho = new TONKHO();
            if (_user.MADVI == "~")
                madvi = "CTKHO1";
            else
                madvi = _user.MADVI;
        }
        private void btnInBill_Click(object sender, EventArgs e)
        {

            if (gvChiTiet.RowCount == 0)
            {
                MessageBox.Show("Chi tiết đơn hàng không được rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            luuThongTin();
            XuatReport("PHIEU_BANLE_VP", "Phiếu bán lẻ");
            lstChungTuCT = new List<obj_CHUNGTU_CT>();
            gcChiTiet.DataSource = lstChungTuCT;
        }

        private void btnChietKhau_Click(object sender, EventArgs e)
        {
            frmChietKhau frm = new frmChietKhau(gvChiTiet);
            frm.ShowDialog();
            chietkhau = frm.txtChietKhau.Text;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {

            if (gvChiTiet.RowCount == 0)
            {
                MessageBox.Show("Chi tiết đơn hàng không được rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            luuThongTin();
            lstChungTuCT = new List<obj_CHUNGTU_CT>();
            gcChiTiet.DataSource = lstChungTuCT;
        }


        private void btnTraHang_Click(object sender, EventArgs e)
        {
            frmTraHang frm = new frmTraHang(lstChungTuCT,gcChiTiet);
            frm.ShowDialog();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {

            int index = 0;
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarcode.Text.IndexOf(".") == 0)
                {
                    _isImport = true;
                    frmDanhMuc _popDM = new frmDanhMuc(gvChiTiet, txtBarcode.Text);
                    _popDM.BringToFront();
                    _popDM.ShowDialog();
                }
                else
                {
                    if (!myFunctions.sIsNumber(txtBarcode.Text))
                    {
                        MessageBox.Show("Mã hàng không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    var hh = _hanghoa.getItem(txtBarcode.Text);
                    if (hh == null)
                    {
                        MessageBox.Show("Mã hàng không có trong danh mục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    obj_CHUNGTU_CT ct = new obj_CHUNGTU_CT();
                    obj_HANGHOA _hh = new obj_HANGHOA();
                    _hh = _hanghoa.getItemFull(txtBarcode.Text);
                    ct.BARCODE = _hh.BARCODE;
                    ct.TENHH = _hh.TENHH;
                    ct.DVT = _hh.DVT;
                    ct.SOLUONG = 1;
                    ct.DONGIA = _hh.DONGIA;
                    ct.THANHTIEN = ct.DONGIA * ct.SOLUONG;
                    if (lstChungTuCT.Count > 0)
                    {
                        var item = lstChungTuCT.FirstOrDefault(x => x.BARCODE == txtBarcode.Text);
                        if (item != null)
                        {
                            index = lstChungTuCT.IndexOf(item);
                            lstChungTuCT[index].SOLUONG = item.SOLUONG + 1;
                            lstChungTuCT[index].THANHTIEN = item.DONGIA * lstChungTuCT[index].SOLUONG;
                        }
                        else
                        {
                            lstChungTuCT.Add(ct);
                        }
                    }
                    else
                        lstChungTuCT.Add(ct);

                    gcChiTiet.DataSource = lstChungTuCT.ToList();
                    txtBarcode.Text = "";
                }

            }
        }
        void ChungTu_Info(tb_CHUNGTU chungtu)
        {
            string madvi = "";
            if(myFunctions._madvi == "~")
            {
                madvi = "CTKHO1";
            }
            else
            {
                madvi = myFunctions._madvi;
            }
            double _TONGCONG = 0;
            tb_DONVI dvi = _donvi.getItem(madvi);
            _seq = _sequence.getItem("BLE@" + DateTime.Today.Year.ToString() + "@" + dvi.KYHIEU);
            if (_seq == null)
            {
                _seq = new tb_SYS_SEQUENCE();
                _seq.SEQNAME = "BLE@" + DateTime.Today.Year.ToString() + "@" + dvi.KYHIEU;
                _seq.SEQVALUE = 1;
                _sequence.add(_seq);
            }
                chungtu.KHOA = Guid.NewGuid();
                chungtu.NGAY = DateTime.Now;
                chungtu.SCT = _seq.SEQVALUE.Value.ToString("000000") + @"/" + DateTime.Today.Year.ToString().Substring(2, 2) + @"/BLE/" + dvi.KYHIEU;
                chungtu.CREATED_BY = _user.IDUSER;
                chungtu.CREATED_DATE = DateTime.Now;
                chungtu.LCT = 4;
                if(chietkhau != null)
                {
                    chungtu.CHIETKHAU = int.Parse(chietkhau);
                }
                chungtu.MACTY = myFunctions._macty;
                chungtu.MADVI = madvi;
                chungtu.MADVI2 = "1";
                chungtu.TRANGTHAI = 2;
                //chungtu.GHICHU = txtGhiChu.Text;
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
                    _ct.NGAY = DateTime.Now;
                    _ct.BARCODE = gvChiTiet.GetRowCellValue(i, "BARCODE").ToString();
                    _ct.SOLUONG = int.Parse(gvChiTiet.GetRowCellValue(i, "SOLUONG").ToString());
                    _ct.DONGIA = double.Parse(gvChiTiet.GetRowCellValue(i, "DONGIA").ToString());
                    if (gvChiTiet.GetRowCellValue(i, "CHIETKHAU") != null)
                        _ct.CHIETKHAU = int.Parse(gvChiTiet.GetRowCellValue(i, "CHIETKHAU").ToString());
                    _ct.THANHTIEN = double.Parse(gvChiTiet.GetRowCellValue(i, "THANHTIEN").ToString());
                    _chungtuct.add(_ct);
                }
            }
        }

        private void luuThongTin()
        {
            try
            {
                tb_CHUNGTU ctu = new tb_CHUNGTU();
                ChungTu_Info(ctu);
                var resultCTu = _chungtu.add(ctu);
                pKhoa = resultCTu.KHOA;
                _sequence.update(_seq);
                ChungTuCT_Info(resultCTu);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Đã có lỗi xảy ra. \r\n" + ex.ToString());
            }
          
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
                        if (myFunctions.cIsNumber(e.Value.ToString()))
                        {
                            double _soluong = double.Parse(e.Value.ToString());
                            if (_soluong != 0)
                            {
                                tb_TONKHO tk = _tonkho.getSoLuongTon(gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "BARCODE").ToString(),madvi, DateTime.Now.Year, DateTime.Now.Month);
                                tb_HANGHOA hh = _hanghoa.getItem(gvChiTiet.GetRowCellValue(gvChiTiet.FocusedRowHandle, "BARCODE").ToString());
                                if (_soluong > tk.LG_CUOI)
                                {
                                    MessageBox.Show("Số lượng tồn không đủ - Max : " + tk.LG_CUOI, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "SOLUONG", 1);
                                    return;
                                }
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
                            MessageBox.Show("Số lượng phải là số hợp lệ.", "Thông báo");
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
            for (int i = gvChiTiet.RowCount - 1; i >= 0; i--)
            {
                _lstBarcode.Add(gvChiTiet.GetRowCellValue(i, "BARCODE").ToString());
                gvChiTiet.DeleteRow(i);
            }
            gvChiTiet.AddNewRow();
            gvChiTiet.SetRowCellValue(gvChiTiet.FocusedRowHandle, "STT", 1);
        }
    }
}
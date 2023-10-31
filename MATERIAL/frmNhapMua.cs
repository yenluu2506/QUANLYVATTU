using BusinesssLayer;
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
using DataLayer;
using MATERIAL.MyPopup;

namespace MATERIAL
{
    public partial class frmNhapMua : DevExpress.XtraEditors.XtraForm
    {
        public frmNhapMua()
        {
            InitializeComponent();
        }
        tb_SYS_USER _user;
        int _right;
        bool _them;
        bool _sua = false;
        bool _import;
        List<string> _lstBarcode;
        string err = "";
        List<_TRANGTHAI> _trangthai;
        CONGTY _congty;
        DONVI _donvi;
        NHACUNGCAP _nhaCC;
        CHUNGTU _chungtu;
        CHUNGTU_CT _chungtuct;
        SYS_SEQUENCE _sequence;
        HANGHOA _hanghoa;
        BindingSource _bdChungTuCT;
        BindingSource _bdChungTu;
        Guid _khoa;
        tb_SYS_SEQUENCE _seq;
        List<tb_CHUNGTU> _lstChungTu;
        bool _isImport;
        private void frmNhapMua_Load(object sender, EventArgs e)
        {
            _import = false;
            _lstBarcode = new List<string>();
            _congty = new CONGTY();
            _donvi = new DONVI();
            _chungtu = new CHUNGTU();
            _chungtuct = new CHUNGTU_CT();
            _hanghoa = new HANGHOA();
            _sequence = new SYS_SEQUENCE();
            _nhaCC = new NHACUNGCAP();
            _bdChungTu = new BindingSource();
            _bdChungTuCT = new BindingSource();

            dtDenNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtDenNgay.Value = DateTime.Now;

            _bdChungTu.PositionChanged += _bdChungTu_PositionChanged;

            _enabled(false);
            loadCongTy();
            cboCongTy.SelectedValue = "CT01";
            cboCongTy.SelectedIndexChanged += CboCongTy_SelectedIndexChanged;
            _trangthai = _TRANGTHAI.getList();
            cboTrangThai.DataSource = _trangthai;
            cboTrangThai.DisplayMember = "_display";
            cboTrangThai.ValueMember = "_value";

            loadKho();
            loadKhoDanhSach();
            _lstChungTu = _chungtu.getList(1, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboKho.SelectedValue.ToString());
            _bdChungTu.DataSource = _lstChungTu;
            gcDanhSach.DataSource = _bdChungTu;

            xuatThongTin();
            cboDonVi.SelectedIndexChanged += CboDonVi_SelectedIndexChanged;
            cboKho.SelectedIndexChanged += CboKho_SelectedIndexChanged;
            loadDonVi();
            loadNhaCC();
            cboCongTy.SelectedValue = "CT01";
            showHideControl(true);
        }

        private void CboKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lstChungTu = _chungtu.getList(1, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboKho.SelectedValue.ToString());
            _bdChungTu.DataSource = _lstChungTu;
            gcDanhSach.DataSource = _bdChungTu;
            xuatThongTin();
        }

        private void CboDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _bdChungTu_PositionChanged(object sender, EventArgs e)
        {
            if (!_them)
            {
                xuatThongTin();
            }
        }

        private void xuatThongTin()
        {
            tb_CHUNGTU current = (tb_CHUNGTU)_bdChungTu.Current;
            if (current != null)
            {
                //tb_DONVI _dvi = _donvi.getItem(current.MADVI);
                dtNgay.Value = current.NGAY.Value;
                txtSoPhieu.Text = current.SCT;
                txtGhiChu.Text = current.GHICHU;
                cboDonVi.SelectedValue = current.MADVI;
                cboNhaCC.SelectedValue = int.Parse(current.MADVI2);

                cboTrangThai.SelectedValue = current.TRANGTHAI;
                if (current.DELETED_BY != null)
                {
                    lblXoa.Visible = true;
                    btnXoa.Visible = false;
                }
                else
                {
                    lblXoa.Visible = false;
                    btnXoa.Enabled = true;
                }
                _bdChungTuCT.DataSource = _chungtuct.getListByKhoaFull(current.KHOA);
                gcChiTiet.DataSource = _bdChungTuCT;
                for (int i = 0; i < gvChiTiet.RowCount; i++)
                {
                    gvChiTiet.SetRowCellValue(i, "STT", i + 1);
                }
            }
        }

        

        void ChungTu_Info(tb_CHUNGTU chungtu)
        {
            double _TONGCONG = 0;
            tb_DONVI dvi = _donvi.getItem(cboDonVi.SelectedValue.ToString());
            _seq  = _sequence.getItem("NHM@" + DateTime.Today.Year.ToString() + "@" + dvi.KYHIEU);
            if (_seq == null)
            {
                _seq = new tb_SYS_SEQUENCE();
                _seq.SEQNAME = "NHM@" + DateTime.Today.Year.ToString() + "@" + dvi.KYHIEU;
                _seq.SEQVALUE = 1;
                _sequence.add(_seq);
            }
            if (_them)
            {
                chungtu.KHOA = Guid.NewGuid();
                chungtu.NGAY = dtNgay.Value;
                chungtu.SCT = _seq.SEQVALUE.Value.ToString("000000") + @"/" + DateTime.Today.Year.ToString().Substring(2, 2) + @"/NHM/" + dvi.KYHIEU;
                chungtu.CREATED_BY = 1;
                chungtu.CREATED_DATE = DateTime.Now;
            }
            chungtu.LCT = 1;
            chungtu.MACTY = cboCongTy.SelectedValue.ToString();
            chungtu.MADVI = cboDonVi.SelectedValue.ToString();
            chungtu.MADVI2 = cboNhaCC.SelectedValue.ToString();
            chungtu.TRANGTHAI = int.Parse(cboTrangThai.SelectedValue.ToString()) == 1;
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
            chungtu.UPDATED_BY = 1;
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
                    _ct.NGAY = dtNgay.Value;
                    _ct.BARCODE = gvChiTiet.GetRowCellValue(i, "BARCODE").ToString();
                    _ct.SOLUONG = int.Parse(gvChiTiet.GetRowCellValue(i, "SOLUONG").ToString());
                    _ct.DONGIA = double.Parse(gvChiTiet.GetRowCellValue(i, "DONGIA").ToString());
                    _ct.THANHTIEN = double.Parse(gvChiTiet.GetRowCellValue(i, "THANHTIEN").ToString());
                    _chungtuct.add(_ct);
                }
            }
        }

        public void luuThongTin()
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
                _sequence.update(_seq);

                ChungTuCT_Info(resultCTu);
                _bdChungTu.Add(resultCTu);
                _bdChungTu.MoveLast();
                //ChungTuCT_Info(resultCTu);
                //_lstChungTu = null;
                //_lstChungTu = _chungtu.getList(1, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboDonVi.SelectedValue.ToString());
                //_bdChungTu.DataSource = _lstChungTu;
                //gvDanhSach.ClearSorting();
                //gvDanhSach.RefreshData();
                //var obj = _bdChungTu.List.OfType<tb_CHUNGTU>().ToList().Find(c => c.SCT == resultCTu.SCT);
                //_bdChungTu.Position = _bdChungTu.IndexOf(obj);
            }
            else
            {
                ctu = (tb_CHUNGTU)_bdChungTu.Current;
                ctu = _chungtu.getItem(ctu.KHOA);
                ChungTu_Info(ctu);
                var resultCTu = _chungtu.update(ctu);
                ChungTuCT_Info(resultCTu);

                _lstChungTu = null;
                _lstChungTu = _chungtu.getList(1, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboDonVi.SelectedValue.ToString());
                
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

        private void CboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDonVi();
            loadKho();
        }

        void loadCongTy()
        {
            cboCongTy.DataSource = _congty.getAll();
            cboCongTy.DisplayMember = "TENCTY";
            cboCongTy.ValueMember = "MACTY";
        }
        void loadDonVi()
        {
            cboDonVi.DataSource = _donvi.getKhoByCty(cboCongTy.SelectedValue.ToString());
            cboDonVi.DisplayMember = "TENDVI";
            cboDonVi.ValueMember = "MADVI";
        }
        void loadKhoDanhSach()
        {
            cboKho.DataSource = _donvi.getKhoByCty(cboCongTy.SelectedValue.ToString());
            cboKho.DisplayMember = "TENDVI";
            cboKho.ValueMember = "MADVI";
        }
        void loadKho()
        {
            cboDonVi.DataSource = _donvi.getKhoByCty(cboCongTy.SelectedValue.ToString());
            cboDonVi.DisplayMember = "TENDVI";
            cboDonVi.ValueMember = "MADVI";
        }

        void loadNhaCC()
        {
            cboNhaCC.DataSource = _nhaCC.getAll();
            cboNhaCC.DisplayMember = "TENNCC";
            cboNhaCC.ValueMember = "MANCC";
        }

        void _enabled(bool t)
        {
            txtGhiChu.Enabled = t;
            cboTrangThai.Enabled = t;
            cboDonVi.Enabled = t;
            cboNhaCC.Enabled = t;
            dtNgay.Enabled = t;
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
            txtSoPhieu.Text = "";
            txtGhiChu.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(_right == 1)
            {
                MessageBox.Show("Không có quyền thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _bdChungTuCT.DataSource = _chungtuct.getListByKhoaFull(_khoa);
            gcChiTiet.DataSource = _bdChungTuCT;
            gvChiTiet.AddNewRow();
            tabChungTu.SelectedTabPage = pageChiTiet;
            gvChiTiet.OptionsBehavior.Editable = true;
            //contentMenuChiTiet.Enabled = true;

            _them = true;
            _sua = false;
            showHideControl(false);
            _enabled(true);
            _reset();
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //if (_right == 1)
            //{
            //    MessageBox.Show("Không có quyền thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else
            //{
            //    tb_CHUNGTU current = (tb_CHUNGTU)_bdChungTu.Current;
            //    if(current.TRANGTHAI == 1)
            //    {
            //        _them = false;
            //        _sua = true;
            //        showHideControl(false);
            //        _enabled(true);
            //        tabChungTu.SelectedTabPage= pageChiTiet;
            //        tabChungTu.TabPages[0].PageEnabled = false;
            //        gvChiTiet.OptionsBehavior.Editable= true;
            //        contextMenuChiTiet.Enabled = true;
            //        cboDonVi.Enabled = false;
            //        if (gvChiTiet.RowCount == 0)
            //        {
            //            List<V_CHUNGTU_CT> _lstChiTiet
            //        }
            //    }
            //}
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        _popDM.ShowDialog();
                    }
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
                    }
                    else
                    {
                        MessageBox.Show("Mã tài sản này đã được nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            }
            else
            {
                return;
            }
            gvChiTiet.RefreshData();
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
    }
}
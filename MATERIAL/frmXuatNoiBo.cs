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
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace MATERIAL
{
    public partial class frmXuatNoiBo : DevExpress.XtraEditors.XtraForm
    {
        public frmXuatNoiBo()
        {
            InitializeComponent();
        }

        public frmXuatNoiBo(tb_SYS_USER user, int right)
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
        NHACUNGCAP _ncc;
        BindingSource _bdChungTuCT;
        BindingSource _bdChungTu;
        Guid _khoa;
        tb_SYS_SEQUENCE _seq;
        List<tb_CHUNGTU> _lstChungTu;
        bool isImport;
        private void frmXuatNoiBo_Load(object sender, EventArgs e)
        {
            isImport = false;
            _lstBarcode = new List<string>();
            _congty = new CONGTY();
            _donvi = new DONVI();
            _chungtu = new CHUNGTU();
            _chungtuct = new CHUNGTU_CT();
            _hanghoa = new HANGHOA();
            _ncc = new NHACUNGCAP();
            _sequence = new SYS_SEQUENCE();
            _bdChungTuCT = new BindingSource();
            _bdChungTu = new BindingSource();

            dtTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtDenNgay.Value = DateTime.Now;
            _bdChungTu.PositionChanged += _bdChungTu_SelectedIndexChanged;

            _trangthai = _TRANGTHAI.getlist();
            cboTrangThai.DataSource = _trangthai;
            cboTrangThai.DisplayMember = "_display";
            cboTrangThai.ValueMember = "_value";

            loadDonVi();
            _lstChungTu = _chungtu.getlist(2, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboDonVi.SelectedValue.ToString());
            _bdChungTu.DataSource = _lstChungTu;
            gcDanhSach.DataSource = _bdChungTu;
            xuatThongTin();
            cboDonVi.SelectedIndexChanged += CboDonVi_SelectedIndexChanged;
            //cboKho.SelectedIndexChanged += CboKho_SelectedIndexChanged;
            showHideControl(true);
            contextMenuChiTiet.Enable = false;
        }

        private void CboDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lstChungTu = _chungtu.getlist(2, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboDonVi.SelectedValue.ToString());
            _bdChungTu.DataSource = _lstChungTu;
            gcDanhSach.DataSource = _bdChungTu;
            xuatThongTin();
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

        void loadCongTy()
        {
            cboCongTy.DataSource = _congty.getAll();
            cboCongTy.DisplayMember = "TENCTY";
            cboCongTy.ValueMember = "MACTY";
        }
        //void loadKhoDanhSach()
        //{
        //    cboDonVi.DataSource = _donvi.getKhoByCty(cboCongTy.SelectedValue.ToString());
        //    cboDonVi.DisplayMember = "TENDVI";
        //    cboDonVi.ValueMember = "MADVI";
        //}

        void loadDonVi()
        {
            cboDonViXuat.DataSource = _donvi.getKhoByCty(cboCongTy.SelectedValue.ToString());
            cboDonViXuat.DisplayMember = "TENDVI";
            cboDonViXuat.ValueMember = "MADVI";
        }
        //void loadNhaCC()
        //{
        //    cboNhaCC.DataSource = _ncc.getList();
        //    cboNhaCC.DisplayMember = "TENNCC";
        //    cboNhaCC.ValueMember = "MANCC";
        //}

        void loadDonViNhap()
        {
            cboDonViNhap.DataSource = _donvi.getDonViByCty(cboCongTy.SelectedValue.ToString(), false);
            cboDonViNhap.DisplayMember = "TENDVI";
            cboDonViNhap.ValueMember = "MADVI";
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
            cboDonViNhap.Enabled = t;
            dpNgay.Enabled = t;
        }

        void _reset()
        {

        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("Không có quyền thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _bdChungTuCT.DataSource = _chungtuct.getListByKhoaFull(_khoa);
            gcChiTiet.DataSource = _bdChungTuCT;
            gvChiTiet.AddNewRow();
            tabChungTu.SelectedTabPage = panelChiTiet;
            gvChiTiet.OptionsBehavior.Editable = true;
            contextMenuChiTiet.Enable = true;
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
                tb_ChungTU current = (tb_CHUNGTU)_bdChungTu.Current;
                if (current.TRANGTHAI == 1)
                {
                    _them = false;
                    _sua = true;
                    showHideControl(false);
                    _edControl(true);
                    tabChungTu.SelectedTabPage = pageChiTiet;
                    tabChungTu.TabPages[0].PageEnable = false;
                    gvChiTiet.OptionsBehavior.Editable = true;
                    contextMenuChiTiet.Enabled = true;
                    CboDonVi.Enable = false;
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
            tabChungTu.SelectedTabPage = panelChiTiet;
            gvChiTiet.OptionsBehavior.Editable = true;
            contextMenuChiTiet.Enable = true;
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
                if (MessageBox.Show("Bạn có chắc muốn hủy phiếu nhập này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    tb_CHUNGTU current = (tb_CHUNGTU)_bdChungTu.Current;
                    int index = _bdChungTu.Position;
                    _chungtu.delete(current.KHOA, 1);
                    gvDanhSach.SetRowCellValue(index, "DELETED_BY", 0);
                    lblXoa.Visible = true;
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
            contextMenuChiTiet.Enable = false;
            tabChungTu.TabPages[0].PageEnabled = true;
            showHideControl(true);
            _edControl(false);
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

        private void btnIn_Click(object sender, EventArgs e)
        {

        }

        void xuatThongTin()
        {
            tb_CHUNGTU current = (tb_CHUNGTU)_bdChungTu.Current;
            if (current != null)
            {
                dtNgay.Value = current.NGAY.Value;
                txtSoPhieu.Text = current.SCT;
                txtGhiChu.Text = current.GHICHU;
                cboDonViXuat.SelectedValue = current.MADVI;
                cboDonViNhap.SelectedValue = int.Parse(current.MADVI2);

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
            tb_DONVI dvi = _donvi.getItem(cboDonViXuat.SelectedValue.ToString());
            _seq = dvi = _sequence.getItem("NHM@" + DateTime.Today.Year.ToString()+"@"+dvi.KYHIEU);
            if(_seq == null)
            {
                _seq = new tb_SYS_SEQUENCE();
                _seq.SEQNAME = "NHM@" + DateTime.Today.Year.ToString() + "@" + dvi.KYHIEU;
                _seq.SEQVALUE = 1;
                _sequence.add(_seq);
            }
            if (_them)
            {
                chungtu.KHOA=Guid.NewGuid();
                chungtu.NGAY = dtNgay.Value;
                chungtu.SCT = _seq.SEQVALUE.Value.ToString("000000") + @"/" + DateTime.Today.Year.ToString().Substring(2, 2) + @"/NHM/" + dvi.KYHIEU;
                chungtu.CREATED_BY = 1;
                chungtu.CREATED_DATE=DateTime.Now;
            }
            chungtu.LCT = 1;
            chungtu.MACTY=cboCongTy.SelectedValue.ToString();
            chungtu.MADVI=cboDonViXuat.SelectedValue.ToString();
            chungtu.MADVI2=cboDonViNhap.SelectedValue.ToString();
            chungtu.TRANGTHAI = int.Parse(cboTrangThai.SelectedValue.ToString());
            chungtu.GHICHU = txtGhiChu.Text;
            chungtu.SOLUONG = int.Parse(gvChiTiet.Columns["SOLUONG"].SummaryItem.SummaryValue.ToString());
            for(int i = 0; i < gvChiTiet.RowCount; i++)
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
                    _ct.KHOACT=Guid.Parse(Guid.NewGuid().ToString().ToUpper());
                    _ct.KHOA = chungtu.KHOA;
                    _ct.STT = i+1;
                    _ct.NGAY = dpNgay.Value;
                    _ct.BARCODE = gvChiTiet.GetRowCellValue(i,"BARCODE").ToString();
                    _ct.SOLUONG = int.Parse(gvChiTiet.GetRowCellValue(i,"SOLUONG").ToString());
                    _ct.DONGIA = double.Parse(gvChiTiet.GetRowCellValue(i,"DONGIA").ToString());
                    _ct.THANHTIEN = double.Parse(gvChiTiet.GetRowCellValue(i, "THANHTIEN").ToString());
                    _chungtu.add(_ct);
                }
            }
        }

        private void luuthongtin()
        {
            err = "";
            tb_CHUNGTU ctu;
            if (gvChiTiet.RowCount == 0)
            {
                err += "Chi tiết phiếu xuất không được rỗng. \r\n";
                MessageBox.Show("Chi tiết phiếu xuất không được rỗng.","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if(gvChiTiet.RowCount == 1 && gvChiTiet.GetRowCellValue(0, "BARCODE") == null)
            {
                err += "Chi tiết phiếu xuất không được rỗng. \r\n";
                MessageBox.Show("Chi tiết phiếu xuất không được rỗng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_them)
            {
                ctu = new tb_CHUNGTU();
                Chungtu_Info(ctu);
                var resultCTu = _chungtu.update(ctu);
                ChungTuCT_Info(resultCTu);
                _lstChungTu = null;
                _lstChungTu= _chungtu.getlist(1, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboDonVi.SelectedValue.ToString());
                _bdChungTu.DataSource = _lstChungTu;
                gvDanhSach.ClearSorting();
                gvDanhSach.RefreshData();
                var obj =_bdChungTu.List.OfType<tb_CHUNGTU>().ToList().Find(c=>c.SCT==resultCTu.SCT);
                _bdChungTu.Position=_bdChungTu.IndexOf(obj);
            }
            xuatThongTin();
            _them = false;
            tabChungTu.SelectedTabPage = pageDanhSach;
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
}
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

        public frmXuatNoiBo(tb_SYS_USER, int right)
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
            _lstChungTu = _chungtu.getlist(2, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboKho.SelectedValue.ToString());
            _bdChungTu.DataSource = _lstChungTu;
            gcDanhSach.DataSource = _bdChungTu;
            xuatThongTin();
            cboDonVi.SelectedIndexChanged += CboDonVi_SelectedIndexChanged;
            //cboKho.SelectedIndexChanged += CboKho_SelectedIndexChanged;
            showHideControl();
            contextMenuChiTiet.Enable = false;
        }

        private void CboDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lstChungTu = _chungtu.getlist(2, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboKho.SelectedValue.ToString());
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
            cboDonVi.DataSource = _donvi.getKhoByCty(cboCongTy.SelectedValue.ToString());
            cboDonVi.DisplayMember = "TENDVI";
            cboDonVi.ValueMember = "MADVI";
        }
        //void loadNhaCC()
        //{
        //    cboNhaCC.DataSource = _ncc.getList();
        //    cboNhaCC.DisplayMember = "TENNCC";
        //    cboNhaCC.ValueMember = "MANCC";
        //}

        void loadDonViNhap()
        {
            //them vao donvi.cs


            cboDonViNhap.DataSource = _donvi.getDonViByCty(cboCongTy.SelectedValue.ToString(), false);
            cboDonViNhap.DisplayMember = "TENDVI";
            cboDonViNhap.ValueMember = "MADVI";
        }
        void showHideControl(bool kt)
        {
            btnLuu.Visible = !kt;
            btnBoQua.Visible = !kt;
            btnThem.Visible = kt;
            btnSua.Visible = kt;
            btnXoa.Visible = kt;
        }

        void _edControl(bool t)
        {
            txtGhiChu.Enable = t;
            cboTrangThai.Enable = t;
            cboDonVi.Enable = t;
            cboDonViNhap.Enable = t;
            dtNgay.Enable = t;
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

        void ChungTu_Info(tb_CHUNGTU cHUNGTU)
        {
            double _TONGCONG = 0;
            tb_DONVI dvi = _donvi.getItem(cboDonVi.SelectedValue.ToString());
            _seq = dvi = _sequence.getItem("NHM@" + DateTime);

        }

    }
}
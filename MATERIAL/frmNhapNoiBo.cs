using BusinesssLayer;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using DataLayer;
using DevExpress.XtraEditors;
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
    public partial class frmNhapNoiBo : DevExpress.XtraEditors.XtraForm
    {
        public frmNhapNoiBo()
        {
            InitializeComponent();
        }
        public frmNhapNoiBo(tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;

        }

        tb_SYS_USER _user;
        int _right;
        List<_TRANGTHAI> _trangthai;
        CONGTY _congty;
        DONVI _donvi;
        CHUNGTU _chungtu;
        CHUNGTU_CT _chungtuct;
        SYS_SEQUENCE _sequence;
        HANGHOA _hanghoa;
        BindingSource _bdChungTuCT;
        BindingSource _bdChungTu;
        Guid _khoa;
        tb_SYS_SEQUENCE _seq;
        List<tb_CHUNGTU> _lstChungTu;
        bool _them = false;
        Guid pKhoa;
        private void frmNhapNoiBo_Load(object sender, EventArgs e)
        {
            _congty = new CONGTY();
            _donvi = new DONVI();
            _chungtu = new CHUNGTU();
            _chungtuct = new CHUNGTU_CT();
            _hanghoa = new HANGHOA();
            _sequence = new SYS_SEQUENCE();
            _bdChungTuCT = new BindingSource();
            _bdChungTu = new BindingSource();

            dtTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtDenNgay.Value = DateTime.Now;

            _bdChungTu.PositionChanged += _bdChungTu_PositionChanged;
            loadCongTy();
            cboCongTy.SelectedValue = myFunctions._macty;
            cboCongTy.SelectedIndexChanged += CboCongTy_SelectedIndexChanged;

            _trangthai = _TRANGTHAI.getList();
            cboTrangThai.DataSource = _trangthai;
            cboTrangThai.DisplayMember = "_display";
            cboTrangThai.ValueMember = "_value";

            loadDonVi();
            loadDonViXuat();
            loadDonViNhap();
            xuatThongTin();
            if (myFunctions._madvi == "~")
            {
                cboDonVi.SelectedValue = "CTKHO1";
                cboDonVi.Enabled = false;
            }
            else
            {
                cboDonVi.SelectedValue = myFunctions._madvi;
                cboDonVi.Enabled = false;
            }
            _lstChungTu = _chungtu.getPhieuNhap(2, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboDonVi.SelectedValue.ToString());
            _bdChungTu.DataSource = _lstChungTu;
            gcDanhSach.DataSource = _bdChungTu;
           
           
            cboDonVi.SelectedIndexChanged += CboDonVi_SelectedIndexChanged;
            btnTaoMa.Enabled = false;
            _edControl(false);
            _disabled(true);
        }

        void _disabled(bool t)
        {
            gvDanhSach.OptionsBehavior.Editable = !t;
            gvChiTiet.OptionsBehavior.Editable = !t;
            txtGhiChu.Enabled = !t;
        }
        private void CboDonVi_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lstChungTu = _chungtu.getPhieuNhap(2, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboDonVi.SelectedValue.ToString());
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
        void loadDonVi()
        {
            cboDonVi.DisplayMember = "TENDVI";
            cboDonVi.ValueMember = "MADVI";
            cboDonVi.DataSource = _donvi.getAll(cboCongTy.SelectedValue.ToString());

        }

        void loadDonViXuat()
        {
            cboDonViXuat.DataSource = _donvi.getAll(cboCongTy.SelectedValue.ToString());
            cboDonViXuat.DisplayMember = "TENDVI";
            cboDonViXuat.ValueMember = "MADVI";
        }
        void loadDonViNhap()
        {
            cboDonViNhap.DataSource = _donvi.getDonViByCty(cboCongTy.SelectedValue.ToString(), false);
            cboDonViNhap.DisplayMember = "TENDVI";
            cboDonViNhap.ValueMember = "MADVI";
        }
        void _edControl(bool t)
        {
            txtGhiChu.Enabled = t;
            cboTrangThai.Enabled = t;
            cboDonViXuat.Enabled = t;
            cboDonViNhap.Enabled = t;
            dtNgay.Enabled = t;
            txtSoPhieu.Enabled = t;
            dtNgay.Enabled = t;
            dtNgayNhap.Enabled = t;
            txtSoPhieuNhap.Enabled = t;
        }

        private void btnTaoMa_Click(object sender, EventArgs e)
        {
            if (_right == 1)
            {
                MessageBox.Show("Không có quyền thao tác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                tb_CHUNGTU ctu;
                string madvi = "";
                if (myFunctions._madvi == "~")
                    madvi = "CTKHO1";
                else
                    madvi = cboDonVi.SelectedValue.ToString();
                tb_DONVI dvi = _donvi.getItem(madvi);
                _seq = _sequence.getItem("NNB@" + DateTime.Today.Year.ToString() + "@" + dvi.KYHIEU);
                if (_seq == null)
                {
                    _seq = new tb_SYS_SEQUENCE();
                    _seq.SEQNAME = "NNB@" + DateTime.Today.Year.ToString() + "@" + dvi.KYHIEU;
                    _seq.SEQVALUE = 1;
                    _sequence.add(_seq);
                }
                ctu = (tb_CHUNGTU)_bdChungTu.Current;   
                ctu = _chungtu.getItem(ctu.KHOA);
                ctu.SCT2= _seq.SEQVALUE.Value.ToString("000000") + @"/" + DateTime.Today.Year.ToString().Substring(2, 2) + @"/NNB/" + dvi.KYHIEU;
                ctu.NGAY2 = DateTime.Now;
                var resultCTu = _chungtu.update(ctu);
                _sequence.update(_seq);
                _lstChungTu = null;
                _lstChungTu = _chungtu.getPhieuNhap(2, dtTuNgay.Value, dtDenNgay.Value.AddDays(1), cboDonVi.SelectedValue.ToString());

                _bdChungTu.DataSource = _lstChungTu;
                gvDanhSach.ClearSorting();
                gvDanhSach.RefreshData();
                var obj = _bdChungTu.List.OfType<tb_CHUNGTU>().ToList().Find(c => c.SCT == resultCTu.SCT);
                _bdChungTu.Position = _bdChungTu.IndexOf(obj);
                xuatThongTin();
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            XuatReport("PHIEU_NHAPNB", "Phiếu nhập nội bộ");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                loadDonViXuat();
                loadDonViNhap();
                cboDonViXuat.SelectedValue = current.MADVI;
                cboDonViNhap.SelectedValue = current.MADVI2;
                if(current.NGAY2!=null)
                {
                    dtNgayNhap.Value=current.NGAY2.Value;
                }
                txtSoPhieuNhap.Text = current.SCT2;
                cboTrangThai.SelectedValue = current.TRANGTHAI;
                if (current.SCT2 != null)
                {
                    btnTaoMa.Enabled = false;
                }
                else
                {
                   btnTaoMa.Enabled=true;
                }
                _bdChungTuCT.DataSource = _chungtuct.getListByKhoaFull(current.KHOA);
                gcChiTiet.DataSource = _bdChungTuCT;
                for (int i = 0; i < gvChiTiet.RowCount; i++)
                {
                    gvChiTiet.SetRowCellValue(i, "STT", i + 1);
                }
            }
        }

        bool cal(Int32 _Width, DevExpress.XtraGrid.Views.Grid.GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
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

        private void gvDanhSach_DoubleClick(object sender, EventArgs e)
        {
            tabChungTu.SelectedTabPage = pageChiTiet;
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
    }
}
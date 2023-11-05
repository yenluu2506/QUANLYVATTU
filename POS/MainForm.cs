using BusinesssLayer;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
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

namespace POS
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
        }
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

        private void MainForm_Load(object sender, EventArgs e)
        {
            _congty = new CONGTY();
            _donvi = new DONVI();
            _chungtu = new CHUNGTU();
            _chungtuct = new CHUNGTU_CT();
            _hanghoa = new HANGHOA();
            _sequence = new SYS_SEQUENCE();
            lstChungTuCT = new List<obj_CHUNGTU_CT>();
        }
        private void btnInBill_Click(object sender, EventArgs e)
        {

            if (gvChiTiet.RowCount == 0)
            {
                MessageBox.Show("Chi tiết đơn hàng không được rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            luuThongTin();
            XuatReport("PHIEU_BANLE", "Phiếu bán lẻ");
            lstChungTuCT = new List<obj_CHUNGTU_CT>();
            gcChiTiet.DataSource = lstChungTuCT;
        }

        private void btnChietKhau_Click(object sender, EventArgs e)
        {
            frmChietKhau frm = new frmChietKhau(gvChiTiet);
            frm.ShowDialog();
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
            frmTraHang frm = new frmTraHang(lstChungTuCT, gcChiTiet);
            frm.ShowDialog();
        }

        private void txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            int index = 0;
            if (e.KeyCode == Keys.Enter)
            {
                if (myFunctions.sIsNumber(txtBarcode.Text))
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
        void ChungTu_Info(tb_CHUNGTU chungtu)
        {
            string madvi = "";
            if (myFunctions._madvi == "~")
            {
                madvi = "CTKH01";
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
            //if (txtChietKhau.Text == "")
            //    chungtu.CHIETKHAU = null;
            //else
            //    chungtu.CHIETKHAU = int.Parse(txtChietKhau.Text);
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
                    ////_chungtu.add(_ct);
                }
            }
        }

        private void luuThongTin()
        {
            try
            {
                tb_CHUNGTU ctu = new tb_CHUNGTU();
                ChungTu_Info(ctu);
                var resultCTu = _chungtu.update(ctu);
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
                    Crv.PrintReport();
                    Crv.Refresh();
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
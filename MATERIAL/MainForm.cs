﻿using BusinesssLayer;
using DataLayer;
using DevExpress.XtraCharts;
using DevExpress.XtraNavBar;
using MATERIAL.MyFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace MATERIAL
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(tb_SYS_USER user)
        {
            InitializeComponent();
            this._user = user;
            this.Text = "HỆ THỐNG QUẢN LÝ KHO VẬT TƯ - " + _user.FULLNAME;
            lblServer.Caption = "Server: " + myFunctions._srv;
            lblDataBase.Caption = "Database: " + myFunctions._db;
            lblDonVi.Caption = "Đơn vị: " + myFunctions._tendvi;
            lblUserName.Caption = user.USERNAME;
        }
        SYS_FUNC _func;
        tb_SYS_USER _user;
        SYS_GROUP _sysGroup;
        SYS_RIGHT _sysRight;
        DONVI _dvi = new DONVI();
        THONGKE _thongke;
        private void MainForm_Load(object sender, EventArgs e)
        {
            _func = new SYS_FUNC();
            //if(_user == null)
            _sysGroup = new SYS_GROUP();
            _sysRight = new SYS_RIGHT();
            _thongke = new THONGKE();
            leftMenu();
            //biểu đồ doanh thu
            Series _seri = new Series("Doanh thu bán hàng theo nhóm hàng", ViewType.Pie3D);
            var lst = _thongke.DoanhThuTheoNhomHangHoa();
            foreach (var item in lst)
            {
                _seri.Points.Add(new SeriesPoint(item.TENNHOM, item.THANHTIEN));
            }
                chartDanhThuNhom.Series.Add(_seri);
            _seri.Label.TextPattern = "{A:} {VP: p0}";

            Series _seri2 = new Series("Doanh thu bán hàng theo nhóm hàng", ViewType.Spline3D);
            var lst2 = _thongke.DoanhThuTheoNhomHangHoa();
            foreach (var item in lst2)
            {
                _seri2.Points.Add(new SeriesPoint(item.TENNHOM, item.THANHTIEN));
            }
            chartDanhThuNhom2.Series.Add(_seri2);
            _seri2.Label.TextPattern = "{A:} {VP: p0}";

        }

        void leftMenu()
        {
            int i = 0;
            var _lsParent = _func.getParent();
            foreach (var _pr in _lsParent)
            {
                NavBarGroup navGroup = new NavBarGroup(_pr.DESCRIPTION);
                navGroup.Tag = _pr.FUNC_CODE;
                navGroup.Name = _pr.FUNC_CODE;
                navGroup.ImageOptions.LargeImageIndex = i;
                i++;
                navMain.Groups.Add(navGroup);

                var _lsChild = _func.getChild(_pr.FUNC_CODE);
                foreach (var _ch in _lsChild)
                {
                    NavBarItem navItem = new NavBarItem(_ch.DESCRIPTION);
                    navItem.Tag = _ch.FUNC_CODE;
                    navItem.Name = _ch.FUNC_CODE;
                    navItem.ImageOptions.SmallImageIndex = 0;
                    navGroup.ItemLinks.Add(navItem);
                }
                navMain.Groups[navGroup.Name].Expanded = true;
            }
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {

        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao(_user);
            frm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void navMain_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            string func_code = e.Link.Item.Tag.ToString();
            var _group = _sysGroup.getGroupByMemBer(_user.IDUSER);
            var _uRight = _sysRight.getRight(_user.IDUSER, func_code);
             
            if (_group != null)
            {
                var _groupRight = _sysRight.getRight(_group.GROUP, func_code);
                if (_uRight.USER_RIGHT < _groupRight.USER_RIGHT)
                    _uRight.USER_RIGHT = _groupRight.USER_RIGHT;
            }

            if (_uRight.USER_RIGHT == 0)
            {
                MessageBox.Show("Không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                switch (func_code)
                {
                    case "CONGTY":
                        {
                            frmCONGTY frm = new frmCONGTY();
                            frm.ShowDialog();
                            break;
                        }
                    case "DONVI":
                        {
                            frmDONVI frm = new frmDONVI();
                            frm.ShowDialog();
                            break;
                        }
                    case "DVT":
                        {
                            frmDONVITINH frm = new frmDONVITINH();
                            frm.ShowDialog();
                            break;
                        }
                    case "NCC":
                        {
                            frmNHACUNGCAP frm = new frmNHACUNGCAP();
                            frm.ShowDialog();
                            break;
                        }
                    case "XX":
                        {
                            frmXUATXU frm = new frmXUATXU();
                            frm.ShowDialog();
                            break;
                        }
                    case "NHOMHH":
                        {
                            frmNHOMHH frm = new frmNHOMHH();
                            frm.ShowDialog();
                            break;
                        }
                    case "HANGHOA":
                        {
                            frmHANGHOA frm = new frmHANGHOA();
                            frm.ShowDialog();
                            break;
                        }
                    case "KHACHHANG":
                        {
                            frmKhachHang frm = new frmKhachHang();
                            frm.ShowDialog();
                            break;
                        }
                    case "NHAPMUA":
                        {
                            frmNhapMua frm = new frmNhapMua(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "XUATNB":
                        {
                            frmXuatNoiBo frm = new frmXuatNoiBo(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "NHAPNB":
                        {
                            frmNhapNoiBo frm = new frmNhapNoiBo(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "XUATSI":
                        {
                            frmXuatSi frm = new frmXuatSi(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "BANLE":
                        {
                            frmBanLe frm = new frmBanLe(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "TONKHOCTY":
                        {
                            frmTonKhoCongTy frm = new frmTonKhoCongTy(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "TONKHODVI":
                        {
                            frmTonKhoDonVi frm = new frmTonKhoDonVi(_user, _uRight.USER_RIGHT.Value);
                            frm.ShowDialog();
                            break;
                        }
                    case "DOIMATKHAU":
                        {
                            frmChangePassword frm = new frmChangePassword(_user);
                            frm.ShowDialog();
                            break;
                        }
                    case "BACKUP":
                        {
                            frmBackup frm = new frmBackup();
                            frm.ShowDialog();
                            break;
                        }
                    case "RESTORE":
                        {
                            frmRestore frm = new frmRestore();
                            frm.ShowDialog();
                            break;
                        }
                }
            }
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            frmInBarcode frm = new frmInBarcode();
            frm.ShowDialog();
        }

        private void btnTinhTon_Click(object sender, EventArgs e)
        {
            string madvi = "";
            TONKHO _tonkho = new TONKHO();
            if (myFunctions._madvi == "~")
                madvi = "CTKHO1";
            else
                madvi = myFunctions._madvi;
            if (_tonkho.TinhTon(madvi, DateTime.Now))
            {
                MessageBox.Show("Cập nhật tồn kho thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật tồn kho không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}

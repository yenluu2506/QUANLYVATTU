using BusinesssLayer;
using DataLayer;
using DevExpress.XtraNavBar;
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
        SYS_FUNC _func;

        private void MainForm_Load(object sender, EventArgs e)
        {
            _func = new SYS_FUNC();
            leftMenu();
        }

        void leftMenu()
        {
            int i = 0;
            var _lsParent = _func.getParent();
            foreach ( var _pr in _lsParent )
            {
                NavBarGroup navGroup = new NavBarGroup(_pr.DESCRIPTION);
                navGroup.Tag = _pr.FUNC_CODE;
                navGroup.Name = _pr.FUNC_CODE;
                navGroup.ImageOptions.LargeImageIndex = i;
                i++;
                navMain.Groups.Add(navGroup);

                var _lsChild = _func.getChild(_pr.FUNC_CODE);
                foreach ( var _ch in _lsChild)
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

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void navMain_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            string func_code = e.Link.Item.Tag.ToString();
            //var _group = _sysGroup.getGroupByMember(_user.IDUSER);
            //var _uRight = _sysRight.getRight(_user.IDUSER, func_code);

            //if(_group != null)
            //{
            //    var _groupRight = tb_SYS_RIGHT.getRight(_group.IDUSER, func_code);
            //    if (_uRight.USER_RIGHT < _groupRight.USER_RIGHT)
            //        _uRight.USER_RIGHT = _groupRight.USER_RIGHT;
            //}

            //if(_uRight.USER_RIGHT == 0)
            //{
            //    MessageBox.Show("Không có quyền thao tác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
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
                case "NHAPMUA":
                    {
                        frmNhapMua frm = new frmNhapMua();
                        frm.ShowDialog();
                        break;
                    }
                    //case "XUATNB":
                    //    {
                    //        frmXuatNoiBo frm = new frmXuatNoiBo(_user,_uRight.USER_RIGHT.Value);
                    //        frm.ShowDialog();
                    //        break;
                    //    }
                    //    case "NHAPNB":
                    //        {
                    //            frmNhapNoiBo frm = new frmNhapNoiBo(_user, _uRight.USER_RIGHT.Value);
                    //            frm.ShowDialog();
                    //            break;
                    //        }
                    //}
            }
        }

        //private void btnTinhTon_Click(object sender, EventArgs e)
        //{
        //    string madvi = "";
        //    TONKHO _tonkho = new TONKHO();
        //    if (myFunctions._madvi == "~")
        //        madvi = "CTKHO1";
        //    else
        //        madvi = myFunctions._madvi;
        //    if (_tonkho.TinhTon(madvi, DateTime.Now))
        //    {
        //        MessageBox.Show("Cập nhật tồn kho thành công.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information); 
        //    }
        //    else
        //    {
        //        MessageBox.Show("Cập nhật tồn kho không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    }
        //}
    }
}

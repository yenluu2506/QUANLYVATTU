﻿using BusinesssLayer;
using DataLayer;
using DevExpress.XtraEditors;
using MATERIAL.ucControls;
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
    public partial class frmBaoCao : DevExpress.XtraEditors.XtraForm
    {
        public frmBaoCao()
        {
            InitializeComponent();
        }
        public frmBaoCao(tb_SYS_USER user)
        {
            InitializeComponent();
            this._user = user;
        }
        tb_SYS_USER _user;
        SYS_USER _sysUser;
        SYS_REPORT _sysReport;
        SYS_RIGHT_REP _sysRightRep;
        Panel _panel;
        ucTuNgay _uTuNgay;
        ucCongTy _uCongTy;
        ucDonVi _uDonVi;
        private void frmBaoCao_Load(object sender, EventArgs e)
        {
            _sysReport = new SYS_REPORT();
            _sysUser = new SYS_USER();
            _sysRightRep = new SYS_RIGHT_REP();
            lstDanhSach.DataSource = _sysReport.getlistByRight(_sysRightRep.getListByUser(_user.IDUSER));
            lstDanhSach.DisplayMember = "DESCRIPTION";
            lstDanhSach.ValueMember = "REP_CODE";
            lstDanhSach.SelectedIndexChanged += LstDanhSach_SelectedIndexChanged;
            loadUserControl();
        }

        private void LstDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadUserControl();
        }
        void loadUserControl()
        {
            int rep_code = 0;
            if(lstDanhSach.SelectedValue != null)
            {
                rep_code = int.Parse(lstDanhSach.SelectedValue.ToString());
            }
            else
            {
                rep_code = 0;
            }
            tb_SYS_REPORT rep = _sysReport.getItem(rep_code);
            if (_panel != null)
                _panel.Dispose();
            _panel = new Panel();
            _panel.Dock = DockStyle.Top;
            _panel.MinimumSize = new Size(_panel.Width, 500);
            List<Control> _ctrl = new List<Control>();
            if(rep != null)
            {
                if (rep.TUNGAY == true)
                {
                    _uTuNgay = new ucTuNgay(rep.TONKHO.Value);
                    _uTuNgay.Dock = DockStyle.Top;
                    _ctrl.Add(_uTuNgay);
                }
                if (rep.MACTY == true)
                {
                    _uCongTy = new ucCongTy();
                    _uCongTy.Dock = DockStyle.Top;
                    _ctrl.Add(_uCongTy);
                }
                if (rep.MADVI == true)
                {
                    _uDonVi = new ucDonVi();
                    _uDonVi.Dock = DockStyle.Top;
                    _ctrl.Add(_uDonVi);
                }
                _ctrl.Reverse();
                _panel.Controls.AddRange(_ctrl.ToArray());
                this.splBaoCao.Panel2.Controls.Add(_panel);
            }
            
        }

        private void btnThucHien_Click(object sender, EventArgs e)
        {
            tb_SYS_REPORT rp = _sysReport.getItem(int.Parse(lstDanhSach.SelectedValue.ToString()));
            Form frm = new Form();
            CrystalReportViewer crv = new CrystalReportViewer();
            crv.ShowGroupTreeButton = false;
            crv.ShowParameterPanelButton = false;
            crv.ToolPanelView = ToolPanelViewType.None;
            TableLogOnInfo Thongtin;
            ReportDocument doc = new ReportDocument();
            doc.Load(System.Windows.Forms.Application.StartupPath + "\\Reports\\" + rp.REP_NAME + @".rpt");
            Thongtin = doc.Database.Tables[0].LogOnInfo;
            Thongtin.ConnectionInfo.ServerName = myFunctions._srv;
            Thongtin.ConnectionInfo.DatabaseName = myFunctions._db; 
            Thongtin.ConnectionInfo.UserID = myFunctions._us; 
            Thongtin.ConnectionInfo.Password = myFunctions._pw; 
            doc.Database.Tables[0].ApplyLogOnInfo(Thongtin);
            if (rp.TUNGAY == true)
            {
                doc.SetParameterValue("@NGAYD", _uTuNgay.dtTuNgay.Value); 
                doc.SetParameterValue("@NGAYC", _uTuNgay.dtDenNgay.Value);
            }
            if (rp.MACTY == true)
            {
                doc.SetParameterValue("@MACTY", _uCongTy.cboCongTy.SelectedValue.ToString());
            }

            if (rp.MADVI == true)
            {
                doc.SetParameterValue("@MACTY",_uDonVi.cboCongTy.SelectedValue.ToString());
                doc.SetParameterValue("@MADVI",_uDonVi.cboDonVi.SelectedValue.ToString());
            }
            crv.Dock = DockStyle.Fill; 
            crv.ReportSource = doc; 
            frm.Controls.Add(crv); 
            crv.Refresh();
            frm.Text = rp.DESCRIPTION;
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
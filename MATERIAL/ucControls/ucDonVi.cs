using BusinesssLayer;
<<<<<<< HEAD
using MATERIAL.MyFunctions;
=======
using DataLayer;
>>>>>>> d171d2e404948165d09d9b901876e18effaa02a8
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATERIAL.ucControls
{
    public partial class ucDonVi : UserControl
    {
        public ucDonVi()
        {
            InitializeComponent();
        }
<<<<<<< HEAD

        CONGTY _congty;
        DONVI _donvi;
=======
        CONGTY _congty;
        DONVI _donvi;
        private void linkDonVi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
>>>>>>> d171d2e404948165d09d9b901876e18effaa02a8

        private void ucDonVi_Load(object sender, EventArgs e)
        {
            _congty = new CONGTY();
            _donvi = new DONVI();
            loadCongTy();
<<<<<<< HEAD
            cboCongTy.Enabled= false;
=======
            cboCongTy.Enabled = false;
>>>>>>> d171d2e404948165d09d9b901876e18effaa02a8
            cboCongTy.SelectedIndexChanged += CboCongTy_SelectedIndexChanged;
            loadDonVi();
            if (myFunctions._madvi == "~")
                cboDonVi.Enabled = true;
            else
            {
<<<<<<< HEAD
                cboDonVi.SelectedValue=myFunctions._madvi;
=======
                cboDonVi.SelectedValue = myFunctions._madvi;
>>>>>>> d171d2e404948165d09d9b901876e18effaa02a8
                cboDonVi.Enabled = false;
            }
        }

        private void CboCongTy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDonVi();
        }

        void loadCongTy()
        {
            cboCongTy.DataSource = _congty.getAll();
            cboCongTy.DisplayMember = "TENCTY";
            cboCongTy.ValueMember = "MACTY";
            cboCongTy.SelectedValue = myFunctions._macty;
        }
        void loadDonVi()
        {
            cboDonVi.DataSource = _donvi.getAll(cboCongTy.SelectedValue.ToString());
            cboDonVi.DisplayMember = "TENDVI";
            cboDonVi.ValueMember = "MADVI";
        }
    }
}

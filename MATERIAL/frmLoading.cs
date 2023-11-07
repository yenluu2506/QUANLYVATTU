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

namespace MATERIAL
{
    public partial class frmLoading : DevExpress.XtraEditors.XtraForm
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        private void frmLoading_Load(object sender, EventArgs e)
        {
            Timer1.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int Startpoint = 0;
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Startpoint += 1;
            ProgressBar1.Value = Startpoint;
            Percentage.Text = Startpoint + "%";
            if (ProgressBar1.Value == 100)
            {
                ProgressBar1.Value = 0;
                Timer1.Stop();
                frmLogin Obj = new frmLogin();
                this.Hide();
                Obj.Show();
            }
        }
    }
}
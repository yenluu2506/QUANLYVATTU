using BusinesssLayer;
<<<<<<< HEAD
using MATERIAL.MyFunctions;
=======
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
    public partial class ucCongTy : UserControl
    {
        public ucCongTy()
        {
            InitializeComponent();
        }

        private void ucCongTy_Load(object sender, EventArgs e)
        {
            CONGTY _congty = new CONGTY();
            cboCongTy.DataSource = _congty.getAll();
            cboCongTy.DisplayMember = "TENCTY";
            cboCongTy.ValueMember = "MACTY";
            cboCongTy.SelectedValue = myFunctions._macty;
        }
    }
}

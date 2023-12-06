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
    public partial class ucTuNgay : UserControl
    {
        public ucTuNgay()
        {
            InitializeComponent();
        }
        public ucTuNgay(bool tonkho)
        {
            InitializeComponent();
            this._tonkho = tonkho;
        }
<<<<<<< HEAD

=======
>>>>>>> d171d2e404948165d09d9b901876e18effaa02a8
        bool _tonkho;
        private void ucTuNgay_Load(object sender, EventArgs e)
        {
            dtTuNgay.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtDenNgay.Value = DateTime.Now;
            if (_tonkho)
                dtTuNgay.Enabled = false;
            else
<<<<<<< HEAD
                dtTuNgay.Enabled=true;
=======
                dtTuNgay.Enabled = true;
>>>>>>> d171d2e404948165d09d9b901876e18effaa02a8
        }

        private void dtTuNgay_ValueChanged(object sender, EventArgs e)
        {
<<<<<<< HEAD
            if(dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                dtTuNgay.Select();
                return;
            }
        }

        private void dtTuNgay_Leave(object sender, EventArgs e)
        {
=======
>>>>>>> d171d2e404948165d09d9b901876e18effaa02a8
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtTuNgay.Select();
                return;
            }
        }

        private void dtDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (_tonkho)
            {
                dtTuNgay.Value = new DateTime(dtDenNgay.Value.Year, dtDenNgay.Value.Month, 1);

            }
            else
            {
                if (dtTuNgay.Value > dtDenNgay.Value)
                {
                    MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtTuNgay.Select();
                    return;
                }
            }
<<<<<<< HEAD
           
=======
        }

        private void dtTuNgay_Leave(object sender, EventArgs e)
        {
            if (dtTuNgay.Value > dtDenNgay.Value)
            {
                MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtTuNgay.Select();
                return;
            }
>>>>>>> d171d2e404948165d09d9b901876e18effaa02a8
        }

        private void dtDenNgay_Leave(object sender, EventArgs e)
        {
            if (_tonkho)
            {
                dtTuNgay.Value = new DateTime(dtDenNgay.Value.Year, dtDenNgay.Value.Month, 1);

            }
            else
            {
                if (dtTuNgay.Value > dtDenNgay.Value)
                {
                    MessageBox.Show("Ngày không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtTuNgay.Select();
                    return;
                }
            }
        }
    }
}

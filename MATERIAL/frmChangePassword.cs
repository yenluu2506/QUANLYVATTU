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

namespace MATERIAL
{
    public partial class frmChangePassword : DevExpress.XtraEditors.XtraForm
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }
        public frmChangePassword(tb_SYS_USER user)
        {
            InitializeComponent();
            this._user = user;
        }
        tb_SYS_USER _user;
        SYS_USER _sysUser;
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _sysUser = new SYS_USER();

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (!txtMKMoi.Text.Equals(txtGoLaiMKMoi.Text))
            {
                MessageBox.Show("Gõ lại mật khẩu không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                return;
            }
            var us = _sysUser.getItem(_user.IDUSER);
            if (us.PASSWD == Encryptor.Encrypt(txtMKCu.Text, "qwert@123poiuy", true))
            {
                us.PASSWD = Encryptor.Encrypt(txtMKMoi.Text, "qwert@123poiuy", true);
                _sysUser.update(us);
                MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Restart();
                Environment.Exit(0);
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
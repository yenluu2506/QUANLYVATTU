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

namespace USERMANAGEMENT
{
    public partial class frmUser : DevExpress.XtraEditors.XtraForm
    {
        public frmUser()
        {
            InitializeComponent();
        }
        frmMain objMain = (frmMain)Application.OpenForms["frmMain"];
        public string _macty;
        public string _madvi;
        public int _idUser;
        public string _username;
        public string _fullname;
        public bool _them;
        SYS_USER _sysUser;
        tb_SYS_USER _user;

        private void frmUser_Load(object sender, EventArgs e)
        {
            _sysUser = new SYS_USER();
            if (!_them)
            {
                var user = _sysUser.getItem(_idUser);
                txtUsername.Text = user.USERNAME;
                _macty = user.MACTY;
                _madvi = user.MADVI;
                txtHoTen.Text = user.FULLNAME;
                chkDissabled.Checked = user.DISABLED.Value;
                txtUsername.ReadOnly = true;
                txtPass.Text = Encryptor.Encrypt(user.PASSWD, "qwert@123poiuy", true);
                txtRePass.Text = Encryptor.Encrypt(user.PASSWD, "qwert@123poiuy", true);
            }
            else
            {
                txtHoTen.Text = "";
                txtPass.Text = "";
                txtRePass.Text = "";
                chkDissabled.Checked = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Chưa nhập tên người dùng. Tên người dùng nhập không dấu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.SelectAll();
                txtUsername.Focus();
                return;
            }
            if (txtPass.Text.Equals(txtRePass.Text))
            {
                MessageBox.Show("Mật khẩu không trùng khớp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.SelectAll();
                txtUsername.Focus();
                return;
            }
            saveData();
        }
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void saveData()
        {
            if (_them)
            {
                bool checkedUser = _sysUser.checkUserExist(_macty, _madvi, txtUsername.Text.Trim());
                if (checkedUser)
                {
                    MessageBox.Show("Nhóm đã tồn tại. Vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                    return;
                }
                _user = new tb_SYS_USER();
                _user.USERNAME = txtUsername.Text.Trim();
                _user.FULLNAME = txtHoTen.Text;
                _user.PASSWD = Encryptor.Encrypt(txtPass.Text.Trim(), "qwert@123poiuy", true);
                _user.ISGROUP = false;
                _user.DISABLED = false;
                _user.MACTY = _macty;
                _user.MADVI = _madvi;
                _sysUser.add(_user);
            }
            else
            {
                _user = _sysUser.getItem(_idUser);
                _user.FULLNAME = txtHoTen.Text;
                _user.PASSWD = Encryptor.Encrypt(txtPass.Text.Trim(), "qwert@123poiuy", true);
                _user.ISGROUP = false;
                _user.DISABLED = chkDissabled.Checked;
                _user.MACTY = _macty;
                _user.MADVI = _madvi;
                _sysUser.update(_user);
            }
            objMain.loadUser(_macty, _madvi);
        }
    }
}
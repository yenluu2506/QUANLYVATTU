using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using MATERIAL.MyFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MATERIAL
{
    public partial class frmBackup : DevExpress.XtraEditors.XtraForm
    {
        public frmBackup()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=" + myFunctions._srv + "; Initial Catalog=" + myFunctions._db + "; User ID=" + myFunctions._us + "; Password = " + myFunctions._pw + ";");
        private void frmBackup_Load(object sender, EventArgs e)
        {
            txtURL.Enabled = false;
            btnBackup.Enabled = false;
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string db = con.Database.ToString();
            if (string.IsNullOrEmpty(txtURL.Text))
            {
                MessageBox.Show("Vui lòng chọn đường dãn lưu file backup.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
                string sql = "BACKUP DATABASE [" + db + "] TO DISK ='" + txtURL.Text + "\\" + db + "-" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".bak'";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                con.Close();
                SplashScreenManager.CloseForm(true);
                MessageBox.Show("Backup dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information );
                btnBackup.Enabled = false;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            if(fb.ShowDialog() == DialogResult.OK)
            {
                txtURL.Text = fb.SelectedPath;
                btnBackup.Enabled = true;
            }
        }
    }
}
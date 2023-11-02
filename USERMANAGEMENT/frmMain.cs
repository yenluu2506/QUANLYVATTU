using BusinesssLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using USERMANAGEMENT.MyComponents;

namespace USERMANAGEMENT
{
    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        MyTreeViewCombo _treeview;
        CONGTY _congty;
        DONVI _donvi;
        SYS_USER _sysUser;
        bool _isRoot;
        string _macty;
        string _madvi;
        private void frmMain_Load(object sender, EventArgs e)
        {
            _congty = new CONGTY();
            _donvi = new DONVI();
            _sysUser = new SYS_USER();
            _isRoot = true;
            loadTreeView();
            loadUser("CT01", "~");
        }
        public void loadUser(string macty, string madvi)
        {
            gcUser.DataSource = _sysUser.getUserByDVI(macty, madvi);
            gvUser.OptionsBehavior.Editable = false;
        }
        void loadTreeView()
        {
            _treeview = new MyTreeViewCombo(pnNhom.Width, 400);
            _treeview.Font = new Font("Tahoma", 10, FontStyle.Bold);
            var lstCTY = _congty.getAll();
            foreach ( var item in lstCTY )
            {
                TreeNode ParentNode = new TreeNode();
                ParentNode.Text = item.MACTY + " - " + item.TENCTY;
                ParentNode.Tag = item.MACTY;
                ParentNode.Name = item.MACTY;
                _treeview.TreeView.Nodes.Add( ParentNode );
                foreach(var dv in _donvi.getAll(item.MACTY))
                {
                    TreeNode childNode = new TreeNode();
                    childNode.Text = dv.MADVI + " - " + dv.TENDVI;
                    childNode.Tag = dv.MACTY + "." + dv.MADVI;
                    childNode.Name = dv.MACTY + "." + dv.MADVI;
                    _treeview.TreeView.Nodes[ParentNode.Name].Nodes.Add( childNode );
                }
            }
            _treeview.TreeView.ExpandAll();
            pnNhom.Controls.Add( _treeview );
            _treeview.Height= pnNhom.Height;
            _treeview.Width= pnNhom.Width;
            _treeview.TreeView.AfterSelect += TreeView_AfterSelect;
            _treeview.TreeView.Click += TreeView_Click;
        }

        private void TreeView_Click(object sender, EventArgs e)
        {
            _treeview.dropDown.Focus();
            _treeview.SelectAll();
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            _treeview.Text = _treeview.TreeView.SelectedNode.Text;
            if (_treeview.TreeView.SelectedNode.Parent == null)
            {
                _isRoot = true;
                _macty = _treeview.TreeView.SelectedNode.Tag.ToString();
                _madvi = "~";
            }
            else
            {
                _isRoot = false;
                _macty = _treeview.TreeView.SelectedNode.Name.Substring(0, 4);
                _madvi = _treeview.TreeView.SelectedNode.Name.Substring(5);
            }
            loadUser(_macty, _madvi);
            _treeview.dropDown.Close();
        }

        private void btnGroup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(_treeview.Text == "")
            {
                MessageBox.Show("Vui lòng chọn Đơn vị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmGroup frm = new frmGroup();
            frm._them = true;
            frm._macty = _macty;
            frm._madvi = _madvi;
            frm.ShowDialog();
        }

        private void btnUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnCapNhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnPhanQuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void gvUser_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "ISGROUP" && bool.Parse(e.CellValue.ToString()) == false)
            {
                Image img = Properties.Resources.Team_16x16;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
            if (e.Column.Name == "ISGROUP" && bool.Parse(e.CellValue.ToString()) == true)
            {
                Image img = Properties.Resources.Team_16x16;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }
        private void gvUser_DoubleClick(object sender, EventArgs e)
        {
            if (gvUser.GetFocusedRowCellValue("ISGROUP")) { }
        }

    }
}

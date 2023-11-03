namespace USERMANAGEMENT
{
    partial class frmPhanQuyenBaoCao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcUsers = new DevExpress.XtraGrid.GridControl();
            this.gvUsers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ISGROUP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.USERNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.FULLNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDUSER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridSplitContainer1 = new DevExpress.XtraGrid.GridSplitContainer();
            this.gcChucNang = new DevExpress.XtraGrid.GridControl();
            this.gvChucNang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.REP_CODE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DESCRIPTION = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QUYEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cISGROUP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnCamQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnToanQuyen = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1.Panel1)).BeginInit();
            this.gridSplitContainer1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1.Panel2)).BeginInit();
            this.gridSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcChucNang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChucNang)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.gcUsers);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.gridSplitContainer1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(977, 549);
            this.splitContainerControl1.SplitterPosition = 353;
            this.splitContainerControl1.TabIndex = 1;
            // 
            // gcUsers
            // 
            this.gcUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcUsers.Location = new System.Drawing.Point(0, 0);
            this.gcUsers.MainView = this.gvUsers;
            this.gcUsers.Name = "gcUsers";
            this.gcUsers.Size = new System.Drawing.Size(353, 549);
            this.gcUsers.TabIndex = 0;
            this.gcUsers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUsers});
            // 
            // gvUsers
            // 
            this.gvUsers.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ISGROUP,
            this.USERNAME,
            this.FULLNAME,
            this.IDUSER});
            this.gvUsers.GridControl = this.gcUsers;
            this.gvUsers.Name = "gvUsers";
            this.gvUsers.OptionsView.ShowGroupPanel = false;
            this.gvUsers.RowHeight = 25;
            this.gvUsers.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gvUsers_CustomDrawCell);
            this.gvUsers.Click += new System.EventHandler(this.gvUsers_Click);
            // 
            // ISGROUP
            // 
            this.ISGROUP.FieldName = "ISGROUP";
            this.ISGROUP.MaxWidth = 40;
            this.ISGROUP.MinWidth = 35;
            this.ISGROUP.Name = "ISGROUP";
            this.ISGROUP.Visible = true;
            this.ISGROUP.VisibleIndex = 0;
            this.ISGROUP.Width = 40;
            // 
            // USERNAME
            // 
            this.USERNAME.Caption = "USERNAME";
            this.USERNAME.FieldName = "USERNAME";
            this.USERNAME.MaxWidth = 100;
            this.USERNAME.MinWidth = 80;
            this.USERNAME.Name = "USERNAME";
            this.USERNAME.Visible = true;
            this.USERNAME.VisibleIndex = 1;
            this.USERNAME.Width = 94;
            // 
            // FULLNAME
            // 
            this.FULLNAME.Caption = "FULLNAME";
            this.FULLNAME.FieldName = "FULLNAME";
            this.FULLNAME.MaxWidth = 120;
            this.FULLNAME.MinWidth = 100;
            this.FULLNAME.Name = "FULLNAME";
            this.FULLNAME.Visible = true;
            this.FULLNAME.VisibleIndex = 2;
            this.FULLNAME.Width = 100;
            // 
            // IDUSER
            // 
            this.IDUSER.Caption = "ID";
            this.IDUSER.FieldName = "IDUSER";
            this.IDUSER.MinWidth = 25;
            this.IDUSER.Name = "IDUSER";
            this.IDUSER.Width = 94;
            // 
            // gridSplitContainer1
            // 
            this.gridSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSplitContainer1.Grid = this.gcChucNang;
            this.gridSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.gridSplitContainer1.Name = "gridSplitContainer1";
            // 
            // gridSplitContainer1.Panel1
            // 
            this.gridSplitContainer1.Panel1.Controls.Add(this.gcChucNang);
            this.gridSplitContainer1.Size = new System.Drawing.Size(612, 549);
            this.gridSplitContainer1.TabIndex = 0;
            // 
            // gcChucNang
            // 
            this.gcChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcChucNang.EmbeddedNavigator.ContextMenuStrip = this.contextMenuStrip1;
            this.gcChucNang.Location = new System.Drawing.Point(0, 0);
            this.gcChucNang.MainView = this.gvChucNang;
            this.gcChucNang.Name = "gcChucNang";
            this.gcChucNang.Size = new System.Drawing.Size(612, 549);
            this.gcChucNang.TabIndex = 0;
            this.gcChucNang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvChucNang});
            // 
            // gvChucNang
            // 
            this.gvChucNang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.REP_CODE,
            this.DESCRIPTION,
            this.QUYEN,
            this.cISGROUP});
            this.gvChucNang.GridControl = this.gcChucNang;
            this.gvChucNang.Name = "gvChucNang";
            this.gvChucNang.OptionsMenu.EnableGroupRowMenu = true;
            this.gvChucNang.OptionsSelection.MultiSelect = true;
            this.gvChucNang.RowHeight = 25;
            this.gvChucNang.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gvChucNang_PopupMenuShowing);
            // 
            // REP_CODE
            // 
            this.REP_CODE.Caption = "REP_CODE";
            this.REP_CODE.FieldName = "REP_CODE";
            this.REP_CODE.MinWidth = 25;
            this.REP_CODE.Name = "REP_CODE";
            this.REP_CODE.Width = 94;
            // 
            // DESCRIPTION
            // 
            this.DESCRIPTION.Caption = "Chức Năng";
            this.DESCRIPTION.FieldName = "DESCRIPTION";
            this.DESCRIPTION.MaxWidth = 250;
            this.DESCRIPTION.MinWidth = 200;
            this.DESCRIPTION.Name = "DESCRIPTION";
            this.DESCRIPTION.Visible = true;
            this.DESCRIPTION.VisibleIndex = 0;
            this.DESCRIPTION.Width = 200;
            // 
            // QUYEN
            // 
            this.QUYEN.Caption = "Quyền";
            this.QUYEN.FieldName = "QUYEN";
            this.QUYEN.MaxWidth = 150;
            this.QUYEN.MinWidth = 100;
            this.QUYEN.Name = "QUYEN";
            this.QUYEN.Visible = true;
            this.QUYEN.VisibleIndex = 1;
            this.QUYEN.Width = 100;
            // 
            // cISGROUP
            // 
            this.cISGROUP.Caption = "GROUP";
            this.cISGROUP.FieldName = "ISGROUP";
            this.cISGROUP.MinWidth = 25;
            this.cISGROUP.Name = "cISGROUP";
            this.cISGROUP.Width = 94;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.contextMenuStrip1.Font = new System.Drawing.Font("Constantia", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnCamQuyen,
            this.toolStripSeparator2,
            this.mnToanQuyen});
            this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 62);
            // 
            // mnCamQuyen
            // 
            this.mnCamQuyen.Image = global::USERMANAGEMENT.Properties.Resources._299051_ban_sign_icon;
            this.mnCamQuyen.Name = "mnCamQuyen";
            this.mnCamQuyen.Size = new System.Drawing.Size(214, 26);
            this.mnCamQuyen.Text = "Khóa quyền";
            this.mnCamQuyen.Click += new System.EventHandler(this.mnCamQuyen_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // mnToanQuyen
            // 
            this.mnToanQuyen.Image = global::USERMANAGEMENT.Properties.Resources._131490_manager_global_control_global_government_police_icon;
            this.mnToanQuyen.Name = "mnToanQuyen";
            this.mnToanQuyen.Size = new System.Drawing.Size(214, 26);
            this.mnToanQuyen.Text = "Toàn quyền";
            this.mnToanQuyen.Click += new System.EventHandler(this.mnToanQuyen_Click);
            // 
            // frmPhanQuyenBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 549);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "frmPhanQuyenBaoCao";
            this.Text = "frmPhanQuyenBaoCao";
            this.Load += new System.EventHandler(this.frmPhanQuyenBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1.Panel1)).EndInit();
            this.gridSplitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1.Panel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).EndInit();
            this.gridSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcChucNang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvChucNang)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraGrid.GridControl gcUsers;
        private DevExpress.XtraGrid.Views.Grid.GridView gvUsers;
        private DevExpress.XtraGrid.Columns.GridColumn ISGROUP;
        private DevExpress.XtraGrid.Columns.GridColumn USERNAME;
        private DevExpress.XtraGrid.Columns.GridColumn FULLNAME;
        private DevExpress.XtraGrid.Columns.GridColumn IDUSER;
        private DevExpress.XtraGrid.GridSplitContainer gridSplitContainer1;
        private DevExpress.XtraGrid.GridControl gcChucNang;
        private DevExpress.XtraGrid.Views.Grid.GridView gvChucNang;
        private DevExpress.XtraGrid.Columns.GridColumn REP_CODE;
        private DevExpress.XtraGrid.Columns.GridColumn DESCRIPTION;
        private DevExpress.XtraGrid.Columns.GridColumn QUYEN;
        private DevExpress.XtraGrid.Columns.GridColumn cISGROUP;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnCamQuyen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnToanQuyen;
    }
}
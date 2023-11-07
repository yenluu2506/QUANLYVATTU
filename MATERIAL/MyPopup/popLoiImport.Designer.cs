namespace MATERIAL.MyPopup
{
    partial class popLoiImport
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
            this.gcErrors = new DevExpress.XtraGrid.GridControl();
            this.gvErrors = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gcErrors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // gcErrors
            // 
            this.gcErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcErrors.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcErrors.Location = new System.Drawing.Point(0, 0);
            this.gcErrors.MainView = this.gvErrors;
            this.gcErrors.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcErrors.Name = "gcErrors";
            this.gcErrors.Size = new System.Drawing.Size(579, 374);
            this.gcErrors.TabIndex = 0;
            this.gcErrors.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvErrors});
            // 
            // gvErrors
            // 
            this.gvErrors.DetailHeight = 284;
            this.gvErrors.GridControl = this.gcErrors;
            this.gvErrors.Name = "gvErrors";
            this.gvErrors.OptionsEditForm.PopupEditFormWidth = 686;
            // 
            // popLoiImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 374);
            this.Controls.Add(this.gcErrors);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "popLoiImport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "popLoiImport";
            this.Load += new System.EventHandler(this.popLoiImport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcErrors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvErrors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcErrors;
        private DevExpress.XtraGrid.Views.Grid.GridView gvErrors;
    }
}
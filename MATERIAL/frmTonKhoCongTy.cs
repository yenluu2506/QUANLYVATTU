﻿using BusinesssLayer;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using MATERIAL.MyFunctions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace MATERIAL
{
    public partial class frmTonKhoCongTy : DevExpress.XtraEditors.XtraForm
    {
        public frmTonKhoCongTy()
        {
            InitializeComponent();
        }
        public frmTonKhoCongTy(tb_SYS_USER user, int right)
        {
            InitializeComponent();
            this._user = user;
            this._right = right;
        }
        tb_SYS_USER _user;
        int _right;
        TONKHO _tonkho;
        CONGTY _congty;
        List<obj_TONKHO> _lstHH = new List<obj_TONKHO>();
        private void frmTonKhoCongTy_Load(object sender, EventArgs e)
        {
            _congty = new CONGTY();
            _tonkho = new TONKHO();
            loadCongTy();
            cboCongTy.SelectedValue = myFunctions._macty;
            dtChonKy.Value = DateTime.Now;
            loadTonKho(myFunctions._macty, DateTime.Now.Year, DateTime.Now.Month);
            _lstHH = _tonkho.getTonKhoCty(myFunctions._macty, dtChonKy.Value.Year, dtChonKy.Value.Month);
        }
        void loadCongTy()
        {
            cboCongTy.DataSource = _congty.getAll();
            cboCongTy.DisplayMember = "TENCTY";
            cboCongTy.ValueMember = "MACTY";
        }
        void loadTonKho(string macty, int nam, int ky)
        {
            gcTonKho.DataSource = _tonkho.getTonKhoCty(macty, nam, ky);
            gvTonKho.OptionsBehavior.Editable = false;
        }
        private void btnExport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _export();
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            loadTonKho(cboCongTy.SelectedValue.ToString(), dtChonKy.Value.Year, dtChonKy.Value.Month);
            _lstHH = _tonkho.getTonKhoCty(cboCongTy.SelectedValue.ToString(), dtChonKy.Value.Year, dtChonKy.Value.Month);
        }

        void _export()
        {
            string tenFile = "";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel 2000-2003 (.xls) | *.xls|Excel 2007 or higher (.xlsx) |*.xlsx"; //Xet dinh dang mac dinh cho file
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
                tenFile = saveFile.FileName;
            }
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add(Type.Missing);
            Excel._Worksheet sheet = null;

            try
            {
                sheet = wb.ActiveSheet;
                //Dat ten sheet
                sheet.Name = "DM " + cboCongTy.Text;
                sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 12]].Merge();
                //canh le text
                sheet.Cells[1, 1].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                //Border
                sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 12]].BorderAround(Type.Missing, Excel.XlBorderWeight.xlThick, Excel.XlColorIndex.xlColorIndexAutomatic);
                sheet.Cells[1, 1].Value = "DANH MỤC TỒN KHO" + cboCongTy.Text.ToUpper();
                sheet.Cells[1, 1].Font.Size = 20;
                sheet.Cells[2, 1].Value = "BARCODE";
                sheet.Cells[2, 2].Value = "TÊN HÀNG HÓA";
                sheet.Cells[2, 3].Value = "ĐVT";
                sheet.Cells[2, 4].Value = "TỒN ĐẦU";
                sheet.Cells[2, 5].Value = "NHẬP MUA";
                sheet.Cells[2, 6].Value = "NHẬP NỘI BỘ";
                sheet.Cells[2, 7].Value = "XUẤT NỘI BỘ";
                sheet.Cells[2, 8].Value = "XUẤT SỈ";
                sheet.Cells[2, 9].Value = "BÁN LẺ";
                sheet.Cells[2, 10].Value = "TỒN CUỐI";
                sheet.Cells[2, 11].Value = "TRỊ GIÁ";
                sheet.Cells[2, 12].Value = "THÀNH TIỀN";
                sheet.Cells[2, 13].Value = "NĂM KỲ";
                sheet.Cells[2, 14].Value = "NĂM";
                sheet.Cells[2, 15].Value = "KỲ";

                //xuat du lieu
                for (int i = 1; i <= _lstHH.Count; i++)
                {
                    sheet.Cells[i + 2, 1].Value = _lstHH.ElementAt(i - 1).BARCODE;
                    sheet.Cells[i + 2, 2].Value = _lstHH.ElementAt(i - 1).TENHH;
                    sheet.Cells[i + 2, 3].Value = _lstHH.ElementAt(i - 1).DVT;
                    sheet.Cells[i + 2, 4].Value = _lstHH.ElementAt(i - 1).LG_DAU;
                    sheet.Cells[i + 2, 5].Value = _lstHH.ElementAt(i - 1).LG_NHAPMUA;
                    sheet.Cells[i + 2, 6].Value = _lstHH.ElementAt(i - 1).LG_NHAPNB;
                    sheet.Cells[i + 2, 7].Value = _lstHH.ElementAt(i - 1).LG_XUATNB;
                    sheet.Cells[i + 2, 8].Value = _lstHH.ElementAt(i - 1).LG_XUATSI;
                    sheet.Cells[i + 2, 9].Value = _lstHH.ElementAt(i - 1).LG_BANLE;
                    sheet.Cells[i + 2, 10].Value = _lstHH.ElementAt(i - 1).LG_CUOI;
                    sheet.Cells[i + 2, 11].Value = _lstHH.ElementAt(i - 1).TRIGIA;
                    sheet.Cells[i + 2, 12].Value = _lstHH.ElementAt(i - 1).TIEN_CUOI;
                    sheet.Cells[i + 2, 13].Value = _lstHH.ElementAt(i - 1).NAMKY;
                    sheet.Cells[i + 2, 14].Value = _lstHH.ElementAt(i - 1).NAM;
                    sheet.Cells[i + 2, 15].Value = _lstHH.ElementAt(i - 1).KY;
                }
                //Save vao file
                wb.SaveAs(tenFile);
            }
            catch (Exception ex)
            {
                SplashScreenManager.CloseForm();
                MessageBox.Show(ex.ToString(), "Error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                wb.Close();
                app.Quit();
                releaseObject(wb);
                releaseObject(app);
                SplashScreenManager.CloseForm();
                MessageBox.Show("Xuất File thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
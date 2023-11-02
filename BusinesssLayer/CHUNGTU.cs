using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class CHUNGTU
    {
        Entities db;

        public CHUNGTU()
        {
            db = Entities.CreateEntities();
        }

        public tb_CHUNGTU getItem(Guid khoa)
        {
            return db.tb_CHUNGTU.FirstOrDefault(x => x.KHOA == khoa);
        }

        public List<tb_CHUNGTU> getList()
        {
            return db.tb_CHUNGTU.ToList();
        }

        public List<tb_CHUNGTU> getList(Guid khoa)
        {
            return db.tb_CHUNGTU.Where(x => x.KHOA == khoa).ToList();
        }
        public List<tb_CHUNGTU> getList(int lct, DateTime tungay, DateTime denngay, string madvi)
        {
            return db.tb_CHUNGTU.Where(x => x.MADVI == madvi && x.NGAY >= tungay && x.NGAY < denngay && x.LCT == lct).OrderBy(x=>x.SCT).ToList();
        }

        public List<tb_CHUNGTU> getPhieuNhap(int lct, DateTime tungay, DateTime denngay, string madvi)
        {
            return db.tb_CHUNGTU.Where(x => x.MADVI2 == madvi && x.NGAY >= tungay && x.NGAY < denngay && x.LCT == lct && x.TRANGTHAI==2).OrderBy(x => x.SCT).ToList();
        }

        public tb_CHUNGTU add(tb_CHUNGTU ct)
        {
            try
            {
                db.tb_CHUNGTU.Add(ct);
                db.SaveChanges();
                return ct;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public tb_CHUNGTU update(tb_CHUNGTU ct)
        {
            tb_CHUNGTU _ct = db.tb_CHUNGTU.FirstOrDefault(x => x.KHOA == ct.KHOA);
            _ct.LCT = ct.LCT;
            _ct.SCT = ct.SCT;
            _ct.NGAY = ct.NGAY;
            _ct.SCT2 = ct.SCT2;
            _ct.NGAY2 = ct.NGAY2;
            _ct.SOLUONG = ct.SOLUONG;
            _ct.TONGTIEN = ct.TONGTIEN;
            _ct.GHICHU = ct.GHICHU;
            _ct.MACTY = ct.MACTY;
            _ct.MADVI = ct.MADVI;
            _ct.MADVI2 = ct.MADVI2;
            _ct.TRANGTHAI = ct.TRANGTHAI;
            try
            {
                db.SaveChanges();
                return _ct;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public void deleteAll(Guid khoa)
        {
            tb_CHUNGTU _ct = db.tb_CHUNGTU.FirstOrDefault(x => x.KHOA == khoa);
            _ct.TRANGTHAI = 2;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
        public void deleteAll(Guid khoa,int V)
        {
            tb_CHUNGTU _ct = db.tb_CHUNGTU.FirstOrDefault(x => x.KHOA == khoa && x.TRANGTHAI == V);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }
    }
}

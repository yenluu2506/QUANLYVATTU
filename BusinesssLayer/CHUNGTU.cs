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
            _ct.SOLUONG = ct.SOLUONG;
            _ct.CHIETKHAU = ct.CHIETKHAU;
            _ct.TONGTIEN = ct.TONGTIEN;
            _ct.GHICHU = ct.GHICHU;
            _ct.TRANGTHAI = ct.TRANGTHAI;
            _ct.UPDATED_BY = ct.UPDATED_BY;
            _ct.UPDATED_DATE=ct.UPDATED_DATE;
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
        public tb_CHUNGTU delete(Guid khoa,int idUser)
        {
            tb_CHUNGTU _ct = db.tb_CHUNGTU.FirstOrDefault(x => x.KHOA == khoa);
            _ct.DELETED_BY = idUser;
            _ct.DELETED_DATE= DateTime.Now;
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
    }
}

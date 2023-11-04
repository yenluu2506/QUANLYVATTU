using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class KHACHHANG
    {
        Entities db;
        public KHACHHANG()
        {
            db = Entities.CreateEntities();
        }

        public tb_KHACHHANG getInfoKH(int idKH)
        {
            return db.tb_KHACHHANG.FirstOrDefault(x => x.IDKH == idKH);
        }

        public List<tb_KHACHHANG> getAll()
        {
            return db.tb_KHACHHANG.ToList();
        }

        public List<tb_KHACHHANG> getAll(int idKH)
        {
            return db.tb_KHACHHANG.Where(x => x.IDKH == idKH).ToList();
        }

        public void add(tb_KHACHHANG kh)
        {
            try
            {
                db.tb_KHACHHANG.Add(kh);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public void update(tb_KHACHHANG kh)
        {
            tb_KHACHHANG _kh = db.tb_KHACHHANG.FirstOrDefault(x => x.IDKH == kh.IDKH);
            _kh.HOTEN = kh.HOTEN;
            _kh.DIENTHOAI = kh.DIENTHOAI;
            _kh.EMAIL = kh.EMAIL;
            _kh.DIACHI = kh.DIACHI;
            _kh.MST = kh.MST;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public void delete(int idKH)
        {
            tb_KHACHHANG kh = db.tb_KHACHHANG.FirstOrDefault(x => x.IDKH == idKH);
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

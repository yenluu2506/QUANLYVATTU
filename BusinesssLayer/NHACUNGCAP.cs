using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class NHACUNGCAP
    {
        Entities db;

        public NHACUNGCAP()
        {
            db = Entities.CreateEntities();
        }

        public tb_NHACUNGCAP getItem(int mancc)
        {
            return db.tb_NHACUNGCAP.FirstOrDefault(x => x.MANCC == mancc);
        }

        public List<tb_NHACUNGCAP> getAll()
        {
            return db.tb_NHACUNGCAP.ToList();
        }

        public List<tb_NHACUNGCAP> getAll(int mancc)
        {
            return db.tb_NHACUNGCAP.Where(x => x.MANCC == mancc).ToList();
        }

        public void add(tb_NHACUNGCAP ncc)
        {
            try
            {
                db.tb_NHACUNGCAP.Add(ncc);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public void update(tb_NHACUNGCAP ncc)
        {
            tb_NHACUNGCAP _ncc = db.tb_NHACUNGCAP.FirstOrDefault(x => x.MANCC == ncc.MANCC);
            _ncc.MANCC = ncc.MANCC;
            _ncc.TENNCC = ncc.TENNCC;
            _ncc.EMAIL = ncc.EMAIL;
            _ncc.DIENTHOAI = ncc.DIENTHOAI;
            _ncc.FAX = ncc.FAX;
            _ncc.DIACHI = ncc.DIACHI;
            _ncc.CREATED_DATE = ncc.CREATED_DATE;
            _ncc.DISABLED = ncc.DISABLED;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public void delete(int mancc)
        {
            tb_NHACUNGCAP ncc = db.tb_NHACUNGCAP.FirstOrDefault(x => x.MANCC == mancc);
            if (ncc != null)
            {
                try
                {
                    db.tb_NHACUNGCAP.Remove(ncc); // Xóa bản ghi khỏi cơ sở dữ liệu
                    db.SaveChanges(); // Lưu thay đổi
                }
                catch (Exception ex)
                {
                    throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
                }
            }
        }
    }
}

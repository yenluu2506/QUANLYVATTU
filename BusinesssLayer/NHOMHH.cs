using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class NHOMHH
    {
        Entities db;

        public NHOMHH()
        {
            db = Entities.CreateEntities();
        }

        public tb_NHOMHH getItem(int idNhom)
        {
            return db.tb_NHOMHH.FirstOrDefault(x => x.IDNHOM == idNhom);
        }

        public List<tb_NHOMHH> getAll()
        {
            return db.tb_NHOMHH.ToList();
        }

        public List<tb_NHOMHH> getAll(int idNhom)
        {
            return db.tb_NHOMHH.Where(x => x.IDNHOM == idNhom).ToList();
        }

        public void add(tb_NHOMHH nhomHH)
        {
            try
            {
                db.tb_NHOMHH.Add(nhomHH);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public void update(tb_NHOMHH nhomHH)
        {
            tb_NHOMHH _nhomHH = db.tb_NHOMHH.FirstOrDefault(x => x.IDNHOM == nhomHH.IDNHOM);
            _nhomHH.TENNHOM = nhomHH.TENNHOM;
            _nhomHH.GHICHU = nhomHH.GHICHU;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public void delete(int idNhom)
        {
            tb_NHOMHH nhomHH = db.tb_NHOMHH.FirstOrDefault(x => x.IDNHOM == idNhom);
            if (nhomHH != null)
            {
                try
                {
                    db.tb_NHOMHH.Remove(nhomHH); // Xóa bản ghi khỏi cơ sở dữ liệu
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

using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class DONVITINH
    {
        Entities db;

        public DONVITINH()
        {
            db = Entities.CreateEntities();
        }

        public tb_DVT getItem(int id)
        {
            return db.tb_DVT.FirstOrDefault(x => x.ID == id);
        }

        public List<tb_DVT> getAll()
        {
            return db.tb_DVT.ToList();
        }

        public List<tb_DVT> getAll(int id)
        {
            return db.tb_DVT.Where(x => x.ID == id).ToList();
        }

        public void add(tb_DVT dvt)
        {
            try
            {
                db.tb_DVT.Add(dvt);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public void update(tb_DVT dvt)
        {
            tb_DVT _dvt = db.tb_DVT.FirstOrDefault(x => x.ID == dvt.ID);
            _dvt.TEN = dvt.TEN;
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public void delete(int id)
        {
            tb_DVT dvt = db.tb_DVT.FirstOrDefault(x => x.ID == id);
            if (dvt != null)
            {
                try
                {
                    db.tb_DVT.Remove(dvt); // Xóa bản ghi khỏi cơ sở dữ liệu
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

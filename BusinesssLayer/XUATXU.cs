using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class XUATXU
    {
        Entities db;

        public XUATXU()
        {
            db = Entities.CreateEntities();
        }

        public tb_XUATXU getItem(int id)
        {
            return db.tb_XUATXU.FirstOrDefault(x => x.ID == id);
        }

        public List<tb_XUATXU> getAll()
        {
            return db.tb_XUATXU.ToList();
        }

        public List<tb_XUATXU> getAll(int id)
        {
            return db.tb_XUATXU.Where(x => x.ID == id).ToList();
        }

        public void add(tb_XUATXU xuatxu)
        {
            try
            {
                db.tb_XUATXU.Add(xuatxu);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public void update(tb_XUATXU xuatxu)
        {
            tb_XUATXU _xuatxu = db.tb_XUATXU.FirstOrDefault(x => x.ID == xuatxu.ID);
            _xuatxu.TEN = xuatxu.TEN;
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
            tb_XUATXU xuatxu = db.tb_XUATXU.FirstOrDefault(x => x.ID == id);
            if (xuatxu != null)
            {
                try
                {
                    db.tb_XUATXU.Remove(xuatxu); // Xóa bản ghi khỏi cơ sở dữ liệu
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

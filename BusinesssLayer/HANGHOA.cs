using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class HANGHOA
    {
        Entities db;

        public HANGHOA() {
            db = Entities.CreateEntities();
        }

        public tb_HANGHOA getItem(string barcode)
        {
            return db.tb_HANGHOA.FirstOrDefault(x => x.BARCODE == barcode);
        }

        public List<tb_HANGHOA> getListByNhom(int idNhom)
        {
            return db.tb_HANGHOA.Where(x=>x.IDNHOM == idNhom).OrderBy(o=>o.CREATED_DATE).ToList(); 
        }

        public List<obj_HANGHOA> getListByNhomFull(int idNhom)
        {
            var lst = db.tb_HANGHOA.Where(x => x.IDNHOM == idNhom).OrderBy(o => o.CREATED_DATE).ToList();
            List<obj_HANGHOA> lstObj = new List<obj_HANGHOA>();
            obj_HANGHOA hh;
            foreach (var item in lst) {
                hh = new obj_HANGHOA();
                hh.BARCODE = item.BARCODE;
                hh.TENHH = item.TENHH;
                hh.TENTAT = item.TENTAT;
                hh.IDNHOM = item.IDNHOM;
                var n = db.tb_NHOMHH.FirstOrDefault(x=>x.IDNHOM == item.IDNHOM);
                hh.TENNHOM = n.TENNHOM;
                hh.MANCC = item.MANCC;
                var m = db.tb_NHACUNGCAP.FirstOrDefault(x=>x.MANCC == item.MANCC);
                hh.TENNCC = m.TENNCC;
                hh.MAXX = item.MAXX;
                var l = db.tb_XUATXU.FirstOrDefault(x=>x.ID == item.MAXX);
                hh.TENXX = l.TEN;
                hh.DVT = item.DVT;
                hh.DONGIA = item.DONGIA;
                hh.MOTA = item.MOTA;
                lstObj.Add(hh);
            }
            return lstObj;
        }

        //public List<tb_HANGHOA> getAll()
        //{
        //    return db.tb_HANGHOA.ToList();
        //}

        //public List<tb_HANGHOA> getAll(string barcode)
        //{
        //    return db.tb_HANGHOA.Where(x => x.BARCODE == barcode).ToList();
        //}

        public tb_HANGHOA add(tb_HANGHOA hh)
        {
            try
            {
                db.tb_HANGHOA.Add(hh);
                db.SaveChanges();
                return hh;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public tb_HANGHOA update(tb_HANGHOA hh)
        {
            tb_HANGHOA _hh = db.tb_HANGHOA.FirstOrDefault(x => x.BARCODE == hh.BARCODE);
            _hh.TENHH = hh.TENHH;
            _hh.TENTAT = hh.TENTAT;
            _hh.DVT = hh.DVT;
            _hh.DONGIA = hh.DONGIA;
            _hh.MANCC = hh.MANCC;
            _hh.MAXX = hh.MAXX;
            _hh.MOTA = hh.MOTA;
            _hh.DISABLED = hh.DISABLED;
            try
            {
                db.SaveChanges();
                return _hh;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public void delete(string barcode)
        {
            tb_HANGHOA _hh = db.tb_HANGHOA.FirstOrDefault(x => x.BARCODE == barcode);
            _hh.DISABLED = true;
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

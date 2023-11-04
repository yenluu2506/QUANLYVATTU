using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class CHUNGTU_CT
    {
        Entities db;

        public CHUNGTU_CT()
        {
            db = Entities.CreateEntities();
        }

        public tb_CHUNGTU_CT getItem(Guid khoact)
        {
            return db.tb_CHUNGTU_CT.FirstOrDefault(x => x.KHOACT == khoact);
        }

        public List<tb_CHUNGTU_CT> getList(Guid khoa)
        {
            return db.tb_CHUNGTU_CT.Where(x => x.KHOA == khoa).ToList();
        }

        public List<obj_CHUNGTU_CT> getListByKhoaFull(Guid khoa)
        {
            var lst = db.tb_CHUNGTU_CT.Where(x => x.KHOA == khoa).ToList();
            List<obj_CHUNGTU_CT> lsCT= new List<obj_CHUNGTU_CT>();
            obj_CHUNGTU_CT obj;
            foreach (var item in lst)
            {
                obj = new obj_CHUNGTU_CT();
                obj.KHOA = item.KHOA;
                obj.KHOACT = item.KHOACT;
                obj.BARCODE = item.BARCODE;
                var n = db.tb_HANGHOA.FirstOrDefault(x => x.BARCODE == item.BARCODE);
                obj.TENHH = n.TENHH;
                obj.DVT = n.DVT;
                obj.SOLUONG = item.SOLUONG;
                obj.DONGIA = item.DONGIA;
                obj.CHIETKHAU = item.CHIETKHAU;
                obj.THANHTIEN = item.THANHTIEN;
                obj.STT = item.STT;
                obj.NGAY = item.NGAY;
                lsCT.Add(obj);
            }
            return lsCT;
        }

        public tb_CHUNGTU_CT add(tb_CHUNGTU_CT chungtuct)
        {
            try
            {
                db.tb_CHUNGTU_CT.Add(chungtuct);
                db.SaveChanges();
                return chungtuct;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        public tb_CHUNGTU_CT update(tb_CHUNGTU_CT chungtuct)
        {
            tb_CHUNGTU_CT _chungtuct = db.tb_CHUNGTU_CT.FirstOrDefault(x => x.KHOACT == chungtuct.KHOACT);
            _chungtuct.SOLUONG = chungtuct.SOLUONG;
            _chungtuct.DONGIA = chungtuct.DONGIA;
            _chungtuct.CHIETKHAU = chungtuct.CHIETKHAU;
            _chungtuct.THANHTIEN = chungtuct.THANHTIEN;
            _chungtuct.NGAY = chungtuct.NGAY;
            try
            {
                db.SaveChanges();
                return _chungtuct;
            }
            catch (Exception ex)
            {
                throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
            }
        }

        //public void delete(Guid khoact)
        //{
        //    tb_CHUNGTU_CT _chungtuct = db.tb_CHUNGTU_CT.FirstOrDefault(x => x.KHOACT == khoact);
        //    _chungtuct.DISABLED = true;
        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Có lỗi xảy ra trong quá trình xử lý dữ liệu." + ex.Message);
        //    }
        //}

        public void deleteAll(Guid khoact)
        {
            tb_CHUNGTU_CT chungtuct = db.tb_CHUNGTU_CT.FirstOrDefault(x => x.KHOACT == khoact);
            if (chungtuct != null)
            {
                try
                {
                    db.tb_CHUNGTU_CT.Remove(chungtuct); // Xóa bản ghi khỏi cơ sở dữ liệu
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

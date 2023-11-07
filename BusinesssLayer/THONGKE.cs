using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class THONGKE
    {
        Entities db;

        public THONGKE()
        {
            db = Entities.CreateEntities();
        }

        public List<obj_BAOCAO_NHOMHH> DoanhThuTheoNhomHangHoa()
        {
            obj_BAOCAO_NHOMHH nhomhh;
            List<obj_BAOCAO_NHOMHH> lstDoanhThuNhom = new List<obj_BAOCAO_NHOMHH>();
            DateTime ngayd = new DateTime(DateTime.Now.Year,DateTime.Now.Month,1);
            var lstnhom = db.FN_DOANHTHU_THEONHOMHANG(ngayd, DateTime.Now.AddDays(1)).ToList();
            foreach (var item in lstnhom)
            {
                nhomhh = new obj_BAOCAO_NHOMHH();
                nhomhh.IDNHOM = item.IDNHOM;
                nhomhh.TENNHOM = item.TENNHOM;
                nhomhh.THANHTIEN = item.THANHTIEN;
                lstDoanhThuNhom.Add(nhomhh);
            }
           
            return lstDoanhThuNhom;
        }
    }
}

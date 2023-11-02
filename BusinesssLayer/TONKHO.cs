using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class TONKHO
    {
        Entities db;
        public TONKHO()
        {
            db = Entities.CreateEntities();
        }

        public bool TinhTon(string madvi,DateTime ngay)
        {
            try
            {
                db.TINH_TONKHO_DONVI(ngay, madvi);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw new Exception("Lỗi: "+ex.Message);
            }
        }
    }
}

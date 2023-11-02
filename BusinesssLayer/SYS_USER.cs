using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class SYS_USER
    {
        Entities db;
        public SYS_USER()
        {
            db = Entities.CreateEntities();
        }
        public List<tb_SYS_USER> getAll()
        {
            return db.tb_SYS_USER.ToList();
        }
        public List<tb_SYS_USER> getUserByDVI(string macty, string madvi)
        {
            return db.tb_SYS_USER.Where(x=>x.MACTY==macty && x.MADVI == madvi).ToList();
        }
        public bool checkUserExist(string macty, string madvi, string username)
        {
            var us = db.tb_SYS_USER.FirstOrDefault(x=>x.MACTY == macty && x.MADVI==madvi && x.USERNAME==username);
            if (us != null)
            {
                return true;
            }
            else 
                return false;
        }
        public tb_SYS_USER add(tb_SYS_USER us)
        {
            try
            {
                db.tb_SYS_USER.Add(us);
                db.SaveChanges();
                return us;
            }
            catch (Exception ex)
            {

                throw new Exception("Lỗi: " + ex.Message);
            }
        }
    }
}

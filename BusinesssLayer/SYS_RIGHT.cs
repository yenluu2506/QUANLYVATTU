﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class SYS_RIGHT
    {
        Entities db;
        public SYS_RIGHT() {
            db = Entities.CreateEntities(); 
        }
        public void update(int idUser, string func_code, int right)
        {
            tb_SYS_RIGHT sRight = db.tb_SYS_RIGHT.FirstOrDefault(x=>x.IDUSER == idUser && x.FUNC_CODE == func_code);
            try
            {
                sRight.USER_RIGHT = right;
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}

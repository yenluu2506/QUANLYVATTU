using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class VIEW_USER_IN_GROUP
    {
        Entities db;
        public VIEW_USER_IN_GROUP()
        {
            db = Entities.CreateEntities();
        }

        public List<V_USER_IN_GROUP>getUserInGroup(string madvi,string macty)
        {
            return db.V_USER_IN_GROUP.Where(x=>x.MADVI==madvi && x.MACTY == macty && x.ISGROUP ==false && x.DISABLED == false).ToList();
        }
    }
}

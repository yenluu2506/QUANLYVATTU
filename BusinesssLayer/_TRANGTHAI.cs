using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesssLayer
{
    public class _TRANGTHAI
    {
        public int _value {  get; set; }
        public string _display {  get; set; }
        public _TRANGTHAI() { }
        
        public _TRANGTHAI(int _val, string _dis)
        {
            this._value = _val;
            this._display = _dis;
        }
        public static List<_TRANGTHAI> getList()
        {
            List<_TRANGTHAI> lst = new List<_TRANGTHAI>();
            _TRANGTHAI[] collect = new _TRANGTHAI[2]
            {
                new _TRANGTHAI(1, "Chưa hoàn tất"),
                new _TRANGTHAI(2, "Đã hoàn tất")
            };
            lst.AddRange(collect);
            return lst;
        }
    }
}

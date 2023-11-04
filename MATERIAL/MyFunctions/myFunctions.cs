﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MATERIAL.MyFunctions
{
    public class myFunctions
    {
        public static string _macty;
        public static string _madvi;
        public static string _srv;
        public static string _us;
        public static string _pw;
        public static string _db;

        public static bool cIsNumber(string pValue)
        {
            foreach (char c in pValue)
            {
                if(!char.IsDigit(c))    
                    return false;
            }
            return true;
        }

        public static bool sIsNumber(string pText)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(pText);
        }
    }
}

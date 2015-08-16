using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RTS.Tools
{
    public class StringUtils
    {
        public static byte[] GetBytes(string str) 
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }
    }
}

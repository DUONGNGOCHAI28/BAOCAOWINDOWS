using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DUONGNGOCHAI_2121110109
{
    public static class MAHOA
    {

        public static string ToMD5(string str)
        {
            MD5 mh = MD5.Create();
            byte[] intputBytes = System.Text.Encoding.ASCII.GetBytes(str);
            byte[] hash = mh.ComputeHash(intputBytes);
            StringBuilder chuoimahoa = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                chuoimahoa.Append(hash[i].ToString("X2"));
            }
            return chuoimahoa.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ACESERVER.Server
{
    class Cryptography
    {
        public static MD5 md5Hasher;
        private static SHA1 sha1Hasher;

        public static string GetMD5(string s)
        {
            md5Hasher = MD5.Create();
            byte[] output = md5Hasher.ComputeHash(Encoding.UTF8.GetBytes(s + GetSalt(s)));
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < output.Length; i++)
            {
                sb.Append(output[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static string GetSalt(string s)
        {
            return GetSHA1(s.Length.ToString());
        }

        public static string GetSHA1(string s)
        {
            sha1Hasher = SHA1.Create();
            byte[] output = sha1Hasher.ComputeHash(Encoding.UTF8.GetBytes(s));
            return Encoding.UTF8.GetString(output);
        }
    }
}

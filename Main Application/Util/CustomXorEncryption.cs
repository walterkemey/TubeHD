using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimeTube.Util
{
    public class CustomXorEncryption
    {
        public static char[] GenerateKey(long encseed)
        {
            string strencSeed = encseed.ToString();

            // cap key length at 30, based on the seed length
            // key must be at least a length of 4
            char[] key = new char[Math.Max(4, Math.Min(30, strencSeed.Length))];
            for (int i = 0; i < key.Length; i++)
            {
                int val = i >= strencSeed.Length ? 0 : strencSeed[i];
                key[i] = (char)(val % 2 == 0 ? val >> 1 : val >> i);  // for the lulz with bitshift... may be able to prevent script kiddies, but not all 
            }
            return key;
        }

        public static string EncryptContent(string toEncrypt, char[] key)
        {
            // bitshift 
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < toEncrypt.Length; i++)
            {
                sb.Append((char)(toEncrypt[i] ^ key[i % key.Length] & 0xFF));
            }
            return sb.ToString();
        }
    }
}

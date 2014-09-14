using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLabs
{
    class VerrnamCipher
    {
        public static string Encode(string russianText,string key)
        {
            string text = russianText.ToUpper();

            char[] result = new char[russianText.Length];

            for (var i = 0; i < russianText.Length; i++ )
            {
                result[i] = (char)(CharToByte(text[i]) ^ (byte)key[i]);
            }


            return String.Empty;
        }

        public static string Decode(string text, string key)
        {
            char[] result = new char[key.Length];

            for (var i = 0; i < key.Length; i++)
            {
                byte b = (byte)(text[i] ^ key[i]);
                result[i] = (char)(ByteToChar(b));
            }


            return String.Empty;
        }

        private static const byte START_CYRILLIC = 128;

        private static byte CharToByte(char c)
        {
            return (byte)(c - START_CYRILLIC);
        }

        private static char ByteToChar(byte b)
        {
            return (char)((char)b + START_CYRILLIC);
        }
    }
}

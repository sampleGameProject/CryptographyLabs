using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLabs
{
    class VerrnamCipher
    {
        private const byte CLEANER = 1 << 0 | 1 << 1 | 1 << 2 | 1 << 3 | 1 << 4;

        private static string alpha = "абвгдежзийклмнопрстуфхцчшщъыьэюя".ToUpper();

        public static string Encode(string russianText,string key)
        {
            string text = russianText.ToUpper();
            char[] result = new char[russianText.Length];

            for (var i = 0; i < russianText.Length; i++ )
            {
                byte val = CharToByte5(text[i]);
                result[i] = (char)(val ^ key[i]);
            }

            return new String(result);
        }

        public static string Decode(string text, string key)
        {
            char[] result = new char[key.Length];

            for (var i = 0; i < key.Length; i++)
            {
                byte dirtValue = (byte)(text[i] ^ key[i]);
                byte val = (byte)(dirtValue & CLEANER);
                result[i] = (ByteToChar(val));
            }

            return new String(result);
        }

        private static byte CharToByte5(char c)
        {
            return (byte)alpha.IndexOf(c);
        }

        private static char ByteToChar(byte b)
        {
            return alpha[b];
        }
    }
}

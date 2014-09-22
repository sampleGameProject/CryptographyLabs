using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    public class VerrnamCipher
    {
        private const byte CLEANER = 1 << 0 | 1 << 1 | 1 << 2 | 1 << 3 | 1 << 4;

        private static string alpha = "абвгдежзийклмнопрстуфхцчшщъыьэюя";

        public static string Encode(string russianText,string key)
        {
            char[] result = new char[russianText.Length];

            for (var i = 0; i < russianText.Length; i++ )
            {
                byte val = ToByte5(CharToByte(russianText[i]));
                byte keyVal = ToByte5((byte)key[i]);
                result[i] = ByteToChar((byte)(val ^ keyVal));
            }

            return new String(result);
        }

        private static byte ToByte5(byte p)
        {
            return (byte)(p & CLEANER);
        }

        public static string Decode(string text, string key)
        {
            char[] result = new char[key.Length];

            for (var i = 0; i < key.Length; i++)
            {
                byte dirtVal = ToByte5(CharToByte(text[i]));
                byte keyVal = ToByte5((byte)key[i]);
                result[i] = ByteToChar((byte)(dirtVal ^ keyVal));
            }

            return new String(result);
        }

        private static byte CharToByte(char c)
        {
            return (byte)alpha.IndexOf(c);
        }

        private static char ByteToChar(byte b)
        {
            return alpha[b];
        }
    }
}

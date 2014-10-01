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

            string s = String.Empty;
            string s1 = String.Empty;
            string s2 = String.Empty;

            for (var i = 0; i < russianText.Length; i++ )
            {
                byte val = ToByte5(CharToByte(russianText[i]));
                s += ByteToString(val);

                byte keyVal = ToByte5((byte)key[i]);
                s1 += ByteToString(keyVal);

                byte resultVal = (byte)(val ^ keyVal);

                result[i] = ByteToChar(resultVal);
                s2 += ByteToString(resultVal);
            }
            Console.WriteLine(s);
            Console.WriteLine(s1);
            Console.WriteLine(s2);

            return new String(result);
        }

        private static byte ToByte5(byte p)
        {
            return (byte)(p & CLEANER);
        }

        private static string ByteToString(byte b)
        {
            return FixByteString(Convert.ToString(b, 2));
        }

        private static string FixByteString(string s)
        {
            string fixedString = s;

            while(fixedString.Length != 5)
            {
                fixedString = "0" + fixedString;
            }

            return fixedString;
        }

        public static string Decode(string text, string key)
        {
            char[] result = new char[key.Length];

            string s = String.Empty;
            string s1 = String.Empty;
            string s2 = String.Empty;

            for (var i = 0; i < key.Length; i++)
            {
                byte dirtVal = ToByte5(CharToByte(text[i]));
                byte keyVal = ToByte5((byte)key[i]);
                byte resultVal = (byte)(dirtVal ^ keyVal);
                result[i] = ByteToChar(resultVal);


                s += ByteToString(dirtVal);
                s1 += ByteToString(keyVal);
                s2 += ByteToString(resultVal);

                s += " ";

                s1 += " ";

                s2 += " ";
            }

            

            Console.WriteLine(s);
            Console.WriteLine(s1);
            Console.WriteLine(s2);

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

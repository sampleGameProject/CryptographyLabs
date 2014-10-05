using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    public class VerrnamCipher
    {
        private const byte CLEANER = 1 << 0 | 1 << 1 | 1 << 2 | 1 << 3 | 1 << 4 | 1 << 5;

        private static string alpha = @"абвгдежзийклмнопрстуфхцчшщъыьэюя 1234567890 ,.!-=+-*/[]{}#$%^&@";

        public static string Encode(string text,string key,StringBuilder sb)
        {
            char[] result = new char[text.Length];

            string s = String.Empty;
            string s1 = String.Empty;
            string s2 = String.Empty;

            for (var i = 0; i < text.Length; i++ )
            {
                // получаем значение буквы оригинального текста в алфавите
                byte val = ToByte6(CharToByte(text[i]));
                s += ByteToString(val);

                // получаем значение ключа 
                var keyChar = key[i % key.Length];
                byte keyVal = ToByte6((byte)keyChar);
                s1 += ByteToString(keyVal);

                // получает символ шифротекста
                byte resultVal = (byte)(val ^ keyVal);

                result[i] = ByteToChar(resultVal);
                s2 += ByteToString(resultVal);

                s += " ";
                s1 += " ";
                s2 += " ";
            }
            sb.AppendLine(s);
            sb.AppendLine(s1);
            sb.AppendLine(s2);

            return new String(result);
        }

        private static byte ToByte6(byte p)
        {
            return (byte)(p & CLEANER);
        }

        private static string ByteToString(byte b)
        {
            return Convert.ToString(b, 2).PadLeft(6,'0');
        }

        public static string Decode(string text, string key, StringBuilder sb)
        {
            char[] result = new char[text.Length];

            string s = String.Empty;
            string s1 = String.Empty;
            string s2 = String.Empty;

            for (var i = 0; i < text.Length; i++)
            {
                // получает символ шифротекста
                byte dirtVal = ToByte6(CharToByte(text[i]));

                // получаем значение ключа 
                var keyChar = key[i % key.Length];
                byte keyVal = ToByte6((byte)keyChar);

                // получаем значение буквы оригинального текста в алфавите
                byte resultVal = (byte)(dirtVal ^ keyVal);

                // получаем букву оригинального текста
                result[i] = ByteToChar(resultVal);


                s += ByteToString(dirtVal);
                s1 += ByteToString(keyVal);
                s2 += ByteToString(resultVal);

                s += " ";
                s1 += " ";
                s2 += " ";
            }

            sb.AppendLine(s);
            sb.AppendLine(s1);
            sb.AppendLine(s2);

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

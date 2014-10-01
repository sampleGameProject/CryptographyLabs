using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    public static class MDM5
    {
        private static string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYabcdefghijklmnopqrstuvwxyz0123456789АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдежзийклмнопрстуфхцчшщъыьэюя .?";

        private const byte BYTE7 = 1 << 0 | 1 << 1 | 1 << 2 | 1 << 3 | 1 << 4 | 1 << 5 | 1 << 6;
        private const int BYTES_PER_BLOCK = 64;
        private const int CHARS_PER_BLOCK = 8;

        public static Tuple<string,string> Encode(string text)
        {
            string fixedText = FixText(text);
            int blocks = fixedText.Length / CHARS_PER_BLOCK;

            char[] encoded = new char[fixedText.Length];
            string cipher = String.Empty;

            string originalStr = String.Empty;
            string gammaStr = String.Empty;
            string cipherStr = String.Empty;

            for (int i = 0; i < blocks; i++ )
            {
                long gamma = FibonacciLagGenerator.NextNormalized();
                
 
                for (int j = 0; j < CHARS_PER_BLOCK; j++)
                {
                    char textChar = fixedText[i * CHARS_PER_BLOCK + j];

                    byte textVal = CharToByte7(textChar);
                    originalStr += ByteToString(textVal);
                    byte keyVal = GammaForIndex(gamma, j);
                    gammaStr += ByteToString(keyVal);
                    int index = textVal ^ keyVal;
                    cipherStr += ByteToString((byte)index);
                    encoded[i * CHARS_PER_BLOCK + j] = alpha[index];
                }

                originalStr += ' ';
                gammaStr += ' ';
                cipherStr += ' ';


                cipher += gamma.ToString();

                if(i != blocks - 1)
                cipher += " ";
            }
            FileWriter.AppendLine("Encode:");
            FileWriter.AppendLine(originalStr);
            FileWriter.AppendLine(gammaStr);
            FileWriter.AppendLine(cipherStr);

            return new Tuple<string, string>(new string(encoded), cipher);
        }

        private static byte GammaForIndex(long gamma, int index)
        {
            long temp = gamma >> index * 8;
            temp &= BYTE7;
            return (byte)temp;
        }

        private static byte CharToByte7(char textChar)
        {
            return (byte)(alpha.IndexOf(textChar) & BYTE7); 
        }

        private static string FixText(string text)
        {
            string fixedText = text;

            while (fixedText.Length % CHARS_PER_BLOCK != 0)
            {
                fixedText += ' ';
            }
            return fixedText;
        }

        public static string Decode(string text, string key)
        {
            FileWriter.AppendLine("Decode:");


            string originalStr = String.Empty;
            string gammaStr = String.Empty;
            string cipherStr = String.Empty;

            char[] decoded = new char[text.Length];
            int blocks = text.Length / CHARS_PER_BLOCK;
            long[] keyArray = ParseKey(key);

            for (int i = 0; i < blocks; i++)
            {
                long gamma = keyArray[i];

                for (int j = 0; j < CHARS_PER_BLOCK; j++)
                {
                    char dirtChar = text[i * CHARS_PER_BLOCK + j];

                    byte dirtVal = CharToByte7(dirtChar);
                    cipherStr += ByteToString(dirtVal);

                    byte keyVal = GammaForIndex(gamma, j);
                    gammaStr += ByteToString(keyVal);

                    int decodedVal = dirtVal ^ keyVal;
                    originalStr += ByteToString((byte)decodedVal);
                    decoded[i * CHARS_PER_BLOCK + j] = alpha[decodedVal];
                }

                originalStr += ' ';
                gammaStr += ' ';
                cipherStr += ' ';
            }


            FileWriter.AppendLine(cipherStr);
            FileWriter.AppendLine(gammaStr);
            FileWriter.AppendLine(originalStr);
           

            FileWriter.FlushToFile("demo.txt");

            return new string(decoded);
        }

        private static long[] ParseKey(string key)
        {
            string[] splitted = key.Split(' ');
            long[] keyArray = new long[splitted.GetLength(0)];

            for(var i = 0; i < splitted.GetLength(0); i++)
            {
                keyArray[i] = Convert.ToInt64(splitted[i]);
            }

            return keyArray;
        }

        private static string ByteToString(byte b)
        {
            return FixByteString(Convert.ToString(b, 2));
        }

        private static string FixByteString(string s)
        {
            string fixedString = s;

            while (fixedString.Length != 7)
            {
                fixedString = "0" + fixedString;
            }

            return fixedString;
        }
    }
}

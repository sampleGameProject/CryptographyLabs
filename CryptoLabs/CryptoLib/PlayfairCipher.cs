using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    public  class PlayfairCipher
    {
       

        public static string sAlphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя .,";
        public static string sKey = "префектура";
            
        public static string Encode(string data, string alphabet,int columns, int rows,string key)
        {
            var alphaArray = Utils.GetWorkAlphaArray(alphabet, columns, rows, key);

            for (int i = 0; i < alphaArray.GetLength(0); i++)
            {
                for (int j = 0; j < alphaArray.GetLength(1); j++)
                {
                    Console.Write(alphaArray[i, j]);
                }
                Console.Write("\n");

            }

            Console.Write("\n\n");

            var bigramms = SplitToBigramms(data);
            var result = CreateTextWithBigramms(alphaArray, bigramms);
            return result;
        }

      

        public static string Decode(string data, string alphabet, int columns, int rows, string key)
        {
            var alphaArray = Utils.GetWorkAlphaArray(alphabet, columns, rows, key);
            var bigramms = SplitToBigramms(data);

            var result = CreateTextWithReBigramms(alphaArray, bigramms);

            return result; 
        }


        public static char[,] SplitToBigramms(string text)
        {
            string correctText = text.ToLower();

            int lenght = text.Length;
            if (lenght % 2 == 1)
            {    
                lenght += 1;
                correctText += " ";
            }
            
            int bigrammsCount = lenght / 2;
            char[,] bigramms = new char[bigrammsCount,2];

            for (int i = 0; i < bigrammsCount; i++)
            {
                bigramms[i, 0] = correctText[i * 2];
                bigramms[i, 1] = correctText[i * 2 + 1];
            }

            return bigramms;
        }


        public static string CreateTextWithBigramms(char[,] alphabet, char[,] bigramms)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < bigramms.GetLength(0); i++)
            {
                char[] reBirgam = GetReBigramm(alphabet, bigramms[i, 0], bigramms[i,1]);
                sb.Append(reBirgam[0]);
                sb.Append(reBirgam[1]);
            }

            return sb.ToString();
        }

        private static char[] GetReBigramm(char[,] alphabet, char p1, char p2)
        {
            var point1 = Utils.GetPointForChar(p1, alphabet);
            var point2 = Utils.GetPointForChar(p2, alphabet);

            int reX1 = 0;
            int reY1 = 0;
            int reX2 = 0;
            int reY2 = 0;

            if(point1.y == point2.y)//same row
            {
                reX1 = point1.x;
                reY1 = point1.y;

                reX2 = point2.x;
                reY2 = point2.y;

                reX1++;
                if (reX1 == alphabet.GetLength(0))
                    reX1 = 0;
                reX2++;
                if (reX2 == alphabet.GetLength(0))
                    reX2 = 0;
            }
            else if(point1.x == point2.x)//same column
            {
                reX1 = point1.x;
                reY1 = point1.y;

                reX2 = point2.x;
                reY2 = point2.y;

                reY1++;
                if (reY1 == alphabet.GetLength(1))
                    reY1 = 0;
                reY2++;
                if (reY2 == alphabet.GetLength(1))
                    reY2 = 0;
            }
            else
            {
                reX1 = point1.x;
                reY1 = point2.y;

                reX2 = point2.x;
                reY2 = point1.y;
            }

            return new char[] { alphabet[reX1, reY1], alphabet[reX2, reY2] };

        }


        private static string CreateTextWithReBigramms(char[,] alphabet, char[,] rebigramms)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < rebigramms.GetLength(0); i++)
            {
                char[] birgam = GetBigramm(alphabet, rebigramms[i, 0], rebigramms[i, 1]);
                sb.Append(birgam[0]);
                sb.Append(birgam[1]);
            }

            return sb.ToString();
        }

        private static char[] GetBigramm(char[,] alphabet, char p1, char p2)
        {
            var point1 = Utils.GetPointForChar(p1, alphabet);
            var point2 = Utils.GetPointForChar(p2, alphabet);

            int reX1 = 0;
            int reY1 = 0;
            int reX2 = 0;
            int reY2 = 0;

            if (point1.y == point2.y)//same row
            {
                reX1 = point1.x;
                reY1 = point1.y;

                reX2 = point2.x;
                reY2 = point2.y;

                reX1--;
                if (reX1 == -1)
                    reX1 = alphabet.GetUpperBound(0);
                reX2--;
                if (reX2 == -1)
                    reX2 = alphabet.GetUpperBound(0);
            }
            else if (point1.x == point2.x)//same column
            {
                reX1 = point1.x;
                reY1 = point1.y;

                reX2 = point2.x;
                reY2 = point2.y;

                reY1--;
                if (reY1 == -1)
                    reY1 = alphabet.GetUpperBound(1);
                reY2--;
                if (reY2 == -1)
                    reY2 = alphabet.GetUpperBound(1);
            }
            else
            {
                reX1 = point1.x;
                reY1 = point2.y;

                reX2 = point2.x;
                reY2 = point1.y;
            }

            return new char[] { alphabet[reX1, reY1], alphabet[reX2, reY2] };
        }
    }
}

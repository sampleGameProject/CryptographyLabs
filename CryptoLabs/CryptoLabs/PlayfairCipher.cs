using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLabs
{
    class PlayfairCipher
    {
        struct Point
        {
            public int x;
            public int y;
        }

        public static string sAlphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя .,";
        public static string sKey = "префектура";
            
        public static void Test()
        {
            
        }
        public static string Encode(string data, string alphabet,int columns, int rows,string key)
        {
            string fixedData = FixInputData(data);
            var alphaArray = GetWorkAlphaArray(alphabet,columns,rows, key);

            for(int i = 0; i < alphaArray.GetLength(0);i++)            
            {
                for (int j = 0; j < alphaArray.GetLength(1); j++)
                {
                    Console.Write(alphaArray[i, j]);
                }
                Console.Write("\n");

            }


            var bigramms = SplitToBigramms(fixedData);

            int r = 0;
            foreach (var c in bigramms)
            {
                Console.Write(c);
                r++;
                if (r % 2 == 0)
                    Console.Write("\n");
            }

            Console.Write("\n\n");

            var result = CreateTextWithBigramms(alphaArray, bigramms);

            return result;
        }

        private static string FixInputData(string data)
        {
            string fixedData = data;
            int doubleLetterPosition;

            while ((doubleLetterPosition = FindDoubleLetterPostion(fixedData)) != -1)
            {
                fixedData = fixedData.Insert(GetSpaceIndex(fixedData,doubleLetterPosition), " ");
            }
            

            return fixedData;
        }

        private static int GetSpaceIndex(string data,int doubleLetterPosition)
        {
            for(int i = doubleLetterPosition-1; i > -1; i--)
            {
                if (data[i] == ' ')
                    return i;
            }
            
            return 0;
        }

        private static int FindDoubleLetterPostion(string data)
        {
            for(var i = 0; i < data.Length-1; i+=2)
            {
                if (data[i] == data[i + 1] && data[i] != ' ')
                    return i;
            }
            return -1;
        }

        public static string Decode(string data, string alphabet, int columns, int rows, string key)
        {
            return String.Empty; 
        }

        public static char[,] GetWorkAlphaArray(string alphabet, int columns, int rows, string key)
        {
            string workAlpha = GetWorkAlphabet(alphabet,key);
            Console.WriteLine("Alpha is : " + workAlpha);

            char [,] arrayAlpha = new char[rows,columns];

            for (var i = 0; i < arrayAlpha.GetLength(0); i++)
                for (var j = 0; j < arrayAlpha.GetLength(1); j++)
                {
                    arrayAlpha[i, j] = workAlpha[i * arrayAlpha.GetLength(1) + j];
                }

            return arrayAlpha;
        }

        public static string GetWorkAlphabet(string alpha,string key)
        {
            string res = String.Empty;

            foreach(var ch in key)
                if (!res.Contains(ch))
                    res += ch;

            foreach (var ch in alpha)
                if (!res.Contains(ch))
                    res += ch;
            
            return res;
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

            if (CorrectBigramms(bigramms))
            {
                return bigramms;
            }
            return null;
        }

        private static bool CorrectBigramms(char[,] bigramms)
        {
            return true;
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
            var point1 = GetPointForChar(p1, alphabet);
            var point2 = GetPointForChar(p2, alphabet);

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

        private static Point GetPointForChar(char p1, char[,] alphabet)
        {
            for(int i = 0; i < alphabet.GetLength(0); i++)
                for(int j = 0; j < alphabet.GetLength(1); j++)
                {
                    if (alphabet[i, j] == p1)
                        return new Point() { x = i, y = j };
                }
            return new Point();
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLabs
{
    class PlayfairCipher
    {
        
        public static string sAlphabet = "абвгдежзеёклмнопрстуфхцчщшьыъэюя ,.";
        public static string sKey = "арбуз";
            
        public static void Test()
        {
            
        }
        public static string Encode(string data, string alphabet,int columns, int rows,string key)
        {
            


            return String.Empty;
        }

        public static string Decode(string data, string alphabet, int columns, int rows, string key)
        {
            


            return String.Empty; 
        }

        public static char[,] GetWorkAlphaArray(string alphabet, int columns, int rows, string key)
        {
            string workAlpha = GetWorkAlpha(alphabet,key);

            char [,] arrayAlpha = new char[columns,rows];

            for(var i = 0; i < columns; i++)
                for(var j = 0; j < rows; j++)
                {
                    arrayAlpha[i, j] = workAlpha[i * rows + j];
                }

            return arrayAlpha;
        }

        public static string GetWorkAlpha(string alpha,string key)
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

    }
}

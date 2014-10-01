using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    public struct Point
    {
        public int x;
        public int y;
        public int z;
    }

    public static class Utils
    {

        public static char[,] GetWorkAlphaArray(string alphabet, int columns, int rows, string key)
        {
            string workAlpha = GetWorkAlphabet(alphabet, key);

            char[,] arrayAlpha = new char[rows, columns];

            for (var i = 0; i < arrayAlpha.GetLength(0); i++)
                for (var j = 0; j < arrayAlpha.GetLength(1); j++)
                {
                    arrayAlpha[i, j] = workAlpha[i * arrayAlpha.GetLength(1) + j];
                }

            return arrayAlpha;
        }

        public static string GetWorkAlphabet(string alpha, string key)
        {
            string res = String.Empty;

            foreach (var ch in key)
                if (!res.Contains(ch))
                    res += ch;
                    

            foreach (var ch in alpha)
                if (!res.Contains(ch))
                    res += ch;
            
            return res;
        }

        public static Point GetPointForChar(char p1, char[,] alphabet)
        {
            for (int i = 0; i < alphabet.GetLength(0); i++)
                for (int j = 0; j < alphabet.GetLength(1); j++)
                {
                    if (alphabet[i, j] == p1)
                        return new Point() { x = i, y = j };
                }
            return new Point();
        }

        public static char[,,] GetWorkAlphaArray2(string alphabet, int columns, int rows, string key)
        {
            string workAlpha = GetWorkAlphabet(alphabet, key);

            int tables = workAlpha.Length / (rows * columns);
            if(tables == 0)
                tables = 1;

            char[, ,] arrayAlpha = new char[tables, rows, columns];

            for (int z = 0; z < arrayAlpha.GetLength(0); z++)
                for (var i = 0; i < arrayAlpha.GetLength(1); i++)
                    for (var j = 0; j < arrayAlpha.GetLength(2); j++)
                    {
                        int shift = z * (rows * columns);
                        int index = shift + i * arrayAlpha.GetLength(2) + j;
                        arrayAlpha[z, i, j] = workAlpha[index];
                    }

            return arrayAlpha;
        }


        public static Point GetPointForChar2(char p1, char[,,] alphabet)
        {
            for (int z = 0; z < alphabet.GetLength(0); z++ )
                for (int i = 0; i < alphabet.GetLength(1); i++)
                    for (int j = 0; j < alphabet.GetLength(2); j++)
                    {
                        if (alphabet[z, i, j] == p1)
                            return new Point() { x = i, y = j, z = z };
                    }
            return new Point();
        }
    }
}

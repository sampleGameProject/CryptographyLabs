using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLabs
{
    class CipherTables
    {
        public static string Encode(string data, string key)
        {
            var table = InputToTable(data, key.Length);
            var sort = KeyToSort(key);

            //DebugTable(table);

            var sortedTable = SortTable(table, sort);

            //DebugTable(sortedTable);
            StringBuilder sb = new StringBuilder();
            
            for (int j = 0; j < table.GetLength(1); j++)
                for (int i = 0; i < table.GetLength(0); i++)
                    sb.Append(sortedTable[i, j]);
            
            return sb.ToString();
        }

        public static string Decode(string data, string key)
        {
            return null;
        }

        private static void DebugTable(char[,] table)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                for (int i = 0; i < table.GetLength(0); i++)
                {
                    Console.Write(table[i, j]);
                }
                Console.Write("\n");
            }

            Console.Write("\n");
        }

        private static char[,] SortTable(char[,] table, int[] sort)
        {
            int columns = table.GetLength(0);
            int rows = table.GetLength(1);

            char[,] result = new char[columns,rows];

            for (int i = 0; i < sort.GetLength(0); i++)
            {
                int columtR = sort[i];

                for(int j = 0; j < rows; j++)
                {
                    result[columtR, j] = table[i, j];
                }
            }

            return result;
        }

        private static char[,] InputToTable(string data, int keyLenght)
        {
            string fixedData = data;
            int mod = fixedData.Length % keyLenght;
            for(int i = mod; i > 0; i--)
            {
                fixedData += " ";
            }

            int columns = keyLenght;
            int rows = fixedData.Length / keyLenght;

            char[,] table = new char[columns, rows];

            for (var i = 0; i < columns; i++)
                for (var j = 0; j < rows; j++)
                {
                    table[i, j] = fixedData[i * rows + j];
                }

            return table;
        }

        private static int[] KeyToSort(string key)
        {
            int[] sort = new int[key.Length];

            var charArray = key.ToCharArray();
            Array.Sort(charArray,StringComparer.Ordinal);

            for(var i = 0; i < key.Length; i++)
            {
                sort[i] = Array.IndexOf(charArray,key[i]);

            }
            return sort;

        }
    }
}

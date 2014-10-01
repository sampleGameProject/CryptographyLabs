using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLabs
{
    public class CipherTables
    {
        public static string Encode(string data, int columns, int rows, out string generatedTable)
        {
            var table = InputToTable(data, columns, rows);
            
            generatedTable = FormatTableToString(table);

            StringBuilder sb = new StringBuilder();
            for (var z = 0; z < table.GetLength(0); z++)
                for (int j = 0; j < table.GetLength(2); j++)
                    for (int i = 0; i < table.GetLength(1); i++)
                        sb.Append(table[z, i, j]);
            
            return sb.ToString();
        }

        private static string FormatTableToString(char[,,] table)
        {
            StringBuilder sb = new StringBuilder();

            for (int j = 0; j < table.GetLength(2); j++)
            {
                for (var z = 0; z < table.GetLength(0); z++)
                {
                    for (int i = 0; i < table.GetLength(1); i++)
                    {
                        sb.Append(table[z, i, j]);
                    }

                    if(z + 1 != table.GetLength(0))
                        sb.Append("\t");
                }
                
                sb.Append("\n");
            }

            return sb.ToString();
        }

        public static string Decode(string data, int columns, int rows)
        {
            var table = EncodedInputToTable(data, columns, rows);
            
            StringBuilder sb = new StringBuilder();

            for (var z = 0; z < table.GetLength(0); z++)
                for (int i = 0; i < table.GetLength(1); i++)
                    for (int j = 0; j < table.GetLength(2); j++)
                        sb.Append(table[z, i, j]);

            return sb.ToString();
        }


        private static char[,,] InputToTable(string data, int columns, int rows)
        {
            string fixedData = data;
            int mod = fixedData.Length % (columns * rows);
            for(int i = mod; i > 0; i--)
            {
                fixedData += " ";
            }

            int tables = fixedData.Length / (columns * rows);

            char[, ,] table = new char[tables,columns, rows];

            for (var z = 0; z < tables; z++)
            {
                for (var i = 0; i < columns; i++)
                    for (var j = 0; j < rows; j++)
                    {
                        int shift = rows * columns * z;
                        table[z, i, j] = fixedData[shift + i * rows + j];
                    }
            }           

            return table;
        }

        private static char[,,] EncodedInputToTable(string data, int columns, int rows)
        {
            int tables = data.Length / (columns * rows);

            char[,,] table = new char[tables,columns, rows];

            for (var i = 0; i < rows; i++)
            {
                for (var z = 0; z < tables; z++)
                    for (var j = 0; j < columns; j++)
                    {
                        int shift = rows * columns * z;
                        table[z, j, i] = data[shift + i * columns + j];
                    }
            }

            return table;
        }

    }
}

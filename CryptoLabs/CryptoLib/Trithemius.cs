using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    public static class Trithemius
    {
        public static string Encode(string data, string alphabet, int columns, int rows, string key)
        {
            var alphaArray = Utils.GetWorkAlphaArray2(alphabet, columns, rows, key);
            
            int lenght = data.Length;
            
            char[] result = new char[lenght];
            for (var i = 0; i < lenght; i++ )
            {
                var point = Utils.GetPointForChar2(data[i], alphaArray);

                point.y++;
                if (point.y == alphaArray.GetLength(2))
                {
                    point.y = 0;
                }

                result[i] = alphaArray[point.z,point.x, point.y];
            }

            return new string(result);
        }

        public static string Decode(string data, string alphabet, int columns, int rows, string key)
        {
            var alphaArray = Utils.GetWorkAlphaArray2(alphabet, columns, rows, key);

            int lenght = data.Length;
            
            char[] result = new char[lenght];
            for (var i = 0; i < lenght; i++)
            {
                var point = Utils.GetPointForChar2(data[i], alphaArray);

                point.y--;
                if (point.y == -1)
                {
                    point.y = alphaArray.GetUpperBound(2);
                }

                result[i] = alphaArray[point.z, point.x, point.y];
            }

            return new string(result);
        }



    }


}

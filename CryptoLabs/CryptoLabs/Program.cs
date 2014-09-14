using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLabs
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //testPlayfair();
            testCipherTables();
        }

        private static void testCipherTables()
        {
            Console.WriteLine(CipherTables.Encode("СИСТЕМНЫЙ ПАРОЛЬ ИЗМЕНЕН", "СКАНЕР"));
        }

        private static void testPlayfair()
        {
            string result = PlayfairCipher.Encode("ВО ВРЕМЯ ПЕРВОЙ МИРОВОЙ ВОЙНЫ ИСПОЛЬЗОВАЛИСЬ БИГРАММНЫЕ ШИФРЫ",
                 PlayfairCipher.sAlphabet, 7, 5, PlayfairCipher.sKey);

            int i = 0;
            foreach (var c in result)
            {

                Console.Write(c);
                i++;
                if (i % 2 == 0)
                    Console.Write("\n");
            }
        }

        private static void testVerrnamCipher()
        {
            var origin = "EVTIQWXQVVOPMCXREPYZ";
            var key = "ALLSWELLTHATENDSWELL";

            Console.WriteLine()
        }

    }
}

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
            //testCipherTables();
            testVerrnamCipher();
        }

        private static void testCipherTables()
        {
            string key = "СКАНЕР".ToLower();
            string test = "СИСТЕМНЫЙ ПАРОЛЬ ИЗМЕНЕН".ToLower();

            Console.WriteLine("Original: " + test);

            string encoded = CipherTables.Encode(test, key);

            Console.WriteLine("Encoded:  " + encoded);

            string decoded = CipherTables.Decode(encoded, key);
           
            
            Console.WriteLine("Decoded:  " + decoded);

            Console.WriteLine();
        }

        private static void testPlayfair()
        {
            string test = "ВО ВРЕМЯ ПЕРВОЙ МИРОВОЙ ВОЙНЫ  ИСПОЛЬЗОВАЛИСЬ БИГРАММНЫЕ ШИФРЫ";
            test = test.ToLower();
            string encoded = PlayfairCipher.Encode(test,PlayfairCipher.sAlphabet, 7, 5, PlayfairCipher.sKey);
            string decoded = PlayfairCipher.Decode(encoded, PlayfairCipher.sAlphabet, 7, 5, PlayfairCipher.sKey);
            Console.WriteLine("Original: " + test);
            Console.WriteLine("Encoded:  " + encoded);
            Console.WriteLine("Decoded:  " + decoded);

            Console.WriteLine();
        }

        private static void testVerrnamCipher()
        {
            var test = "ВОРУЙУБИВАЙ";
            var key  = "asdА1235апр";

            Console.WriteLine("Original: " + test);

            string encoded = VerrnamCipher.Encode(test, key);

            Console.WriteLine("Encoded:  " + encoded);

            string decoded = VerrnamCipher.Decode(encoded, key);
            
            Console.WriteLine("Decoded:  " + decoded);
            Console.WriteLine();
        }

    }
}

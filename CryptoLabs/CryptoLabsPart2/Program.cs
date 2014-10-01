using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoLib;

namespace CryptoLabsPart2
{
    class Program
    {
        static void Main(string[] args)
        {
           string test = "колдуй исчезай death with it 4 8 15 16 23 42";

           Console.WriteLine("Original:  " + test);
           var result = MDM5.Encode(test);

           Console.WriteLine("");
           Console.WriteLine("Encoded: " + result.Item1);
           Console.WriteLine("Key: " + result.Item2);
            
           Console.WriteLine("");
           string decoded = MDM5.Decode(result.Item1, result.Item2);
           Console.WriteLine("Decoded: " + decoded);

           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    public class LinearFeedbackShiftRegister
    {
        // все, кроме 0
        static ulong shiftRegister = 1;

        // x^21 + x^2 + 1 - примитивный многочлен со степенью 21

        public static StringBuilder SB { get; set; }

        private static ulong Next()
        {
            // см. Б. Шнайер, гл 16.2   
            shiftRegister = ((((shiftRegister >> 20)
                ^ (shiftRegister >> 1)
                ^ shiftRegister)
                & 0x00000001)
                << 20) |
                (shiftRegister >> 1);

            return shiftRegister & 0x00000001;
        }

        public static ulong NextLong()
        {
            Next();

            ulong value = shiftRegister;
            
            var bytes = BitConverter.GetBytes(value);
            // выводим биты полученного значения
            if (SB != null)
                SB.AppendFormat("LFSB: next value: {0}\t\t {1} {2} {3} {4} {5} {6} {7} {8}\n", value, 
                    Convert.ToString(bytes[7], 2).PadLeft(8, '0'),
                    Convert.ToString(bytes[6], 2).PadLeft(8, '0'),
                    Convert.ToString(bytes[5], 2).PadLeft(8, '0'),
                    Convert.ToString(bytes[4], 2).PadLeft(8, '0'),
                    Convert.ToString(bytes[3], 2).PadLeft(8, '0'),
                    Convert.ToString(bytes[2], 2).PadLeft(8, '0'),
                    Convert.ToString(bytes[1], 2).PadLeft(8, '0'),
                    Convert.ToString(bytes[0], 2).PadLeft(8, '0'));
            
            return value;
        }

    }
}

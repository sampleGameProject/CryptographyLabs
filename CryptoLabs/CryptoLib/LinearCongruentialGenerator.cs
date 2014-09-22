using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    public class LinearCongruentialGenerator
    {
        private const ulong A = 6364136223846793005;
        private const ulong M = (ulong)((ulong)1 << 32);
        private const ulong B = 1013904223;

        private static ulong yPrev = 0;

        static LinearCongruentialGenerator()
        {
            yPrev = (ulong)Math.Sqrt(DateTime.Now.Ticks);
        }

        public static ulong Next()
        {
            yPrev = (A * yPrev + B) % M;
            return yPrev;
        }

    }
}

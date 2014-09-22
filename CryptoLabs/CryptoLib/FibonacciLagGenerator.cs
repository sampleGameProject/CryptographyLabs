using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    public static class QueueExtentions
    {
        public static void EnqueueAndDequeue<T>(this Queue<T> queue, T obj)
        {
            queue.Enqueue(obj);
            queue.Dequeue();
        }
    }

    public static class FibonacciLagGenerator
    {
        private const int A = 97;
        private const int B = 33;

        private const float DIVIDER = 1000000000000;

        private static Queue<float> values = new Queue<float>();

        static FibonacciLagGenerator()
        {
            int max = Math.Max(A, B);

            while(max-- > 0)
            {
                float randFloat = (float)LinearCongruentialGenerator.Next();
                values.Enqueue(randFloat / DIVIDER);
            }
        }


        public static float Next()
        {
            float valA = values.ElementAt(A-1);
            float valB = values.ElementAt(B - 1);

            float y = valA >= valB ? valA - valB : valA - valB + 1.0f;
            values.EnqueueAndDequeue(y);

            return y;
        }

        public static long NextNormalized()
        {
            return (long)(Next() * DIVIDER);
        }
    }
}

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
        // все по методичке.
        private const int A = 55;
        private const int B = 24;

        private const float DIVIDER = 100000000000;

        private static Queue<float> values = new Queue<float>();

        public static StringBuilder SB { get; set; }

        static FibonacciLagGenerator()
        {
            int max = Math.Max(A, B);

            while(max-- > 0)
            {
                float randFloat = (float)LinearFeedbackShiftRegister.NextLong();
                values.Enqueue(randFloat / DIVIDER);
            }
        }


        public static float Next()
        {
            float valA = values.ElementAt(A-1);
            float valB = values.ElementAt(B - 1);

            float y = valA >= valB ? valA - valB : valA - valB + 1.0f;
            values.EnqueueAndDequeue(y);

            if (SB != null)
                SB.AppendLine("FLG: next value " + y.ToString());
            return y;
        }

        public static long NextNormalized()
        {
            var normilized = (long)(Next() * DIVIDER * 1000000);
            if (SB != null)
                SB.AppendLine("FLG: next normilized value " + normilized.ToString());
            return normilized;
        }
    }
}

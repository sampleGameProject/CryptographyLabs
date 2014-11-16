using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast256CFB.Cipher
{
    public static class BlockConverter
    {
        const byte CHAR_PER_BLOCK = 4;

        public static uint[] StringToUintBlock(string text)
        {
            Console.WriteLine("StringToUintBlock...");

            while (text.Length % CHAR_PER_BLOCK != 0)
                text += (char)0;

            Console.WriteLine("Text : "  + text);

            var bytes = Encoding.UTF8.GetBytes(text);

            Console.WriteLine("Bytes : ");

            foreach(var b in bytes)
            {
                Console.Write(b + " ");
            }

            Console.WriteLine(" ");

           

            int blockSize = text.Length / CHAR_PER_BLOCK;
            var block = new uint[blockSize];

            for (int i = 0; i < blockSize; i++ )
            {
                var v0 = (uint)(bytes[CHAR_PER_BLOCK * i]);
                var v1 = (uint)(bytes[CHAR_PER_BLOCK * i + 1]);
                var v2 = (uint)(bytes[CHAR_PER_BLOCK * i + 2]);
                var v3 = (uint)(bytes[CHAR_PER_BLOCK * i + 3]);


                block[i] |= v0 << 24;
                block[i] |= v1 << 16;
                block[i] |= v2 << 8;
                block[i] |= v3;

                Console.WriteLine("{0} | {1} | {2} | {3} => {4}", v0, v1, v2, v3, block[i]);
            }

            Console.WriteLine(" ");
                
            return block;
        }

        public static string UintBlockToString(uint[] block)
        {
            Console.WriteLine("UintBlockToString...");

            int blockSize = block.GetLength(0);

            var bytes = new byte[block.GetLength(0) * 4];

            

            for (int i = 0; i < blockSize; i++)
            {
                var v0 = (byte)(block[i] >> 24);
                var v1 = (byte)(block[i] >> 16);
                var v2 = (byte)(block[i] >> 8);
                var v3 = (byte)(block[i]);


                Console.WriteLine("{0} => {1} | {2} | {3} | {4}", block[i], v0, v1, v2, v3);

                bytes[CHAR_PER_BLOCK * i] = v0;
                bytes[CHAR_PER_BLOCK * i + 1] = v1;
                bytes[CHAR_PER_BLOCK * i + 2] = v2;
                bytes[CHAR_PER_BLOCK * i + 3] = v3;
            }


            Console.WriteLine("Bytes : ");

            foreach (var b in bytes)
            {
                Console.Write(b + " ");
            }

            Console.WriteLine(" ");

            var text = Encoding.UTF8.GetString(bytes);
            Console.WriteLine("Text : " + text);

            return text;
        }
    }
}

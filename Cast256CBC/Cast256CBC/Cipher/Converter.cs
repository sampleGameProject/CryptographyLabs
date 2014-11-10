using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast256CBC.Cipher
{
    public static class BlockConverter
    {
        const byte CHAR_PER_BLOCK = 4;

        public static uint[] StringToUintBlock(string text)
        {
            while (text.Length % CHAR_PER_BLOCK != 0)
                text += " ";

            var bytes = Encoding.UTF8.GetBytes(text);


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
            }
                
            return block;
        }

        public static string UintBlockToString(uint[] block)
        {
            int blockSize = block.GetLength(0);

            var bytes = new byte[block.GetLength(0) * 4];

            for (int i = 0; i < blockSize; i++)
            {
                bytes[CHAR_PER_BLOCK * i] = (byte)(block[i] >> 24);
                bytes[CHAR_PER_BLOCK * i + 1] = (byte)(block[i] >> 16);
                bytes[CHAR_PER_BLOCK * i + 2] = (byte)(block[i] >> 8);
                bytes[CHAR_PER_BLOCK * i + 3] = (byte)(block[i]);
            }                
            
            return Encoding.UTF8.GetString(bytes);
        }
    }
}

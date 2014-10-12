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

            int blockSize = text.Length / CHAR_PER_BLOCK;
            var block = new uint[blockSize];

            for (int i = 0; i < blockSize; i++ )
            {
                var v0 = (uint)((byte)(text[CHAR_PER_BLOCK * i]));
                var v1 = (uint)((byte)(text[CHAR_PER_BLOCK * i + 1]));
                var v2 = (uint)((byte)(text[CHAR_PER_BLOCK * i + 2]));
                var v3 = (uint)((byte)(text[CHAR_PER_BLOCK * i + 3]));


                block[i] |= v0 << 24;
                block[i] |= v1 << 16;
                block[i] |= v2 << 8;
                block[i] |= v3;
            }
                
            return block;
        }

        public static string UintBlockToString(uint[] block)
        {
            StringBuilder sb = new StringBuilder();
            int blockSize = block.GetLength(0);

            for (int i = 0; i < blockSize; i++)
            {
                char c0 = (char)(byte)(block[i] >> 24);
                char c1 = (char)(byte)(block[i] >> 16);
                char c2 = (char)(byte)(block[i] >> 8);
                char c3 = (char)(byte)(block[i]);

                sb.Append(c0);
                sb.Append(c1);
                sb.Append(c2);
                sb.Append(c3);
            }
                
            
            return sb.ToString();
        }
    }
}

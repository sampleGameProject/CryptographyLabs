using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast256CBC.Cipher
{
    public static class BlockConverter
    {
        public static uint[] StringToUintBlock(string text)
        {
            int blockSize = text.Length;
            var block = new uint[blockSize];

            for (int i = 0; i < blockSize; i++ )
                block[i] = text[i];
            
            return block;
        }

        public static string UintBlockToString(uint[] block)
        {
            StringBuilder sb = new StringBuilder();
            int blockSize = block.GetLength(0);

            for (int i = 0; i < blockSize; i++)
                sb.Append((char)block[i]);
            
            return sb.ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast256CFB.Cipher
{
    public static class CipherFeedback
    {
        public static void Chain(ICipher cipher, uint[] input, ref uint[] output, ref uint[] iv)
        {
            iv = new uint[4];

            iv[0] = (uint)FibonacciLagGenerator.NextNormalized();
            iv[1] = (uint)FibonacciLagGenerator.NextNormalized();
            iv[2] = (uint)FibonacciLagGenerator.NextNormalized();
            iv[3] = (uint)FibonacciLagGenerator.NextNormalized();

            int blockSize = input.GetLength(0);

            while(blockSize % 4 != 0)
                blockSize++;
            
            Array.Resize<uint>(ref input, blockSize);

            output = new uint[blockSize];

            uint[] currBlock = new uint[4];
            uint[] prevBlock = new uint[4];
            uint[] temp = new uint[4];


            CopyBlock(prevBlock, iv);

            for (int i = 0; i < blockSize / 4; i++)
            {
                cipher.Encrypt(prevBlock, temp);

                FillBlockFromInput(currBlock, input, i);
                ChainBlock(currBlock, temp);

                CopyBlock(prevBlock, currBlock);
                FillOutputFromBlock(prevBlock, output, i);
            }
        }

        private static void ChainBlock(uint[] block1, uint[] block0)
        {
            block1[0] ^= block0[0];
            block1[1] ^= block0[1];
            block1[2] ^= block0[2];
            block1[3] ^= block0[3];
        }

        private static void FillBlockFromInput(uint[] block, uint[] input, int index)
        {
            block[0] = input[index * 4];
            block[1] = input[index * 4 + 1];
            block[2] = input[index * 4 + 2];
            block[3] = input[index * 4 + 3];
        }

        private static void FillOutputFromBlock(uint[] block, uint[] output, int index)
        {
            output[index * 4]     = block[0];
            output[index * 4 + 1] = block[1];
            output[index * 4 + 2] = block[2];
            output[index * 4 + 3] = block[3];
        }


        private static void CopyBlock(uint[] dest, uint[] scr)
        {
            dest[0] = scr[0];
            dest[1] = scr[1];
            dest[2] = scr[2];
            dest[3] = scr[3];
        }

        public static void Unchain(ICipher cipher, uint[] input, uint[] iv, ref uint[] output)
        {
            int blockSize = input.GetLength(0);
            
            output = new uint[blockSize];

            uint[] currBlock = new uint[4];
            uint[] prevBlock = new uint[4];
            uint[] outBlock = new uint[4];
            
            int blocks = blockSize / 4;

            for (int i = blocks - 1; i >= 0; i--)
            {
                FillBlockFromInput(currBlock, input, i);

                if (i != 0)
                    FillBlockFromInput(prevBlock, input, i - 1);
                else
                    CopyBlock(prevBlock, iv);


                cipher.Encrypt(prevBlock, outBlock);
                ChainBlock(outBlock, currBlock);
                FillOutputFromBlock(outBlock, output, i);
            }
        }
    }
}

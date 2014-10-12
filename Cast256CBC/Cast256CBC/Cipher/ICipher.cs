using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cast256CBC.Cipher
{
    public interface ICipher
    {
        void Encrypt(uint[] inBlock, uint[] outBlock);

        void Decrypt(uint[] inBlock, uint[] outBlock);        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLabs
{
    interface ICryptoMethod
    {
        string Decode(string data);
        string Encode(string data);        
    }
}

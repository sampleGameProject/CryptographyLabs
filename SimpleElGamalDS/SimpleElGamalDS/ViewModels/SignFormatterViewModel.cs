using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SimpleElGamalDS.ViewModels
{
    class FormatterViewModel
    {
        protected BigInteger x, y, g, p;
        protected Tuple<string, string> fileContent;
        
        public void SelectFile()
        {
            fileContent = Utils.ReadFileWithDialog();
        }

        public void SelectOpenKey()
        {
            var jsonStr = Utils.ReadOpenKeyFromFileWithDialog();

            if (jsonStr == null)
                return;

            var openKeyJSON = SimpleJson.DeserializeObject(jsonStr) as JsonObject;

            p = new BigInteger(openKeyJSON["P"] as string, 10);
            g = new BigInteger(openKeyJSON["G"] as string, 10);
            y = new BigInteger(openKeyJSON["Y"] as string, 10);
        }
    }

    class SignFormatterViewModel : FormatterViewModel
    {
        
        public void SelectPrivateKey()
        {
            var jsonStr = Utils.ReadPrivateKeyFromFileWithDialog();

            if (jsonStr == null)
                return;

            var privateKeyJSON = SimpleJson.DeserializeObject(jsonStr) as JsonObject;

            x = new BigInteger(privateKeyJSON["X"] as string, 10);
        }


        public void CreateSigning()
        {
            ElGamalManaged signAlg = new ElGamalManaged();
            signAlg.KeyStruct = new ElGamalKeyStruct{ X = x, P = p, G = g, Y = y };

            byte[] bytes = Encoding.Default.GetBytes(fileContent.Item1);

            HashAlgorithm hashAlg = HashAlgorithm.Create("SHA1");
            byte[] hashCode = hashAlg.ComputeHash(bytes);

            var sigFormater = new ElGamalPKCS1SignatureFormatter();
            sigFormater.SetHashAlgorithm("SHA1");
            sigFormater.SetKey(signAlg);
            var signature = sigFormater.CreateSignature(hashCode);

            Utils.SaveSignatureWithDialog(signature,fileContent.Item2);
        }
    }
}

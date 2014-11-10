using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleElGamalDS.ViewModels
{
    class SignDeformatterViewModel : FormatterViewModel
    {

        public void CheckSignature()
        {
            ElGamalManaged verifyAlg = new ElGamalManaged();
            verifyAlg.KeyStruct = new ElGamalKeyStruct { X = new BigInteger(0), P = p, G = g, Y = y };

            byte[] bytes = Encoding.Default.GetBytes(fileContent.Item1);

            HashAlgorithm hashAlg = HashAlgorithm.Create("SHA1");
            byte[] hashCode = hashAlg.ComputeHash(bytes);

            var sigDeformatter = new ElGamalPKCS1SignatureDeformatter();
            sigDeformatter.SetHashAlgorithm("SHA1");
            sigDeformatter.SetKey(verifyAlg);

            var signature = Utils.ReadSignatureWithDialog();

            if(sigDeformatter.VerifySignature(hashCode, signature))
                MessageBox.Show("Подпись подтверждена");
            else
                MessageBox.Show("Подпись не подтверждена");
        }
    }
}

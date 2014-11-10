using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleElGamalDS.ViewModels
{
   
    class OpenKeyViewModel
    {
        BigInteger x;

        public void SelectPrivateKey()
        {
            var jsonStr = Utils.ReadPrivateKeyFromFileWithDialog();

            if (jsonStr == null)
                return;

            var privateKeyJSON = SimpleJson.DeserializeObject(jsonStr) as JsonObject;
        
            x = new BigInteger(privateKeyJSON["X"] as string, 10);
        }

        public void GenerateOpenKeyAndSave()
        {
            ElGamalManaged elGamal = new ElGamalManaged();
            elGamal.KeyStruct = new ElGamalKeyStruct() 
            { 
                X = x,
                P = new BigInteger(0),
                G = new BigInteger(0),
                Y = new BigInteger(0)
            };

            var keyStruct = elGamal.KeyStruct;

            var json = new JsonObject();
            json.Add("P", elGamal.KeyStruct.P.ToString());
            json.Add("G", elGamal.KeyStruct.G.ToString());
            json.Add("Y", elGamal.KeyStruct.Y.ToString());
            var jsonStr = json.ToString();
            Utils.SaveKeyToFileWithDialog(jsonStr,true);
        }
    }
}

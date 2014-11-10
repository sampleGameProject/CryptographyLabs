using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleElGamalDS.ViewModels
{
    class PrivateKeyViewModel
    {
        ElGamalManaged privateKey;

        public void CreatePrivateKey()
        {
            privateKey = new ElGamalManaged();
        }

        public void SavePrivateKey()
        {
            var json = new JsonObject();
            json.Add("X",privateKey.KeyStruct.X.ToString());
            var jsonStr = json.ToString();
            Utils.SaveKeyToFileWithDialog(jsonStr,false);
        }
    }
}

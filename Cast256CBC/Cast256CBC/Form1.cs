using Cast256CBC.Cipher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cast256CBC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Test();          
        }

        void Test()
        {
            var cout = new Cout(mainTextBox);

            var text = "asdtreasftgrgdfgklgernmtsnjhstnh";
            cout.AppendLine(text);
            var inputBlock = BlockConverter.StringToUintBlock(text);

            var key = new uint[2] { 12312312, 435345332 };
            var cast = new Cast();
            cast.SetKey(key, 64);

            uint[] encryptedBlock = null;
            uint[] iv = null;

            CipherBlockChaining.Chain(cast, inputBlock, ref encryptedBlock, ref iv);

            uint[] decryptedBlock = null;

            CipherBlockChaining.Unchain(cast, encryptedBlock, iv, ref decryptedBlock);

            var t2 = BlockConverter.UintBlockToString(decryptedBlock);
            cout.AppendLine(t2);
        }
    }
}

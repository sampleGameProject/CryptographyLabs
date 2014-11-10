using SimpleElGamalDS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleElGamalDS
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

            byte[] plainText = Encoding.Default.GetBytes("ЭЦП Эль-Гамаля");

            
            ElGamalManaged signAlg = new ElGamalManaged();           
            signAlg.KeySize = 384;

            ElGamalManaged verifyAlg = new ElGamalManaged();
            verifyAlg.KeyStruct = signAlg.KeyStruct;
            verifyAlg.KeySize = 384;

            HashAlgorithm hashAlg = HashAlgorithm.Create("SHA1");
            byte[] hashCode = hashAlg.ComputeHash(plainText);


            var sigFormater = new ElGamalPKCS1SignatureFormatter();
            sigFormater.SetHashAlgorithm("SHA1");
            sigFormater.SetKey(signAlg);
            var signature = sigFormater.CreateSignature(hashCode);

            var sigDeformatter = new ElGamalPKCS1SignatureDeformatter();
            sigDeformatter.SetHashAlgorithm("SHA1");
            sigDeformatter.SetKey(verifyAlg);

            Console.WriteLine("PKCS#1 SIGNATURE: {0}", sigDeformatter.VerifySignature(hashCode, signature));
        }

        private static bool CompareArrays(byte[] arr1, byte[] arr2)
        {
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    return false;
                }
            }
            return true;
        }

        private void buttonGeneratePrivateKey_Click(object sender, EventArgs e)
        {
            PrivateKeyViewModel model = new PrivateKeyViewModel();
            model.CreatePrivateKey();
            model.SavePrivateKey();
        }

        OpenKeyViewModel openKeyViewModel = new OpenKeyViewModel();

        private void buttonSelectPrivateKeyToGenerateOpenKey_Click(object sender, EventArgs e)
        {
            openKeyViewModel.SelectPrivateKey();
        }

        private void buttonGenerateOpenKey_Click(object sender, EventArgs e)
        {
            openKeyViewModel.GenerateOpenKeyAndSave();
        }


        SignFormatterViewModel signFormatterViewModel = new SignFormatterViewModel();

        private void button2_Click(object sender, EventArgs e)
        {
            signFormatterViewModel.SelectFile();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            signFormatterViewModel.SelectPrivateKey();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            signFormatterViewModel.SelectOpenKey();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            signFormatterViewModel.CreateSigning();
        }

        SignDeformatterViewModel signDeformatterViewModel = new SignDeformatterViewModel();

        private void button10_Click(object sender, EventArgs e)
        {
            signDeformatterViewModel.SelectFile();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            signDeformatterViewModel.SelectOpenKey();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            signDeformatterViewModel.CheckSignature();
        }
    }
}

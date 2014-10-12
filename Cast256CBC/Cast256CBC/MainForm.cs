using Cast256CBC.Cipher;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cast256CBC
{
    
    public partial class MainForm : Form
    {
        Data encodingData = new Data();
        Data decodingData = new Data();

        public MainForm()
        {
            InitializeComponent();
            Test();
        }

        void Test()
        {
            var a = BlockConverter.StringToUintBlock("asddasddasddasdа");
            var b = BlockConverter.UintBlockToString(a);

            var cout = new Cout(richTextBox1);

            var text = "шифруй, воруй и убивай, колдуй и исчезай";

            while (text.Length % 16 != 0)
                text += " ";

            cout.AppendLine(text);
            var inputBlock = BlockConverter.StringToUintBlock(text);

            var key = new uint[2] { 12312312, 435345332 };
            var cast = new Cast();
            cast.SetKey(key, 64);

            uint[] encryptedBlock = null;
            uint[] iv = null;

            CipherBlockChaining.Chain(cast, inputBlock, ref encryptedBlock, ref iv);

            var t1 = BlockConverter.UintBlockToString(encryptedBlock);
            cout.AppendLine(t1);

            uint[] decryptedBlock = null;

            CipherBlockChaining.Unchain(cast, encryptedBlock, iv, ref decryptedBlock);

            var t2 = BlockConverter.UintBlockToString(decryptedBlock);
            
            cout.AppendLine(t2);
        }

        private void buttonEncSelectText_Click(object sender, EventArgs e)
        {
            string selectedFile = SelectFile();

            if (selectedFile != null)
            {
                encodingData.TextPath = selectedFile;
                label1.Text = encodingData.TextPath;
            }
        }

        private void buttonEncSelectKey_Click(object sender, EventArgs e)
        {
            string selectedFile = SelectFile();

            if (selectedFile != null)
            {
                encodingData.KeyPath = selectedFile;
                label2.Text = encodingData.KeyPath;
            }
        }

        private void buttonEncode_Click(object sender, EventArgs e)
        {
            Cout cout = new Cout(richTextBox1);

            try
            {
                var w1251 = Encoding.GetEncoding(1251);

                var text = File.ReadAllText(encodingData.TextPath, w1251);

                while (text.Length % 16 != 0)
                    text += " ";

                cout.AppendLine("Original text: ");
                cout.AppendLine(text);
                var inputBlock = BlockConverter.StringToUintBlock(text);

                var keyStr = File.ReadAllText(encodingData.KeyPath, w1251);

                cout.AppendLine("Key: ");
                cout.AppendLine(keyStr);
                

                var key = StringToUintArray(keyStr);
                var cast = new Cast();
                cast.SetKey(key, key.GetLength(0) * 32);

                uint[] encryptedBlock = null;
                uint[] iv = null;

                CipherBlockChaining.Chain(cast, inputBlock, ref encryptedBlock, ref iv);

                var ecnryptedText = BlockConverter.UintBlockToString(encryptedBlock);
                
                cout.AppendLine("Encrypted text: ");
                cout.AppendLine(ecnryptedText);

                var ivStr = String.Join<uint>(" ", iv);

                cout.AppendLine("Initialization vector:");
                cout.AppendLine(ivStr);

                var encPath     = String.Format("cast_encrypted_{0}.txt",   Path.GetFileNameWithoutExtension(encodingData.TextPath));
                var encIVPath   = String.Format("cast_encrypted_{0}_iv.txt",Path.GetFileNameWithoutExtension(encodingData.TextPath));

                File.WriteAllText(encPath, ecnryptedText, w1251);
                File.WriteAllText(encIVPath, ivStr, w1251);

                cout.AppendLine(String.Format("Initialization vector saved at {0}", encIVPath));
                cout.AppendLine(String.Format("Encrypted text saved at {0}", encPath));
                
            }
            catch (Exception ex)
            {
                cout.AppendLine(ex.Message);
                cout.AppendLine(ex.ToString());
            }
        }

        private static uint[] StringToUintArray(string key)
        {
            string[] splitted = key.Split(' ');
            uint[] keyArray = new uint[splitted.GetLength(0)];

            for (var i = 0; i < splitted.GetLength(0); i++)
            {
                keyArray[i] = Convert.ToUInt32(splitted[i]);
            }

            return keyArray;
        }

        private void buttonDecSelectText_Click(object sender, EventArgs e)
        {
            string selectedFile = SelectFile();

            if (selectedFile != null)
            {
                decodingData.TextPath = selectedFile;
                label4.Text = decodingData.TextPath;
            }
        }

        private void buttonDecSelectKey_Click(object sender, EventArgs e)
        {
            string selectedFile = SelectFile();

            if (selectedFile != null)
            {
                decodingData.KeyPath = selectedFile;
                label3.Text = decodingData.KeyPath;
            }
        }

        private void buttonDecSelectIV_Click(object sender, EventArgs e)
        {
            string selectedFile = SelectFile();

            if (selectedFile != null)
            {
                decodingData.IVPath = selectedFile;
                label5.Text = decodingData.IVPath;
            }
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            Cout cout = new Cout(richTextBox2);

            try
            {
                var w1251 = Encoding.GetEncoding(1251);

                var text = File.ReadAllText(decodingData.TextPath, w1251);

                cout.AppendLine("Encrypted text: ");
                cout.AppendLine(text);
                var inputBlock = BlockConverter.StringToUintBlock(text);

                var keyStr = File.ReadAllText(decodingData.KeyPath, w1251);

                cout.AppendLine("Key: ");
                cout.AppendLine(keyStr);

                var ivStr = File.ReadAllText(decodingData.IVPath, w1251);

                cout.AppendLine("Initialization vector:");
                cout.AppendLine(ivStr);

                uint[] iv = StringToUintArray(ivStr);

                var key = StringToUintArray(keyStr);
                var cast = new Cast();
                cast.SetKey(key, key.GetLength(0) * 32);


                uint[] decryptedBlock = null;

                CipherBlockChaining.Unchain(cast, inputBlock, iv, ref decryptedBlock);

                var decryptedText = BlockConverter.UintBlockToString(decryptedBlock);

                cout.AppendLine("Decrypted text: ");
                cout.AppendLine(decryptedText);

                var decPath = String.Format("cast_decrypted_{0}.txt", Path.GetFileNameWithoutExtension(decodingData.TextPath));
                
                File.WriteAllText(decPath, decryptedText, w1251);

                cout.AppendLine(String.Format("Decrypted text saved at {0}", decPath));

            }
            catch (Exception ex)
            {
                cout.AppendLine(ex.Message);
                cout.AppendLine(ex.ToString());
            }

        }

        private string SelectFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                return ofd.FileName;
            }
            return null;
        }
    }

    class Data
    {
        public string TextPath { get; set; }
        public string KeyPath { get; set; }
        public string IVPath { get; set; }
    }

}

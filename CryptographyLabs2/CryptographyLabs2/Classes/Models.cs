using CryptoLabs;
using CryptoLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyLabs2
{
    abstract class ViewModel
    {
        protected string Text { get; set; }

        public string TextPath { get; set; }

        public abstract string[] ValidateModel();

        public abstract string DoEncodingAndDecoding();

    }

    class PlayfairViewModel : ViewModel
    {
        protected string Key { get; set; }

        public string KeyPath { get; set; }

        public int Columns { get; set; }


        public override string[] ValidateModel()
        {
            List<string> validation = new List<string>();

            if (TextPath == null)
            {
                validation.Add("Не указан путь к файлу с текстом");
            }

            if (KeyPath == null)
            {
                validation.Add("Не указан путь к файлу с ключом");
            }

            return validation.ToArray();
        }

        public static string sAlphabet = "абвгдежзийклмнопрстуфхцчшщъыьэюя .,";
        
        public override string DoEncodingAndDecoding()
        {
            try
            {
                Text = File.ReadAllText(TextPath, Encoding.GetEncoding(1251));
                var key = File.ReadAllText(KeyPath, Encoding.GetEncoding(1251));


                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Original: " + Text);
                sb.AppendLine("Key: " + key);

                sb.AppendLine();
                string table;
                var encoded = PlayfairCipher.Encode(Text,sAlphabet,Columns,sAlphabet.Length / Columns,key, out table);
                sb.AppendLine(table);

                sb.AppendLine("Encoded:  " + encoded);

                var decoded = PlayfairCipher.Decode(encoded, sAlphabet, Columns, sAlphabet.Length / Columns, key);
                sb.AppendLine("Decoded:  " + decoded);

                return sb.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

    class CipherTablesViewModel : ViewModel
    {
        public int Columns { get; set; }

        public int Rows { get; set; }


        public override string[] ValidateModel()
        {
            List<string> validation = new List<string>();

            if(Columns < 2 && Columns > 10)
            {
                validation.Add("Указано недопустимое количество столбцов: " + Columns.ToString());
            }
            if (Rows < 2 && Rows > 10)
            {
                validation.Add("Указано недопустимое количество столбцов: " + Columns.ToString());
            }
            if (TextPath == null)
            {
                validation.Add("Не указан путь к файлу с текстом");
            }
            return validation.ToArray();
        }


        public override string DoEncodingAndDecoding()
        {
            try
            {
                Text = File.ReadAllText(TextPath, Encoding.GetEncoding(1251));

                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Original: " + Text);

                sb.AppendLine();
                string table;
                var encoded = CipherTables.Encode(Text, Columns, Rows, out table);
                sb.AppendLine(table);

                sb.AppendLine("Encoded:  " + encoded);

                var decoded = CipherTables.Decode(encoded, Columns, Rows);
                sb.AppendLine("Decoded:  " + decoded);

                return sb.ToString();
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }
    }

}

using CryptoLabs;
using CryptoLabsPart3;
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

    class VerrnamViewModel : PlayfairViewModel
    {
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
                var encoded = VerrnamCipher.Encode(Text, key,sb);
                
                sb.AppendLine("Encoded:  " + encoded);

                var decoded = VerrnamCipher.Decode(encoded,key,sb);
                sb.AppendLine("Decoded:  " + decoded);

                return sb.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

    class DecryptingViewModel : PlayfairViewModel
    {
        public override string DoEncodingAndDecoding()
        {
            try
            {
                string[] testKeys = File.ReadAllLines(KeyPath, Encoding.GetEncoding(1251));
                string originalText = FileToString(TextPath).ToUpper();

                StringBuilder sb = new StringBuilder();

                var decrypting = new Decrypting();
                decrypting.Do(originalText, testKeys, sb);

                return sb.ToString();
            }
            catch (Exception e)
            {
                return e.Message + e.ToString();
            }
        }

        private string FileToString(string file)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding(1251)))
            {
                String line = sr.ReadToEnd();
                sb.Append(line);
            }

            var result = sb.ToString().ToUpper().Trim('\r', '\n');
            return result;
        }
    }

    class MDM6ViewModel : ViewModel
    {

        public override string[] ValidateModel()
        {
            List<string> validation = new List<string>();

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
                StringBuilder sb = new StringBuilder();

                Text = File.ReadAllText(TextPath, Encoding.GetEncoding(1251));

                sb.AppendLine("Original:  " + Text);

                LinearFeedbackShiftRegister.SB = sb;
                FibonacciLagGenerator.SB = sb;
                
                var result = MDM6.Encode(Text,sb);

                sb.AppendLine("");
                sb.AppendLine("Encoded: " + result.Item1);
                sb.AppendLine("Key: " + result.Item2);

                sb.AppendLine("");
                string decoded = MDM6.Decode(result.Item1, result.Item2, sb);
                sb.AppendLine("Decoded: " + decoded);

                return sb.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

}

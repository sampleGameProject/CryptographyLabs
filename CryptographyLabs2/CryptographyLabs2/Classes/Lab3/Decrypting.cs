using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoLib;
using System.IO;

namespace CryptoLabsPart3
{
    class Decrypting
    {
        Dictionary<char, float> charProbability = CreateCharProbability();

        private static Dictionary<char, float> CreateCharProbability()
        {
            Dictionary<char, float> chars = new Dictionary<char, float>();

            chars.Add(' ', 0.175f);
            chars.Add('О', 0.090f);
            chars.Add('Е', 0.072f);
            chars.Add('Ё', 0.072f);            
            chars.Add('А', 0.062f);
            chars.Add('И', 0.062f );
            chars.Add('Н',	0.053f);
            chars.Add('Т',	0.053f );
            chars.Add('С',	0.045f);
            chars.Add('Р',	0.040f );
            chars.Add('В',	0.038f);
            chars.Add('Л',	0.035f);
            chars.Add('К',	0.028f);
            chars.Add('М',	0.026f);
            chars.Add('Д',	0.025f);
            chars.Add('П',	0.023f);
            chars.Add('У',	0.021f);
            chars.Add('Я',	0.018f);
            chars.Add('Ы',	0.016f);
            chars.Add('З',	0.016f);
            chars.Add('Ь',	0.014f );
            chars.Add('Ъ',	0.014f);
            chars.Add('Б',	0.014f);
            chars.Add('Г',	0.013f);
            chars.Add('Ч',	0.012f);
            chars.Add('Й',	0.010f );
            chars.Add('Х',	0.009f );
            chars.Add('Ж',	0.007f );
            chars.Add('Ю',	0.006f );
            chars.Add('Ш',	0.006f);
            chars.Add('Ц',	0.004f);
            chars.Add('Щ',	0.003f );
            chars.Add('Э',	0.003f );
            chars.Add('Ф',	0.002f);

            return chars;
        }

        string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ ,.";
        
        int[,] sizes = new int[,] { { 2, 18 }, { 18, 2 }, { 3, 12 }, { 12, 3 }, { 9, 4 }, { 4, 9 }, { 6, 6 } };

        public void Do(string originalText, string[] keysArray, StringBuilder sb)
        {
            // выбираем случайные параметры для шифрования
            string randKey = keysArray[DateTime.Now.Ticks % keysArray.Length];
            int rand = (int)(DateTime.Now.Ticks) % sizes.GetLength(0);

            sb.AppendLine("Original: " + originalText);
            sb.AppendLine("Random key: " + randKey);
            sb.AppendFormat("Random size: {0}x{1}\n",sizes[rand,0],sizes[rand,1]);
            // шифруем оригинальный текст
            string encodedText = Trithemius.Encode(originalText, alphabet, sizes[rand, 0], sizes[rand, 1], randKey);


            List<Tuple<int,string,float>> dispersion = new List<Tuple<int,string,float>>();

            // для всех комбинаций ключей и размеров таблиц производим дефишровку
            foreach (var tesKey in keysArray)
            {
                for (int i = 0; i < sizes.GetLength(0); i++)
                {
                    // дешифруем текст с текущими размерами и ключом
                    var decoded = Trithemius.Decode(encodedText, alphabet, sizes[i, 0], sizes[i,1], tesKey);
                    Dictionary<char, float> charCounter = new Dictionary<char, float>();

                    // считаем количество букв в получившемся тексте
                    foreach(char c in decoded)
                    {
                        if (!charCounter.ContainsKey(c))
                            charCounter.Add(c, 0);
                        charCounter[c]++;
                    }

                    // считаем вероятность появления каждой буквы в тексте
                    var keys = charCounter.Keys.ToArray();
                    for (int w = 0; w < keys.GetLength(0); w++ )
                    {
                        var key = keys[w];
                        if (charProbability.ContainsKey(key))
                        {
                            charCounter[key] /= decoded.Length;
                        }
                    }

                    dispersion.Add(new Tuple<int,string,float>(i,tesKey,GetDispersion(charCounter)));
                }
            }
            
            foreach(var item in dispersion)
            {
                sb.AppendLine(String.Format("For size '{0}x{1}'\t and key \t'{2}' : \t{3}", sizes[item.Item1, 0], sizes[item.Item1, 1], item.Item2, item.Item3));
            }
            // выбираем результат с наименьшим среднеквадратическим отклонением
            var best = dispersion.OrderBy(item => item.Item3).First();
            sb.AppendLine(String.Format("Best size '{0}x{1}'\t and key \t'{2}' : \t{3}", sizes[best.Item1, 0], sizes[best.Item1, 1], best.Item2, best.Item3));
            sb.AppendLine(Trithemius.Decode(encodedText, alphabet, sizes[best.Item1, 0], sizes[best.Item1, 1], best.Item2));
        }

        private float GetDispersion(Dictionary<char, float> charCounter)
        {
            float result = 0;

            foreach (var key in charProbability.Keys)
            {
                if (charCounter.ContainsKey(key))
                {
                    result += (charProbability[key] - charCounter[key]) * (charProbability[key] - charCounter[key]);
                }
                
            }

            return result;
        }

    }    
}

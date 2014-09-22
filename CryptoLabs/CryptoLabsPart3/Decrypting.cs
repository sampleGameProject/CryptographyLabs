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
       
        int[,] bigramms = new int[,]
        {
                //А	Б	В	Г	Д	Е	Ж	З	И	Й	К	Л	М	Н	О	П   Р 	С 	Т 	У 	Ф 	Х 	Ц 	Ч 	Ш 	Щ 	Ы 	Ь 	Э 	Ю 	Я
            {   2,	12,	35,	8,	14,	7,	6,	15,	7,	7,	19,	27,	19,	45,	5,	11,26,	31,	27,	3,	1,	10,	6,	7,	10,	1,	0,	0,	2,	6,	9},
	        {   5,	0,	0,	0,	0,	9,	1,	0,	6,	0,	0,	6,	0,	2,	21,	0,8,	1,	0,	6,	0,	0,	0,	0,	0,	1,	11,	0,	0,	0,	2},
            {	35,	1,	5,	3,	3,	32,	0,	2,	17,	0,	7,	10,	3,	9,	58,	6,6,	19,	6,	7,	0,	1,	1,	2,	4,	1,	18,	1,	2,	0,	3},
            {	7,	0,	0,	0,	3,	3,	0,	0,	5,	0,	1,	5,	0,	1,	50,	0,7,	0,	0,	2,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0},
            {	25,	0,	3,	1,	1,	29,	1,	1,	13,	0,	1,	5,	1,	13,	22,	3,6,	8,	1,	10,	0,	0,	1,	1,	1,	0,	5,	1,	0,	0,	1},
            {	2,	9,	18,	11,	27,	7,	5,	10,	6,	15,	13,	35,	24,	63,	7,	16,39,	37,	33,	3,	1,	8,	3,	7,	3,	3,	0,	0,	1,	1,	2},
            {	5,	1,	0,	0,	6,	12,	0,	0,	5,	0,	0,	0,	0,	6,	0,	0,0,	1,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,},
            {	35,	1,	7,	1,	5,  3,	0,	0,	4,	0,	2,	1,	2,	9,	9,	1,3,	1,	0,	2,	0,	0,	0,	0,	0,	0,	4,	0,	0,	0,	4},
            {	4,	6,	22,	5,	10,	21,	2,	23,	19,	11,	19,	21,	20,	32,	8,	13,11,	29,	29,	3,	1,	17,	3,	11,	1,	1,	0,	0,	1,	3,	17},
            {	1,	1,	4,	1,	3,	0,	1,	2,	4,	0,	5,	1,	2,	7,	9,	7,3,	10,	2,	0,	0,	0,	1,	3,	2,	0,	0,	0,	0,	0,	0},
            {	24,	1,	4,	1,	0,	4,	1,	1,	26,	0,	1,	4,	1,	2,	66,	2,10,	3,	7,	10,	0,	0,	1,	0,	0,	0,	0,	0,	0,	0,	0},
            {	25,	1,	1,	1,	1,	33,	2,	1,	36,	0,	1,	2,	1,	8,	30,	2,0,	3,	1,	6,	0,	4,	0,	1,	0,	0,	3,	20,	0,	4,	9},
            {	18,	2,	4,	1,	1,	21,	1,	2,	23,	0,	3,	1,	3,	7,	19,	5,2,	5,	3,	9,	1,	0,	0,	2,	0,	0,	5,	1,	1,	0,	3},
            {	54,	1,	2,	3,	3,	34,	0,	0,	58,	0,	3,	0,	1,	24,	67,	2,1,	9,	9,	7,	1,	0,	5,	2,	0,	0,	36,	3,	0,	0,	5},
            {	1,	28,	84,	32,	47,	15,	7,	18,	12,	29,	19,	41,	38,	30,	9,	18,43,	50,	39,	3,	2,	5,	2,	12,	4,	3,	0,	0,	2,	3,	2},
            {	7,	0,	0,	0,	0,	15,	0,	0,	4,	0,	0,	9,	0,	1,	46,	41,	1,	0,	6,	0,	0,	0,	0,	0,	0,	2,	0,	0,	0,	2,0},
            {	55,	1,	4,	4,	3,	37,	3,	1,	24,	0,	3,	1,	3,	7,	56,	2,1,	5,	9,	16,	0,	1,	1,	1,	2,	0,	8,	3,	0,	0,	5},
            {	8,	1,	7,	1,	2,	25,	0,	0,	6,	0,	40,	13,	3,	9,	27,	11,4,	11,	82,	6,	0,	1,	1,	2,	2,	0,	1,	8,	0,	0,	17},
            {	35,	1,	27,	1,	3,	31,	0,	1,	28,	0,	5,	1,	1,	11,	56,	4,26,	18,	2,	10,	0,	0,	0,	1,	0,	0,	11,	21,	0,	0,	4},
            {	1,	4,	4,	4,	11,	2,	6,	3,	2,	0,	8,	5,	5,	5,	1,	5,7,	14,	7,	0,	0,	1,	0,	8,	3,	2,	0,	0,	0,	9,	1},
            {	2,	0,	0,	0,	0,	2,	0,	0,	2,	0,	0,	0,	0,	0,	1,	0,1,	1,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0},
            {	4,	1,	4,	1,	3,	1,	0,	2,	3,	0,	4,	3,	3,	4,	18,	5,3,	4,	2,	2,	1,	0,	0,	1,	0,	0,	0,	0,	0,	0,	0},
            {	3,	0,	0,	0,	0,	7,	0,	0,	10,	0,	2,	0,	0,	0,	1,	0,0,	0,	0,	1,	0,	0,	0,	0,	0,	0,	1,	0,	0,	0,	0,},
            {	12,	0,	0,	0,	0,	23,	0,	0,	13,	0,	2,	0,	0,	6,	0,	0,0,	0,	7,	1,	0,	0,	0,	0,	1,	0,	0,	1,	0,	0,	0,},
            {	5,	0,	0,	0,	0,	11,	0,	0,	14,	0,	1,	2,	0,	2,	2,	0,0,	0,	0,	1,	0,	0,	0,	0,	0,	0,	0,	1,	0,	0,	0,},
            {	3,	0,	0,	0,	0,	8,	0,	0,	6,	0,	0,	0,	0,	1,	0,	0,0,	0,	0,	1,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,},
            {	0,	1,	9,	1,	3,	12,	0,	2,	4,	7,	3,	6,	6,	3,	2,	10,3,	9,	4,	1,	0,	16,	0,	1,	2,	0,	0,	0,	0,	0,	0,},
            {	0,	2,	4,	1,	1,	2,	0,	2,	2,	0,	6,	0,	3,	13,	2,	4,1,	11,	3,	0,	0,	0,	0,	1,	4,	0,	0,	0,	1,	3,	1},
            {	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	1,	0,	0,	1,	0,	0,0,	0,	1,	9,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,	0,},	
            {	0,	2,	1,	2,	1,	0,	0,	3,	1,	0,	1,	0,	1,	1,	1,	3,1,	1,	7,	0,	0,	0,	1,	1,	0,	4,	0,	0,	0,	0,	0,},
            {	1,	3,	9,	1,	3,	3,	1,	5,	3,	2,	3,	3,	4,	6,	3,	6,3,	6,	10,	0,	0,	2,	1,	4,	1,	1,	0,	0,	1,	1,	1}
        };

        string bigrammAlpha = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЫЬЭЮЯ";

        string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ ,.";
        string KEY = "ВОРУЙКРАБОВ";

        int[,] sizes = new int[,] { { 2, 2 }, { 2, 3 }, { 2, 6 }, { 2, 12 }, { 2, 18 }, 
            { 3, 4 }, { 3, 6 }, { 3, 12 }, { 4, 9 }, { 6, 6 } };

        public Decrypting()
        {
            string[] testKeys = File.ReadAllLines("keys.txt", Encoding.GetEncoding(1251));
            
            string originalText = FileToString("test.txt").ToUpper();

            string encodedText = Trithemius.Encode(originalText,alphabet,4,9,KEY);
            //Console.WriteLine(encodedText);
            
            //string decodedText = Trithemius.Decode(encodedText, alphabet, 4, 9, KEY);
            //Console.WriteLine(decodedText);

            List<Tuple<int,string,float>> dispersion = new List<Tuple<int,string,float>>();

            foreach(var tesKey in testKeys)
            {
                for (int i = 0; i < sizes.GetLength(0); i++)
                {
                    var decoded = Trithemius.Decode(encodedText, alphabet, sizes[i, 0], sizes[i,1], tesKey);
                    Dictionary<char, float> charCounter = new Dictionary<char, float>();

                    foreach(char c in decoded)
                    {
                        if (!charCounter.ContainsKey(c))
                            charCounter.Add(c, 0);
                        charCounter[c]++;
                    }

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

            var best = dispersion.OrderBy(item => item.Item3).First();
            Console.WriteLine(String.Format("Best size '{0}x{1}' and key '{2}'",sizes[best.Item1,0],sizes[best.Item1,1],best.Item2));
            Console.WriteLine(Trithemius.Decode(encodedText, alphabet, sizes[best.Item1, 0], sizes[best.Item1, 1], best.Item2));
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

        private string FileToString(string file)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader sr = new StreamReader(file, Encoding.GetEncoding(1251)))
            {
                String line = sr.ReadToEnd();
                sb.Append(line);
            }

            var result = sb.ToString().ToUpper().Trim('\r','\n');
            return result;            
        }
    }    
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoLib
{
    public static class FileWriter
    {
        static StringBuilder sb = new StringBuilder();

        public static void FlushToFile(string file)
        {
            File.WriteAllText(file,sb.ToString());
            sb.Clear();
        }

        public static void AppendLine(string line)
        {
            sb.AppendLine(line);
        }
    }
}

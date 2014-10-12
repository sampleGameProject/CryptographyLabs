using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cast256CBC
{
    class Cout
    {
        RichTextBox _box;

        public Cout(RichTextBox box)
        {
            _box = box;
            _box.Text = String.Empty;
        }

        public void AppendLine(string line)
        {
            _box.Text += (line + "\n");
        }
    }
}

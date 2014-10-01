using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptographyLabs2
{
    public partial class MainForm : Form
    {
        PlayfairViewModel playfair = new PlayfairViewModel();
        CipherTablesViewModel tables = new CipherTablesViewModel() { Columns = 2, Rows = 2};

        ViewModel current = null;

        public MainForm()
        {
            InitializeComponent();

            var dict = new Dictionary<int, string>();
            dict.Add(7, "7");
            dict.Add(5, "5");
            comboBox2.DataSource = new BindingSource(dict, null);
            comboBox2.DisplayMember = "Value";
            comboBox2.ValueMember = "Key";

            playfair.Columns = 7;

            radioButton2.Select();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control control in this.groupBox1.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radio = control as RadioButton;
                    if (radio.Checked && radio == radioButton1)
                    {
                        groupBoxPlayfair.Visible = true;
                        groupBoxTables.Visible = false;
                        current = playfair;
                    }
                    if (radio.Checked && radio == radioButton2)
                    {
                        groupBoxPlayfair.Visible = false;
                        groupBoxTables.Visible = true;
                        current = tables;
                    }
                }
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            var validate = current.ValidateModel();
            if (validate.Length == 0)//все нормально
            {
                richTextBox.Text = current.DoEncodingAndDecoding();
            }
            else
            {
                MessageBox.Show("Внимание!",String.Join(", ",validate));
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            tables.Columns = (int)numericUpDown1.Value;
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            tables.Rows = (int)numericUpDown2.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedFile = SelectFile();

            if(selectedFile != null)
            {
                tables.TextPath = selectedFile;
                selectedTablesFileLabel.Text = tables.TextPath;
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

        private void button4_Click(object sender, EventArgs e)
        {
            string selectedFile = SelectFile();

            if (selectedFile != null)
            {
                playfair.TextPath = selectedFile;
                labelPlayfair1.Text = playfair.TextPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedFile = SelectFile();

            if (selectedFile != null)
            {
                playfair.KeyPath = selectedFile;
                labelPlayfair2.Text = playfair.KeyPath;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            playfair.Columns = (int)(comboBox2.SelectedValue);
        }



    }
}

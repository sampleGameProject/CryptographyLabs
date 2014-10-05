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
        //Лаб1
        PlayfairViewModel playfair = new PlayfairViewModel();
        CipherTablesViewModel tables = new CipherTablesViewModel() { Columns = 2, Rows = 2};
        ViewModel current = null;

        //Лаб2
        VerrnamViewModel verrnam = new VerrnamViewModel();

        //Лаб3
        DecryptingViewModel decrypting = new DecryptingViewModel();

        //Лаб4
        MDM6ViewModel mdm6 = new MDM6ViewModel();

//===============LAB1===================================================================
        
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
            // выбираем количество колонок для шифра Плейфера
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
                // 1 из 2 типов шифра для 1й лабораторной работы
                richTextBox.Text = current.DoEncodingAndDecoding();
            }
            else
            {
                MessageBox.Show(String.Join(", ",validate), "Внимание!");
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


//===============LAB2===================================================================
        private void buttonLab2SelectTextFile_Click(object sender, EventArgs e)
        {
            string selectedFile = SelectFile();

            if (selectedFile != null)
            {
                verrnam.TextPath = selectedFile;
                label2File.Text = verrnam.TextPath;
            }
        }

        private void buttonLab2SelectKeyFile_Click(object sender, EventArgs e)
        {
            string selectedFile = SelectFile();

            if (selectedFile != null)
            {
                verrnam.KeyPath = selectedFile;
                label2Key.Text = verrnam.KeyPath;
            }
        }

        private void buttonLab2Start_Click(object sender, EventArgs e)
        {
            var validate = verrnam.ValidateModel();
            if (validate.Length == 0)//все нормально
            {
                richTextBox2.Text = verrnam.DoEncodingAndDecoding();
            }
            else
            {
                MessageBox.Show(String.Join(", ", validate), "Внимание!");
            }
        }


//===============LAB3===================================================================


        private void buttonLab3TextSelect_Click(object sender, EventArgs e)
        {
            string selectedFile = SelectFile();

            if (selectedFile != null)
            {
                decrypting.TextPath = selectedFile;
                labelLab3Text.Text = decrypting.TextPath;
            }
        }

        private void buttonLab3SelectKeys_Click(object sender, EventArgs e)
        {
            string selectedFile = SelectFile();

            if (selectedFile != null)
            {
                decrypting.KeyPath = selectedFile;
                labelLab3Keys.Text = decrypting.KeyPath;
            }
        }

        private void start3_Click(object sender, EventArgs e)
        {
            var validate = decrypting.ValidateModel();
            if (validate.Length == 0)//все нормально
            {
                richTextBox3.Text = decrypting.DoEncodingAndDecoding();
            }
            else
            {
                MessageBox.Show(String.Join(", ", validate), "Внимание!");
            }
        }

//===============LAB4===================================================================



        private void buttonLab4_Click(object sender, EventArgs e)
        {
            string selectedFile = SelectFile();

            if (selectedFile != null)
            {
                mdm6.TextPath = selectedFile;
                labelLab4.Text = mdm6.TextPath;
            }
        }

        private void buttonLab4Start_Click(object sender, EventArgs e)
        {
            var validate = mdm6.ValidateModel();
            if (validate.Length == 0)//все нормально
            {
                richTextBox4.Text = mdm6.DoEncodingAndDecoding();
            }
            else
            {
                MessageBox.Show(String.Join(", ", validate), "Внимание!" );
            }
        }

    }
}

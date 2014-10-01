namespace CryptographyLabs2
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBoxPlayfair = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBoxTables = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.selectedTablesFileLabel = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPlayfair2 = new System.Windows.Forms.Label();
            this.buttonSelectPlayfairKey = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPlayfair1 = new System.Windows.Forms.Label();
            this.buttonSelectPlayfairText = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxPlayfair.SuspendLayout();
            this.groupBoxTables.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(722, 536);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(714, 510);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Лаб. 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox.Location = new System.Drawing.Point(204, 3);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.Size = new System.Drawing.Size(507, 504);
            this.richTextBox.TabIndex = 5;
            this.richTextBox.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.groupBoxTables);
            this.groupBox1.Controls.Add(this.groupBoxPlayfair);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 504);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип шифра";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(30, 424);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 42);
            this.button3.TabIndex = 8;
            this.button3.Text = "СТАРТ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBoxPlayfair
            // 
            this.groupBoxPlayfair.Controls.Add(this.label6);
            this.groupBoxPlayfair.Controls.Add(this.label2);
            this.groupBoxPlayfair.Controls.Add(this.labelPlayfair2);
            this.groupBoxPlayfair.Controls.Add(this.buttonSelectPlayfairKey);
            this.groupBoxPlayfair.Controls.Add(this.comboBox2);
            this.groupBoxPlayfair.Controls.Add(this.label3);
            this.groupBoxPlayfair.Controls.Add(this.labelPlayfair1);
            this.groupBoxPlayfair.Controls.Add(this.buttonSelectPlayfairText);
            this.groupBoxPlayfair.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxPlayfair.Location = new System.Drawing.Point(3, 73);
            this.groupBoxPlayfair.Name = "groupBoxPlayfair";
            this.groupBoxPlayfair.Size = new System.Drawing.Size(192, 310);
            this.groupBoxPlayfair.TabIndex = 7;
            this.groupBoxPlayfair.TabStop = false;
            this.groupBoxPlayfair.Text = "Исходные данные";
            // 
            // label6
            // 
            this.label6.AllowDrop = true;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(6, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Количество столбцов:";
            // 
            // groupBoxTables
            // 
            this.groupBoxTables.Controls.Add(this.label9);
            this.groupBoxTables.Controls.Add(this.label7);
            this.groupBoxTables.Controls.Add(this.selectedTablesFileLabel);
            this.groupBoxTables.Controls.Add(this.numericUpDown2);
            this.groupBoxTables.Controls.Add(this.button1);
            this.groupBoxTables.Controls.Add(this.numericUpDown1);
            this.groupBoxTables.Controls.Add(this.label1);
            this.groupBoxTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxTables.Location = new System.Drawing.Point(3, 73);
            this.groupBoxTables.Name = "groupBoxTables";
            this.groupBoxTables.Size = new System.Drawing.Size(192, 310);
            this.groupBoxTables.TabIndex = 5;
            this.groupBoxTables.TabStop = false;
            this.groupBoxTables.Text = "Исходные данные";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 15);
            this.label9.TabIndex = 12;
            this.label9.Text = "Количество строк:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(6, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "Выбранный файл с текстом:";
            // 
            // selectedTablesFileLabel
            // 
            this.selectedTablesFileLabel.AutoSize = true;
            this.selectedTablesFileLabel.Location = new System.Drawing.Point(12, 52);
            this.selectedTablesFileLabel.Name = "selectedTablesFileLabel";
            this.selectedTablesFileLabel.Size = new System.Drawing.Size(96, 15);
            this.selectedTablesFileLabel.TabIndex = 10;
            this.selectedTablesFileLabel.Text = "Файл не выбан";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(16, 192);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(67, 21);
            this.numericUpDown2.TabIndex = 6;
            this.numericUpDown2.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 24);
            this.button1.TabIndex = 9;
            this.button1.Text = "Выбрать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(16, 135);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(55, 21);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Количество столбцов:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Выбранный файл с ключом:";
            // 
            // labelPlayfair2
            // 
            this.labelPlayfair2.AutoSize = true;
            this.labelPlayfair2.Location = new System.Drawing.Point(6, 141);
            this.labelPlayfair2.Name = "labelPlayfair2";
            this.labelPlayfair2.Size = new System.Drawing.Size(103, 15);
            this.labelPlayfair2.TabIndex = 6;
            this.labelPlayfair2.Text = "Файл не выбран";
            // 
            // buttonSelectPlayfairKey
            // 
            this.buttonSelectPlayfairKey.Location = new System.Drawing.Point(16, 162);
            this.buttonSelectPlayfairKey.Name = "buttonSelectPlayfairKey";
            this.buttonSelectPlayfairKey.Size = new System.Drawing.Size(69, 24);
            this.buttonSelectPlayfairKey.TabIndex = 5;
            this.buttonSelectPlayfairKey.Text = "Выбрать";
            this.buttonSelectPlayfairKey.UseVisualStyleBackColor = true;
            this.buttonSelectPlayfairKey.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(16, 231);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(82, 23);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectionChangeCommitted += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Выбранный файл с текстом:";
            // 
            // labelPlayfair1
            // 
            this.labelPlayfair1.AutoSize = true;
            this.labelPlayfair1.Location = new System.Drawing.Point(6, 54);
            this.labelPlayfair1.Name = "labelPlayfair1";
            this.labelPlayfair1.Size = new System.Drawing.Size(103, 15);
            this.labelPlayfair1.TabIndex = 2;
            this.labelPlayfair1.Text = "Файл не выбран";
            // 
            // buttonSelectPlayfairText
            // 
            this.buttonSelectPlayfairText.Location = new System.Drawing.Point(16, 74);
            this.buttonSelectPlayfairText.Name = "buttonSelectPlayfairText";
            this.buttonSelectPlayfairText.Size = new System.Drawing.Size(69, 24);
            this.buttonSelectPlayfairText.TabIndex = 1;
            this.buttonSelectPlayfairText.Text = "Выбрать";
            this.buttonSelectPlayfairText.UseVisualStyleBackColor = true;
            this.buttonSelectPlayfairText.Click += new System.EventHandler(this.button4_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton2.Location = new System.Drawing.Point(16, 22);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(169, 21);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Шифрующие таблицы";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton1.Location = new System.Drawing.Point(16, 49);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(137, 21);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Шифр Плейфера";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(714, 510);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Лаб. 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(714, 510);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Лаб. 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(714, 510);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Лаб. 4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 536);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Лабораторные работы по дисциплине \"Методы и средства защиты информации\"";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxPlayfair.ResumeLayout(false);
            this.groupBoxPlayfair.PerformLayout();
            this.groupBoxTables.ResumeLayout(false);
            this.groupBoxTables.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBoxPlayfair;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPlayfair1;
        private System.Windows.Forms.Button buttonSelectPlayfairText;
        private System.Windows.Forms.GroupBox groupBoxTables;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelPlayfair2;
        private System.Windows.Forms.Button buttonSelectPlayfairKey;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label selectedTablesFileLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button button3;
    }
}


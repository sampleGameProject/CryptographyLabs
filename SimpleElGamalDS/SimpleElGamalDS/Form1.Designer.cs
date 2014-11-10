namespace SimpleElGamalDS
{
    partial class Form1
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonGenerateOpenKey = new System.Windows.Forms.Button();
            this.buttonSelectPrivateKeyToGenerateOpenKey = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonGeneratePrivateKey = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(643, 413);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(635, 387);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Создание цифровой подписи";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonGenerateOpenKey);
            this.groupBox2.Controls.Add(this.buttonSelectPrivateKeyToGenerateOpenKey);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(202, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 381);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Создание открытого ключа";
            // 
            // buttonGenerateOpenKey
            // 
            this.buttonGenerateOpenKey.Location = new System.Drawing.Point(32, 115);
            this.buttonGenerateOpenKey.Name = "buttonGenerateOpenKey";
            this.buttonGenerateOpenKey.Size = new System.Drawing.Size(184, 46);
            this.buttonGenerateOpenKey.TabIndex = 1;
            this.buttonGenerateOpenKey.Text = "Сгенерировать открытый ключ и сохранить в файл";
            this.buttonGenerateOpenKey.UseVisualStyleBackColor = true;
            this.buttonGenerateOpenKey.Click += new System.EventHandler(this.buttonGenerateOpenKey_Click);
            // 
            // buttonSelectPrivateKeyToGenerateOpenKey
            // 
            this.buttonSelectPrivateKeyToGenerateOpenKey.Location = new System.Drawing.Point(32, 36);
            this.buttonSelectPrivateKeyToGenerateOpenKey.Name = "buttonSelectPrivateKeyToGenerateOpenKey";
            this.buttonSelectPrivateKeyToGenerateOpenKey.Size = new System.Drawing.Size(122, 46);
            this.buttonSelectPrivateKeyToGenerateOpenKey.TabIndex = 0;
            this.buttonSelectPrivateKeyToGenerateOpenKey.Text = "Выбрать закрытый ключ";
            this.buttonSelectPrivateKeyToGenerateOpenKey.UseVisualStyleBackColor = true;
            this.buttonSelectPrivateKeyToGenerateOpenKey.Click += new System.EventHandler(this.buttonSelectPrivateKeyToGenerateOpenKey_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonGeneratePrivateKey);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 381);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Создание закрытого ключа";
            // 
            // buttonGeneratePrivateKey
            // 
            this.buttonGeneratePrivateKey.Location = new System.Drawing.Point(21, 74);
            this.buttonGeneratePrivateKey.Name = "buttonGeneratePrivateKey";
            this.buttonGeneratePrivateKey.Size = new System.Drawing.Size(122, 87);
            this.buttonGeneratePrivateKey.TabIndex = 0;
            this.buttonGeneratePrivateKey.Text = "Сгенерировать закрытый ключ и сохранить в файл";
            this.buttonGeneratePrivateKey.UseVisualStyleBackColor = true;
            this.buttonGeneratePrivateKey.Click += new System.EventHandler(this.buttonGeneratePrivateKey_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(635, 387);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Подпись файлов и проверка";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 381);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Подпись файла";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.button10);
            this.groupBox4.Controls.Add(this.button9);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(203, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(429, 381);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Проверка подписи";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(25, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 43);
            this.button2.TabIndex = 0;
            this.button2.Text = "Выбрать файл";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(25, 95);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(106, 43);
            this.button5.TabIndex = 1;
            this.button5.Text = "Выбрать закрытый ключ";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(25, 157);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(106, 43);
            this.button6.TabIndex = 2;
            this.button6.Text = "Выбрать открытый ключ";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(25, 222);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(106, 43);
            this.button7.TabIndex = 3;
            this.button7.Text = "Создать подпись";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(38, 179);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(106, 43);
            this.button8.TabIndex = 6;
            this.button8.Text = "Проверить подпись файла";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(38, 105);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(106, 43);
            this.button9.TabIndex = 5;
            this.button9.Text = "Выбрать открытый ключ";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(38, 33);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(106, 43);
            this.button10.TabIndex = 4;
            this.button10.Text = "Выбрать файл";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 413);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "ElGamal Signature";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonGeneratePrivateKey;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonGenerateOpenKey;
        private System.Windows.Forms.Button buttonSelectPrivateKeyToGenerateOpenKey;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
    }
}


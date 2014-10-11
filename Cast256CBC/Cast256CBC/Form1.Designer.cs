namespace Cast256CBC
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
            this.mainTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // mainTextBox
            // 
            this.mainTextBox.AcceptsTab = true;
            this.mainTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.mainTextBox.Location = new System.Drawing.Point(12, 12);
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.ReadOnly = true;
            this.mainTextBox.Size = new System.Drawing.Size(726, 549);
            this.mainTextBox.TabIndex = 21;
            this.mainTextBox.Text = "";
            this.mainTextBox.WordWrap = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 573);
            this.Controls.Add(this.mainTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox mainTextBox;

    }
}


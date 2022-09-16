namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.CBMeth1 = new System.Windows.Forms.CheckBox();
            this.CBMeth2 = new System.Windows.Forms.CheckBox();
            this.CBMeth3 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите метод, который будет учавствовать в подсчёте";
            // 
            // CBMeth1
            // 
            this.CBMeth1.AutoSize = true;
            this.CBMeth1.Location = new System.Drawing.Point(12, 50);
            this.CBMeth1.Name = "CBMeth1";
            this.CBMeth1.Size = new System.Drawing.Size(73, 24);
            this.CBMeth1.TabIndex = 2;
            this.CBMeth1.Text = "Meth1";
            this.CBMeth1.UseVisualStyleBackColor = true;
            // 
            // CBMeth2
            // 
            this.CBMeth2.AutoSize = true;
            this.CBMeth2.Location = new System.Drawing.Point(12, 96);
            this.CBMeth2.Name = "CBMeth2";
            this.CBMeth2.Size = new System.Drawing.Size(73, 24);
            this.CBMeth2.TabIndex = 3;
            this.CBMeth2.Text = "Meth2";
            this.CBMeth2.UseVisualStyleBackColor = true;
            // 
            // CBMeth3
            // 
            this.CBMeth3.AutoSize = true;
            this.CBMeth3.Location = new System.Drawing.Point(12, 144);
            this.CBMeth3.Name = "CBMeth3";
            this.CBMeth3.Size = new System.Drawing.Size(73, 24);
            this.CBMeth3.TabIndex = 4;
            this.CBMeth3.Text = "Meth3";
            this.CBMeth3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(407, 29);
            this.button1.TabIndex = 5;
            this.button1.Text = "Подсчитать время выполнения";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Затраченное время:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(325, 228);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "Очистить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(169, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 31);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 326);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CBMeth3);
            this.Controls.Add(this.CBMeth2);
            this.Controls.Add(this.CBMeth1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private CheckBox CBMeth1;
        private CheckBox CBMeth2;
        private CheckBox CBMeth3;
        private Button button1;
        private Label label2;
        private Button button2;
        private Label label3;
    }
}
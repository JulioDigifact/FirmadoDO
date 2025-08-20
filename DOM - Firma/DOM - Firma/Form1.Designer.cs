namespace DOM___Firma
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
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            openFileDialog1 = new OpenFileDialog();
            label1 = new Label();
            button3 = new Button();
            richTextBox2 = new RichTextBox();
            comboBox1 = new ComboBox();
            label2 = new Label();
            button4 = new Button();
            openFileDialog2 = new OpenFileDialog();
            button5 = new Button();
            txtCertPass = new TextBox();
            label3 = new Label();
            button6 = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(32, 75);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(696, 568);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Location = new Point(787, 113);
            button1.Name = "button1";
            button1.Size = new Size(120, 47);
            button1.TabIndex = 1;
            button1.Text = "Firmar Texto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(934, 113);
            button2.Name = "button2";
            button2.Size = new Size(122, 47);
            button2.TabIndex = 2;
            button2.Text = "Firmar XML";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(235, 34);
            label1.Name = "label1";
            label1.Size = new Size(203, 25);
            label1.TabIndex = 3;
            label1.Text = "Ingresar el texto XML";
            label1.Click += label1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(927, 193);
            button3.Name = "button3";
            button3.Size = new Size(155, 37);
            button3.TabIndex = 4;
            button3.Text = "Generar token";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.Location = new Point(764, 245);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(333, 285);
            richTextBox2.TabIndex = 5;
            richTextBox2.Text = "";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(770, 201);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(770, 173);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 7;
            label2.Text = "Ambiente";
            // 
            // button4
            // 
            button4.Location = new Point(787, 47);
            button4.Name = "button4";
            button4.Size = new Size(269, 54);
            button4.TabIndex = 8;
            button4.Text = "Certificar XML";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // button5
            // 
            button5.Location = new Point(764, 565);
            button5.Name = "button5";
            button5.Size = new Size(159, 37);
            button5.TabIndex = 9;
            button5.Text = "Seleccionar Certficado";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // txtCertPass
            // 
            txtCertPass.Location = new Point(837, 620);
            txtCertPass.Name = "txtCertPass";
            txtCertPass.Size = new Size(245, 23);
            txtCertPass.TabIndex = 10;
            txtCertPass.TextChanged += textBox_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(764, 623);
            label3.Name = "label3";
            label3.Size = new Size(67, 15);
            label3.TabIndex = 11;
            label3.Text = "Contraseña";
            // 
            // button6
            // 
            button6.Location = new Point(950, 565);
            button6.Name = "button6";
            button6.Size = new Size(147, 37);
            button6.TabIndex = 12;
            button6.Text = "Validar Certificado";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(812, 661);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 13;
            label4.Text = "Status: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1134, 694);
            Controls.Add(label4);
            Controls.Add(button6);
            Controls.Add(label3);
            Controls.Add(txtCertPass);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(richTextBox2);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Firmador - DO";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button button1;
        private Button button2;
        private OpenFileDialog openFileDialog1;
        private Label label1;
        private Button button3;
        private RichTextBox richTextBox2;
        private ComboBox comboBox1;
        private Label label2;
        private Button button4;
        private OpenFileDialog openFileDialog2;
        private Button button5;
        private TextBox txtCertPass;
        private Label label3;
        private Button button6;
        private Label label4;
    }
}
namespace Convert
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            openFd = new OpenFileDialog();
            listBox1 = new ListBox();
            label1 = new Label();
            listBox2 = new ListBox();
            label2 = new Label();
            button2 = new Button();
            openFDExcel = new OpenFileDialog();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.Location = new Point(111, 12);
            button1.Name = "button1";
            button1.Size = new Size(78, 71);
            button1.TabIndex = 0;
            button1.Text = "Descifrar XML";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // openFd
            // 
            openFd.FileName = "openFileDialog1";
            openFd.Filter = "Xml file | *.xml";
            openFd.Title = "Seleccionar archivo XML";
            // 
            // listBox1
            // 
            listBox1.ForeColor = Color.Red;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 441);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(776, 274);
            listBox1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 423);
            label1.Name = "label1";
            label1.Size = new Size(213, 15);
            label1.TabIndex = 3;
            label1.Text = "Cantidad de elementos NO descifrados";
            // 
            // listBox2
            // 
            listBox2.ForeColor = Color.Blue;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(12, 127);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(776, 274);
            listBox2.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 109);
            label2.Name = "label2";
            label2.Size = new Size(192, 15);
            label2.TabIndex = 5;
            label2.Text = "Cantidad de elementos descifrados";
            // 
            // button2
            // 
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.TopCenter;
            button2.Location = new Point(12, 12);
            button2.Name = "button2";
            button2.Size = new Size(78, 71);
            button2.TabIndex = 6;
            button2.Text = "Cargar esquema";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // openFDExcel
            // 
            openFDExcel.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 727);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(listBox2);
            Controls.Add(label1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Utilitario descifrar XML";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private OpenFileDialog openFd;
        private ListBox listBox1;
        private Label label1;
        private ListBox listBox2;
        private Label label2;
        private Button button2;
        private OpenFileDialog openFDExcel;
    }
}
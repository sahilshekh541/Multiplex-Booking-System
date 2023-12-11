namespace marvelmultiplex
{
    partial class bookmovieresult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bookmovieresult));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.dtcombobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.seattypestxt = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ticketstxt = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.guestnmtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.submitbtn = new System.Windows.Forms.Button();
            this.backbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::marvelmultiplex.Properties.Resources.guest;
            this.pictureBox1.Location = new System.Drawing.Point(721, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 132);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(869, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 60);
            this.label1.TabIndex = 1;
            this.label1.Text = "Guset Details";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.dtcombobox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.seattypestxt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.ticketstxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.guestnmtxt);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Font = new System.Drawing.Font("Calisto MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(444, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1381, 615);
            this.panel1.TabIndex = 2;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Calisto MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(764, 518);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(149, 29);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Credit Card";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Calisto MT", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(621, 518);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(77, 29);
            this.radioButton1.TabIndex = 12;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "UPI";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calisto MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(49, 515);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(192, 32);
            this.label6.TabIndex = 11;
            this.label6.Text = "Payment Type";
            // 
            // dtcombobox
            // 
            this.dtcombobox.Font = new System.Drawing.Font("Calisto MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtcombobox.FormattingEnabled = true;
            this.dtcombobox.Location = new System.Drawing.Point(621, 407);
            this.dtcombobox.Name = "dtcombobox";
            this.dtcombobox.Size = new System.Drawing.Size(282, 30);
            this.dtcombobox.TabIndex = 10;
            this.dtcombobox.SelectedIndexChanged += new System.EventHandler(this.dtcombobox_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calisto MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(49, 415);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Choose Date";
            // 
            // seattypestxt
            // 
            this.seattypestxt.Font = new System.Drawing.Font("Calisto MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seattypestxt.FormattingEnabled = true;
            this.seattypestxt.Items.AddRange(new object[] {
            "balcony",
            "middle",
            "lower"});
            this.seattypestxt.Location = new System.Drawing.Point(621, 304);
            this.seattypestxt.Name = "seattypestxt";
            this.seattypestxt.Size = new System.Drawing.Size(282, 30);
            this.seattypestxt.TabIndex = 8;
            this.seattypestxt.SelectedIndexChanged += new System.EventHandler(this.seattypestxt_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calisto MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(49, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "Choose Seats Type";
            // 
            // ticketstxt
            // 
            this.ticketstxt.Font = new System.Drawing.Font("Calisto MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ticketstxt.FormattingEnabled = true;
            this.ticketstxt.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.ticketstxt.Location = new System.Drawing.Point(621, 194);
            this.ticketstxt.Name = "ticketstxt";
            this.ticketstxt.Size = new System.Drawing.Size(282, 30);
            this.ticketstxt.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calisto MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(49, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(445, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "How Many Tickets Do You Want ?";
            // 
            // guestnmtxt
            // 
            this.guestnmtxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.guestnmtxt.Font = new System.Drawing.Font("Californian FB", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guestnmtxt.Location = new System.Drawing.Point(621, 65);
            this.guestnmtxt.Multiline = true;
            this.guestnmtxt.Name = "guestnmtxt";
            this.guestnmtxt.Size = new System.Drawing.Size(448, 36);
            this.guestnmtxt.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calisto MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(48, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 40);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter Name";
            // 
            // submitbtn
            // 
            this.submitbtn.BackColor = System.Drawing.Color.Navy;
            this.submitbtn.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitbtn.ForeColor = System.Drawing.Color.White;
            this.submitbtn.Location = new System.Drawing.Point(1073, 846);
            this.submitbtn.Name = "submitbtn";
            this.submitbtn.Size = new System.Drawing.Size(274, 45);
            this.submitbtn.TabIndex = 19;
            this.submitbtn.Text = "Submit";
            this.submitbtn.UseVisualStyleBackColor = false;
            this.submitbtn.Click += new System.EventHandler(this.submitbtn_Click);
            // 
            // backbtn
            // 
            this.backbtn.BackColor = System.Drawing.Color.Navy;
            this.backbtn.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backbtn.ForeColor = System.Drawing.Color.White;
            this.backbtn.Location = new System.Drawing.Point(499, 846);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(274, 45);
            this.backbtn.TabIndex = 20;
            this.backbtn.Text = "Back";
            this.backbtn.UseVisualStyleBackColor = false;
            this.backbtn.Click += new System.EventHandler(this.backbtn_Click);
            // 
            // bookmovieresult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(1)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.backbtn);
            this.Controls.Add(this.submitbtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "bookmovieresult";
            this.Text = "Marvel Multiplex Bokking System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.bookmovieresult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox guestnmtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox dtcombobox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox seattypestxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ticketstxt;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button submitbtn;
        private System.Windows.Forms.Button backbtn;
    }
}
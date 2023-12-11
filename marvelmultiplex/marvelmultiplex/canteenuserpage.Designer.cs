namespace marvelmultiplex
{
    partial class canteenuserpage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(canteenuserpage));
            this.moviesPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.homebtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // moviesPanel
            // 
            this.moviesPanel.AutoScroll = true;
            this.moviesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(1)))), ((int)(((byte)(0)))));
            this.moviesPanel.Location = new System.Drawing.Point(36, 161);
            this.moviesPanel.Name = "moviesPanel";
            this.moviesPanel.Size = new System.Drawing.Size(1826, 816);
            this.moviesPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(529, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(515, 109);
            this.label1.TabIndex = 2;
            this.label1.Text = "CANTEEN";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::marvelmultiplex.Properties.Resources.canteen;
            this.pictureBox1.Location = new System.Drawing.Point(1050, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 113);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // homebtn
            // 
            this.homebtn.BackColor = System.Drawing.Color.Black;
            this.homebtn.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.homebtn.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.homebtn.FlatAppearance.BorderSize = 0;
            this.homebtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.homebtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.homebtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.homebtn.Font = new System.Drawing.Font("Californian FB", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homebtn.ForeColor = System.Drawing.Color.White;
            this.homebtn.Location = new System.Drawing.Point(-1, 0);
            this.homebtn.Name = "homebtn";
            this.homebtn.Size = new System.Drawing.Size(287, 52);
            this.homebtn.TabIndex = 5;
            this.homebtn.Text = "HOME";
            this.homebtn.UseVisualStyleBackColor = false;
            this.homebtn.Click += new System.EventHandler(this.homebtn_Click);
            // 
            // canteenuserpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(1)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.homebtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moviesPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "canteenuserpage";
            this.Text = "canteenuserpage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.canteenuserpage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel moviesPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button homebtn;
    }
}
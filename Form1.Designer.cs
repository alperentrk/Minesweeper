namespace deneme3
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxGrid = new System.Windows.Forms.TextBox();
            this.textBoxKullanici = new System.Windows.Forms.TextBox();
            this.textBoxMayin = new System.Windows.Forms.TextBox();
            this.BaslaBttn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(183, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "MAYIN TARLASI OYUNU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(185, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kenar Sayısı ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(338, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kullanıcı Adı";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(507, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mayın Sayısı";
            // 
            // textBoxGrid
            // 
            this.textBoxGrid.Location = new System.Drawing.Point(190, 240);
            this.textBoxGrid.Name = "textBoxGrid";
            this.textBoxGrid.Size = new System.Drawing.Size(100, 22);
            this.textBoxGrid.TabIndex = 4;
            // 
            // textBoxKullanici
            // 
            this.textBoxKullanici.Location = new System.Drawing.Point(317, 152);
            this.textBoxKullanici.Name = "textBoxKullanici";
            this.textBoxKullanici.Size = new System.Drawing.Size(165, 22);
            this.textBoxKullanici.TabIndex = 5;
            // 
            // textBoxMayin
            // 
            this.textBoxMayin.Location = new System.Drawing.Point(512, 240);
            this.textBoxMayin.Name = "textBoxMayin";
            this.textBoxMayin.Size = new System.Drawing.Size(100, 22);
            this.textBoxMayin.TabIndex = 6;
            // 
            // BaslaBttn
            // 
            this.BaslaBttn.BackColor = System.Drawing.Color.Silver;
            this.BaslaBttn.Location = new System.Drawing.Point(328, 295);
            this.BaslaBttn.Name = "BaslaBttn";
            this.BaslaBttn.Size = new System.Drawing.Size(147, 77);
            this.BaslaBttn.TabIndex = 8;
            this.BaslaBttn.Text = "OYNA";
            this.BaslaBttn.UseVisualStyleBackColor = false;
            this.BaslaBttn.Click += new System.EventHandler(this.BaslaBttn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BaslaBttn);
            this.Controls.Add(this.textBoxMayin);
            this.Controls.Add(this.textBoxKullanici);
            this.Controls.Add(this.textBoxGrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxGrid;
        private System.Windows.Forms.TextBox textBoxKullanici;
        private System.Windows.Forms.TextBox textBoxMayin;
        private System.Windows.Forms.Button BaslaBttn;
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace deneme3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BaslaBttn_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBoxGrid.Text) || string.IsNullOrWhiteSpace(textBoxKullanici.Text) || string.IsNullOrWhiteSpace(textBoxMayin.Text))
            {
                MessageBox.Show("Lütfen tüm bu alanları doldurun!");
                return;
            }

            if (!int.TryParse(textBoxGrid.Text, out int sayiGrid) || !int.TryParse(textBoxMayin.Text, out int sayiMayin))
            {
                MessageBox.Show("Lütfen Geçerli Bir Sayi Giriniz!!");
                return;
            }

            if (sayiGrid < 5 || sayiGrid > 30)
            {
                MessageBox.Show("Kenar Sayi Değeri 5 ile 30 Arasında Olmalıdır!!");
                return ;   
            }

            if(sayiMayin<10)
            {
                MessageBox.Show("Mayın Sayısı En Az 10 Olmalıdır!!");
                return;
            }

            


            Form form2 = new Form2(textBoxKullanici.Text, sayiGrid, sayiMayin);
            form2.Show();
            this.Hide();
            form2.FormClosed += (s, args) => Application.Exit();
        }
    }
}

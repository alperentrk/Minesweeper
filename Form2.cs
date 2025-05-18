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
    public partial class Form2 : Form
    {
        private string kullaniciAdi;
        private int sayiGrid;
        private int sayiMayin;

        private Scoreboard scoreboard;

        public Form2(string kullaniciAdi, int sayiGrid, int sayiMayin)
        {
            this.kullaniciAdi = kullaniciAdi;
            this.sayiGrid = sayiGrid;
            this.sayiMayin = sayiMayin;
            this.scoreboard = new Scoreboard();

            InitializeComponent();
            StartGame();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void StartGame()
        {
            Oyun oyun = new Oyun(kullaniciAdi ,sayiGrid, sayiMayin, this, scoreboard);
            oyun.OyunModOn();
        }
    }
}

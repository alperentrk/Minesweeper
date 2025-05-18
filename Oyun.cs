using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;


//SORNASINDA SKORBOARD SKOR SÜRE 

namespace deneme3
{
    public class Oyun
    {   
        public string kullaniciAdi {  get; set; }
        public int SayiMayin { get; set; }
        public int SayiGrid {  get; set; }
        private Form2 form;

        public Button[,] buttons;
        private Random random = new Random();
        private Panel panel = new Panel();
        private Timer timer = new Timer();

        private int HamleSayisi = 0;
        Label Hamle = new Label();

        private int skor = 0;

        public int buttonSize;

        Label labelsure = new Label();
        private System.Windows.Forms.Timer zamanlayici;
        private int GecenZaman = 0;

        private Scoreboard scoreboard;


        public Oyun(string kullaniciAdi,int sayiGrid,int sayiMayin, Form2 form2, Scoreboard scoreboard) 
        {         
            this.kullaniciAdi = kullaniciAdi;
            this.SayiMayin = sayiMayin;
            this.SayiGrid = sayiGrid;
            this.form = form2;
            this.scoreboard = scoreboard;
        }

        public void OyunModOn()
        {
            btnOlustur();
            MayinRastgele();
            PanelMod();
            FormNesneler();
            ZamanBaslat();
            zamanlayici.Start();   
        }


        public void btnOlustur()
        {

            if(SayiGrid < 10)
            {
                buttonSize = 40;
            }
            else if (SayiGrid < 25)
            {
                buttonSize = 30;
            }
            else
            {
                buttonSize = 20;
            }


            buttons = new Button[SayiGrid,SayiGrid];


            for (int i = 0; i < SayiGrid; i++)
            { 
                for (int j = 0; j < SayiGrid; j++)
                {
                    Button button = new Button
                    {
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(i * buttonSize, j * buttonSize),
                        Tag = "safe", 
                    };

                    button.Click += Btn_Click;
                    button.MouseDown += Btn_RightClick;
                    button.ForeColor = Color.White;

                    buttons[i, j] = button;
                    panel.Controls.Add(button);
                }
            }     
        }

        private void ZamanBaslat()
        {
            zamanlayici= new System.Windows.Forms.Timer();
            zamanlayici.Interval = 1000;
            zamanlayici.Tick += SaniyeArttir;
        }

        private void SaniyeArttir(object sender, EventArgs e)
        {
            GecenZaman++;
            ZamanGuncelle();
        }
        public int dakika;
        public int saniye;
        private void ZamanGuncelle()
        {
            dakika = GecenZaman / 60;
            saniye = GecenZaman % 60;
            labelsure.Text = "Geçen Süre=" + dakika + "." + saniye;
        }

        private void zamanDurdur()
        {
            zamanlayici.Stop();
        }

        private void MayinRastgele()
        {
            int eklenenMayin = 0;

            while (eklenenMayin < SayiMayin)
            {
                int x = random.Next(0, SayiGrid);
                int y = random.Next(0, SayiGrid);

                if (buttons[x, y].Tag.ToString() != "mine")
                {
                    buttons[x, y].Tag = "mine";
                    eklenenMayin++;
                }
            }
        }

        


        private void PanelMod()
        {
            panel.Size = new Size(SayiGrid * buttonSize, SayiGrid * buttonSize);
            panel.Location = new Point(0, 0);
            form.Controls.Add(panel);
            

            form.Size = new Size(SayiGrid * buttonSize + 200, SayiGrid * buttonSize + 100);
        }

        private int bayrakliMayin = 0;

        private void Btn_RightClick(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Right)
            {
                Button clickedButton = (Button)sender;
                if (clickedButton.Text == "🚩")
                {
                    clickedButton.Text = ""; 

                    if(clickedButton.Tag.ToString() == "mine")
                    {
                        bayrakliMayin--;
                    }
                }
                else
                {
                    clickedButton.Text = "🚩"; 
                    clickedButton.ForeColor = Color.Green;

                    if(clickedButton.Tag.ToString() == "mine")
                    {
                        bayrakliMayin++;
                    }
                }

                if(bayrakliMayin == SayiMayin)
                {                    
                    foreach (Button btn in buttons)
                    {
                        btn.Enabled = false;
                    }

                    zamanDurdur();

                    int skor = scoreboard.skorHesapla(bayrakliMayin, GecenZaman);

                    MessageBox.Show($"Tebrikler Tüm Mayınları Doğru İşaretlediniz! Skorunuz: {skor}");
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;

            if (clickedButton.Text != "🚩")
            {
                if (clickedButton.Tag.ToString() == "mine")
                {
                    clickedButton.Text = "💣";

                    foreach (Button btn in buttons)
                    {
                        if (btn.Tag.ToString() == "mine")
                        {
                            btn.BackColor = Color.Red;
                            btn.ForeColor = Color.Black;
                            btn.Text = "💣";
                            btn.Enabled = false;
                        }
                        else if (btn.Tag.ToString() == "safe")
                        {
                            btn.Enabled = false;
                        }
                    }

                    zamanDurdur();

                    int skor = scoreboard.skorHesapla(bayrakliMayin, GecenZaman);

                    MessageBox.Show($"GameOver! Mayına bastınız. Skorunuz: {skor}"); 
                }
                else
                {
                    HamleSayisi++;
                    Hamle.Text = $"Hamle Sayısı = {HamleSayisi}";
                    KomsuAc(clickedButton);
                    clickedButton.BackColor = Color.Gray;
                }
            }
        }


        private void KomsuAc(Button button)
        {
            if (button.Enabled && (string)button.Tag != "mine")
            {
                int minesAround = CountMinesAround(button);

                if (minesAround != 0)
                {
                    button.Text = minesAround.ToString();
                    button.Enabled = false;
                }
                else
                {
                    button.Text = "";
                    button.Enabled = false;

                    int[,] dizi = new int[4, 2];

                    dizi[0, 0] = button.Location.X / buttonSize;
                    dizi[0, 1] = (button.Location.Y / buttonSize - 1) < 0 ? 0 : button.Location.Y / buttonSize - 1;

                    dizi[1, 0] = (button.Location.X / buttonSize - 1) < 0 ? 0 : button.Location.X / buttonSize - 1;
                    dizi[1, 1] = button.Location.Y / buttonSize;

                    dizi[2, 0] = (button.Location.X / buttonSize + 1) > SayiGrid - 1 ? SayiGrid - 1 : button.Location.X / buttonSize + 1;
                    dizi[2, 1] = button.Location.Y / buttonSize;

                    dizi[3, 0] = button.Location.X / buttonSize;
                    dizi[3, 1] = (button.Location.Y / buttonSize + 1) > SayiGrid - 1 ? SayiGrid - 1 : button.Location.Y / buttonSize + 1;


                    for (int i = 0; i < 4; i++)
                    {
                        KomsuAc(buttons[dizi[i, 0], dizi[i, 1]]);
                    }
                }
            }
        }

        private int CountMinesAround(Button button)
        {
            int count = 0;

            int X_1 = (button.Location.X / buttonSize - 1) < 0 ? 0 : (button.Location.X / buttonSize - 1);
            int X_2 = (button.Location.X / buttonSize + 1) > SayiGrid - 1 ? SayiGrid - 1 : (button.Location.X / buttonSize + 1);
            int Y_1 = (button.Location.Y / buttonSize - 1) < 0 ? 0 : (button.Location.Y / buttonSize - 1);
            int Y_2 = (button.Location.Y / buttonSize + 1) > SayiGrid - 1 ? SayiGrid - 1 : (button.Location.Y / buttonSize + 1);

            for (int i = X_1; i <= X_2; i++)
            {
                for(int j = Y_1; j <= Y_2; j++)
                {
                    Button buttonNext = buttons[i, j];

                    if (buttonNext.Tag.ToString() == "mine")
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        


        private void FormNesneler()
        {
            Label senginer = new Label();
            senginer.AutoSize = true;
            senginer.Location = new Point((SayiGrid * buttonSize / 2) - 87, (SayiGrid * buttonSize) + 5);
            senginer.Text = "sengText";
            senginer.Size = new Size(340, 65);
            senginer.Text = "Yazılımcı: Alperen Türk\r\nOkul Numarası:230229019\r\n";

            
            Hamle.AutoSize = true;
            Hamle.Name = "HamleLabel";
            Hamle.Location = new Point((SayiGrid * buttonSize + 30), 30);
            Hamle.Text = $"Hamle Sayısı : {HamleSayisi}";


            labelsure.AutoSize = true;
            labelsure.Location = new Point((SayiGrid * buttonSize + 30), 60);
            labelsure.Size = new Size(150, 50);
            labelsure.Text = "Geçen Süre=" + dakika + "." + saniye;


            form.Controls.Add(senginer);
            form.Controls.Add(Hamle);
            form.Controls.Add(labelsure);

        }
    }
}

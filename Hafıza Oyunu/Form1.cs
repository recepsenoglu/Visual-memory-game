using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hafıza_Oyunu                           // Written by Recep Oğuzhan Şenoğlu
                                                // Recep Oğuzhan Şenoğlu tarafından yazılmıştır
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           
            picturebox[0] = pictureBox1;
            picturebox[1] = pictureBox2;
            // Tüm pictureboxları diziye atıyoruz
            all_pictureboxes[0] = pictureBox1;
            all_pictureboxes[1] = pictureBox2;
            all_pictureboxes[2] = pictureBox3;
            all_pictureboxes[3] = pictureBox4;
            all_pictureboxes[4] = pictureBox5;
            all_pictureboxes[5] = pictureBox6;
            all_pictureboxes[6] = pictureBox7;
            all_pictureboxes[7] = pictureBox8;
            all_pictureboxes[8] = pictureBox9;
            all_pictureboxes[9] = pictureBox10;
            all_pictureboxes[10] = pictureBox11;
            all_pictureboxes[11] = pictureBox12;
            all_pictureboxes[12] = pictureBox13;
            all_pictureboxes[13] = pictureBox14;
            all_pictureboxes[14] = pictureBox15;
            all_pictureboxes[15] = pictureBox16;
            all_pictureboxes[16] = pictureBox17;
            all_pictureboxes[17] = pictureBox18;
            all_pictureboxes[18] = pictureBox19;
            all_pictureboxes[19] = pictureBox20;
            all_pictureboxes[20] = pictureBox21;
            all_pictureboxes[21] = pictureBox22;
            all_pictureboxes[22] = pictureBox23;
            all_pictureboxes[23] = pictureBox24;
            all_pictureboxes[24] = pictureBox25;
            all_pictureboxes[25] = pictureBox26;
            all_pictureboxes[26] = pictureBox27;
            all_pictureboxes[27] = pictureBox28;
            all_pictureboxes[28] = pictureBox29;
            all_pictureboxes[29] = pictureBox30;
            all_pictureboxes[30] = pictureBox31;
            all_pictureboxes[31] = pictureBox32;
            all_pictureboxes[32] = pictureBox33;
            all_pictureboxes[33] = pictureBox34;
            all_pictureboxes[34] = pictureBox35;
            all_pictureboxes[35] = pictureBox36;
            all_pictureboxes[36] = pictureBox37;
            all_pictureboxes[37] = pictureBox38;
            all_pictureboxes[38] = pictureBox39;
            all_pictureboxes[39] = pictureBox40;

            Random_Image();
        }

        // Gerekli değişkenleri yaratıyoruz
        PictureBox[] picturebox = new PictureBox[2];
        PictureBox[] all_pictureboxes = new PictureBox[40];
        string dir = Directory.GetCurrentDirectory();
        bool secim1 = false;
        int oyuncu1_puan = 0;
        int oyuncu2_puan = 0;
        bool oyuncu1_sirasi = true;
        int[] resim_dizisi = new int[40];
        bool breaker = false;
        int index = 0;
        int second = 5;
        int second2 = 0;
        int second3 = 0;
        int second4 = 0;
        bool sil = false;
        string name = "";
        string name2 = "";

        private void Sil2(PictureBox a, PictureBox b) // Seçilen aynı pictureboxları ekrandan kaybetme metodu
        {
            a.Visible = false;
            b.Visible = false;
        }
        private void Show_All() // Tüm resimleri gösterme metodu
        {
            for (int i = 0; i < 40; i++)
            {
                all_pictureboxes[i].Image = Image.FromFile(dir + @"\\Images\\" + resim_dizisi[i] + ".jpg");
            }
        }
        private void Unable_One(PictureBox n) // 1. secilen resme tıklanmasını engelleyen metod
        {
            n.Enabled = false;
        }
        private void Unable_All(bool c) // Tüm pictureboxlara tıklanmayı engelleyen metod
        {
            for (int i = 0; i < 40; i++)
            {
                if (c)
                {
                    all_pictureboxes[i].Enabled = false;
                }
                else if (c == false)
                {
                    all_pictureboxes[i].Enabled = true;
                }
            }
        }
        private void hepsini_kapat(PictureBox c, PictureBox d) // Açılan resimleri kapatma metodu
        {
            c.Image = Image.FromFile(dir + @"\Images\kapak.jpg");
            d.Image = Image.FromFile(dir + @"\Images\kapak.jpg");
        }
        private void Random_Image() // Rastgele resim seçme metodu
        {
            resim_dizisi = new int[40];
            breaker = false;
            index = 0;
            while (true)
            {
                breaker = false;
                Random random = new Random();
                int sayi = random.Next(1, 41);
                for (int i = 0; i < 40; i++)
                {
                    if (sayi == resim_dizisi[i])
                    {
                        breaker = true;
                        break;
                    }
                }
                if (breaker) continue;
                resim_dizisi[index] = sayi;
                index++;
                if (index == 40) break;
            }
        }
        private void karsilastir(PictureBox e, PictureBox f) // Seçilen 2 resim aynı oluğ olmadığını kontrol eden metod
        {
            secim1 = false;

            if ((e.Image.Height == f.Image.Height) && (e.Image.Width == f.Image.Width))
            {
                // doğru
                this.BackColor = Color.Green;
                sil = true;
                if (oyuncu1_sirasi) oyuncu1_puan++;
                else oyuncu2_puan++;
                if (oyuncu1_puan == 11)
                {
                    panel1.Visible = true;
                    panel2.Visible = false;
                    label7.Text = name + " won the game !";
                }
                else if (oyuncu2_puan == 11)
                {
                    panel1.Visible = true;
                    panel2.Visible = false;
                    label7.Text = name2 + " won the game !";
                }
                label8.Text = oyuncu1_puan.ToString();
                label9.Text = oyuncu2_puan.ToString();
            }
            else
            {
                //yanlış
                this.BackColor = Color.Red;
                if (oyuncu1_sirasi) oyuncu1_sirasi = false;
                else oyuncu1_sirasi = true;
            }
        }
        private void Kontrol(PictureBox h, int j)
        {
            Resim_Koy(h, j);
            if (secim1 != true)
            {
                Unable_All(true);
                label_second.Text = "5";
                Unable_One(h);
                timer1.Start();
                timer4.Start();
                picturebox[0] = h;
                secim1 = true;
            }
            else
            {
                picturebox[1] = h;
                karsilastir(picturebox[0], picturebox[1]);

                timer1.Stop();
                timer2.Start();
                Unable_All(true);
            }
        }
        private void Resim_Koy(PictureBox f, int g) // Pictureboxlara resim koyan metod
        {
            f.Image = Image.FromFile(dir + @"//Images//" + resim_dizisi[g - 1] + ".jpg");
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (second < 0)
            {
                second = 5;
            }
            else if (second == 0)
            {
                if (oyuncu1_sirasi) oyuncu1_sirasi = false;
                else oyuncu1_sirasi = true;
                hepsini_kapat(picturebox[0], picturebox[1]);
                Unable_All(false);
                secim1 = false;
                second = 6;
                timer1.Stop();
            }
            second--;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            second2++;
            if (second2 == 2)
            {
                hepsini_kapat(picturebox[0], picturebox[1]);
                label_second.Text = "5";
                if (sil)
                {
                    Sil2(picturebox[0], picturebox[1]);
                    sil = false;
                }
                second = -1;
                Unable_All(false);
                if (oyuncu1_sirasi) this.BackColor = Color.Gold;
                else this.BackColor = Color.Tan;
            }
            else if (second2 > 2)
            {
                second2 = 0;
                timer2.Stop();
            }
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (second != -1) label_second.Text = second.ToString();

            if (oyuncu1_sirasi) label1.Text = name + "'s Turn";
            else label1.Text = name2 + "'s Turn";

            if (second2 > 3)
            {
                hepsini_kapat(picturebox[0], picturebox[1]);
                second = -1;
                second2 = 0;
                timer2.Stop();
            }
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (second3 >= 5)
            {
                Unable_All(false);
                second3 = 0;
                timer4.Stop();
            }
            second3++;
        }
        private void timer5_Tick(object sender, EventArgs e)
        {
            second4++;

            if (second4 == 5)
            {
                for (int i = 0; i < 40; i++)
                {
                    all_pictureboxes[i].Image = Image.FromFile(dir + @"\Images\kapak.jpg");
                }
                Unable_All(false);
                timer5.Stop();
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (textBox2.Text != "")
                    button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Unable_All(true);
            Show_All();
            timer5.Start();
            this.BackColor = Color.Gold;
            panel1.Visible = false;
            name = textBox1.Text;
            name2 = textBox2.Text;
            label3.Text = name + "'s Score: ";
            label4.Text = name2 + "'s Score: ";
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox1.Text != "") button2.Enabled = true;
            else button2.Enabled = false;
        }
        // Gerisi referans işlemleri
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox1, 1);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox2, 2);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox3, 3);
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox4, 4);
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox5, 5);
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox6, 6);
        }
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox7, 7);
        }
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox8, 8);
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox9, 9);
        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox10, 10);
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox11, 11);
        }
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox12, 12);
        }
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox13, 13);
        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox14, 14);
        }
        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox15, 15);
        }
        private void pictureBox16_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox16, 16);
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox17, 17);
        }
        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox18, 18);
        }
        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox19, 19);
        }
        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox20, 20);
        }
        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox21, 21);
        }
        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox22, 22);
        }
        private void pictureBox23_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox23, 23);
        }
        private void pictureBox24_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox24, 24);
        }
        private void pictureBox25_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox25, 25);
        }
        private void pictureBox26_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox26, 26);
        }
        private void pictureBox27_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox27, 27);
        }
        private void pictureBox28_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox28, 28);
        }
        private void pictureBox29_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox29, 29);
        }
        private void pictureBox30_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox30, 30);
        }
        private void pictureBox31_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox31, 31);
        }
        private void pictureBox32_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox32, 32);
        }
        private void pictureBox33_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox33, 33);
        }
        private void pictureBox34_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox34, 34);
        }
        private void pictureBox35_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox35, 35);
        }
        private void pictureBox36_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox36, 36);
        }
        private void pictureBox37_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox37, 37);
        }
        private void pictureBox38_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox38, 38);
        }
        private void pictureBox39_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox39, 39);
        }
        private void pictureBox40_Click(object sender, EventArgs e)
        {
            Kontrol(pictureBox40, 40);
        }
    }
}
// Written by Recep Oğuzhan Şenoğlu
// Recep Oğuzhan Şenoğlu tarafından yazılmıştır


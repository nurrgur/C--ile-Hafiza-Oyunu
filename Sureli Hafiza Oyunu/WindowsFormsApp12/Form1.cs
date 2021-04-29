using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp12

{
    public partial class Form1 : Form
    {
        private int zaman;
        Image[] resimler ={
            Properties.Resources._5a24123c6003f508dd5d5b39,
            Properties.Resources._1496184260OMG_Emoji_Png_transparent_background,
            Properties.Resources.smiley_face_emoji_with_no_background_150471_9989002,
            Properties.Resources.Sad_Face_Emoji,
            Properties.Resources.Heart_Eyes,
            Properties.Resources.indir
        };

        int[] index = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
        PictureBox ilkkutu;
        int ilkindex, bulunan, deneme;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            zaman = 150;
            label1.Text = zaman.ToString();

            resimlerikarsilastir();
         


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            zaman--;
            label1.Text = zaman.ToString();
            if (zaman == 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("süre bitti");
                Application.Exit();
            }
        }

        public void resimlerikarsilastir()
        {
            Random random = new Random();
            for(int i = 0; i < 12; i++)
            {
                int sayi = random.Next(12);
                int a = index[i];
                index[i] = index[sayi];
                index[sayi] = a;
            }

        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            
 PictureBox kutu = (PictureBox)sender;
            int kutuno = int.Parse(kutu.Name.Substring(10));
            int indexno = index[kutuno - 1];
            kutu.Image = resimler[indexno];
            kutu.Refresh();
            


            if (ilkkutu == null)
            {
                ilkkutu = kutu;
                ilkindex = indexno;
                deneme++;
            }
            else
            {
                System.Threading.Thread.Sleep(750);
                ilkkutu.Image = null;
                kutu.Image = null;
                if (ilkindex == indexno)
                {
                    bulunan++;
                    ilkkutu.Visible = false;
                    kutu.Visible = false;
                    if (bulunan == 6)
                    {
                        MessageBox.Show("TEBRİKLER KAZANDINIZ"+deneme+" DENEMEDE");
                        Application.Exit();
                        bulunan = 0;
                        deneme = 0;
                        foreach(Control kontrol in Controls)
                        {
                            kontrol.Visible = true;
                        }
                        resimlerikarsilastir();
                    }
                }
                ilkkutu = null;
            }
        }
        
        }
    }

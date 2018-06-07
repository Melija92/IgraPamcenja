using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgraPamcenja
{
    public partial class IgraPamcenja : Form
    {
        PictureBox prethodna;
        byte stanje;
        int preostaloParova;
        byte preostaloVremena = 60;

        public IgraPamcenja()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PokreniIgru();
        }

        private void PokreniIgru()
        {
            preostaloParova = 8;
            PostaviRandomTag();

            foreach (Control p in this.Controls)
            {
                if (p is PictureBox)
                    (p as PictureBox).Visible = true;
            }

            foreach (Control p in this.Controls)
            {
                if (p is PictureBox)
                    (p as PictureBox).Image = Properties.Resources.upitnik;
            }

            PreostalihParova.Text = "Preostalih parova: " + preostaloParova;
            stanje = 0;
            preostaloVremena = 60;
            PreostaloVrijeme.Text = "Preostalo vrijeme: " + preostaloVremena;
            brojac.Enabled = true;
            Aktiviraj();
        }
        void showImage(PictureBox box)
        {
            switch (Convert.ToInt32(box.Tag))
            {
                case 1:
                    box.Image = Properties.Resources.konj;
                    break;
                case 2:
                    box.Image = Properties.Resources.kornjaca;
                    break;
                case 3:
                    box.Image = Properties.Resources.krava;
                    break;
                case 4:
                    box.Image = Properties.Resources.lav;
                    break;
                case 5:
                    box.Image = Properties.Resources.macka;
                    break;
                case 6:
                    box.Image = Properties.Resources.pas;
                    break;
                case 7:
                    box.Image = Properties.Resources.ptica;
                    break;
                case 8:
                    box.Image = Properties.Resources.svinja;
                    break;
                default:
                    box.Image = Properties.Resources.upitnik;
                    break;
            }

        }
        void Aktiviraj()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox) (x as PictureBox).Enabled = true;
            } 
        }
        void Deaktiviraj()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox) (x as PictureBox).Enabled = false;
            } 
        }

        private void PostaviRandomTag()
        {
            int[] arr = new int[16];
            int index = 0;
            Random rand = new Random();
            int r;
            while (index < 16)
            {
                r = rand.Next(1, 17);
                if (Array.IndexOf(arr, r) == -1)
                {
                    arr[index] = r;
                    index++;
                }
            }
            for (index = 0; index < 16; index++)
            {
                if (arr[index] > 8) arr[index] -= 8;
            }
            index = 0;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    (x as PictureBox).Tag = arr[index].ToString();
                    index++;
                }
            }
        }
        private void KlikNaSliku(object sender, EventArgs e)
        {
            PictureBox trenutna = (sender as PictureBox);
            showImage((sender as PictureBox));
            if (stanje == 0)
            {
                prethodna = trenutna;
                stanje = 1;
            }
            else if (prethodna != trenutna)
            {
                UsporediSlike(prethodna, trenutna);
                stanje = 0;
            }
        }

        private void UsporediSlike(PictureBox prvaSlika, PictureBox drugaSlika)
        {
            if (prvaSlika.Tag.ToString() == drugaSlika.Tag.ToString())
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                if (--preostaloParova == 0)
                {
                    brojac.Enabled = false;
                    PreostalihParova.Text = "Čestitamo!";
                    MessageBox.Show("Čestitamo, pobijedili ste!", "Završetak igre!");
                }
                else PreostalihParova.Text = "Preostalih parova" + preostaloParova;
            }
            else
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
                prvaSlika.Image = Properties.Resources.upitnik;
                drugaSlika.Image = Properties.Resources.upitnik;
            }
        }

        private void brojacVremena(object sender, EventArgs e)
        {

            if (--preostaloVremena == 0)
            {
                brojac.Enabled = !brojac.Enabled;
                PreostaloVrijeme.Text = "Vrijeme je isteklo.";
                MessageBox.Show("Vrijeme je isteklo", "Kraj igre!");
                Deaktiviraj();

            }
            else
            {
                if(preostaloVremena < 15)
                {
                    PreostaloVrijeme.ForeColor = Color.Red;
                }
                PreostaloVrijeme.Text = "Preostalo vrijeme: " + preostaloVremena;

            }
        }
    }
}

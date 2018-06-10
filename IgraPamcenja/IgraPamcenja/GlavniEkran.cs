using IgraPamcenja.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IgraPamcenja
{
    public partial class GlavniEkran : Form
    {
        public int BrojPreostalihParova { get; set; } = 8;

        Dictionary<String, Bitmap> slikePoTagu = new Dictionary<String, Bitmap>();
        public Boolean PrvaSlikaKliknuta { get; set; } = true;
        public PictureBox ProslaSlika { get; set; }
        public UnosImena UnosImena { get; set; }
        public int MaxBrojBodova { get; set; } = 0;
        public GlavniEkran()
        {
            InitializeComponent();

            BrojPreostalihParova = 8;
            this.brojPreostalihParova.Text += " " + BrojPreostalihParova.ToString();


            foreach (Control slika in this.Controls)
            {
                if (slika is PictureBox)
                    (slika as PictureBox).Image = Resources.upitnik;
            }

            PostaviRandomTagoveNaSlike();

            PostaviRandomSlikeUDictionary();

            UnosImena = new UnosImena();
            UnosImena.ShowDialog();

            this.imeIgraca.Text = "Igrač:\n" + UnosImena.ImeIgraca;
        }

        private void PostaviRandomTagoveNaSlike()
        {
            List<int> brojSlika = new List<int>();
            Random random = new Random();

            for (int i = 0; i < 16; i++)
            {
                var randomBroj = random.Next(1, 9);
                if (brojSlika.Count(a => a == randomBroj) > 1)
                {
                    while (brojSlika.Count(a => a == randomBroj) > 1)
                    {
                        randomBroj = random.Next(1, 9);
                        if (brojSlika.Count(a => a == randomBroj) > 1)
                            continue;
                        else
                        {
                            brojSlika.Add(randomBroj);
                            break;
                        }

                    }
                }
                else
                {
                    brojSlika.Add(randomBroj);
                }

            }

            foreach (Control slika in this.Controls)
            {
                if(slika is PictureBox)
                {
                    (slika as PictureBox).Tag = brojSlika.Last();
                    brojSlika.RemoveAt(brojSlika.Count - 1);
                }
            }
        }
        private void KlikNaSliku(object sender, EventArgs e)
        {
            PrikaziSlikuIzDictionarya(sender);
            PictureBox trenutnaSlika = (sender as PictureBox);


            if (PrvaSlikaKliknuta)
            {
                ProslaSlika = trenutnaSlika;
                PrvaSlikaKliknuta = false;
            }
            else if (ProslaSlika != trenutnaSlika)
            {
                if (ProslaSlika.Tag.ToString() == trenutnaSlika.Tag.ToString())
                {
                    MaxBrojBodova += 100;
                    this.brojBodova.Text = MaxBrojBodova.ToString();
                    Application.DoEvents();
                    Thread.Sleep(1000);

                    BrojPreostalihParova -= 1;

                    if (BrojPreostalihParova == 0)
                    {
                        brojPreostalihParova.Text = "Čestitamo na pobjedi\n" + UnosImena.ImeIgraca + " osvojio si " + MaxBrojBodova + " bodova";
                    }
                    else
                        brojPreostalihParova.Text = "Broj preostalih parova: " + BrojPreostalihParova;
                }
                else
                {
                    MaxBrojBodova -= 50;
                    this.brojBodova.Text = MaxBrojBodova.ToString();
                    Application.DoEvents();
                    Thread.Sleep(1000);
                    ProslaSlika.Image = Resources.upitnik;
                    trenutnaSlika.Image = Resources.upitnik;
                }


                PrvaSlikaKliknuta = true;
            }
        }

        private void PostaviRandomSlikeUDictionary()
        {
            PropertyInfo[] props = typeof(Resources).GetProperties(BindingFlags.NonPublic | BindingFlags.Static);
            var slikeIzResursa = props.Where(prop => prop.PropertyType == typeof(Bitmap)).Select(prop => prop.GetValue(null, null) as Bitmap).ToArray();
            
            Random r = new Random();
            List<int> generiraniBrojevi = new List<int>();

            for (int i = 1; i < 9; i++)
            {
                int randomSlika = r.Next(slikeIzResursa.Length);
                if (generiraniBrojevi.Contains(randomSlika) || slikeIzResursa[randomSlika].Flags == 73746)
                {
                    while (generiraniBrojevi.Contains(randomSlika) || slikeIzResursa[randomSlika].Flags == 73746)
                    {
                        randomSlika = r.Next(slikeIzResursa.Length);
                    }
                }
                generiraniBrojevi.Add(randomSlika);
                slikePoTagu.Add(i.ToString(), slikeIzResursa[randomSlika]);
            }
        }

        private void PrikaziSlikuIzDictionarya(object sender)
        {
            var slika = sender as PictureBox;
            switch (Convert.ToInt32(slika.Tag))
            {
                case 1:
                    slika.Image = slikePoTagu[slika.Tag.ToString()];
                    break;
                case 2:
                    slika.Image = slikePoTagu[slika.Tag.ToString()];
                    break;
                case 3:
                    slika.Image = slikePoTagu[slika.Tag.ToString()];
                    break;
                case 4:
                    slika.Image = slikePoTagu[slika.Tag.ToString()];
                    break;
                case 5:
                    slika.Image = slikePoTagu[slika.Tag.ToString()];
                    break;
                case 6:
                    slika.Image = slikePoTagu[slika.Tag.ToString()];
                    break;
                case 7:
                    slika.Image = slikePoTagu[slika.Tag.ToString()];
                    break;
                case 8:
                    slika.Image = slikePoTagu[slika.Tag.ToString()];
                    break;
                default:
                    slika.Image = Resources.upitnik;
                    break;
            }
        }
    }
}

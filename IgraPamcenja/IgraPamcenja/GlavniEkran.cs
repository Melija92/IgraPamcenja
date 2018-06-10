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
        public int BrojPreostalihParova { get; set; }

        Dictionary<String, Bitmap> slikePoTagu = new Dictionary<String, Bitmap>();
        public Boolean PrvaSlikaKliknuta { get; set; } = true;
        public PictureBox ProslaSlika { get; set; }
        public UnosImena UnosImena { get; set; }
        public int MaxBrojBodova { get; set; } = 0;
        public int BrojPoteza { get; set; }
        private string[] zabranjeneSlikeZaNiziNivo = { "slika1", "slika2", "slika3", "slika4", "slika13", "slika14", "slika15", "slika16" };
        public GlavniEkran()
        {
            InitializeComponent();


            foreach (Control slika in this.Controls)
            {
                if (slika is PictureBox)
                    (slika as PictureBox).Image = Resources.upitnik;
            }

            UnosImena = new UnosImena();
            UnosImena.ShowDialog();

            PostaviRandomTagoveNaSlike();

            PostaviRandomSlikeUDictionary();

            BrojPreostalihParova = 8;
            if (UnosImena.Tezina == "Lagano")
            {
                BrojPreostalihParova = 4;
                this.slika1.Visible = false;
                this.slika2.Visible = false;
                this.slika3.Visible = false;
                this.slika4.Visible = false;
                this.slika13.Visible = false;
                this.slika14.Visible = false;
                this.slika15.Visible = false;
                this.slika16.Visible = false;

            }
            this.brojPreostalihParova.Text += " " + BrojPreostalihParova.ToString();


            this.imeIgraca.Text = "Igrač:\n" + UnosImena.ImeIgraca;
        }

        private void PostaviRandomTagoveNaSlike()
        {
            List<int> brojSlika = new List<int>();
            Random random = new Random();

            int maxTesko = 16;
            int maxRandomBroj = 9;

            if(UnosImena.Tezina == "Lagano")
            {
                maxTesko = 8;
                maxRandomBroj = 5;
            }

            for (int i = 0; i < maxTesko; i++)
            {
                var randomBroj = random.Next(1, maxRandomBroj);
                if (brojSlika.Count(a => a == randomBroj) > 1)
                {
                    while (brojSlika.Count(a => a == randomBroj) > 1)
                    {
                        randomBroj = random.Next(1, maxRandomBroj);
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
                if(UnosImena.Tezina == "Lagano")
                {
                    if (slika is PictureBox && !zabranjeneSlikeZaNiziNivo.Contains(slika.Name))
                    {
                        (slika as PictureBox).Tag = brojSlika.Last();
                        brojSlika.RemoveAt(brojSlika.Count - 1);
                    }
                }

                if (slika is PictureBox)
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
                BrojPoteza += 1;
                if (ProslaSlika.Tag.ToString() == trenutnaSlika.Tag.ToString())
                {
                    MaxBrojBodova += 100;
                    this.brojBodova.Text = "Broj bodova: " + MaxBrojBodova.ToString();
                    this.listBox1.Items.Add(BrojPoteza + "." + MaxBrojBodova + " - Pogodio!");
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
                    this.brojBodova.Text = "Broj bodova: " + MaxBrojBodova.ToString();
                    this.listBox1.Items.Add(BrojPoteza + "." + MaxBrojBodova + " - Promašio");
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

            int maxBroj = 9;
            if (UnosImena.Tezina == "Lagano")
                maxBroj = 5;

            for (int i = 1; i < maxBroj; i++)
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

using System;
using System.Windows;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows.Media;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Matikkapeli
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // "Globaalit" muuttujat
        int[] taul_vas = new int[10];
        int[] taul_oik = new int[10];
        int[] taul_res = new int[10];
        short pisteet = 0,
              valinta = 0;
        char operaattori = '+';
        bool muokkaus = false,
             nayta_oikeat = false;

        // ala- ja yläraja-arvot == KESKITASO
        short summa_yla = 101, // -1
              summa_ala = 1;
        short erotus_yla_vas = 101, // -1
              erotus_yla_oik = 51, // -1
              erotus_ala_vas = 50,
              erotus_ala_oik = 5;
        short kerto_yla_vas = 21, // -1
              kerto_yla_oik = 13, // -1
              kerto_ala = 1;
        short jako_yla_vas = 101, // -1
              jako_yla_oik = 51, // -1
              jako_ala_vas = 50,
              jako_ala_oik = 5;

        public MainWindow()
        {
            InitializeComponent();
            restart_summa();
        }

        private void tulosta()
        {
            //valitaan oikea operaattori
            if (valinta == 0)
            {
                operaattori = '+';
            }
            else if (valinta == 1)
            {
                operaattori = '-';
            }
            else if (valinta == 2)
            {
                operaattori = 'x';
            }
            else if (valinta == 3)
            {
                operaattori = '/';
            }
            else
            {
                operaattori = '?';
            }
            // tulostetaan kysymykset
            label_kys1.Content = taul_vas[0] + " " + operaattori + " " + taul_oik[0];
            label_kys2.Content = taul_vas[1] + " " + operaattori + " " + taul_oik[1];
            label_kys3.Content = taul_vas[2] + " " + operaattori + " " + taul_oik[2];
            label_kys4.Content = taul_vas[3] + " " + operaattori + " " + taul_oik[3];
            label_kys5.Content = taul_vas[4] + " " + operaattori + " " + taul_oik[4];
            label_kys6.Content = taul_vas[5] + " " + operaattori + " " + taul_oik[5];
            label_kys7.Content = taul_vas[6] + " " + operaattori + " " + taul_oik[6];
            label_kys8.Content = taul_vas[7] + " " + operaattori + " " + taul_oik[7];
            label_kys9.Content = taul_vas[8] + " " + operaattori + " " + taul_oik[8];
            label_kys10.Content = taul_vas[9] + " " + operaattori + " " + taul_oik[9];
            // piilotetaan vastaukset
            label_vast1.Content = "?";
            label_vast2.Content = "?";
            label_vast3.Content = "?";
            label_vast4.Content = "?";
            label_vast5.Content = "?";
            label_vast6.Content = "?";
            label_vast7.Content = "?";
            label_vast8.Content = "?";
            label_vast9.Content = "?";
            label_vast10.Content = "?";
            // Nollataan tekstikentät
            textBox_1.Text = "";
            textBox_2.Text = "";
            textBox_3.Text = "";
            textBox_4.Text = "";
            textBox_5.Text = "";
            textBox_6.Text = "";
            textBox_7.Text = "";
            textBox_8.Text = "";
            textBox_9.Text = "";
            textBox_10.Text = "";
            // lasketaan pisteet
            label_pisteet.Content = ""; // Piilotetaan "Pisteesi x / 10."
            // avataan kaikki kentät kirjoitettavaksi
            textBox_1.IsReadOnly = false;
            textBox_2.IsReadOnly = false;
            textBox_3.IsReadOnly = false;
            textBox_4.IsReadOnly = false;
            textBox_5.IsReadOnly = false;
            textBox_6.IsReadOnly = false;
            textBox_7.IsReadOnly = false;
            textBox_8.IsReadOnly = false;
            textBox_9.IsReadOnly = false;
            textBox_10.IsReadOnly = false;
        }

        private void restart_summa()
        {
            valinta = 0;
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                taul_vas[i] = rnd.Next(summa_ala, summa_yla);
                taul_oik[i] = rnd.Next(summa_ala, summa_yla);
                taul_res[i] = taul_vas[i] + taul_oik[i];
            }
            tulosta();
        }

        private void restart_erotus()
        {
            valinta = 1;
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                taul_vas[i] = rnd.Next(erotus_ala_vas, erotus_yla_vas);
                taul_oik[i] = rnd.Next(erotus_ala_oik, erotus_yla_oik);
                taul_res[i] = taul_vas[i] - taul_oik[i];
            }
            tulosta();
        }

        private void restart_kerto()
        {
            valinta = 2;
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                taul_vas[i] = rnd.Next(kerto_ala, kerto_yla_vas);
                taul_oik[i] = rnd.Next(kerto_ala, kerto_yla_oik);
                taul_res[i] = taul_vas[i] * taul_oik[i];
            }
            tulosta();
        }

        private void restart_jako()
        {
            valinta = 3;
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                do {
                    taul_vas[i] = rnd.Next(jako_ala_vas, jako_yla_vas);
                    taul_oik[i] = rnd.Next(jako_ala_oik, jako_yla_oik);
                } while ((taul_vas[i] % taul_oik[i]) != 0);

                taul_res[i] = taul_vas[i] / taul_oik[i];
            }
            tulosta();
        }

        private void restart_random()
        {
            valinta = 4;
            operaattori = '+';
            char[] taul_chars = new char[10];
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                // random numero
                int x = rnd.Next(1, 5);
                if (x == 1) {
                    taul_chars[i] = '+';
                } else if (x == 2) {
                    taul_chars[i] = '-';
                } else if (x == 3) {
                    taul_chars[i] = 'x';
                } else {
                    taul_chars[i] = '/';
                }

                //numerojen arvonta
                //taul_vas[i] = rnd.Next(1, 16);
                //taul_oik[i] = rnd.Next(1, 16);

                if (taul_chars[i] == '/') {
                    do {
                        taul_vas[i] = rnd.Next(jako_ala_vas, jako_yla_vas);
                        taul_oik[i] = rnd.Next(jako_ala_oik, jako_yla_oik);
                    } while ((taul_vas[i] % taul_oik[i]) != 0);
                    taul_res[i] = taul_vas[i] / taul_oik[i];
                } else if (taul_chars[i] == '-') {
                    taul_vas[i] = rnd.Next(erotus_ala_vas, erotus_yla_vas);
                    taul_oik[i] = rnd.Next(erotus_ala_oik, erotus_yla_oik);
                    taul_res[i] = taul_vas[i] - taul_oik[i];
                } else if (taul_chars[i] == '+') {
                    taul_vas[i] = rnd.Next(summa_ala, summa_yla);
                    taul_oik[i] = rnd.Next(summa_ala, summa_yla);
                    taul_res[i] = taul_vas[i] + taul_oik[i];
                } else if (taul_chars[i] == 'x') {
                    taul_vas[i] = rnd.Next(kerto_ala, kerto_yla_vas);
                    taul_oik[i] = rnd.Next(kerto_ala, kerto_yla_oik);
                    taul_res[i] = taul_vas[i] * taul_oik[i];
                }

                //// oikeat vastaukset
                //if (taul_chars[i] == '+')
                //{
                //    taul_res[i] = taul_vas[i] + taul_oik[i];
                //}
                //else if (taul_chars[i] == '-')
                //{
                //    taul_res[i] = taul_vas[i] - taul_oik[i];
                //}
                //else if (taul_chars[i] == 'x')
                //{
                //    taul_res[i] = taul_vas[i] * taul_oik[i];
                //}
                //else
                //{
                //    taul_res[i] = taul_vas[i] / taul_oik[i];
                //}

            } // for loppu

            // tulostetaan kysymykset
            label_kys1.Content = taul_vas[0] + " " + taul_chars[0] + " " + taul_oik[0];
            label_kys2.Content = taul_vas[1] + " " + taul_chars[1] + " " + taul_oik[1];
            label_kys3.Content = taul_vas[2] + " " + taul_chars[2] + " " + taul_oik[2];
            label_kys4.Content = taul_vas[3] + " " + taul_chars[3] + " " + taul_oik[3];
            label_kys5.Content = taul_vas[4] + " " + taul_chars[4] + " " + taul_oik[4];
            label_kys6.Content = taul_vas[5] + " " + taul_chars[5] + " " + taul_oik[5];
            label_kys7.Content = taul_vas[6] + " " + taul_chars[6] + " " + taul_oik[6];
            label_kys8.Content = taul_vas[7] + " " + taul_chars[7] + " " + taul_oik[7];
            label_kys9.Content = taul_vas[8] + " " + taul_chars[8] + " " + taul_oik[8];
            label_kys10.Content = taul_vas[9] + " " + taul_chars[9] + " " + taul_oik[9];
            // piilotetaan vastaukset
            label_vast1.Content = "?";
            label_vast2.Content = "?";
            label_vast3.Content = "?";
            label_vast4.Content = "?";
            label_vast5.Content = "?";
            label_vast6.Content = "?";
            label_vast7.Content = "?";
            label_vast8.Content = "?";
            label_vast9.Content = "?";
            label_vast10.Content = "?";
            // Nollataan tekstikentät
            textBox_1.Text = "";
            textBox_2.Text = "";
            textBox_3.Text = "";
            textBox_4.Text = "";
            textBox_5.Text = "";
            textBox_6.Text = "";
            textBox_7.Text = "";
            textBox_8.Text = "";
            textBox_9.Text = "";
            textBox_10.Text = "";
            // lasketaan pisteet
            label_pisteet.Content = ""; // Piilotetaan "Pisteesi x / 10."
            // avataan kaikki kentät kirjoitettavaksi
            textBox_1.IsReadOnly = false;
            textBox_2.IsReadOnly = false;
            textBox_3.IsReadOnly = false;
            textBox_4.IsReadOnly = false;
            textBox_5.IsReadOnly = false;
            textBox_6.IsReadOnly = false;
            textBox_7.IsReadOnly = false;
            textBox_8.IsReadOnly = false;
            textBox_9.IsReadOnly = false;
            textBox_10.IsReadOnly = false;

        }

        private void textBox_vuosi_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void button_tarkista_Click(object sender, RoutedEventArgs e)
        {
            int[] taul_vastaukset = new int[10];
            pisteet = 0;

            if (int.TryParse(textBox_1.Text, out taul_vastaukset[0]) == false) {
                taul_vastaukset[0] = -999;
            }
            if (int.TryParse(textBox_2.Text, out taul_vastaukset[1]) == false) {
                taul_vastaukset[1] = -999;
            }
            if (int.TryParse(textBox_3.Text, out taul_vastaukset[2]) == false) {
                taul_vastaukset[2] = -999;
            }
            if (int.TryParse(textBox_4.Text, out taul_vastaukset[3]) == false) {
                taul_vastaukset[3] = -999;
            }
            if (int.TryParse(textBox_5.Text, out taul_vastaukset[4]) == false) {
                taul_vastaukset[4] = -999;
            }
            if (int.TryParse(textBox_6.Text, out taul_vastaukset[5]) == false) {
                taul_vastaukset[5] = -999;
            }
            if (int.TryParse(textBox_7.Text, out taul_vastaukset[6]) == false) {
                taul_vastaukset[6] = -999;
            }
            if (int.TryParse(textBox_8.Text, out taul_vastaukset[7]) == false) {
                taul_vastaukset[7] = -999;
            }
            if (int.TryParse(textBox_9.Text, out taul_vastaukset[8]) == false) {
                taul_vastaukset[8] = -999;
            }
            if (int.TryParse(textBox_10.Text, out taul_vastaukset[9]) == false) {
                taul_vastaukset[9] = -999;
            }

            if (muokkaus && !nayta_oikeat)
            {
                textBox_1.IsReadOnly = false;
                textBox_2.IsReadOnly = false;
                textBox_3.IsReadOnly = false;
                textBox_4.IsReadOnly = false;
                textBox_5.IsReadOnly = false;
                textBox_6.IsReadOnly = false;
                textBox_7.IsReadOnly = false;
                textBox_8.IsReadOnly = false;
                textBox_9.IsReadOnly = false;
                textBox_10.IsReadOnly = false;
            } else
            {
                textBox_1.IsReadOnly = true;
                textBox_2.IsReadOnly = true;
                textBox_3.IsReadOnly = true;
                textBox_4.IsReadOnly = true;
                textBox_5.IsReadOnly = true;
                textBox_6.IsReadOnly = true;
                textBox_7.IsReadOnly = true;
                textBox_8.IsReadOnly = true;
                textBox_9.IsReadOnly = true;
                textBox_10.IsReadOnly = true;
            }

            for (int i = 0; i < 10; i++)
            {
                if (taul_vastaukset[i] == taul_res[i])
                {
                    pisteet++;
                }
            }

            if (pisteet == 10)
            {
                label_pisteet.Content = "Sait " + pisteet + " / 10 pistettä. Erinomaista!";
            }
            else
            {
                label_pisteet.Content = "Sait " + pisteet + " / 10 pistettä.";
            }
        }

        private void button_oikeat_Click(object sender, RoutedEventArgs e)
        {
            nayta_oikeat = true;

            label_vast1.Content = taul_res[0];
            label_vast2.Content = taul_res[1];
            label_vast3.Content = taul_res[2];
            label_vast4.Content = taul_res[3];
            label_vast5.Content = taul_res[4];
            label_vast6.Content = taul_res[5];
            label_vast7.Content = taul_res[6];
            label_vast8.Content = taul_res[7];
            label_vast9.Content = taul_res[8];
            label_vast10.Content = taul_res[9];

            textBox_1.IsReadOnly = true;
            textBox_2.IsReadOnly = true;
            textBox_3.IsReadOnly = true;
            textBox_4.IsReadOnly = true;
            textBox_5.IsReadOnly = true;
            textBox_6.IsReadOnly = true;
            textBox_7.IsReadOnly = true;
            textBox_8.IsReadOnly = true;
            textBox_9.IsReadOnly = true;
            textBox_10.IsReadOnly = true;
        }

        private void uudestaan_click()
        {
            if (valinta == 0)
            {
                restart_summa();
            }
            else if (valinta == 1)
            {
                restart_erotus();
            }
            else if (valinta == 2)
            {
                restart_kerto();
            }
            else if (valinta == 3)
            {
                restart_jako();
            }
            else
            {
                restart_random();
            }
        }

        private void button_uudestaan_Click(object sender, RoutedEventArgs e)
        {
            nayta_oikeat = false;
            uudestaan_click();
        }

        private void MenuItem_Click_summa(object sender, RoutedEventArgs e)
        {
            restart_summa ();
        }

        private void MenuItem_Click_erotus(object sender, RoutedEventArgs e)
        {
            restart_erotus();
        }

        private void MenuItem_Click_kerto(object sender, RoutedEventArgs e)
        {
            restart_kerto();
        }

        private void MenuItem_Click_jako(object sender, RoutedEventArgs e)
        {
            restart_jako();
        }

        private void MenuItem_Click_random(object sender, RoutedEventArgs e)
        {
            restart_random();
        }

        private void vaikeustaso_helppo(object sender, RoutedEventArgs e)
        {
            // ala- ja yläraja-arvot
            summa_yla = 11; // -1
            summa_ala = 1;
            erotus_yla_vas = 21; // -1
            erotus_yla_oik = 11; // -1
            erotus_ala_vas = 10;
            erotus_ala_oik = 1;
            kerto_yla_vas = 11; // -1
            kerto_yla_oik = 11; // -1
            kerto_ala = 1;
            jako_yla_vas = 51; // -1
            jako_yla_oik = 11; // -1
            jako_ala_vas = 10;
            jako_ala_oik = 2;

            uudestaan_click();
        }

        private void vaikeustaso_keskitaso(object sender, RoutedEventArgs e)
        {
            // ala- ja yläraja-arvot
            summa_yla = 101; // -1
            summa_ala = 1;
            erotus_yla_vas = 101; // -1
            erotus_yla_oik = 51; // -1
            erotus_ala_vas = 50;
            erotus_ala_oik = 5;
            kerto_yla_vas = 21; // -1
            kerto_yla_oik = 13; // -1
            kerto_ala = 1;
            jako_yla_vas = 101; // -1
            jako_yla_oik = 51; // -1
            jako_ala_vas = 50;
            jako_ala_oik = 5;

            uudestaan_click();
        }

        private void vaikeustaso_vaikea(object sender, RoutedEventArgs e)
        {
            // ala- ja yläraja-arvot
            summa_yla = 500; // -1
            summa_ala = 1;
            erotus_yla_vas = 1000; // -1
            erotus_yla_oik = 501; // -1
            erotus_ala_vas = 500;
            erotus_ala_oik = 15;
            kerto_yla_vas = 33; // -1
            kerto_yla_oik = 32; // -1
            kerto_ala = 10;
            jako_yla_vas = 1001; // -1
            jako_yla_oik = 126; // -1
            jako_ala_vas = 500;
            jako_ala_oik = 5;

            uudestaan_click();
        }

        private void MenuItem_Click_vari_antiikinvalkoinen(object sender, RoutedEventArgs e)
        {
            main_grid.Background = new SolidColorBrush(Color.FromRgb(250, 235, 215));
        }

        private void MenuItem_Click_vari_beige(object sender, RoutedEventArgs e)
        {
            main_grid.Background = new SolidColorBrush(Color.FromRgb(245, 245, 220));
        }

        private void MenuItem_Click_vari_haamunvalkoinen(object sender, RoutedEventArgs e)
        {
            main_grid.Background = new SolidColorBrush(Color.FromRgb(248, 248, 255));
        }

        private void MenuItem_Click_vari_akvamariini(object sender, RoutedEventArgs e)
        {
            main_grid.Background = new SolidColorBrush(Color.FromRgb(127, 255, 212));
        }

        private void MenuItem_Click_vari_pinkki(object sender, RoutedEventArgs e)
        {
            main_grid.Background = new SolidColorBrush(Color.FromRgb(255, 192, 203));
        }

        private void MenuItem_Click_vari_vaaleanvihrea(object sender, RoutedEventArgs e)
        {
            main_grid.Background = new SolidColorBrush(Color.FromRgb(144, 238, 144));
        }

        private void MenuItem_Click_asetukset_muokkaus(object sender, RoutedEventArgs e)
        {
           if (menuitem_muokkaus.IsChecked) // == true
            {
                muokkaus = true;
            } else // false
            {
                muokkaus = false;
            }
        }

        private void MenuItem_Click_sulje(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows.Media;
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

        int[] taul_vas = new int[10];
        int[] taul_oik = new int[10];
        int[] taul_res = new int[10];
        short pisteet;

        public MainWindow()
        {
            InitializeComponent();
            restart();
        }

        private void restart()
        {
            pisteet = 0;
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                taul_vas[i] = rnd.Next(1, 13);
                taul_oik[i] = rnd.Next(1, 13);
            }

            for (int i = 0; i < 10; i++)
            {
                taul_res[i] = taul_vas[i] * taul_oik[i];
            }

            label_kys1.Content = taul_vas[0] + " x " + taul_oik[0];
            label_kys2.Content = taul_vas[1] + " x " + taul_oik[1];
            label_kys3.Content = taul_vas[2] + " x " + taul_oik[2];
            label_kys4.Content = taul_vas[3] + " x " + taul_oik[3];
            label_kys5.Content = taul_vas[4] + " x " + taul_oik[4];
            label_kys6.Content = taul_vas[5] + " x " + taul_oik[5];
            label_kys7.Content = taul_vas[6] + " x " + taul_oik[6];
            label_kys8.Content = taul_vas[7] + " x " + taul_oik[7];
            label_kys9.Content = taul_vas[8] + " x " + taul_oik[8];
            label_kys10.Content = taul_vas[9] + " x " + taul_oik[9];

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
            //
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
            //
            label_pisteet.Content = ""; // Pisteesi 0 / 10.
            //
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
                taul_vastaukset[0] = -1;
            }
            if (int.TryParse(textBox_2.Text, out taul_vastaukset[1]) == false) {
                taul_vastaukset[1] = -1;
            }
            if (int.TryParse(textBox_3.Text, out taul_vastaukset[2]) == false) {
                taul_vastaukset[2] = -1;
            }
            if (int.TryParse(textBox_4.Text, out taul_vastaukset[3]) == false) {
                taul_vastaukset[3] = -1;
            }
            if (int.TryParse(textBox_5.Text, out taul_vastaukset[4]) == false) {
                taul_vastaukset[4] = -1;
            }
            if (int.TryParse(textBox_6.Text, out taul_vastaukset[5]) == false) {
                taul_vastaukset[5] = -1;
            }
            if (int.TryParse(textBox_7.Text, out taul_vastaukset[6]) == false) {
                taul_vastaukset[6] = -1;
            }
            if (int.TryParse(textBox_8.Text, out taul_vastaukset[7]) == false) {
                taul_vastaukset[7] = -1;
            }
            if (int.TryParse(textBox_9.Text, out taul_vastaukset[8]) == false) {
                taul_vastaukset[8] = -1;
            }
            if (int.TryParse(textBox_10.Text, out taul_vastaukset[9]) == false) {
                taul_vastaukset[9] = -1;
            }

            for (int i = 0; i < 10; i++)
            {
                if (taul_vastaukset[i] == taul_res[i])
                {
                    pisteet++;
                }
            }

            label_pisteet.Content = "Sait " + pisteet + " / 10 pistettä.";
        }

        private void button_oikeat_Click(object sender, RoutedEventArgs e)
        {
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

        private void button_uudestaan_Click(object sender, RoutedEventArgs e)
        {
            restart();
        }

    }
}

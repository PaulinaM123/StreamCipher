using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POD_proj
{
    /// <summary>
    /// Interaction logic for Zasada_działania.xaml
    /// </summary>
    public partial class Zasada_działania : Window
    {
        public Zasada_działania()
        {
            InitializeComponent();
        }

        public static int krok = -1;


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DataTable table = GetTable();
            dgData.ItemsSource = table.DefaultView;
            ki.Text = " ";
            krok = 0;

        }

        static DataTable GetTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Pierwsze 25 bitów", typeof(string));
            for (int i = 0; i < 25; i++)
            {
                table.Columns.Add((i + 1).ToString(), typeof(int));
            }

            int[] a = { 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0 };
            int[] s = { 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1 };
            // Here we add five DataRows.
            table.Rows.Add("LFSR-S", 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1, 0, 1);
            table.Rows.Add("LFSR-A", 1, 0, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0);
            table.Rows.Add("Ki");


            return table;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int[] k = { 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 0 };
            string s;
            if (krok < 0)
            {
                MessageBox.Show("Aby zobaczyć kolejny krok nalezy uruchomic wizualizację przyciskiem 'Rozpocznij'.");
            }
            if (krok > 24)
            {
                MessageBox.Show("Koniec wizualizacji.");
                krok = -1;
            }
            /* if(krok==0)
             {

                 DataTable table = GetTable();
                 DataRow workRow = table.Rows[2];
                 s = (krok + 1).ToString();
                 workRow[s] = 1;
                 dgData.ItemsSource = table.DefaultView;
             }*/
            else
            {
                DataTable table = GetTable();
                DataRow workRow = table.Rows[2];

                switch (krok)
                {
                    case 0:
                    case 3:
                    case 8:
                    case 14:
                    case 15:
                    case 17:
                    case 21:
                        {
                            s = (krok + 1).ToString();
                            workRow[s] = 1;
                            ki.Text += "1";
                            break;
                        }
                    case 1:
                    case 7:
                    case 10:
                    case 22:
                    case 24:
                        {
                            s = (krok + 1).ToString();
                            workRow[s] = 0;
                            ki.Text += "0";
                            break;
                        }
                    case 2:
                    case 4:
                    case 5:
                    case 6:
                    case 9:
                    case 11:
                    case 12:
                    case 13:
                    case 16:
                    case 18:
                    case 19:
                    case 20:
                    case 23:
                        {
                            MessageBox.Show("Wartość rejestru S na pozycji " + (krok + 1) + " wynosi 0 więc pomijamy wartośc wyjściową rejestru A");
                            break;
                        }
                }
                krok++;
                dgData.ItemsSource = table.DefaultView;
            }

        }
    }
}

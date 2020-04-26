using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POD_proj
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Generator : UserControl
    {
        public Generator()
        {
            InitializeComponent();
        }
    
        public int N = 4;
        public int N1 = 3;



        public static bool Sprzężenie_zwrotne(int n, BitArray rejestr)
        {
            bool nastepny;
            switch (n)
            {
                case 2:
                    {
                        nastepny = true ^ rejestr[0] ^ rejestr[1];
                        return nastepny;
                    }
                case 3:
                    {
                        nastepny = true ^ rejestr[1] ^ rejestr[2];
                        return nastepny;
                    }
                case 4:
                    {
                        nastepny = true ^ rejestr[2] ^ rejestr[3];
                        return nastepny;
                    }
                case 5:
                    {
                        nastepny = true ^ rejestr[2] ^ rejestr[4];
                        return nastepny;
                    }
                case 6:
                    {
                        nastepny = true ^ rejestr[4] ^ rejestr[5];
                        return nastepny;
                    }
                case 7:
                    {
                        nastepny = true ^ rejestr[5] ^ rejestr[6];
                        return nastepny;
                    }
                case 8:
                    {
                        nastepny = true ^ rejestr[3] ^ rejestr[4] ^ rejestr[5] ^ rejestr[7];
                        return nastepny;
                    }
                case 9:
                    {
                        nastepny = true ^ rejestr[4] ^ rejestr[8];
                        return nastepny;
                    }
                case 10:
                    {
                        nastepny = true ^ rejestr[6] ^ rejestr[9];
                        return nastepny;
                    }
                case 11:
                    {
                        nastepny = true ^ rejestr[8] ^ rejestr[10];
                        return nastepny;
                    }
                case 12:
                    {
                        nastepny = true ^ rejestr[3] ^ rejestr[9] ^ rejestr[10] ^ rejestr[11];
                        return nastepny;
                    }
                default:
                    {
                        //
                        return false;
                    }

            }

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            int rozmiar = 0;
            bool kontynuuj = true;
            BitArray ziarnoA = new BitArray(N);
            BitArray ziarnoS = new BitArray(N1);
            string z = wp.Text;
            string z2 = wp2.Text;

            if (z.Length == 0 || długość.Text.Length == 0 || z2.Length == 0)
            {
                MessageBox.Show("Brak wystarczających danych. Wartość początkowa rejestru oraz długosć generowanego ciągu powinny być wypełnione ");
                kontynuuj = false;
            }


            if (z.Length != N)
            {
                MessageBox.Show("Wielkość wartości poczatkowej rejestru A nie jest zgodna z wielkością rejestru: " + N);
                kontynuuj = false;
            }
            if (z2.Length != N1)
            {
                MessageBox.Show("Wielkość wartości poczatkowej rejestru S nie jest zgodna z wielkością rejestru: " + N1);
                kontynuuj = false;
            }
            if (kontynuuj)
            {
                rozmiar = Int32.Parse(długość.Text);
                for (int i = 0; i < z.Length; i++)
                {
                    if (z[i] == '1')
                    {
                        ziarnoA[i] = true;
                    }
                    if (z[i] == '0')
                    {
                        ziarnoA[i] = false;
                    }
                    else if (z[i] != '0' && z[i] != '1')
                    {
                        MessageBox.Show("Błędne dane.Wartość początkowa rejestru A powinna się składać tylko z 0 i 1.");
                        kontynuuj = false;
                    }

                }
                for (int i = 0; i < z2.Length; i++)
                {
                    if (z2[i] == '1')
                    {
                        ziarnoS[i] = true;
                    }
                    if (z2[i] == '0')
                    {
                        ziarnoS[i] = false;
                    }
                    else if (z2[i] != '0' && z2[i] != '1')
                    {
                        MessageBox.Show("Błędne dane.Wartość początkowa rejestru S powinna się składać tylko z 0 i 1.");
                        kontynuuj = false;
                    }

                }

            }

            if (kontynuuj)
            {
                BitArray wyjście = new BitArray(rozmiar);
                wyjście = Rozrzedzający(ziarnoA, ziarnoS, N, N1, rozmiar);
                char[] wyj = new char[rozmiar];
                int r = 0;
                foreach (bool value in wyjście)
                {
                    if (value == true)
                    {
                        wyj[r] = '1';
                    }
                    else
                    {
                        wyj[r] = '0';
                    }
                    r++;
                }
                wynik.Text = new string(wyj);

            }

        }

        static String odczyt_z_pliku(String path)
        {
            string s = File.ReadAllText(path, Encoding.Default);
            return s;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (.txt)|.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            Nullable<bool> result = saveFileDialog1.ShowDialog();
            if (result == true)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    byte[] buffer = Encoding.Default.GetBytes(wynik.Text);
                    myStream.Write(buffer, 0, buffer.Length);

                    myStream.Close();
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            wp.Clear();

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string path = dlg.FileName;
                wp.Text = odczyt_z_pliku(path);
            }

        }


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Właściwości w = new Właściwości(this);
            //w.Owner = this;
            w.długośćA.Text = N.ToString();
            w.długośćS.Text = N1.ToString();
            w.fa.Text = "f(x0,x1,x2,x3)= 1 + x2 + x3";
            w.fs.Text = "f(x0,x1,x2)= 1 + x1 + x2";

            w.ShowDialog();

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

            Zasada_działania zd = new Zasada_działania();
            zd.ShowDialog();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            wp2.Clear();

            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".txt"; // Default file extension
            dlg.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string path = dlg.FileName;
                wp2.Text = odczyt_z_pliku(path);
            }
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (.txt)|.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            Nullable<bool> result = saveFileDialog1.ShowDialog();
            if (result == true)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    byte[] buffer = Encoding.Default.GetBytes(wp.Text);
                    myStream.Write(buffer, 0, buffer.Length);

                    myStream.Close();
                }
            }
        }

        public static string Losuj(int n)
        {

            bool zly = true;
            int suma = 0;
            int[] losowy = new int[n];
            string los = "";
            while (zly)
            {

                Random rnd = new Random();
                for (int i = 0; i < n; i++)
                {
                    losowy[i] = rnd.Next(0, 2);
                    suma = suma + losowy[i];
                }

                if ((suma != 0) && (suma != n))
                {
                    zly = false;
                }
                else
                {
                    suma = 0;
                }

            }

            foreach (int liczba in losowy)
            {
                los += Convert.ToString(liczba);
            }

            return los;

        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            wp.Text = Losuj(N);
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            wp2.Text = Losuj(N1);
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (.txt)|.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            Nullable<bool> result = saveFileDialog1.ShowDialog();
            if (result == true)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    // Code to write the stream goes here.
                    byte[] buffer = Encoding.Default.GetBytes(wp2.Text);
                    myStream.Write(buffer, 0, buffer.Length);

                    myStream.Close();
                }
            }
        }

        private byte[] ToByteArray(BitArray input)
        {
            if (input.Length % 8 != 0)
            {
                byte[] ret = new byte[(input.Length / 8)];
                for (int i = 0; i < input.Length - input.Length % 8; i += 8)
                {
                    int value = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        if (input[i + j])
                        {
                            value += 1 << (7 - j);
                        }
                    }
                    ret[i / 8] = (byte)value;
                }
                return ret;

            }
            else
            {
                byte[] ret = new byte[input.Length / 8];
                for (int i = 0; i < input.Length; i += 8)
                {
                    int value = 0;
                    for (int j = 0; j < 8; j++)
                    {
                        if (input[i + j])
                        {
                            value += 1 << (7 - j);
                        }
                    }
                    ret[i / 8] = (byte)value;
                }
                return ret;
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            int rozmiar = 0;
            bool kontynuuj = true;
            BitArray ziarnoA = new BitArray(N);
            BitArray ziarnoS = new BitArray(N1);
            string z = wp.Text;
            string z2 = wp2.Text;
            BitArray input;

            if (z.Length == 0 || długość.Text.Length == 0 || z2.Length == 0)
            {
                MessageBox.Show("Brak wystarczających danych. Wartość początkowa rejestru oraz długosć generowanego ciągu powinny być wypełnione ");
                kontynuuj = false;
            }
            if (z.Length != N)
            {
                MessageBox.Show("Wielkość wartości poczatkowej rejestru A nie jest zgodna z wielkością rejestru: " + N);
                kontynuuj = false;
            }
            if (z2.Length != N1)
            {
                MessageBox.Show("Wielkość wartości poczatkowej rejestru S nie jest zgodna z wielkością rejestru: " + N1);
                kontynuuj = false;
            }
            if (kontynuuj)
            {
                rozmiar = Int32.Parse(długość.Text);
                for (int i = 0; i < z.Length; i++)
                {
                    if (z[i] == '1')
                    {
                        ziarnoA[i] = true;
                    }
                    if (z[i] == '0')
                    {
                        ziarnoA[i] = false;
                    }
                    else if (z[i] != '0' && z[i] != '1')
                    {
                        MessageBox.Show("Błędne dane.Wartość początkowa rejestru A powinna się składać tylko z 0 i 1.");
                        kontynuuj = false;
                    }

                }
                for (int i = 0; i < z2.Length; i++)
                {
                    if (z2[i] == '1')
                    {
                        ziarnoS[i] = true;
                    }
                    if (z2[i] == '0')
                    {
                        ziarnoS[i] = false;
                    }
                    else if (z2[i] != '0' && z2[i] != '1')
                    {
                        MessageBox.Show("Błędne dane.Wartość początkowa rejestru S powinna się składać tylko z 0 i 1.");
                        kontynuuj = false;
                    }

                }

            }



            input = Rozrzedzający(ziarnoA, ziarnoS, N, N1, rozmiar);

            byte[] buffer = ToByteArray(input);

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "bin files (.bin)|.bin";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            Nullable<bool> result = saveFileDialog1.ShowDialog();
            if (result == true)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {

                    myStream.Write(buffer, 0, buffer.Length);

                    myStream.Close();
                }
            }

        }

        static public BitArray Rozrzedzający(BitArray ziarnoA, BitArray ziarnoS, int N, int N1, int rozmiar)
        {
            int n = N;
            int n1 = N1;
            BitArray rejestrA;
            BitArray rejestrS;
            rejestrA = new BitArray(n);
            rejestrS = new BitArray(n1);

            for (int i = 0; i < n; i++)
            {
                rejestrA[i] = ziarnoA[i];
            }
            for (int i = 0; i < n1; i++)
            {
                rejestrS[i] = ziarnoS[i];
            }

            BitArray wyjście = new BitArray(rozmiar);
            int t = 0;
            bool nastepnyA;
            bool nastepnyS;
            while (t < rozmiar)
            {
                if (rejestrS[n1 - 1] == true)
                {
                    wyjście[t] = rejestrA[n - 1];
                    t++;
                }

                nastepnyA = Sprzężenie_zwrotne(n, rejestrA);
                for (int i = n - 1; i > 0; i--)
                {
                    rejestrA[i] = rejestrA[i - 1];
                }
                rejestrA[0] = nastepnyA;

                nastepnyS = Sprzężenie_zwrotne(n1, rejestrS);
                for (int i = n1 - 1; i > 0; i--)
                {
                    rejestrS[i] = rejestrS[i - 1];
                }
                rejestrS[0] = nastepnyS;


            }

            return wyjście;

        }


    }
}


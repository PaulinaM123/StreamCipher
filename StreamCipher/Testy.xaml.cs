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
    /// Interaction logic for Testy.xaml
    /// </summary>
    public partial class Testy : UserControl
    {
        public Testy()
        {
            InitializeComponent();
        }


        static String odczyt_z_pliku(String path)
        {
            string s = File.ReadAllText(path, Encoding.Default);
            return s;
        }

        private void wczytaj_tekstowy_Click(object sender, RoutedEventArgs e)
        {
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
                tekst.Text = odczyt_z_pliku(path);
            }
        }

        private void zapisz_tekst_Click(object sender, RoutedEventArgs e)
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
                    byte[] buffer = Encoding.Default.GetBytes(tekst.Text);
                    myStream.Write(buffer, 0, buffer.Length);

                    myStream.Close();
                }
            }
        }

        private void wczytaj_binarny_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".bin"; // Default file extension
            dlg.Filter = "Binary documents (.bin)|*.bin"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string path = dlg.FileName;
                byte[] b = File.ReadAllBytes(path);

                BitArray bity = new BitArray(b);
                char[] s = new char[(b.Length) * 8];
                char[] pom = new char[(b.Length) * 8];

                int rr = 0;
                foreach (bool value in bity)
                {
                    if (value == true)
                    {
                        s[rr] = '1';
                        pom[rr] = '1';
                    }
                    else
                    {
                        s[rr] = '0';
                        pom[rr] = '0';
                    }
                    rr++;
                }

                int z = (b.Length);
                Console.WriteLine("Długosć z: " + z);
                int k = 0;
                while (z > 0)
                {
                    s[0 + k] = pom[7 + k];
                    s[1 + k] = pom[6 + k];
                    s[2 + k] = pom[5 + k];
                    s[3 + k] = pom[4 + k];
                    s[4 + k] = pom[3 + k];
                    s[5 + k] = pom[2 + k];
                    s[6 + k] = pom[1 + k];
                    s[7 + k] = pom[0 + k];

                    z--;
                    k = k + 8;
                }



                tekst.Text = new string(s);
            }
        }

        public static int test_pojedynczych_bitów(char[] ciąg)
        {
            
            int rezultat=0;
            for (int i = 0; i < ciąg.Length; i++)
            {
                if (ciąg[i]=='1')
                { rezultat++; }
            }

            return rezultat;
        }

        

        public static int[] test_serii(char[] ciąg)
        {
            //0,1,2,3,4,5-zera  6,7,8,9,10,11- jedynki
            int[] rezultat = new int[12];
            int seria=0;
            char testowana = ciąg[0];
            for (int i = 0; i < ciąg.Length; i++)
            {
                if (i == ciąg.Length - 1 && ciąg[i]==testowana)
                {
                    seria++;
                    if (testowana == '0')
                    {
                        switch (seria)
                        {
                            case 1:
                                {
                                    rezultat[0]++;
                                    break;
                                }
                            case 2:
                                {
                                    rezultat[1]++;
                                    break;
                                }
                            case 3:
                                {
                                    rezultat[2]++;
                                    break;
                                }
                            case 4:
                                {
                                    rezultat[3]++;
                                    break;
                                }
                            case 5:
                                {
                                    rezultat[4]++;
                                    break;
                                }
                            default:
                                {
                                    rezultat[5]++;
                                    break;
                                }
                        }
                    }
                    else
                    {
                        switch (seria)
                        {
                            case 1:
                                {
                                    rezultat[6]++;
                                    break;
                                }
                            case 2:
                                {
                                    rezultat[7]++;
                                    break;
                                }
                            case 3:
                                {
                                    rezultat[8]++;
                                    break;
                                }
                            case 4:
                                {
                                    rezultat[9]++;
                                    break;
                                }
                            case 5:
                                {
                                    rezultat[10]++;
                                    break;
                                }
                            default:
                                {
                                    rezultat[11]++;
                                    break;
                                }
                        }

                    }
                }
                else if (i == ciąg.Length - 1 && ciąg[i] != testowana)
                    {         
                        if (testowana == '0')
                        {
                            switch (seria)
                            {
                                case 1:
                                    {
                                        rezultat[0]++;
                                        rezultat[6]++;
                                        break;
                                    }
                                case 2:
                                    {
                                        rezultat[1]++;
                                        rezultat[6]++;
                                    break;
                                    }
                                case 3:
                                    {
                                        rezultat[2]++;
                                        rezultat[6]++;
                                    break;
                                    }
                                case 4:
                                    {
                                        rezultat[3]++;
                                         rezultat[6]++;
                                    break;
                                    }
                                case 5:
                                    {
                                        rezultat[4]++;
                                         rezultat[6]++;
                                    break;
                                    }
                                default:
                                    {
                                        rezultat[5]++;
                                        rezultat[6]++;
                                    break;
                                    }
                            }
                        }
                        else
                        {
                            switch (seria)
                            {
                                case 1:
                                    {
                                        rezultat[6]++;
                                        rezultat[0]++;
                                    break;
                                    }
                                case 2:
                                    {
                                        rezultat[7]++;
                                        rezultat[0]++;
                                    break;
                                    }
                                case 3:
                                    {
                                        rezultat[8]++;
                                        rezultat[0]++;
                                    break;
                                    }
                                case 4:
                                    {
                                        rezultat[9]++;
                                         rezultat[0]++;
                                    break;
                                    }
                                case 5:
                                    {
                                        rezultat[10]++;
                                        rezultat[0]++;
                                    break;
                                    }
                                default:
                                    {
                                        rezultat[11]++;
                                        rezultat[0]++;
                                    break;
                                    }
                            }

                        }
                    }
                else if (ciąg[i] == testowana)
                {
                    seria++;                 
                }
                else
                {
                    if (testowana == '0')
                    {
                        switch (seria)
                        {
                            case 1:
                                {
                                    rezultat[0]++;
                                    testowana = '1';
                                    break;
                                }
                            case 2:
                                {
                                    rezultat[1]++;
                                    testowana = '1';
                                    break;
                                }
                            case 3:
                                {
                                    rezultat[2]++;
                                    testowana = '1';
                                    break;
                                }
                            case 4:
                                {
                                    rezultat[3]++;
                                    testowana = '1';
                                    break;
                                }
                            case 5:
                                {
                                    rezultat[4]++;
                                    testowana = '1';
                                    break;
                                }
                            default:
                                {
                                    rezultat[5]++;
                                    testowana = '1';
                                    break;
                                }
                        }
                    }
                    else
                    {
                        switch (seria)
                        {
                            case 1:
                                {
                                    rezultat[6]++;
                                    testowana = '0';
                                    break;
                                }
                            case 2:
                                {
                                    rezultat[7]++;
                                    testowana = '0';
                                    break;
                                }
                            case 3:
                                {
                                    rezultat[8]++;
                                    testowana = '0';
                                    break;
                                }
                            case 4:
                                {
                                    rezultat[9]++;
                                    testowana = '0';
                                    break;
                                }
                            case 5:
                                {
                                    rezultat[10]++;
                                    testowana = '0';
                                    break;
                                }
                            default:
                                {
                                    rezultat[11]++;
                                    testowana = '0';
                                    break;
                                }
                        }


                    }
                    seria = 1;
                }
              
            }
            return rezultat;
        }


        public static int test_długiej_serii(char[] ciąg)
        {
            int rezultat = 0;
            int długa_seria = 0;
            char testowana = ciąg[0];
            for (int i = 0; i < ciąg.Length; i++)
            {
                if (ciąg[i] == testowana)
                {
                    długa_seria++;
                    if (długa_seria >= 26 && i == ciąg.Length - 1)
                    {
                        rezultat++;
                    }
                }
                else
                {
                    if (długa_seria >= 26)
                    {
                        rezultat++;
                    }
                    długa_seria = 1;
                    if (testowana == '1')
                    {
                        testowana = '0';
                    }
                    else
                    {
                        testowana = '1';
                    }
                }
            }
            return rezultat;

        }

        public static float test_pokerowy(char[] ciąg)
        {
            float rezultat;
            int[] segmenty = new int[16];

            char[] pom = new char[4];
            int i=0;
            string porównywany;
            for(int x =0;x<5000;x++)
            {
                
                pom[0]= ciąg[i];
                pom[1]= ciąg[i+1];
                pom[2]= ciąg[i+2];
                pom[3]= ciąg[i+3];
                i = i + 4;

                porównywany = new string(pom);
                switch(porównywany)
                {
                    case "0001":
                    {
                            segmenty[0]++;
                            break;
                    }
                    case "0011":
                        {
                            segmenty[1]++;
                            break;
                        }
                    case "0111":
                        {
                            segmenty[2]++;
                            break;
                        }
                    case "1111":
                        {
                            segmenty[3]++;
                            break;
                        }
                    case "1101":
                        {
                            segmenty[4]++;
                            break;
                        }
                    case "1001":
                        {
                            segmenty[5]++;
                            break;
                        }
                    case "0101":
                        {
                            segmenty[6]++;
                            break;
                        }
                    case "1011":
                        {
                            segmenty[7]++;
                            break;
                        }
                    case "0000":
                        {
                            segmenty[8]++;
                            break;
                        }
                    case "0010":
                        {
                            segmenty[9]++;
                            break;
                        }
                    case "0110":
                        {
                            segmenty[10]++;
                            break;
                        }
                    case "1110":
                        {
                            segmenty[11]++;
                            break;
                        }
                    case "1100":
                        {
                            segmenty[12]++;
                            break;
                        }
                    case "1000":
                        {
                            segmenty[13]++;
                            break;
                        }
                    case "0100":
                        {
                            segmenty[14]++;
                            break;
                        }
                    case "1010":
                        {
                            segmenty[15]++;
                            break;
                        }
                }
            }
            float suma_kwadratów=0;
            for (int x = 0; x < 16; x++)
            {
                suma_kwadratów += segmenty[x]*segmenty[x];
            }
            rezultat = (16.0F/5000.0F)*suma_kwadratów-5000.0F;
            
    
            return rezultat;
        }


        private void Testuj_Click(object sender, RoutedEventArgs e)
        {
            bool poprawny = true;
            pb_w.Text = "";
            pb_wynik.Text = " ";
            s_w.Text = "";
            s_wynik.Text = " ";
            ds_w.Text = "";
            ds_wynik.Text = " ";
            p_w.Text = "";
            p_wynik.Text = " ";
            if (tekst.Text.Length<20000)
            {             
                MessageBox.Show("Ciąg jest za krótki. Długość badanego ciągu powinna wynosić 20 000 bitów. ");
                poprawny = false;
            }
            if(tekst.Text.Length>20000)
            {
                MessageBox.Show("Ciąg jest za długi. Testy zostaną wykonane na początkowych 20 000 bitach wczytanego ciągu. ");
            }
           if (poprawny==true)
            {
                if (pojedynczych_bitów.IsChecked == true)
                {
                    char[] wczytany = tekst.Text.ToCharArray();
                    char[] ciąg = new char[20000];
                    for (int i = 0; i < 20000; i++)
                    {
                        ciąg[i] = wczytany[i];
                    }

                    int rezultat;
                    rezultat = test_pojedynczych_bitów(ciąg);
                    pb_wynik.Text = "Liczba jedynek: " + rezultat.ToString();
                    if (rezultat > 9725 && rezultat < 10275)
                    {
                        pb_w.Text = "SUKCES";
                    }
                    else
                    {
                        pb_w.Text = "NIEPOWODZENIE";
                    }
                }
                if (serii.IsChecked == true)
                {
                    char[] wczytany = tekst.Text.ToCharArray();
                    char[] ciąg = new char[20000];
                    for (int i = 0; i < 20000; i++)
                    {
                        ciąg[i] = wczytany[i];
                    }
                    int[] rezultat;
                    rezultat = test_serii(ciąg);
                    s_wynik.Text = "Zera:      " + rezultat[0] + "," + rezultat[1] + "," + rezultat[2] + "," + rezultat[3] + "," + rezultat[4] + "," + rezultat[5] +
                        " Jedynki: " + rezultat[6] + "," + rezultat[7] + "," + rezultat[8] + "," + rezultat[9] + "," + rezultat[10] + "," + rezultat[11];

                    if ((rezultat[0] > 2315 && rezultat[0] < 2685) && (rezultat[6] > 2315 && rezultat[6] < 2685) && (rezultat[1] > 1114 && rezultat[1] < 1386) && (rezultat[7] > 1114 && rezultat[7] < 1386) &&
                        (rezultat[2] > 527 && rezultat[2] < 723) && (rezultat[8] > 527 && rezultat[8] < 723) && (rezultat[3] > 240 && rezultat[3] < 384) && (rezultat[9] > 240 && rezultat[9] < 384) &&
                        (rezultat[4] > 103 && rezultat[4] < 209) && (rezultat[10] > 103 && rezultat[10] < 209) && (rezultat[5] > 103 && rezultat[5] < 209) && (rezultat[11] > 103 && rezultat[11] < 209))
                    {
                        s_w.Text = "SUKCES";
                    }
                    else
                    {
                        s_w.Text = "NIEPOWODZENIE";
                    }

                }
                if (długiej_serii.IsChecked == true)
                {
                    char[] wczytany = tekst.Text.ToCharArray();
                    char[] ciąg = new char[20000];
                    for (int i = 0; i < 20000; i++)
                    {
                        ciąg[i] = wczytany[i];
                    }
                    int rezultat;
                    rezultat = test_długiej_serii(ciąg);
                    ds_wynik.Text = "Liczba długich serii: " + rezultat.ToString();
                    if (rezultat > 0)
                    {
                        ds_w.Text = "NIEPOWODZENIE";
                    }
                    else
                    {
                        ds_w.Text = "SUKCES";
                    }

                }
                if (pokerowy.IsChecked == true)
                {
                    char[] wczytany = tekst.Text.ToCharArray();
                    char[] ciąg = new char[20000];
                    for (int i = 0; i < 20000; i++)
                    {
                        ciąg[i] = wczytany[i];
                    }
                    float rezultat;
                    rezultat = test_pokerowy(ciąg);
                    p_wynik.Text = rezultat.ToString();
                    if (rezultat > 2.16 && rezultat < 46.17)
                    {
                        p_w.Text = "SUKCES";
                    }
                    else
                    {
                        p_w.Text = "NIEPOWODZENIE";
                    }

                }


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Testy_opis t = new Testy_opis();
            t.ShowDialog();
        }
    }
}

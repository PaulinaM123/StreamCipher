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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POD_proj
{
    /// <summary>
    /// Interaction logic for Właściwości.xaml
    /// </summary>
    public partial class Właściwości : Window
    {
        Generator mw;
        public Właściwości(Generator mw)
        {
            this.mw = mw;
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                int x = Int32.Parse(długośćA.Text);
                if (x > 12 || x < 2)
                {
                    MessageBox.Show("Wielkość rejestru ograniczona od 2 do 12");
                }
                else
                {
                    mw.N = x;
                    fa.Text = Wielomian(x);
                }
            }
            catch
            {
                MessageBox.Show("Wartosć musi być cyfrą z przedziału od 2 do 12");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int x = Int32.Parse(długośćS.Text);
                if (x > 12 || x < 2)
                {
                    MessageBox.Show("Wielkość rejestru ograniczona od 2 do 12");
                }
                else
                {
                    mw.N1 = x;
                    fs.Text = Wielomian(x);
                }
            }
            catch
            {
                MessageBox.Show("Wartosć musi być cyfrą z przedziału od 2 do 12");
            }
        }

        public static string Wielomian(int x)
        {
            string funkcja;
            switch (x)
            {
                case 2:
                    {
                        funkcja = "f(x0,x1)= 1 + x0 + x1";
                        return funkcja;
                    }
                case 3:
                    {
                        funkcja = "f(x0,x1,x2)= 1 + x1 + x2";
                        return funkcja;
                    }
                case 4:
                    {
                        funkcja = "f(x0,x1,x2,x3)= 1 + x2 + x3";
                        return funkcja;
                    }
                case 5:
                    {
                        funkcja = "f(x0,x1,x2,x3,x4)= 1 + x2 + x4";
                        return funkcja;
                    }
                case 6:
                    {
                        funkcja = "f(x0,x1,x2,x3,x4,x5)= 1 + x4 + x5";
                        return funkcja;
                    }
                case 7:
                    {
                        funkcja = "f(x0,x1,x2,x3,x4,x5,x6)= 1 + x5 + x6";
                        return funkcja;
                    }
                case 8:
                    {
                        funkcja = "f(x0,x1,x2,x3,x4,x5,x6,x7)= 1 + x3 + x4 + x5 + x7";
                        return funkcja;
                    }
                case 9:
                    {
                        funkcja = "f(x0,x1,x2,x3,x4,x5,x6,x7,x8)= 1 + x4 + x8";
                        return funkcja;
                    }
                case 10:
                    {
                        funkcja = "f(x0,x1,x2,x3,x4,x5,x6,x7,x8,x9)= 1 + x6 + x9";
                        return funkcja;
                    }
                case 11:
                    {
                        funkcja = "f(x0,x1,x2,x3,x4,x5,x6,x7,x8,x9,x10)= 1 + x8 + x10";
                        return funkcja;
                    }
                case 12:
                    {
                        funkcja = "f(x0,x1,x2,x3,x4,x5,x6,x7,x8,x9,x10,x11)= 1 + x3 + x9 + x10 + x11";
                        return funkcja;
                    }

                default:
                    {
                        //
                        return "Poza zakresem";
                    }

            }
        }

    }
}


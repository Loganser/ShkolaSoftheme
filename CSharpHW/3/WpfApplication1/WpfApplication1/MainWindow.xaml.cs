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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string GetZodiacName(DateTime dt)
        {
            int month = dt.Month;
            int day = dt.Day;
            switch (month)
            {
                case 1:
                    if (day <= 19)
                        return "capricorn";
                    else
                        return "aquarius";

                case 2:
                    if (day <= 18)
                        return "aquarius";
                    else
                        return "pisces";
                case 3:
                    if (day <= 20)
                        return "pisces";
                    else
                        return "aries";
                case 4:
                    if (day <= 19)
                        return "aries";
                    else
                        return "taurus";
                case 5:
                    if (day <= 20)
                        return "taurus";
                    else
                        return "gemini";
                case 6:
                    if (day <= 20)
                        return "gemini";
                    else
                        return "cancer";
                case 7:
                    if (day <= 22)
                        return "cancer";
                    else
                        return "leo";
                case 8:
                    if (day <= 22)
                        return "leo";
                    else
                        return "virgo";
                case 9:
                    if (day <= 22)
                        return "virgo";
                    else
                        return "libra";
                case 10:
                    if (day <= 22)
                        return "libra";
                    else
                        return "scorpio";
                case 11:
                    if (day <= 21)
                        return "scorpio";
                    else
                        return "sagittarius";
                case 12:
                    if (day <= 21)
                        return "sagittarius";
                    else
                        return "capricorn";
            }
            return "";
        }
        private bool validDate(string date)
        {
            DateTime todayDate = DateTime.Today;
            DateTime userBirthdate = DateTime.MinValue;
            if (!DateTime.TryParse(date, out userBirthdate) || userBirthdate > todayDate) return false;
            return true;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (!validDate(textBox.Text)) System.Windows.MessageBox.Show("Invalid data, please try again");
            else
            {
                label2.Visibility = System.Windows.Visibility.Visible;
                //BitmapImage bi3 = new BitmapImage();
                //bi3.BeginInit();
                //bi3.UriSource = new Uri("pack://application:,,,/Resources/" + GetZodiacName(DateTime.Parse(textBox.Text))+ ".jpg");
                //bi3.EndInit();
                //image.Source = bi3;
                image.Source = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/" + GetZodiacName(DateTime.Parse(textBox.Text))+ ".jpg", UriKind.Absolute));
            }
        }
    }
}

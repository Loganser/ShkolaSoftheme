using System;
using System.Linq;
using System.Windows;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool GenderChecked = false;

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            if ((FirstNameBox.Text.Where(Char.IsLetter).ToArray().Length < FirstNameBox.Text.Length) || (FirstNameBox.Text.Length >= 255) ||
                (LastNameBox.Text.Where(Char.IsLetter).ToArray().Length < LastNameBox.Text.Length) ||(LastNameBox.Text.Length >= 255) || 
                (BirthdayBox.SelectedDate == null) ||
                (BirthdayBox.SelectedDate.Value.Year > DateTime.Now.Year) || (BirthdayBox.SelectedDate.Value.Year < 1900) ||
                (PhoneBox.Text.Where(Char.IsDigit).ToArray().Length < FirstNameBox.Text.Length) ||
                (!EmailBox.Text.Contains("@")) || (EmailBox.Text.Length >= 255) ||
                (!GenderChecked) ||
                (PhoneBox.Text.Length != 12) ||
                (AdditionalBox.Text.Length >= 2000))

                    MessageBox.Show("Error!");
            else
                    MessageBox.Show("OK");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            GenderChecked = true;
        }
    }
}

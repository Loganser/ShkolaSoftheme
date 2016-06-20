using System;
using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int MaxValue = 10;
        private Random Randomizer = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int value;
            try
            {
                value = Convert.ToInt32(NumberEdit.Text);
            }
            catch
            {
                MessageBox.Show("Please enter number in [1; 10]", "");
                return;
            }

            int randValue = Randomizer.Next(MaxValue) + 1;
            if (randValue == value)
                MessageBox.Show("Right! Gratz!");
            else
                MessageBox.Show("Right answer is: " + randValue + " Please try again");

        }
    }
}

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
            
        }
        class MyTable
        {
            public MyTable(string Numeric_Type, string Default_Value, string Minimum_Value, string Maximum_Value)
            {
                this.Numeric_Type = Numeric_Type;
                this.Default_Value = Default_Value;
                this.Minimum_Value = Minimum_Value;
                this.Maximum_Value = Maximum_Value;
            }
            public string Numeric_Type { get; set; }
            public string Default_Value { get; set; }
            public string Minimum_Value { get; set; }
            public string Maximum_Value { get; set; }
        }

        private void Numeric_Types_Loaded(object sender, RoutedEventArgs e)
        {
            List<MyTable> result = new List<MyTable>(4);
            result.Add(new MyTable("bool", "false", "none","none"));
            result.Add(new MyTable("byte", "0", "0", "255"));
            result.Add(new MyTable("char", @"'\0'", "none", "none"));
            result.Add(new MyTable("decimal", "0.0M", "-79228162514264337593543950335", "79228162514264337593543950335"));
            result.Add(new MyTable("double", "0.0D", "-1.79769313486232e308", "1.79769313486232e308"));
            result.Add(new MyTable("enum", "The value produced by the expression (E)0, where E is the enum identifier.", "none", "none"));
            result.Add(new MyTable("float", "0.0F", "-3.402823e38", "3.402823e38"));
            result.Add(new MyTable("int", "0", "-2,147,483,648", "2,147,483,647"));
            result.Add(new MyTable("long", "0L", "-9,223,372,036,854,775,808", "9,223,372,036,854,775,807"));
            result.Add(new MyTable("sbyte", "0", "-128", "127"));
            result.Add(new MyTable("short", "0", "-32,768", "32,767"));
            result.Add(new MyTable("struct", "The value produced by setting all value-type fields to their default values and all reference-type fields to null.", "none", "none"));
            result.Add(new MyTable("uint", "0", "0", "4,294,967,295"));
            result.Add(new MyTable("ulong", "0", "0", "18,446,744,073,709,551,615"));
            result.Add(new MyTable("ushort", "0", "0", "65,535"));
            Numeric_Types.ItemsSource = result;
            Numeric_Types.MinRowHeight = 16;

            //Numeric_Types.ItemsSource = null;
        }
    }
}

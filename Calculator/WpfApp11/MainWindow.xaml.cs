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

namespace WpfApp11
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

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var tb = sender as Button;

            textbox.Text += tb.Content as string;
        }

        private void Delete_Contex(object sender, RoutedEventArgs e)
        {

            textbox.Text = " ";

        }

        private void result(object sender, RoutedEventArgs e)
        {
            string op;
            int op2 = 0;
            string[] opList = {"*","/","+","-","%",".","&" };
            string text = textbox.Text;

            op= Calc.Containsop(text, opList);

            string[] numberslist = Calc.split(text, opList);

            double number1 = Calc.converter(numberslist[0]);

            double number2 = Calc.converter(numberslist[1]);


            textbox.Text += "=" + Calc.calculator(op, number1, number2);
        }
    }
}

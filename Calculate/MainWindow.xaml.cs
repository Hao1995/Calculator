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

namespace Calculate
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

        double nowValue, lastResult;
        string nowOperator, lastOperator;
        bool addOperator = false;

        //CE
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            txtResultNow.Text = "0";
        }

        //C
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            txtResultNow.Text = "0";
            txtResultBefore.Text = "";
            nowValue = lastResult = 0;
            nowOperator = lastOperator = null;
        }

        //DLE
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            var str = txtResultNow.Text;
            txtResultNow.Text = str.Substring(0, str.Length - 1);
        }

        //Operator
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            lastResult = nowValue;
            lastOperator = nowOperator;

            try
            {

                txtResultNow.Text = txtResultNow.Text.TrimEnd('.');//Remove last '.'
                nowValue = double.Parse(txtResultNow.Text);
                nowOperator = b.Content.ToString();
                if (txtResultBefore.Text == "")
                {
                    if (nowOperator == "=")
                    {
                        nowOperator = null;
                        addOperator = true;
                    }
                    else
                        txtResultBefore.Text = txtResultNow.Text + b.Content.ToString();
                }
                else
                {
                    if (nowOperator == "=")
                    {
                        txtResultBefore.Text = "";
                    }
                    else
                    {
                        txtResultBefore.Text += txtResultNow.Text + b.Content.ToString();
                    }
                    switch (lastOperator)
                    {
                        case "+":
                            nowValue = lastResult + nowValue;
                            txtResultNow.Text = Convert.ToString(nowValue);
                            break;
                        case "-":
                            nowValue = lastResult - nowValue;
                            txtResultNow.Text = Convert.ToString(nowValue);
                            break;
                        case "*":
                            nowValue = lastResult * nowValue;
                            txtResultNow.Text = Convert.ToString(nowValue);
                            break;
                        case "/":
                            nowValue = lastResult / nowValue;
                            txtResultNow.Text = Convert.ToString(nowValue);
                            break;
                    }
                }
                
                addOperator = true;
            }
            catch
            {
                MessageBox.Show("You have no number can be calculate ! ");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            if (addOperator)
            {
                txtResultNow.Text = "0";
                addOperator = false;
            }

            if (txtResultNow.Text == "0")
            {
                if (b.Content.ToString() == ".")
                {
                    txtResultNow.Text += b.Content.ToString();
                }
                else
                {
                    txtResultNow.Text = b.Content.ToString();
                }
            }
            else
            {
                txtResultNow.Text += b.Content.ToString();
            }
        }
    }
}

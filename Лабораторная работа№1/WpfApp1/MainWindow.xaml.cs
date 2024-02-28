using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using StarBuzz;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string imageAmericanoPath = "pack://application:,,,/americano.jpg";
        string imageCappuccinoPath = "pack://application:,,,/cappuccino.jpeg";
        string imageCocoaPath = "pack://application:,,,/cocoa.jpeg";
        string imageEspressoPath = "pack://application:,,,/espresso.jpeg";
        string imageMilkPath = "pack://application:,,,/Milk.jpg";
        string imageSugarPath = "pack://application:,,,/Sugar.jpg";
        Beverage beverage;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;

            if (pressed.Name == "Americano")
            {
                imageType.Source = new BitmapImage(new Uri(imageAmericanoPath, UriKind.Absolute));
            }

            if (pressed.Name == "Cappuccino")
            {
                imageType.Source = new BitmapImage(new Uri(imageCappuccinoPath, UriKind.Absolute));
            }

            if (pressed.Name == "Espresso")
            {
                imageType.Source = new BitmapImage(new Uri(imageEspressoPath, UriKind.Absolute));
            }

            if (pressed.Name == "Cocoa")
            {
                imageType.Source = new BitmapImage(new Uri(imageCocoaPath, UriKind.Absolute));
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox check = (CheckBox)sender;

            if(check.Name =="milk" && check.IsChecked == true)
            {
                imageMikl.Visibility = Visibility.Visible;
                imageMikl.Source = new BitmapImage(new Uri(imageMilkPath, UriKind.Absolute));
            }

            else if (check.Name == "milk")
            {
                imageMikl.Visibility = Visibility.Hidden;
            }

            if (check.Name == "sugar" && check.IsChecked == true)
            {
                imageSugar.Visibility = Visibility.Visible;
                imageSugar.Source = new BitmapImage(new Uri(imageSugarPath, UriKind.Absolute));
            }

            else if (check.Name == "sugar")
            {
                imageSugar.Visibility = Visibility.Hidden;
            }
        }

        private void inMoneyButton(object sender, RoutedEventArgs e)
        {
            if (inputMoney.Text != "")
            {
                inputtedMoney.Content = "Внесенная сумма: " + double.Parse(inputMoney.Text.ToString());
            }
        }

        private void ClickOK(object sender, RoutedEventArgs e)
        {
            if(Americano.IsChecked == true)
            {
                beverage = new Americano();
            }

            if (Cappuccino.IsChecked == true)
            {
                beverage = new Cappuccino();
            }

            if (Espresso.IsChecked == true)
            {
                beverage = new Espresso();
            }

            if (Cocoa.IsChecked == true)
            {
                beverage = new Cocoa();
            }

            if (sugar.IsChecked == true)
            {
                beverage = new Milk(beverage);
            }

            if(milk.IsChecked == true)
            {
                beverage = new Sugar(beverage);
            }

            if(inputMoney.Text != "")
            {
                inputtedMoney.Content = "Внесенная сумма: " + double.Parse(inputMoney.Text.ToString());

                costBeverage.Content = "Цена напитка: " + beverage.cost();

                changeLable.Content = "Сдача: " + (double.Parse(inputMoney.Text.ToString()) - beverage.cost());

            }
        }
    }
}

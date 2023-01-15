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

namespace XOCalculator
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

        private void ResourceMenuButtonOpen(object sender, RoutedEventArgs e)//opens and closes resource menu
        {
            if (ResouceMenu.Visibility != Visibility.Hidden)
            {
                ResouceMenu.Visibility = Visibility.Hidden;//hides resource menu
                ShowAndHideResourcesButton.Content = "show resources";
                CalculationMenu.Visibility = Visibility.Visible;
            }
            else
            {
                ResouceMenu.Visibility = Visibility.Visible;//unhides resource menu
                CalculationMenu.Visibility = Visibility.Hidden;
                ShowAndHideResourcesButton.Content = "hide resources";
            }
        }

        private void ValueSearched(object sender, DependencyPropertyChangedEventArgs e)//search bar for resources
        {

        }
        private void Calculate(object sender, RoutedEventArgs e)//Runs the calculation
        {

        }
    }
}

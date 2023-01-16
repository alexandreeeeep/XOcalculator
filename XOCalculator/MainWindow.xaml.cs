using System;
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
using System.Windows.Media.TextFormatting;
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
            InitializeComponent();//starts UI
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
            
            string ItemName = FindValue("mediumwheelst");
            OutputValue.Text = ItemName;
        }
        string FindValue(string SearchItem)
        {
            // Calling the ReadAllLines() function
            string ItemFound;
        string[] ItemName = File.ReadAllLines("Items.txt");
        foreach (string line in ItemName)//itarates threw each line
        {
            ItemFound = "";
            foreach (char c in line) {//itarates threw each letter 
                    if (c != '_')//finds the end of the first word
                    {
                        ItemFound += c.ToString();
                    }
                    else if(ItemFound==SearchItem)
                    {
                        return line;
                    }
                    else { break; }
            }
        }
        return "Item Not Found";
        }
    }
}

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
        private void Calculate(object sender, RoutedEventArgs e)//Runs the calculation for the Item
        {
            //validates if there is an input
            if (scrapQuantity.Text == "")
            {
                scrapQuantity.Text = "0";
            }
            if (copperQuantity.Text == "")
            {
                copperQuantity.Text = "0";
            }
            if(wiresQuantity.Text == "")
            {
                wiresQuantity.Text = "0";
            }
            if (batterysQuantity.Text== "")
            {
                batterysQuantity.Text = "0";
            }
            if (plasticQuantity.Text == "")
            {
                plasticQuantity.Text = "0";
            }
            if (electronicsQuantity.Text == "")
            {
                electronicsQuantity.Text = "0";
            }
            if (uraniumQuantity.Text == "")
            {
                uraniumQuantity.Text = "0";
            }
            if (ScrapCost.Text == "")
            {
                ScrapCost.Text = "0";
            }
            if (CopperCost.Text == "")
            {
                CopperCost.Text = "0";
            }
            if (WiresCost.Text == "")
            {
                WiresCost.Text = "0";
            }
            if (BatterysCost.Text == "")
            {
                BatterysCost.Text = "0";
            }
            if (PlasticCost.Text == "")
            {
                PlasticCost.Text = "0";
            }
            if (ElectronicsCost.Text == "")
            {
                ElectronicsCost.Text = "0";
            }
            if (UraniumCost.Text == "")
            {
                UraniumCost.Text = "0";
            }

            //valdades if there is an incorrect input
            if ((scrapQuantity.Text+copperQuantity.Text+wiresQuantity.Text + batterysQuantity.Text + plasticQuantity.Text + electronicsQuantity.Text + uraniumQuantity.Text).All("1234567890.".Contains))
            {
                if((ScrapCost.Text + CopperCost.Text + WiresCost.Text + BatterysCost.Text + PlasticCost.Text + ElectronicsCost.Text + UraniumCost.Text).All("1234567890.".Contains)){
                    //calculation goes here
                }
                else
                {
                    OutputValue.Text = "Resource costs must be a number";
                }
            }
            else
            {
                OutputValue.Text = "Resource Quantity must be a number";
            }
        }

        private void Search(object sender, RoutedEventArgs e)//Runs the calculation
        {
            string ItemName = FindValue(ItemSearch.Text.ToLower().ToString());//takes user input and searches for it in algorithm
            string[] Item = SeparateList(ItemName);
            OutputValue.Text = Item[0];

            //setting amount boxes
            scrapQuantity.Text = Item[1];
            copperQuantity.Text = Item[2];
            wiresQuantity.Text = Item[3];
            batterysQuantity.Text = Item[4];
            plasticQuantity.Text = Item[5];
            electronicsQuantity.Text = Item[6];
            uraniumQuantity.Text = Item[7];

            //runs the program showing the cost
            Calculate(sender, e);
        }
        string[] SeparateList(string ItemName)//finds the name in the text file
        {
            string[] Item = new string[] { "","","","","","","","", "", "", "", "", "", "" };
            int CountForList = 0;
            for (int i = 0; i < ItemName.Length;i++)
            {//itarates threw each letter
                if (ItemName[i] != '_')//finds the end of the first word
                {
                    Item[CountForList] += ItemName[i];
                }
                else
                {
                    CountForList++;
                }
            }
            return Item;
        }
        string FindValue(string SearchItem)//finds the name in the text file
        {
            // Calling the ReadAllLines() function
            string ItemFound;
            string[] ItemName = File.ReadAllLines("Items.txt");
            Array.Sort(ItemName);//sorts it into alphabetical order
            foreach (string line in ItemName)//itarates threw each line
            {
                ItemFound = "";
                foreach (char c in line)
                {//itarates threw each letter 
                    if (c != '_')//finds the end of the first word
                    {
                        ItemFound += c.ToString();
                    }
                    else if (ItemFound == SearchItem && ItemFound != "")
                    {
                        return line;
                    }
                    else { break; }
                }
            }
            return "Item Not Found";//returns if item not found
        }
    }
}

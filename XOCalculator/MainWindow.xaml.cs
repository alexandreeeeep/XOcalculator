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
            RarityCombobox.Text = "Common";
        }
        private void ResourceMenuHintsButton(object sender, RoutedEventArgs e)//opens and closes resource menu
        {
            if (CalculationMenuHints.Visibility != Visibility.Hidden)
            {
                CalculationMenuHints.Visibility = Visibility.Hidden;
                ShowAndHideHintsButton.Content = "show hints";
            }
            else
            {
                CalculationMenuHints.Visibility = Visibility.Visible;
                ShowAndHideHintsButton.Content = "hide hints";
            }
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
            string ItemName = FindValue(ItemSearch.Text.ToLower().ToString());//takes user input and searches for it in algorithm
            string[] Item = SeparateList(ItemName);
            float CraftingCost = 0;
            //validates if there is an input
            if (scrapQuantity.Text == ""){
                scrapQuantity.Text = "0";
            }
            if (copperQuantity.Text == ""){
                copperQuantity.Text = "0";
            }
            if(wiresQuantity.Text == ""){
                wiresQuantity.Text = "0";
            }
            if (batterysQuantity.Text== ""){
                batterysQuantity.Text = "0";
            }
            if (plasticQuantity.Text == ""){
                plasticQuantity.Text = "0";
            }
            if (electronicsQuantity.Text == ""){
                electronicsQuantity.Text = "0";
            }
            if (uraniumQuantity.Text == ""){
                uraniumQuantity.Text = "0";
            }
            if (ScrapCost.Text == ""){
                ScrapCost.Text = "0";
            }
            if (CopperCost.Text == ""){
                CopperCost.Text = "0";
            }
            if (WiresCost.Text == ""){
                WiresCost.Text = "0";
            }
            if (BatterysCost.Text == ""){
                BatterysCost.Text = "0";
            }
            if (PlasticCost.Text == ""){
                PlasticCost.Text = "0";
            }
            if (ElectronicsCost.Text == ""){
                ElectronicsCost.Text = "0";
            }
            if (UraniumCost.Text == ""){
                UraniumCost.Text = "0";
            }
            if (Item1Count.Text == ""){
                Item1Count.Text = "1";
            }
            if (Item2Count.Text == ""){
                Item2Count.Text = "1";
            }
            if (Item3Count.Text == ""){
                Item3Count.Text = "1";
            }
            if (Item1Value.Text == ""){
                Item1Value.Text = "0";
            }
            if (Item2Value.Text == ""){
                Item2Value.Text = "0";
            }
            if (Item3Value.Text == ""){
                Item3Value.Text = "0";
            }
            if (RarityCombobox.Text == "Common" || RarityCombobox.Text == "Relic")
            {
                CraftingCost = 0;
            }
            else if (RarityCombobox.Text == "Rare")
            {
                CraftingCost = 3;
            }
            else if (RarityCombobox.Text == "Special")
            {
                CraftingCost = 6;
            }
            else if (RarityCombobox.Text == "Epic")
            {
                CraftingCost = 15;
            }
            else if (RarityCombobox.Text == "Legendary")
            {
                CraftingCost = 75;
            }

            //valdades if there is an incorrect input
            if ((scrapQuantity.Text+copperQuantity.Text+wiresQuantity.Text + batterysQuantity.Text + plasticQuantity.Text + electronicsQuantity.Text + uraniumQuantity.Text).All("1234567890.".Contains))
            {
                if ((ScrapCost.Text + CopperCost.Text + WiresCost.Text + BatterysCost.Text + PlasticCost.Text + ElectronicsCost.Text + UraniumCost.Text).All("1234567890.".Contains)) {

                    if ((Item1Count.Text + Item2Count.Text + Item3Count.Text).All("1234567890.".Contains))
                    {
                        //calcultation

                        //sets name of item and displays items in the box above
                        if (!Item1Value.Text.All("1234567890.".Contains))
                        {
                            ItemName1.Content = Item1Value.Text;
                        }
                        else if (!Item2Value.Text.All("1234567890.".Contains))
                        {
                            ItemName2.Content = Item2Value.Text;
                        }
                        else if (!Item3Value.Text.All("1234567890.".Contains))
                        {
                            ItemName3.Content = Item3Value.Text;
                        }
                        Item1Value.Text = CalculateCostOfItem(Item1Value.Text).ToString();
                        Item2Value.Text = CalculateCostOfItem(Item2Value.Text).ToString();
                        Item3Value.Text = CalculateCostOfItem(Item3Value.Text).ToString();
                        //calculates end result
                        OutputValue.Text = "Cost: " + (float.Parse(ScrapCost.Text) / 100f * float.Parse(scrapQuantity.Text) +
                            float.Parse(copperQuantity.Text) * float.Parse(CopperCost.Text) / 100f +
                            float.Parse(WiresCost.Text) / 100f * float.Parse(wiresQuantity.Text) +
                            float.Parse(BatterysCost.Text) / 10f * float.Parse(batterysQuantity.Text) +
                            float.Parse(PlasticCost.Text) / 100f * float.Parse(plasticQuantity.Text) +
                            float.Parse(ElectronicsCost.Text) / 10f * float.Parse(electronicsQuantity.Text) +
                            float.Parse(UraniumCost.Text) / 10f * float.Parse(electronicsQuantity.Text) +
                            float.Parse(Item1Value.Text) * float.Parse(Item1Count.Text) +
                            float.Parse(Item2Value.Text) * float.Parse(Item2Count.Text) +
                            float.Parse(Item3Value.Text) * float.Parse(Item3Count.Text) +
                            CraftingCost
                            ).ToString();
                    }
                    else
                    {
                        OutputValue.Text = "Item amount must be a number";
                    }
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
        float CalculateCostOfItem(string ItemName)//calculates cost of item
        {
            if(ItemName == "Empty" || ItemName =="") {
                return 0f;
            }
            if (float.TryParse(ItemName , out float Result))
            {
                return Result;
            }
            string[] Item = SeparateList(FindValue(ItemName));//finds the item and creates list
            if (Item[0] == "Item Not Found")
            {
                return 0f;
            }
            //calculates value of item and calculates other items if needed
            return float.Parse(ScrapCost.Text) / 100f * float.Parse(Item[1]) +
            float.Parse(Item[2]) * float.Parse(CopperCost.Text) / 100f +
               float.Parse(WiresCost.Text) / 100 * float.Parse(Item[3]) +
               float.Parse(Item[4]) / 10f * float.Parse(BatterysCost.Text) +
               float.Parse(Item[5]) / 100f * float.Parse(PlasticCost.Text) +
               float.Parse(Item[6]) / 10f * float.Parse(ElectronicsCost.Text) +
               float.Parse(Item[7]) / 10f * float.Parse(UraniumCost.Text)
               +CalculateCostOfItem(Item[8])*float.Parse(Item[9])+
               CalculateCostOfItem(Item[10]) * float.Parse(Item[11])+
               CalculateCostOfItem(Item[12]) * float.Parse(Item[13])+ float.Parse(Item[14]);
        }

        private void Search(object sender, RoutedEventArgs e)//Runs the calculation
        {
            Calculate(null, null);//prevents null errors
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
            //inputs for items
            Item1Value.Text = CalculateCostOfItem(Item[8]).ToString();
            ItemName1.Content = Item[8];
            Item1Count.Text = Item[9];
            Item2Value.Text = CalculateCostOfItem(Item[10]).ToString();
            ItemName2.Content = Item[10];
            Item2Count.Text = Item[11];
            Item3Value.Text = CalculateCostOfItem(Item[12]).ToString();
            ItemName3.Content = Item[12];
            Item3Count.Text = Item[13];
            float uranium = 0;
            float.TryParse(uraniumQuantity.Text, out uranium);
            if (uranium > 0)
            {
                RarityCombobox.Text = "Relic";
            }
            else if (Item[14] == "0")
            {
                RarityCombobox.Text = "Common";
            }
            else if (Item[14] == "3")
            {
                RarityCombobox.Text = "Rare";
            }
            else if (Item[14] == "6")
            {
                RarityCombobox.Text = "Special";
            }
            else if (Item[14] == "15")
            {
                RarityCombobox.Text = "Epic";
            }
            else if (Item[14] == "75")
            {
                RarityCombobox.Text = "Legendary";
            }
            //runs the program showing the cost
            if (Item[0] != "Item Not Found")//shows an error message if item is not found
            {
                Calculate(sender, e);
            }
        }
        string[] SeparateList(string ItemName)//finds the name in the text file
        {
            string[] Item = new string[] { "","","","","","","","", "", "", "", "", "", "","" };
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
                    else { break;}
                }
            }
            return "Item Not Found";//returns if item not found
        }
    }
}

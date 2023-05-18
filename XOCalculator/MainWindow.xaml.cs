using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace XOCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()//main window
        {
            InitializeComponent();//starts UI
            if (!File.Exists("Savefile.txt"))
            {
                string[] emptyFile = new string[] { "0", "0", "0", "0", "0", "0", "0" };
                File.WriteAllLines("Savefile.txt", emptyFile);
            }
            if (!File.Exists("Items.txt"))
            {
                CreateDatabase();//creates the data store on first boot up
            }
            RarityCombobox.Text = "Common";

            if (File.Exists("Items.txt"))//allows to check if items are missing
            {
                var AllItems = new List<string>();
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
                        else if (ItemFound != "")
                        {
                            AllItems.Add(ItemFound);
                            break;
                        }
                    }
                }
                //give text boxes have a auto complete
                ItemSearch.FilterMode = AutoCompleteFilterMode.Contains;
                ItemSearch.ItemsSource = AllItems;
                Item1Value.FilterMode = AutoCompleteFilterMode.Contains;
                Item1Value.ItemsSource = AllItems;
                Item2Value.FilterMode = AutoCompleteFilterMode.Contains;
                Item2Value.ItemsSource = AllItems;
                Item3Value.FilterMode = AutoCompleteFilterMode.Contains;
                Item3Value.ItemsSource = AllItems;
                BuildItem1.FilterMode = AutoCompleteFilterMode.Contains;
                BuildItem1.ItemsSource = AllItems;
                BuildItem2.FilterMode = AutoCompleteFilterMode.Contains;
                BuildItem2.ItemsSource = AllItems;
                BuildItem3.FilterMode = AutoCompleteFilterMode.Contains;
                BuildItem3.ItemsSource = AllItems;
                BuildItem4.FilterMode = AutoCompleteFilterMode.Contains;
                BuildItem4.ItemsSource = AllItems;
                BuildItem5.FilterMode = AutoCompleteFilterMode.Contains;
                BuildItem5.ItemsSource = AllItems;
                BuildItem6.FilterMode = AutoCompleteFilterMode.Contains;
                BuildItem6.ItemsSource = AllItems;
				BuildItem7.FilterMode = AutoCompleteFilterMode.Contains;
				BuildItem7.ItemsSource = AllItems;
				BuildItem8.FilterMode = AutoCompleteFilterMode.Contains;
				BuildItem8.ItemsSource = AllItems;
				BuildItem9.FilterMode = AutoCompleteFilterMode.Contains;
				BuildItem9.ItemsSource = AllItems;
				BuildItem10.FilterMode = AutoCompleteFilterMode.Contains;
				BuildItem10.ItemsSource = AllItems;
				BuildItem11.FilterMode = AutoCompleteFilterMode.Contains;
				BuildItem11.ItemsSource = AllItems;
				BuildItem12.FilterMode = AutoCompleteFilterMode.Contains;
				BuildItem12.ItemsSource = AllItems;
				BuildItem13.FilterMode = AutoCompleteFilterMode.Contains;
				BuildItem13.ItemsSource = AllItems;
				BuildItem14.FilterMode = AutoCompleteFilterMode.Contains;
				BuildItem14.ItemsSource = AllItems;
				BuildItem15.FilterMode = AutoCompleteFilterMode.Contains;
				BuildItem15.ItemsSource = AllItems;
			}
            //takes values from save file
            string[] MaterialCosts = File.ReadAllLines("Savefile.txt");
            ScrapCost.Text = MaterialCosts[0];
            CopperCost.Text = MaterialCosts[1];
            WiresCost.Text = MaterialCosts[2];
            PlasticCost.Text = MaterialCosts[3];
            BatterysCost.Text = MaterialCosts[4];
            ElectronicsCost.Text = MaterialCosts[5];
            UraniumCost.Text = MaterialCosts[6];
            BuildMenuButtonOpen(null, null);
        }
		public static string GetLast(string source, int numberOfChars)
		{
			if (numberOfChars >= source.Length)
				return source;
			return source.Substring(source.Length - numberOfChars);
		}
        private void Clear(object sender, RoutedEventArgs e)
        {
            int SenderNumber;
            string senderStr = ((Button)sender).Name;
            try
            {
                //  Block of code to try
                SenderNumber = int.Parse(GetLast(senderStr, 2).ToString());
            }
            catch (Exception)
            {
                //  Block of code to handle errors
                SenderNumber = int.Parse(GetLast(senderStr, 1).ToString());
            }
            if (SenderNumber == 1)
            {
                Cost1.Text = Cost2.Text;
                Count1.Text = Count2.Text;
                Total1.Text = Total2.Text;
                BuildItem1.Text = BuildItem2.Text;
            }
            if (SenderNumber <= 2)
            {
                Cost2.Text = Cost3.Text;
                Count2.Text = Count3.Text;
                Total2.Text = Total3.Text;
                BuildItem2.Text = BuildItem3.Text;
                if (BuildItem2.Text == "" && Row3.Visibility == Visibility.Hidden)
                {
                    Row2.Visibility = Visibility.Hidden;
                }
            }
            if (SenderNumber <= 3)
            {
                Cost3.Text = Cost4.Text;
                Count3.Text = Count4.Text;
                Total3.Text = Total4.Text;
                BuildItem3.Text = BuildItem4.Text;
                if (BuildItem3.Text == "" && Row4.Visibility == Visibility.Hidden)
                {
                    Row3.Visibility = Visibility.Hidden;
                }
            }
            if (SenderNumber <= 4)
            {
                Cost4.Text = Cost5.Text;
                Count4.Text = Count5.Text;
                Total4.Text = Total5.Text;
                BuildItem4.Text = BuildItem5.Text;
                if (BuildItem4.Text == "" && Row5.Visibility == Visibility.Hidden)
                {
                    Row4.Visibility = Visibility.Hidden;
                }
            }
            if (SenderNumber <= 5)
            {
                Cost5.Text = Cost6.Text;
                Count5.Text = Count6.Text;
                Total5.Text = Total6.Text;
                BuildItem5.Text = BuildItem6.Text;
                if (BuildItem5.Text == "" && Row6.Visibility == Visibility.Hidden)
                {
                    Row5.Visibility = Visibility.Hidden;
                }
            }
            if (SenderNumber <= 6)
            {
                Cost6.Text = Cost7.Text;
                Count6.Text = Count7.Text;
                Total6.Text = Total7.Text;
                BuildItem6.Text = BuildItem7.Text;
                if (BuildItem6.Text == "" && Row7.Visibility == Visibility.Hidden)
                {
                    Row6.Visibility = Visibility.Hidden;
                }
            }
            if (SenderNumber <= 7)
            {
                Cost7.Text = Cost8.Text;
                Count7.Text = Count8.Text;
                Total7.Text = Total8.Text;
                BuildItem7.Text = BuildItem8.Text;
                if (BuildItem7.Text == "" && Row8.Visibility == Visibility.Hidden)
                {
                    Row7.Visibility = Visibility.Hidden;
                }
            }
            if (SenderNumber <= 8)
            {
                Cost8.Text = Cost9.Text;
                Count8.Text = Count9.Text;
                Total8.Text = Total9.Text;
                BuildItem8.Text = BuildItem9.Text;
                if (BuildItem8.Text == "" && Row9.Visibility == Visibility.Hidden)
                {
                    Row8.Visibility = Visibility.Hidden;
                }
            }
            if (SenderNumber <= 9)
            {
                Cost9.Text = Cost10.Text;
                Count9.Text = Count10.Text;
                Total9.Text = Total10.Text;
                BuildItem9.Text = BuildItem10.Text;
                if (BuildItem9.Text == "" && Row10.Visibility == Visibility.Hidden)
                {
                    Row9.Visibility = Visibility.Hidden;
                }
            }
            if (SenderNumber <= 10)
            {
                Cost10.Text = Cost11.Text;
                Count10.Text = Count11.Text;
                Total10.Text = Total11.Text;
                BuildItem10.Text = BuildItem11.Text;
                if (BuildItem10.Text == "" && Row11.Visibility == Visibility.Hidden)
                {
                    Row10.Visibility = Visibility.Hidden;
                }
            }
            if (SenderNumber <= 11)
            {
                Cost11.Text = Cost12.Text;
                Count11.Text = Count12.Text;
                Total11.Text = Total12.Text;
                BuildItem11.Text = BuildItem12.Text;
                if (BuildItem11.Text == "" && Row12.Visibility == Visibility.Hidden)
                {
                    Row11.Visibility = Visibility.Hidden;
                }
            }
            if (SenderNumber <= 12)
            {
                Cost12.Text = Cost13.Text;
                Count12.Text = Count13.Text;
                Total12.Text = Total13.Text;
                BuildItem12.Text = BuildItem13.Text;
                if (BuildItem12.Text == "" && Row13.Visibility == Visibility.Hidden)
                {
                    Row12.Visibility = Visibility.Hidden;
                }
            }
            if (SenderNumber <= 13)
            {
                Cost13.Text = Cost14.Text;
                Count13.Text = Count14.Text;
                Total13.Text = Total14.Text;
                BuildItem13.Text = BuildItem14.Text;
                if (BuildItem13.Text == "" && Row14.Visibility == Visibility.Hidden)
                {
                    Row13.Visibility = Visibility.Hidden;
                }
            }
            if (SenderNumber <= 14)
            {
                Cost14.Text = Cost15.Text;
                Count14.Text = Count15.Text;
                Total14.Text = Total15.Text;
                BuildItem14.Text = BuildItem15.Text;
                if (BuildItem14.Text == "" && Row15.Visibility == Visibility.Hidden)
                {
                    Row14.Visibility = Visibility.Hidden;
                }
            }
            Cost15.Text = "0";
            Count15.Text = "";
            Total15.Text = "0";
            BuildItem15.Text = "";
			Row15.Visibility = Visibility.Hidden;

		}
        void CheckNulls()
        {
            if (!Cost1.Text.Any("1234567890".Contains)) { Cost1.Text = "0"; }
            if (!Cost2.Text.Any("1234567890".Contains)) { Cost2.Text = "0"; }
            if (!Cost3.Text.Any("1234567890".Contains)) { Cost3.Text = "0"; }
            if (!Cost4.Text.Any("1234567890".Contains)) { Cost4.Text = "0"; }
            if (!Cost5.Text.Any("1234567890".Contains)) { Cost5.Text = "0"; }
            if (!Cost6.Text.Any("1234567890".Contains)) { Cost6.Text = "0"; }
            if (!Cost7.Text.Any("1234567890".Contains)) { Cost7.Text = "0"; }
            if (!Cost8.Text.Any("1234567890".Contains)) { Cost8.Text = "0"; }
            if (!Cost9.Text.Any("1234567890".Contains)) { Cost9.Text = "0"; }
            if (!Cost10.Text.Any("1234567890".Contains)) { Cost10.Text = "0"; }
            if (!Cost11.Text.Any("1234567890".Contains)) { Cost11.Text = "0"; }
            if (!Cost12.Text.Any("1234567890".Contains)) { Cost12.Text = "0"; }
            if (!Cost13.Text.Any("1234567890".Contains)) { Cost13.Text = "0"; }
            if (!Cost14.Text.Any("1234567890".Contains)) { Cost14.Text = "0"; }
            if (!Cost15.Text.Any("1234567890".Contains)) { Cost15.Text = "0"; }
                
            if (!Count1.Text.Any("1234567890".Contains)) { Count1.Text = "1"; }
            if (!Count2.Text.Any("1234567890".Contains)) { Count2.Text = "1"; }
            if (!Count3.Text.Any("1234567890".Contains)) { Count3.Text = "1"; }
            if (!Count4.Text.Any("1234567890".Contains)) { Count4.Text = "1"; }
            if (!Count5.Text.Any("1234567890".Contains)) { Count5.Text = "1"; }
            if (!Count6.Text.Any("1234567890".Contains)) { Count6.Text = "1"; }
            if (!Count7.Text.Any("1234567890".Contains)) { Count7.Text = "1"; }
            if (!Count8.Text.Any("1234567890".Contains)) { Count8.Text = "1"; }
            if (!Count9.Text.Any("1234567890".Contains)) { Count9.Text = "1"; }
            if (!Count10.Text.Any("1234567890".Contains)) { Count10.Text = "1"; }
            if (!Count11.Text.Any("1234567890".Contains)) { Count11.Text = "1"; }
            if (!Count12.Text.Any("1234567890".Contains)) { Count12.Text = "1"; }
            if (!Count13.Text.Any("1234567890".Contains)) { Count13.Text = "1"; }
            if (!Count14.Text.Any("1234567890".Contains)) { Count14.Text = "1"; }
            if (!Count15.Text.Any("1234567890".Contains)) { Count15.Text = "1"; }
        }
        private void CalcTotal(object sender, RoutedEventArgs e)
        {
            CheckNulls();
            Total1.Text = (float.Parse(Cost1.Text) * float.Parse(Count1.Text)).ToString();
            Total2.Text = (float.Parse(Cost2.Text) * float.Parse(Count2.Text)).ToString();
            Total3.Text = (float.Parse(Cost3.Text) * float.Parse(Count3.Text)).ToString();
            Total4.Text = (float.Parse(Cost4.Text) * float.Parse(Count4.Text)).ToString();
            Total5.Text = (float.Parse(Cost5.Text) * float.Parse(Count5.Text)).ToString();
            Total6.Text = (float.Parse(Cost6.Text) * float.Parse(Count6.Text)).ToString();
            Total7.Text = (float.Parse(Cost7.Text) * float.Parse(Count7.Text)).ToString();
            Total8.Text = (float.Parse(Cost8.Text) * float.Parse(Count8.Text)).ToString();
            Total9.Text = (float.Parse(Cost9.Text) * float.Parse(Count9.Text)).ToString();
            Total10.Text = (float.Parse(Cost10.Text) * float.Parse(Count10.Text)).ToString();
            Total11.Text = (float.Parse(Cost11.Text) * float.Parse(Count11.Text)).ToString();
            Total12.Text = (float.Parse(Cost12.Text) * float.Parse(Count12.Text)).ToString();
            Total13.Text = (float.Parse(Cost13.Text) * float.Parse(Count13.Text)).ToString();
            Total14.Text = (float.Parse(Cost14.Text) * float.Parse(Count14.Text)).ToString();
            Total15.Text = (float.Parse(Cost15.Text) * float.Parse(Count15.Text)).ToString();
            CalculateTotal();
        }
        void CalculateTotal()
        {
            CheckNulls();
            TotalCost.Text ="Total: "+
                (float.Parse(Cost1.Text) * float.Parse(Count1.Text)
               + float.Parse(Cost2.Text) * float.Parse(Count2.Text)
               + float.Parse(Cost3.Text) * float.Parse(Count3.Text)
               + float.Parse(Cost4.Text) * float.Parse(Count4.Text)
               + float.Parse(Cost5.Text) * float.Parse(Count5.Text)
               + float.Parse(Cost6.Text) * float.Parse(Count6.Text)
               + float.Parse(Cost7.Text) * float.Parse(Count7.Text)
               + float.Parse(Cost8.Text) * float.Parse(Count8.Text)
               + float.Parse(Cost9.Text) * float.Parse(Count9.Text)
               + float.Parse(Cost10.Text) * float.Parse(Count10.Text)
               + float.Parse(Cost11.Text) * float.Parse(Count11.Text)
               + float.Parse(Cost12.Text) * float.Parse(Count12.Text)
               + float.Parse(Cost13.Text) * float.Parse(Count13.Text)
               + float.Parse(Cost14.Text) * float.Parse(Count14.Text)
               + float.Parse(Cost15.Text) * float.Parse(Count15.Text)).ToString();
        }
        private void ShowCost(object sender, RoutedEventArgs e)
        {
            string senderStr = ((Button)sender).Name; 
            int SenderNumber;
			try
			{
				//  Block of code to try
				SenderNumber = int.Parse(GetLast(senderStr, 2).ToString());
			}
			catch (Exception)
			{
				//  Block of code to handle errors
				SenderNumber = int.Parse(GetLast(senderStr, 1).ToString());
			}
			switch (SenderNumber)
            {
                case 1:
                    Cost1.Text = CalculateCostOfItem(BuildItem1.Text).ToString();
                    if (Count1.Text == "")
                    {
                        Count1.Text = "1";
                    }
                    Total1.Text = (float.Parse(Cost1.Text) * float.Parse(Count1.Text)).ToString();
                    if (float.Parse(Cost1.Text) > 0)
                    {
                        Row2.Visibility = Visibility.Visible;
                    }
                    break;
                case 2:
                    Cost2.Text = CalculateCostOfItem(BuildItem2.Text).ToString();
                    if (Count2.Text == "")
                    {
                        Count2.Text = "1";
                    }
                    Total2.Text = (float.Parse(Cost2.Text) * float.Parse(Count2.Text)).ToString();
					if (float.Parse(Cost2.Text) > 0)
					{
						Row3.Visibility = Visibility.Visible;
					}
					break;
                case 3:
                    Cost3.Text = CalculateCostOfItem(BuildItem3.Text).ToString();
                    if (Count3.Text == "")
                    {
                        Count3.Text = "1";
                    }
                    Total3.Text = (float.Parse(Cost3.Text) * float.Parse(Count3.Text)).ToString();
					if (float.Parse(Cost3.Text) > 0)
					{
						Row4.Visibility = Visibility.Visible;
					}
					break;
                case 4:
                    Cost4.Text = CalculateCostOfItem(BuildItem4.Text).ToString();
                    if (Count4.Text == "")
                    {
                        Count4.Text = "1";
                    }
                    Total4.Text = (float.Parse(Cost4.Text) * float.Parse(Count4.Text)).ToString();
					if (float.Parse(Cost4.Text) > 0)
					{
						Row5.Visibility = Visibility.Visible;
					}
					break;
                case 5:
                    Cost5.Text = CalculateCostOfItem(BuildItem5.Text).ToString();
                    if (Count5.Text == "")
                    {
                        Count5.Text = "1";
                    }
                    Total5.Text = (float.Parse(Cost5.Text) * float.Parse(Count5.Text)).ToString();
					if (float.Parse(Cost5.Text) > 0)
					{
						Row6.Visibility = Visibility.Visible;
					}
					break;
                case 6:
                    Cost6.Text = CalculateCostOfItem(BuildItem6.Text).ToString();
                    if (Count6.Text == "")
                    {
                        Count6.Text = "1";
                    }
                    Total6.Text = (float.Parse(Cost6.Text) * float.Parse(Count6.Text)).ToString();
					if (float.Parse(Cost6.Text) > 0)
					{
						Row7.Visibility = Visibility.Visible;
					}
					break;
				case 7:
					Cost7.Text = CalculateCostOfItem(BuildItem7.Text).ToString();
					if (Count7.Text == "")
					{
						Count7.Text = "1";
					}
					Total7.Text = (float.Parse(Cost7.Text) * float.Parse(Count7.Text)).ToString();
					if (float.Parse(Cost7.Text) > 0)
					{
						Row8.Visibility = Visibility.Visible;
					}
					break;
				case 8:
					Cost8.Text = CalculateCostOfItem(BuildItem8.Text).ToString();
					if (Count8.Text == "")
					{
						Count8.Text = "1";
					}
					Total8.Text = (float.Parse(Cost8.Text) * float.Parse(Count8.Text)).ToString();
					if (float.Parse(Cost8.Text) > 0)
					{
						Row9.Visibility = Visibility.Visible;
					}
					break;
				case 9:
					Cost9.Text = CalculateCostOfItem(BuildItem9.Text).ToString();
					if (Count9.Text == "")
					{
						Count9.Text = "1";
					}
					Total9.Text = (float.Parse(Cost9.Text) * float.Parse(Count9.Text)).ToString();
					if (float.Parse(Cost9.Text) > 0)
					{
						Row10.Visibility = Visibility.Visible;
					}
					break;
				case 10:
					Cost10.Text = CalculateCostOfItem(BuildItem10.Text).ToString();
					if (Count10.Text == "")
					{
						Count10.Text = "1";
					}
					Total10.Text = (float.Parse(Cost10.Text) * float.Parse(Count10.Text)).ToString();
					if (float.Parse(Cost10.Text) > 0)
					{
						Row11.Visibility = Visibility.Visible;
					}
					break;
				case 11:
					Cost11.Text = CalculateCostOfItem(BuildItem11.Text).ToString();
					if (Count11.Text == "")
					{
						Count11.Text = "1";
					}
					Total11.Text = (float.Parse(Cost11.Text) * float.Parse(Count11.Text)).ToString();
					if (float.Parse(Cost11.Text) > 0)
					{
						Row12.Visibility = Visibility.Visible;
					}
					break;
				case 12:
					Cost12.Text = CalculateCostOfItem(BuildItem12.Text).ToString();
					if (Count12.Text == "")
					{
						Count12.Text = "1";
					}
					Total12.Text = (float.Parse(Cost12.Text) * float.Parse(Count12.Text)).ToString();
					if (float.Parse(Cost12.Text) > 0)
					{
						Row13.Visibility = Visibility.Visible;
					}
					break;
				case 13:
					Cost13.Text = CalculateCostOfItem(BuildItem13.Text).ToString();
					if (Count13.Text == "")
					{
						Count13.Text = "1";
					}
					Total13.Text = (float.Parse(Cost13.Text) * float.Parse(Count13.Text)).ToString();
					if (float.Parse(Cost13.Text) > 0)
					{
						Row14.Visibility = Visibility.Visible;
					}
					break;
				case 14:
					Cost14.Text = CalculateCostOfItem(BuildItem14.Text).ToString();
					if (Count14.Text == "")
					{
						Count14.Text = "1";
					}
					Total14.Text = (float.Parse(Cost14.Text) * float.Parse(Count14.Text)).ToString();
					if (float.Parse(Cost14.Text) > 0)
					{
						Row15.Visibility = Visibility.Visible;
					}
					break;
				case 15:
					Cost15.Text = CalculateCostOfItem(BuildItem15.Text).ToString();
					if (Count15.Text == "")
					{
						Count15.Text = "1";
					}
					Total15.Text = (float.Parse(Cost15.Text) * float.Parse(Count15.Text)).ToString();
					break;
			}
            CheckNulls();
            CalculateTotal();
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
                ShowAndHideResourcesButton.Content = "Resources";
                CalculationMenu.Visibility = Visibility.Visible;
                BuildMenu.Visibility = Visibility.Hidden;
                ShowBuildMenubuttion.Content = "Build";
            }
            else
            {
                ResouceMenu.Visibility = Visibility.Visible;//unhides resource menu
                CalculationMenu.Visibility = Visibility.Hidden;
                ShowAndHideResourcesButton.Content = "Crafting";
                BuildMenu.Visibility = Visibility.Hidden;
                ShowBuildMenubuttion.Content = "Build";
            }

        }
        private void BuildMenuButtonOpen(object sender, RoutedEventArgs e)//opens and closes resource menu
        {
            if (BuildMenu.Visibility != Visibility.Hidden)
            {
                ResouceMenu.Visibility = Visibility.Hidden;//hides resource menu
                ShowAndHideResourcesButton.Content = "Resources";
                CalculationMenu.Visibility = Visibility.Visible;
                BuildMenu.Visibility = Visibility.Hidden;
                ShowBuildMenubuttion.Content = "Build";
            }
            else
            {
                ShowBuildMenubuttion.Content = "Crafting";
                BuildMenu.Visibility = Visibility.Visible;
                ResouceMenu.Visibility = Visibility.Hidden;//unhides resource menu
                CalculationMenu.Visibility = Visibility.Hidden;
                ShowAndHideResourcesButton.Content = "Resources";
            }

        }

        private void Calculate(object sender, RoutedEventArgs e)//Runs the calculation for the Item
        {
            string ItemName = FindValue(ItemSearch.Text.ToLower().ToString());//takes user input and searches for it in algorithm
            string[] Item = SeparateList(ItemName);
            float CraftingCost = 0;
            //validates if there is an input
            if (scrapQuantity.Text == "")
            {
                scrapQuantity.Text = "0";
            }
            if (copperQuantity.Text == "")
            {
                copperQuantity.Text = "0";
            }
            if (wiresQuantity.Text == "")
            {
                wiresQuantity.Text = "0";
            }
            if (batterysQuantity.Text == "")
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
            if (Item1Count.Text == "")
            {
                Item1Count.Text = "1";
            }
            if (Item2Count.Text == "")
            {
                Item2Count.Text = "1";
            }
            if (Item3Count.Text == "")
            {
                Item3Count.Text = "1";
            }
            if (Item1Value.Text == "")
            {
                Item1Value.Text = "0";
            }
            if (Item2Value.Text == "")
            {
                Item2Value.Text = "0";
            }
            if (Item3Value.Text == "")
            {
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

            string[] lines = { ScrapCost.Text.ToString(), CopperCost.Text.ToString(), WiresCost.Text.ToString(), PlasticCost.Text.ToString(), BatterysCost.Text.ToString(), ElectronicsCost.Text.ToString(), UraniumCost.Text.ToString() };
            File.WriteAllLines("Savefile.txt", lines);
            //valdades if there is an incorrect input
            if ((scrapQuantity.Text + copperQuantity.Text + wiresQuantity.Text + batterysQuantity.Text + plasticQuantity.Text + electronicsQuantity.Text + uraniumQuantity.Text).All("1234567890.".Contains))
            {
                if ((ScrapCost.Text + CopperCost.Text + WiresCost.Text + BatterysCost.Text + PlasticCost.Text + ElectronicsCost.Text + UraniumCost.Text).All("1234567890.".Contains))
                {

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
                            float.Parse(UraniumCost.Text) / 10f * float.Parse(uraniumQuantity.Text) +
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
        private float CalculateCostOfItem(string ItemName)//calculates cost of item
        {
            if (ItemName == "Empty" || ItemName == "")
            {
                return 0f;
            }
            if (float.TryParse(ItemName, out float Result))
            {
                return Result;
            }
            string[] Item = SeparateList(FindValue(ItemName));//finds the item and creates list
            if (Item[0] == "Item Not Found (make sure the item is spelt correctly and is craftable)")
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
               + CalculateCostOfItem(Item[8]) * float.Parse(Item[9]) +
               CalculateCostOfItem(Item[10]) * float.Parse(Item[11]) +
               CalculateCostOfItem(Item[12]) * float.Parse(Item[13]) + float.Parse(Item[14]);
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
            //Selecta the correct rairty 
            float.TryParse(uraniumQuantity.Text, out float uranium);
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
            if (Item[0] != "Item Not Found (make sure the item is spelt correctly and is craftable)")//shows an error message if item is not found
            {
                Calculate(sender, e);
            }
        }
        string[] SeparateList(string ItemName)//finds the name in the text file
        {
            string[] Item = new string[] { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            int CountForList = 0;
            for (int i = 0; i < ItemName.Length; i++)
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
            return "Item Not Found (make sure the item is spelt correctly and is craftable)";//returns if item not found
        }

        void CreateDatabase()
        {
            string[] data = {
"small wheel_15_3_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"small wheel st_15_3_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"medium wheel_15_3_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"medium wheel st_15_3_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"sprinter_75_15_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"huntsman_75_15_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"wwt1_75_15_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"docker_75_15_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"lm-54 chord_30_6_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"lupara_30_6_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"avenger 57mm_30_6_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"fuel barrel_60_12_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"car jack_20_4_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"radio_20_4_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"rs-1 ruby_35_8_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"b-1 aviator_55_11_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"r-1 breeze_20_4_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"repair kit_300_90_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"decor container_400_0_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"engineer flag_300_150_0_0_0_0_0_Empty_0_Empty_0_Empty_0_0",
"paint container_400_400_0_300_0_300_0_Empty_0_Empty_0_Empty_0_0",

"growl_700_130_0_0_0_0_0_sprinter_1_lupara_1_Empty_0_3",
"wyvern_700_130_0_0_0_0_0_huntsman_1_rs-1 ruby_1_Empty_0_3",
"trucker_700_130_0_0_0_0_0_docker_1_sprinter_1_Empty_0_3",
"st-m23 defender_650_130_0_0_0_0_0_lm-54 chord_1_r-1 breeze_1_Empty_0_3",
"vector_650_130_0_0_0_0_0_lm-54 chord_1_car jack_1_Empty_0_3",
"sledgehammer_650_130_0_0_0_0_0_lupara_1_car jack_1_Empty_0_3",
"spitfire_650_130_0_0_0_0_0_lupara_1_b-1 aviator_1_Empty_0_3",
"ac43 rapier_650_130_0_0_0_0_0_lm-54 chord_1_b-1 aviator_1_Empty_0_3",
"little boy 6lb_650_130_0_0_0_0_0_avenger 57mm_1_fuel barrel_1_Empty_0_3",
"judge 76mm_650_130_0_0_0_0_0_avenger 57mm_1_medium wheel st_1_Empty_0_3",
"wasp_650_130_0_0_0_0_0_avenger 57mm_1_fuel barrel_1_Empty_0_3",
"borer_650_130_0_0_0_0_0_car jack_1_r-1 breeze_1_Empty_0_3",
"ad-12 falcon_650_130_0_0_0_0_0_lm-54 chord_1_rs-1 ruby_1_Empty_0_3",
"dt cobra_650_130_0_0_0_0_0_radio_1_lupara_1_Empty_0_3",
"fuel tank_650_130_0_0_0_0_0_fuel barrel_1_docker_1_Empty_0_3",
"rd-1 listener_650_130_0_0_0_0_0_rs-1 ruby_1_fuel barrel_1_Empty_0_3",
"ts-1 horizon_650_130_0_0_0_0_0_radio_1_small wheel_1_Empty_0_3",
"big g_700_130_0_0_0_0_0_b-1 aviator_1_avenger 57mm_1_Empty_0_3",
"blastoff_650_130_0_0_0_0_0_b-1 aviator_1_rs-1 ruby_1_Empty_0_3",
"r-2 chill_650_130_0_0_0_0_0_b-1 aviator_1_radio_1_Empty_0_3",
"cs taymyr_650_130_0_0_0_0_0_r-1 breeze_1_huntsman_1_Empty_0_3",
"ammo pack_650_130_0_0_0_0_0_car jack_1_radio_1_Empty_0_3",
"studded wheel_600_130_0_0_0_0_0_medium wheel_1_small wheel_1_Empty_0_3",
"studded wheel st_600_130_0_0_0_0_0_medium wheel st_1_small wheel st_1_Empty_0_3",
"chained wheel_600_130_0_0_0_0_0_medium wheel_1_small wheel_1_Empty_0_3",
"chained wheel st_600_130_0_0_0_0_0_medium wheel st_1_small wheel st_1_Empty_0_3",
"balloon tyre_600_130_0_0_0_0_0_medium wheel_2_Empty_0_Empty_0_3",
"balloon tyre st_600_130_0_0_0_0_0_small wheel st_2_Empty_0_Empty_0_3",
"racing wheel_600_130_0_0_0_0_0_medium wheel_1_small wheel_1_Empty_0_3",
"racing wheel st_600_130_0_0_0_0_0_medium wheel st_1_small wheel st_1_Empty_0_3",
"landing gear_600_130_0_0_0_0_0_medium wheel_1_small wheel_1_Empty_0_3",
"landing gear st_600_130_0_0_0_0_0_medium wheel st_1_small wheel st_1_Empty_0_3",
"large wheel_600_130_0_0_0_0_0_small wheel_1_wwt1_1_Empty_0_3",
"large wheel st_600_130_0_0_0_0_0_medium wheel st_1_wwt1_1_Empty_0_3",

"bat_50_100_100_0_50_0_0_growl_1_big g_1_Empty_0_6",
"pilgrim_50_100_100_0_50_0_0_wyvern_1_ad-12 falcon_1_Empty_0_6",
"jawbreaker_50_100_100_0_50_0_0_trucker_1_rd-1 listener_1_Empty_0_6",
"m-37 piercer_250_100_100_0_50_0_0_vector_1_big g_1_Empty_0_6",
"sinus-0_50_100_100_0_50_0_0_vector_1_ac43 rapier_1_Empty_0_6",
"goblin_50_100_100_0_50_0_0_wasp_1_spitfire_1_Empty_0_6",
"junkbow_50_100_100_0_50_0_0_sledgehammer_1_growl_1_Empty_0_6",
"mace_50_100_100_0_50_0_0_sledgehammer_1_spitfire_1_Empty_0_6",
"ac50 storm_50_100_100_0_50_0_0_st-m23 defender_1_ac43 rapier_1_Empty_0_6",
"zs-33 hulk_50_100_100_0_50_0_0_judge 76mm_1_fuel tank_1_Empty_0_6",
"prosecutor 76mm_50_100_100_0_50_0_0_judge 76mm_1_ammo pack_1_Empty_0_6",
"pyralid_50_100_100_0_50_0_0_wasp_1_studded wheel_1_Empty_0_6",
"synthesis_50_100_100_0_50_0_0_vector_1_wyvern_1_Empty_0_6",
"boom_50_100_100_0_50_0_0_wasp_1_fuel tank_1_Empty_0_6",
"tempura_200_100_200_0_30_0_0_borer_1_rd-1 listener_1_Empty_0_6",
"buzzsaw_50_100_100_0_50_0_0_blastoff_1_little boy 6lb_1_Empty_0_6",
"ad-13 hawk_50_100_100_0_50_0_0_ad-12 falcon_1_cs taymyr_1_Empty_0_6",
"sidekick_50_100_100_0_50_0_0_dt cobra_1_borer_1_Empty_0_6",
"dt python_50_100_100_0_50_0_0_dt cobra_1_r-2 chill_1_Empty_0_6",
"summator_50_100_100_0_50_0_0_st-m23 defender_1_borer_1_Empty_0_6",
"chameleon_50_100_100_0_50_0_0_landing gear_1_cs taymyr_1_Empty_0_6",
"ka-1 discharger_50_100_100_0_50_0_0_cs taymyr_1_trucker_1_Empty_0_6",
"oculus vi_50_100_100_0_50_0_0_rd-1 listener_1_ts-1 horizon_1_Empty_0_6",
"maxwell_50_100_100_0_50_0_0_landing gear st_1_ts-1 horizon_1_Empty_0_6",
"ampere_50_100_100_0_50_0_0_racing wheel st_1_r-2 chill_1_Empty_0_6",
"pu-1 charge_50_100_100_0_50_0_0_dt cobra_1_ts-1 horizon_1_Empty_0_6",
"hardcore_50_100_100_0_50_0_0_blastoff_1_cs taymyr_1_Empty_0_6",
"razorback_50_100_100_0_50_0_0_trucker_1_little boy 6lb_1_Empty_0_6",
"dun horse_50_100_100_0_50_0_0_racing wheel_1_r-2 chill_1_Empty_0_6",
"genesis_50_100_100_0_50_0_0_ad-12 falcon_1_ammo pack_1_Empty_0_6",
"lunar iv_50_100_100_0_50_0_0_racing wheel_1_landing gear_1_Empty_0_6",
"lunar iv st_50_100_100_0_50_0_0_racing wheel st_1_landing gear st_1_Empty_0_6",
"camber_200_200_100_0_30_0_0_racing wheel_1_balloon tyre_1_Empty_0_6",
"camber st_200_200_100_0_30_0_0_racing wheel st_1_balloon tyre st_1_Empty_0_6",
"shiv_50_100_100_0_50_0_0_studded wheel_1_chained wheel_1_Empty_0_6",
"shiv st_50_100_100_0_50_0_0_studded wheel st_1_chained wheel st_1_Empty_0_6",
"array_50_100_100_0_50_0_0_chained wheel_1_studded wheel_1_Empty_0_6",
"array st_50_100_100_0_50_0_0_chained wheel st_1_studded wheel st_1_Empty_0_6",
"apc wheel_50_100_100_0_50_0_0_large wheel_1_balloon tyre_1_Empty_0_6",
"apc wheel st_50_100_100_0_50_0_0_large wheel st_1_balloon tyre st_1_Empty_0_6",
"twin wheel_50_100_100_0_50_0_0_large wheel_1_balloon tyre_1_Empty_0_6",
"twin wheel st_50_100_100_0_50_0_0_large wheel st_1_balloon tyre st_1_Empty_0_6",

"huginn_450_450_200_0_100_0_0_pyralid_1_razorback_1_oculus vi_1_15",
"jannabi_250_250_200_100_60_0_0_bat_1_tempura_1_razorback_1_15",
"werewolf_100_150_200_0_100_0_0_bat_1_shiv st_1_ampere_1_15",
"harpy_100_150_200_0_100_0_0_bat_1_shiv_1_sinus-0_1_15",
"aggressor_100_150_200_100_60_0_0_hardcore_1_goblin_1_buzzsaw_1_15",
"quantum_100_150_200_0_100_0_0_pilgrim_1_genesis_1_ad-13 hawk_1_15",
"photon_100_150_200_0_100_0_0_pilgrim_1_synthesis_1_ad-13 hawk_1_15",
"omnibox_100_150_200_0_100_0_0_pilgrim_1_array st_1_jawbreaker_1_15",
"humpback_100_150_200_0_100_0_0_jawbreaker_1_apc wheel_1_razorback_1_15",
"bastion_100_150_200_0_100_0_0_jawbreaker_1_apc wheel st_1_pu-1 charge_1 _15",
"gungnir_450_450_200_0_100_0_0_ac62 therm_1_sinus-0_1_m-37 piercer_1_15",
"m-29 protector_100_150_200_0_100_0_0_sinus-0_1_dun horse_1_chameleon_1_15",
"m-38 fidget_600_600_200_0_100_0_0_m-37 piercer_1_ac50 storm_1_razorback_1_15",
"spectre-2_100_150_200_0_100_0_0_sinus-0_1_ad-13 hawk_1_maxwell_1_15",
"mg13 equalizer_100_150_200_0_100_0_0_ac50 storm_1_sinus-0_1_ampere_1_15",
"caucasus_100_150_200_0_100_0_0_prosecutor 76mm_1_jawbreaker_1_apc wheel_1_15",
"gremlin_100_250_200_100_60_0_0_goblin_1_mace_1_boom_1_15",
"fafnir_100_150_200_0_100_0_0_junkbow_2_zs-33 hulk_1_Empty_0_15",
"thunderbolt_100_150_200_0_100_0_0_mace_1_goblin_1_buzzsaw_1_15",
"rupture_100_150_200_0_100_0_0_goblin_1_hardcore_1_buzzsaw_1_15",
"ac72 whirlwind_100_150_200_0_100_0_0_ac50 storm_1_chameleon_1_sinus-0_1_15",
"whirl_100_150_200_0_100_0_0_ac50 storm_1_apc wheel_1_sidekick_1_15",
"zs-34 fat man_100_150_200_0_100_0_0_zs-33 hulk_2_twin wheel st_1_Empty_0_15",
"executioner 88mm_100_150_200_0_100_0_0_prosecutor 76mm_1_twin wheel_1_oculus vi_1_15",
"cricket_100_150_200_0_100_0_0_goblin_1_boom_1_mace_1_15",
"pyre_100_150_200_0_100_0_0_prosecutor 76mm_1_oculus vi_1_dt python_1_15",
"nest_100_150_200_0_100_0_0_zs-33 hulk_1_pu-1 charge_1_dt python_1_15",
"clarinet tow_100_150_200_0_100_0_0_dt python_1_sidekick_1_apc wheel st_1_15",
"thresher_100_150_200_100_60_0_0_ac50 storm_1_dun horse_1_maxwell_1_15",
"gl-55 impulse_100_150_200_100_60_0_0_prosecutor 76mm_1_pu-1 charge_1_dt python_1_15",
"aurora_100_150_200_100_60_0_0_synthesis_1_lunar iv st_1_ampere_1_15",
"gravastar_100_150_200_100_60_0_0_synthesis_1_lunar iv_1_mace_1_15",
"quasar_100_150_200_100_60_0_0_zs-33 hulk_1_synthesis_1_genesis_1_15",
"prometheus v_100_150_200_100_60_0_0_synthesis_1_genesis_1_maxwell_1_15",
"trigger_100_150_200_0_100_0_0_summator_1_oculus vi_1_lunar iv st_1_15",
"blockchain_100_150_200_0_100_0_0_summator_1_mace_1_dun horse_1_15",
"phoenix_100_150_200_0_100_0_0_junkbow_1_shiv_1_boom_1_15",
"lancelot_100_150_200_0_100_0_0_boom_1_goblin_1_hardcore_1_15",
"mauler_100_150_200_0_100_0_0_buzzsaw_1_boom_1_goblin_1_15",
"incinerator_100_150_200_0_100_0_0_shiv_1_junkbow_1_pu-1 charge_1_15",
"md-3 owl_100_150_200_0_100_0_0_ad-13 hawk_1_ampere_1_sinus-0_1_15",
"fuze_100_150_200_0_100_0_0_hardcore_1_boom_1_goblin_1_15",
"rt anaconda_100_150_200_0_100_0_0_dt python_1_pu-1 charge_1_twin wheel st_1_15",
"barrier ix_100_150_200_0_100_0_0_pilgrim_1_lunar iv_1_dt python_1_15",
"yaoguai_100_150_200_0_100_0_0_tempura_1_sidekick_1_ad-13 hawk_1_15",
"skinner_100_150_200_0_100_0_0_junkbow_1_shiv st_1_mace_1_15",
"enlightenment_100_250_200_100_60_0_0_tempura_1_oculus vi_1_pyralid_1_15",
"tormentor_100_150_200_0_100_0_0_bat_1_junkbow_1_ad-13 hawk_1_15",
"chameleon mk2_100_150_200_0_100_0_0_chameleon_1_maxwell_1_ac50 storm_1_15",
"ka-2 flywheel_100_150_200_0_100_0_0_ka-1 discharger_1_razorback_1_oculus vi_1_15",
"verifier_100_150_200_0_100_0_0_array_1_oculus vi_1_sidekick_1_15",
"doppler_100_150_200_0_100_0_0_maxwell_2_chameleon_1_Empty_0_15",
"rd-2 keen_100_150_200_0_100_0_0_oculus vi_1_twin wheel_1_pu-1 charge_1_15",
"neutrino_100_150_200_0_100_0_0_lunar iv_1_genesis_1_twin wheel st_1_15",
"gasgen_100_150_200_0_100_0_0_buzzsaw_1_goblin_1_boom_1_15",
"oppressor_100_150_200_0_100_0_0_bat_1_shiv_1_hardcore_1_15",
"hot red_100_150_200_0_100_0_0_hardcore_1_goblin_1_mace_1_15",
"colossus_100_150_200_0_100_0_0_razorback_1_twin wheel_1_zs-33 hulk_1_15",
"cheetah_100_150_200_0_100_0_0_dun horse_1_chameleon_1_ac50 storm_1_15",
"hermes_100_150_200_0_100_0_0_hardcore_1_boom_1_buzzsaw_1_15",
"rn seal_100_150_200_0_100_0_0_ampere_1_maxwell_1_dun horse_1_15",
"shiver_100_150_200_0_100_0_0_buzzsaw_1_mace_1_hardcore_1_15",
"expanded ammo pack_100_150_200_0_100_0_0_oculus vi_1_pu-1 charge_1_prosecutor 76mm_1_15",
"buggy wheel st_250_250_200_100_60_0_0_buzzsaw_1_mace_1_boom_1_15",
"buggy wheel_250_250_200_100_60_0_0_buzzsaw_1_hardcore_1_mace_1_15",
"hermit st_100_150_200_0_100_0_0_hardcore_1_mace_1_boom_1_15",
"hermit_100_150_200_0_100_0_0_buzzsaw_1_goblin_1_boom_1_15",
"bigfoot st_100_250_200_0_100_0_0_shiv st_1_bat_1_twin wheel st_1_15",
"bigfoot_100_250_200_0_100_0_0_shiv_1_bat_1_twin wheel_1_15",
"omni_100_250_200_0_100_0_0_camber_1_camber st_1_twin wheel st_1_15",
"small track_100_150_200_0_100_0_0_hardcore_1_buzzsaw_1_mace_1_15",
"hardened track_100_150_200_0_100_0_0_ampere_1_chameleon_1_dun horse_1_15",
"armored track_100_150_200_0_100_0_0_twin wheel_1_twin wheel st_1_razorback_1_15",
"sleipnir_450_450_200_0_100_0_0_m-25 guardian_1_ampere_1_buzzsaw_1_15",
"icarus vii_100_150_200_0_100_0_0_lunar iv st_1_lunar iv_1_dun horse_1_15",
"ml 200_100_150_200_0_100_0_0_sidekick_1_apc wheel_1_razorback_1_15",
"bigram_100_150_200_0_100_0_0_array_1_array st_1_apc wheel_1_15",
"meat grinder_100_150_200_0_100_0_0_shiv_1_shiv st_1_buzzsaw_1_15",

"muninn_0_750_600_750_0_600_0_huginn_2_hermit st_2_mg13 equalizer_1_75",
"griffon_100_750_0_750_0_750_0_harpy_2_rupture_2_neutrino_1_75",
"beholder_100_750_0_750_0_750_0_chameleon mk2_2_hermit_2_nest_1_75",
"nova_100_750_0_750_0_750_0_photon_2_whirl_2_mauler_1_75",
"yokozuna_100_750_0_750_0_750_0_jannabi_2_enlightenment_2_yaoguai_1_75",
"cohort_100_750_0_750_0_750_0_humpback_2_gravastar_2_md-3 owl_1_75",
"m-39 imp_1350_1350_0_800_0_800_0_m-38 fidget_2_colossus_2_bigfoot_1_75",
"nothung_0_750_600_750_0_600_0_gungnir_2_omni_1_mg13 equalizer_1_75",
"aspect_100_750_0_750_0_750_0_spectre-2_2_small track_2_rd-2 keen_1_75",
"mg14 arbiter_100_750_0_750_0_750_0_mg13 equalizer_2_rt anaconda_2_gasgen_1_75",
"reaper_100_750_0_750_0_750_0_ac72 whirlwind_2_hot red_2_armored track_1_75",
"nidhogg_100_750_0_750_0_750_0_fafnir_2_cricket_2_bastion_1_75",
"hammerfall_100_750_0_750_0_750_0_thunderbolt_2_cheetah_2_rd-2 keen_1_75",
"cyclone_100_750_0_750_0_750_0_caucasus_2_oppressor_2_hardened track_1_75",
"zs-46 mammoth_100_750_0_750_0_750_0_zs-34 fat man_2_hermes_2_hardened track_1_75",
"bc-17 tsunami_100_750_0_750_0_750_0_clarinet tow_2_icarus vii_2_harpy_1_75",
"hurricane_100_750_0_750_0_750_0_pyre_2_doppler_2_lancelot_1_75",
"retcher_100_750_0_750_0_750_0_md-3 owl_2_gl-55 impulse_2_lancelot_1_75",
"pulsar_100_750_0_750_0_750_0_quasar_2_m-29 protector_2_phoenix_1_75",
"helios_100_750_0_750_0_750_0_prometheus v_2_tormentor_2_ml 200_1_75",
"assembler_100_750_0_750_0_750_0_blockchain_2_bigram_2_verifier_1_75",
"spark iii_100_750_0_750_0_750_0_aurora_2_shiver_2_phoenix_1_75",
"harvester_100_750_0_750_0_750_0_mauler_2_expanded ammo pack_2_rn seal_1_75",
"draco_100_750_0_750_0_750_0_werewolf_2_fuze_2_photon_1_75",
"mandrake_100_750_0_750_0_750_0_humpback_2_executioner 88mm_2_skinner_1_75",
"jubokko_100_750_0_750_0_750_0_yaoguai_2_jannabi_2_enlightenment_1_75",
"fortune_100_750_0_750_0_750_0_incinerator_2_neutrino_2_rn seal_1_75",
"anninhilator_100_750_0_750_0_750_0_trigger_2_omnibox_2_verifier_1_75",
"kaiju_100_750_0_750_0_750_0_enlightenment_2_yaoguai_2_jannabi_1_75",
"aegis-prime_100_750_0_750_0_750_0_barrier ix_2_chameleon mk2_2_meat grinder_1_75",
"apollo iv_100_750_0_750_0_750_0_quantum_2_bigfoot st_2_gasgen_1_75",
"thor-6s_0_750_600_750_0_600_0_sleipnir_2_ka-2 flywheel_2_gasgen_1_75",


"punisher_0_1000_0_1000_0_1000_600_aspect_1_cyclone_1_Empty_0_75",
"jormungandr_0_1000_0_1000_0_1000_600_nidhogg_1_helios_1_Empty_0_75",
"breaker_0_1000_0_1000_0_1000_600_hammerfall_1_fortune_1_Empty_0_75",
"zs-52 mastodon_0_1000_0_1000_0_1000_600_zs-46 mammoth_1_nidhogg_1_Empty_0_75",
"cc-18 tythoon_0_1000_0_1000_0_1000_600_bc-17 tsunami_1_mandrake_1_Empty_0_75",
"flash i_0_1000_0_1000_0_1000_600_spark iii_1_draco_1_Empty_0_75",
"firebug_0_1000_0_1000_0_1000_600_zs-46 mammoth_1_harvester_1_Empty_0_75",
"porcupine_0_1000_0_1000_0_1000_600_retcher_1_hurricane_1_Empty_0_75",
"ripper_0_1000_0_1000_0_1000_600_fortune_1_mg14 arbiter_1_Empty_0_75",
"scorpion_0_1000_0_1000_0_1000_600_pulsar_1_reaper_1_Empty_0_75"
            };
            File.WriteAllLines("Items.txt", data);
        }

        private void Count2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

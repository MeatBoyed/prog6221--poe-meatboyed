using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;
using RideYouRent.Models;
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

namespace RideYouRent
{
    /// <summary>
    /// Interaction logic for PieChart.xaml
    /// </summary>
    public partial class PieChart : Page
    {

        // List to hold Pie chart values
        public SeriesCollection seriesCollection { get; set; }
        public PieChart()
        {
            InitializeComponent();

            // Creating the general display & labels for Pie chart
            seriesCollection = new SeriesCollection
            {
                new PieSeries { Title = "Starchy foods", Values = new ChartValues<ObservableValue> { new ObservableValue(0)  }, DataLabels = true },
                new PieSeries { Title = "Vegetables and fruits\"", Values = new ChartValues<ObservableValue> { new ObservableValue(0) }, DataLabels = true },
                new PieSeries { Title = "Dry beans, peas, lentils and soya", Values = new ChartValues<ObservableValue> { new ObservableValue(0) } , DataLabels = true},
                new PieSeries { Title = "Chicken, fish, meat and eggs", Values = new ChartValues<ObservableValue> { new ObservableValue(0) } , DataLabels = true},
                new PieSeries { Title = "Milk and dairy products", Values = new ChartValues<ObservableValue> { new ObservableValue(0) } , DataLabels = true},
                new PieSeries { Title = "Fats and oil", Values = new ChartValues<ObservableValue> { new ObservableValue(0) } , DataLabels = true},
                new PieSeries { Title = "Oil", Values = new ChartValues<ObservableValue> { new ObservableValue(0) } , DataLabels = true}
            };

            // Creating link for code-behind and UI
            DataContext = this;

            // Populating UI compoentns
            PopulateComboBox();
            PopulateTable();
        }


        /// <summary>
        /// Handles functionality for adding recipe to menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddToMenu_Click(object sender, RoutedEventArgs e)
        {
            // Error handling (used throughout the code)
            try
            {
                // Get's Recipe and adds it to Menu + UI
                Recipe selectedRecipe = (Recipe)SelectRecCB.SelectedItem;
                StateManager.menu.Add(selectedRecipe);
                PopulateTable();

            }
            catch
            {
                ErrorMessage.Content = "An Error Occured - Couldn't add to Menu";
            }

        }

        public void PopulateTable()
        {
            // Clears UI
            ErrorMessage.Content = "";
            RecipeTable.Children.Clear();

            // Create header
            Label header = new Label();
            header.Content = "Recipes in Menu:";
            RecipeTable.Children.Add(header);

            // Same logic as View Recipe
            for (int i = 0; i < StateManager.menu.Count; i++)
            {
                Label value = new Label();

                value.Content = $"{i + 1} - {StateManager.menu[i].name} {StateManager.menu[i].description}";
                RecipeTable.Children.Add(value);
            }

            CalculateData();
        }


        /// <summary>
        /// Handes the removing of recipe from Menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveFromMenu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Opposite logic as above
                Recipe selectedRecipe = (Recipe)SelectRecCB.SelectedItem;
                StateManager.menu.Remove(selectedRecipe);
                PopulateTable();
            }
            catch
            {
                ErrorMessage.Content = "An Error Occured - Couldn't Remove from Menu";
            }
        }

        /// <summary>
        /// Populates the combo box
        /// </summary>
        public void PopulateComboBox()
        {
            // Populate ComboBox
            SelectRecCB.ItemsSource = StateManager.recipes;
            SelectRecCB.DisplayMemberPath = "name";
        }
        public void CalculateData()
        {
            // Counting food cateegories
            int starchCount = 0;
            int vegCount = 0;
            int beansCount = 0;
            int meatCount = 0;
            int dairyCount = 0;
            int fatsCount = 0;
            int oilCount = 0;

            // Looping Recipes for Ingredients to count Food categories
            foreach (Recipe recipe in StateManager.recipes)
            {
                foreach (Ingredient ingredient in recipe.ingredients)
                {
                    // Figuring out which count to add
                    switch (ingredient.foodGroup)
                    {
                        case "Startchy Foods":
                            starchCount++;
                            break;
                        case "Vegetables and fruits":
                            vegCount++;
                            break;
                        case "Dry beans, peas, lentils and soya":
                            beansCount++;
                            break;
                        case "Chicken, fish, meat and eggs":
                            meatCount++;
                            break;
                        case "Milk and dairy products":
                            dairyCount++;
                            break;
                        case "Fats and oil":
                            fatsCount++;
                            break;
                        case "Oil":
                            oilCount++;
                            break;
                    }
                }
            }

            // Adds count to the Pie Chart via the Charvalues object
            seriesCollection[0].Values = new ChartValues<ObservableValue> { new ObservableValue(starchCount) };
            seriesCollection[1].Values = new ChartValues<ObservableValue> { new ObservableValue(vegCount) };
            seriesCollection[2].Values = new ChartValues<ObservableValue> { new ObservableValue(beansCount) };
            seriesCollection[3].Values = new ChartValues<ObservableValue> { new ObservableValue(meatCount) };
            seriesCollection[4].Values = new ChartValues<ObservableValue> { new ObservableValue(dairyCount) };
            seriesCollection[5].Values = new ChartValues<ObservableValue> { new ObservableValue(fatsCount) };
            seriesCollection[6].Values = new ChartValues<ObservableValue> { new ObservableValue(oilCount) };
        }
    }
}

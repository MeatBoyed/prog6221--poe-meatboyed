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
    /// Interaction logic for ScaleRecipe.xaml
    /// </summary>
    public partial class ScaleRecipe : Page
    {
        public ScaleRecipe()
        {
            InitializeComponent();
            PopulateCB();
        }

        /// <summary>
        /// Populates the combo box
        /// </summary>
        public void PopulateCB()
        {
            // Populate ComboBox
            SelectRecCB.ItemsSource = StateManager.recipes;
            SelectRecCB.DisplayMemberPath = "name";
        }

        /// <summary>
        ///  Handles the scaling logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            // Gets recipe & scale factor
            Recipe selectedRecipe = (Recipe)SelectRecCB.SelectedItem;
            string scaleFactor = ScaeByCB.Text;

            switch (scaleFactor)
            {
                case "2x (Double)":
                    // scales and prints
                    selectedRecipe.ScaleBy(2);
                    PrintRecipe(selectedRecipe);
                    break;
                case "3x (Tripple)":
                    selectedRecipe.ScaleBy(3);
                    PrintRecipe(selectedRecipe);
                    break;
                case "4x (Quaduple)":
                    selectedRecipe.ScaleBy(4);
                    PrintRecipe(selectedRecipe);
                    break;
                default:
                    ErrorMessage.Content = "An error occured - Please check Scale Factor";
                    break;
            }
        }

        // Prints the recipe's info same as other display/print statmentss
        private void PrintRecipe(Recipe recipe)
        {
            RecipeTable.Children.Clear();
            Label details = new Label();
            details.Content = $"Recipe Details for {recipe.name}\n\t{recipe.description}";
            RecipeTable.Children.Add(details);

            // Print out Steps
            Label stepsLabel = new Label();
            stepsLabel.Content = "Calories:";
            RecipeTable.Children.Add(stepsLabel);

            for (int i = 0; i < recipe.steps.Count; i++)
            {
                Label value = new Label();

                value.Content = $"{i + 1} - {recipe.steps[i]}";
                RecipeTable.Children.Add(value);
            }


            // Print Ingredents
            Label ingreHeader = new Label();
            ingreHeader.Content = "Ingredients:";
            RecipeTable.Children.Add(ingreHeader);

            for (int i = 0; i < recipe.ingredients.Count; i++)
            {
                Label value = new Label();

                value.Content = $"{i + 1} - {recipe.ingredients[i].name} {recipe.ingredients[i].quantity}{recipe.ingredients[i].unitOfMesure} ";
                RecipeTable.Children.Add(value);
            }
        }

        /// <summary>
        /// Handles all reseting logic
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetQuant_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Recipe selectedRecipe = (Recipe)SelectRecCB.SelectedItem;
                selectedRecipe.ResetQuantities();
                PrintRecipe(selectedRecipe);
            }
            catch
            {
                ErrorMessage.Content = "An error occured with Reseting values";
            }
        }
    }
}

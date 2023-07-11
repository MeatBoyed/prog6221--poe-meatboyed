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
    /// Interaction logic for CreateRecipe.xaml
    /// </summary>
    public partial class CreateRecipe : Page
    {
        public Recipe recipe;
        public CreateRecipe()
        {
            InitializeComponent();
            recipe = new Recipe();
        }

        /// <summary>
        /// Adds an Ingredient to list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Content = "";
            try
            {
                // Collecting Data from user
                string name = TB_IngridentName.Text;
                int quantity = Convert.ToInt32(TB_Quantity.Text);
                string measure = TB_UnitOfMes.Text;
                int calories = Convert.ToInt32(TB_Calories.Text);
                string foodGroup = CB_FoodGroup.Text;

                // Creating recipe
                recipe.ingredients.Add(new Ingredient(name, quantity, measure, calories, foodGroup));
                PopulateTable();
                ResetIngredient();

            }
            catch
            {
                ErrorMessage.Content = "An Error Occured - Please ensure inputted Ingredient is correct";
            }
        }

        /// <summary>
        /// Adding Step button action hander
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddStep_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Content = "";
            try
            {
                // Adds to Steps, and reset's textbox
                recipe.steps.Add(TB_StepDesc.Text);
                PopulateTable();
                TB_StepDesc.Text = "";
            }
            catch
            {
                ErrorMessage.Content = "An Error Occured - Please ensure inputted Step is correct";
            }
        }

        /// <summary>
        /// Adding Recipe button handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            ErrorMessage.Content = "";
            try
            {
                string name = TB_Name.Text;
                string desc = TB_Dresc.Text;

                recipe.AddDetails(name, desc);

                // Ensuring there are Ingredient's and Steps in the recipe
                if (recipe.ingredients.Count > 0 || recipe.steps.Count > 0)
                {
                    StateManager.recipes.Add(recipe);
                    SuccessMessage.Content = "Recipe Successfuly Added!";

                    // Reseting UI for next add
                    ResetRec();
                    ResetIngredient();
                    InputTable.Children.Clear();
                    recipe = new Recipe();
                    return;
                }

                ErrorMessage.Content = "Please Add A Step & Ingredient to Continue";
            }
            catch
            {
                ErrorMessage.Content = "An Error Occured - Please ensure inputted Recipe is correct";
            }
        }


        public void PopulateTable()
        {
            // Clearing UI
            ErrorMessage.Content = "";
            InputTable.Children.Clear();

            // Only show list if Ingredients is presenet, same for next If statement
            if (recipe.ingredients.Count > 0)
            {
                // Creates a Label for liest
                Label ingreHeader = new Label();
                ingreHeader.Content = "Ingredients Added";
                InputTable.Children.Add(ingreHeader);

                // Looping of Ingredients and adding to table 
                for (int i = 0; i < recipe.ingredients.Count; i++)
                {
                    Label value = new Label();

                    value.Content = $"{i + 1} - {recipe.ingredients[i].name} {recipe.ingredients[i].quantity}{recipe.ingredients[i].unitOfMesure} ";
                    InputTable.Children.Add(value);
                }
            }

            // Same process as above - but for Steps
            if (recipe.steps.Count > 0)
            {
                Label stepsHeader = new Label();
                stepsHeader.Content = "Steps Added";
                InputTable.Children.Add(stepsHeader);

                for (int i = 0; i < recipe.steps.Count; i++)
                {
                    Label value = new Label();

                    value.Content = $"{i + 1} - {recipe.steps[i]}";
                    InputTable.Children.Add(value);
                }
            }
        }


        /// <summary>
        /// Handles the Resting of UI for Receipe
        /// </summary>
        private void ResetRec()
        {
            TB_Name.Text = "";
            TB_Dresc.Text = "";
            TB_StepDesc.Text = "";
        }
        /// <summary>
        /// Handles the reseting of UI for Ingredients
        /// </summary>
        private void ResetIngredient()
        {
            TB_IngridentName.Text = "";
            TB_Quantity.Text = "";
            TB_UnitOfMes.Text = "";
            TB_Calories.Text = "";
        }
}
}

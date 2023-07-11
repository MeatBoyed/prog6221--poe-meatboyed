using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideYouRent.Models
{
    public class Recipe
    {
        // Core Recipe Data (Requirement #1)
        public string name { get; set; }
        public string description { get; set; }

        public List<string> steps { get; set; }
        public List<Ingredient> ingredients { get; set; }

        // (BillWagner)
        public delegate void NofityUserDelegate(int totalCalories);

        // Storing previous Factor for clean quantity resets
        public List<int> scaledByFactors { get; set; }

        public Recipe()
        {
            this.steps = new List<string>();
            this.ingredients = new List<Ingredient>();
            this.scaledByFactors = new List<int>();
        }

        public Recipe(string name, string desc)
        {
            this.name = name;
            this.description = desc;
            this.scaledByFactors = new List<int>();
            this.steps = new List<string>();
            this.ingredients = new List<Ingredient>();
        }

        public void AddDetails(string name, string desc)
        {
            this.name = name;
            this.description = desc;
        }


        /// <summary>
        // Requirement #3
        // Loops over Ingredients and Multiplies the Quantity
        /// </summary>
        /// <param name="factor">The amount to scale the Quantites by</param>
        public void ScaleBy(int factor)
        {
            // Storing the inputted scale factor to achieve a clean reset of quantity amounts
            this.scaledByFactors.Add(factor);

            for (int i = 0; i < ingredients.Count; i++)
            {
                this.ingredients[i].quantity *= factor;
                // (BillWagner)
            }
        }

        /// <summary>
        // Requirement #4
        // Loops over Ingredients and Divides by the saved factor value
        /// </summary>
        public void ResetQuantities()
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                foreach (int factor in scaledByFactors)
                {
                    this.ingredients[i].quantity /= factor;
                }
            }
        }

        public void NotifyUserForCalories(int totalCalories)
        {
            if (totalCalories > 300)
            {
                // Make  a pop up here!
                Console.WriteLine("ALERT!! -- Your recipe exceeds 300");
            }

        }

        /// <summary>
        //  Requirement #6
        /// Calculates the total calories the recipe has
        /// </summary>
        /// <returns>Recipe's Total Calories</returns>
        public int CalculateTotalCalories()
        {
            int totalCalories = 0;
            foreach (Ingredient ingredient in ingredients)
            {
                totalCalories += ingredient.calories;
            }

            // (BillWagner)
            NofityUserDelegate notify = new NofityUserDelegate(NotifyUserForCalories);
            notify(totalCalories);
            return totalCalories;
        }
    }
}

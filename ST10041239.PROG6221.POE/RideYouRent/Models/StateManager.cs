using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideYouRent.Models
{
    public class StateManager
    {
        // USE combo boxes to select recipes for Reseting, scaling & deleting
        public static List<Recipe> recipes = new List<Recipe>();
        public static List<Recipe> menu = new List<Recipe>();

      public static void RemoveRecipe(Recipe recipe)
        {
            recipes.Remove(recipe);
        }
    }
}

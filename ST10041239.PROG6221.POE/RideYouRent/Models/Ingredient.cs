using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RideYouRent.Models
{
     public class Ingredient
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public string unitOfMesure { get; set; }

        public int calories { get; set; }
        public string foodGroup { get; set; }

        // Creates the Ingredients object
        public Ingredient() { }

        public Ingredient(string name, int quantity, string unitOfMesure, int cal, string foodgroup)
        {
            this.name = name;
            this.quantity = quantity;
            this.unitOfMesure = unitOfMesure;
            this.calories = cal;
            this.foodGroup = foodgroup;
        }

        /// <summary>
        /// Helper method for printing out an Ingredient
        /// </summary>
        /// <returns></returns>
        public string PrintIngredient()
        {
            return $"Name: {name}\n" +
                $"Quantity: {quantity} {unitOfMesure}\n";
        }
    }
}

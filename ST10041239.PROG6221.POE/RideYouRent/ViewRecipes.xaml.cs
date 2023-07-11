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
using System.Xml;

namespace RideYouRent
{
    /// <summary>
    /// Interaction logic for ViewRecipes.xaml
    /// </summary>
    public partial class ViewRecipes : Page
    {
        public ViewRecipes()
        {
            InitializeComponent();
            PopulateTable();
        }

        /// <summary>
        /// As the name implies...
        /// </summary>
        public void PopulateTable()
        {
            foreach (Recipe recipe in StateManager.recipes)
            {
                // Creating Lables
                TextBlock row = new TextBlock();

                row.Text = $"{recipe.name}\t\t--\t{recipe.CalculateTotalCalories()} kj";

                // Adds styling to row
                row.Style = Application.Current.FindResource("tableValue") as Style;

                // Add to Table
                NameTbl.Children.Add(row);
            }
        }
    }
}

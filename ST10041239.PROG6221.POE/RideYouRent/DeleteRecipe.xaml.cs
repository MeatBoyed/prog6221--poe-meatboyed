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
    /// Interaction logic for DeleteRecipe.xaml
    /// </summary>
    public partial class DeleteRecipe : Page
    {
        public DeleteRecipe()
        {
            InitializeComponent();
            PopulateCB();
        }

        public void PopulateCB()
        {
            // Populate ComboBox - (Chand, WPF ComboBox)
            SelectRecCB.ItemsSource = StateManager.recipes;
            SelectRecCB.DisplayMemberPath = "name";
        }
        private void deleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe selectedRecipe = (Recipe)SelectRecCB.SelectedItem;

            //Module.RemoveModule(selectedModule);

            StateManager.RemoveRecipe(selectedRecipe);
            this.NavigationService.Navigate(new DeleteRecipe()); // (Adegeo, Navigation Overview - WPF .NET framework)
        }
    }
}

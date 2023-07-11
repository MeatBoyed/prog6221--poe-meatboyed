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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddRecipe_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CreateRecipe());
        }

        private void DisplayRecipe_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ViewRecipes());
        }

        private void ScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ScaleRecipe());
        }

        private void PieChart_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PieChart());
        }

        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new DeleteRecipe());
        }
    }
}

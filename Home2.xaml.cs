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
using System.Windows.Shapes;

namespace ParcInfo
{
    /// <summary>
    /// Logique d'interaction pour Home2.xaml
    /// </summary>
    public partial class Home2 : Window
    {
        public Home2()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Dashboard_Click(object sender, RoutedEventArgs e)
        {
            navFrame.Navigate("/Pages/Dashboard.xaml");
        }

        private void Button_Appareils_Click(object sender, RoutedEventArgs e)
        {
            navFrame.Navigate("/Pages/Materiel.xaml");
        }

        private void Button_Associations_Click(object sender, RoutedEventArgs e)
        {
            navFrame.Navigate("/Pages/Association.xaml");
        }

        private void Button_Personnel_Click(object sender, RoutedEventArgs e)
        {
            navFrame.Navigate("/Pages/Personnel.xaml");
        }

        private void sidebar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = sidebar.SelectedItem as Button;
            if (selected == dashboard)
            {
                navFrame.Navigate("/Pages/Dashboard.xaml");
            } else if (selected == association)
            {
                navFrame.Navigate("/Pages/Association.xaml");
            } else if (selected == appareils)
            {
                navFrame.Navigate("/Pages/Materiel.xaml");
            } else if (selected == personnel)
            {
                navFrame.Navigate("/Pages/Personnel.xaml");
            }
        }
    }
}

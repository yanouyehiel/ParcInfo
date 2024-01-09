using MySql.Data.MySqlClient;
using ParcInfo.Views;
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

namespace ParcInfo
{
    public partial class Home2 : Window
    {
        public Home2()
        {
            InitializeComponent();
            contentControl.Content = new HomeView();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }

        private void dashboard_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new HomeView();
        }

        private void appareils_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new MaterielView();
        }

        private void Button_Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow m = new MainWindow();
            m.Show();
        }

        private void association_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new AssociationView();
        }

        private void personnel_Click(object sender, RoutedEventArgs e)
        {
            contentControl.Content = new PersonnelView();
        }

    }
}

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

namespace LevelBuilder
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            NewPage newPage = new NewPage();
            this.NavigationService.Navigate(newPage);
        }

        private void btnOptions_Click(object sender, RoutedEventArgs e)
        {
            OptionsPage optionsPage = new OptionsPage();
            this.NavigationService.Navigate(optionsPage);
        }
    }
}

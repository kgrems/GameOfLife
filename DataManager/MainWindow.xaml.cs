using Newtonsoft.Json;
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
using DataLibrary;

namespace DataManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Player p1;

        public MainWindow()
        {
            InitializeComponent();
            string json = System.IO.File.ReadAllText(@"C:\Users\kgrems\source\repos\MonoGame\player.dat");
            p1 = JsonConvert.DeserializeObject<Player>(json);

            txtName.Text = p1.Name;
            txtXP.Text = p1.Xp.ToString();
        }

        private void btnSaveClick(object sender, RoutedEventArgs e)
        {
            p1.Name = txtName.Text;
            p1.Xp = int.Parse(txtXP.Text);
        }
    }
}

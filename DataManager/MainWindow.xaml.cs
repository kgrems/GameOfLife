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
        private string formatError = "Incorrect format for input.";
        private string valueRequiredError = "Value required.";

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
            bool isDirty = false;
            if(txtName.Text.Length == 0)
            {
                isDirty = true;
                lblNameError.Content = valueRequiredError;
            }
            else
            {
                p1.Name = txtName.Text;
            }

            try
            {
                p1.Xp = int.Parse(txtXP.Text);
            }
            catch (FormatException)
            {
                isDirty = true;
                lblXPError.Content = formatError;
            }

            if (!isDirty)
            {
                string output = JsonConvert.SerializeObject(p1);
                System.IO.File.WriteAllText(@"C:\Users\kgrems\source\repos\MonoGame\player.dat", output);
                lblStatusMessage.Content = "Player saved successfully.";
            }
        }
    }
}

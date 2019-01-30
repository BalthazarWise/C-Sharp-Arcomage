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

namespace Arcomage_alpha3
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GameField f = new GameField();
            f.Owner = this;
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Show();
            f.Server();
            f.RefreshInterface();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string ip = textBox1.Text;
            GameField f = new GameField();
            f.Owner = this;
            f.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            f.Show();
            f.Client(ip);
            f.RefreshInterface();
        }
    }
}

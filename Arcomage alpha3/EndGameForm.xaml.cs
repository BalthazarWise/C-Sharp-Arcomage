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

namespace Arcomage_alpha3
{
    /// <summary>
    /// Interaction logic for EndGameForm.xaml
    /// </summary>
    public partial class EndGameForm : Window
    {
        public EndGameForm(bool win)
        {
            InitializeComponent();
            if (win)
            {
                endGameForm.Background = GetImageBrush("EndGameWinner.png");
            }
            else
            {
                endGameForm.Background = GetImageBrush("EndGameLooser.png");
            }
        }
        private static ImageBrush GetImageBrush(string fileName)
        {
            ImageBrush imgBrush = new ImageBrush();
            BitmapImage bmi = new BitmapImage();
            string fullPath = @"Images\" + fileName;

            bmi.BeginInit();
            bmi.UriSource = new Uri(fullPath, UriKind.Relative);
            bmi.EndInit();

            imgBrush.ImageSource = bmi;

            return imgBrush;
        }

    }
}

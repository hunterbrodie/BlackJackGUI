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

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for EndGame.xaml
    /// </summary>
    public partial class EndGame : UserControl
    {
        public EndGame()
        {
            InitializeComponent();
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game();
            (this.Parent as Grid).Children.Add(game);
            (this.Parent as Grid).Children.Remove(this);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

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
    /// Interaction logic for EndGameButtons.xaml
    /// </summary>
    public partial class EndGameButtons : UserControl
    {
        public EndGameButtons()
        {
            InitializeComponent();
        }

        private void PlayAgain_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game();
            (((this.Parent as Grid).Parent as Grid).Parent as Grid).Children.Add(game);
            (((this.Parent as Grid).Parent as Grid).Parent as Grid).Children.Remove(((this.Parent as Grid).Parent as Grid));
        }

        private void ExitGame_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

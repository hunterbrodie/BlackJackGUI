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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Deck deck = new Deck();
        public List<Card> pcards = new List<Card>();
        public List<Card> dcards = new List<Card>();

        #region Main Constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Startup
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BitmapImage image1 = new BitmapImage();
            BitmapImage image2 = new BitmapImage();
            BitmapImage image3 = new BitmapImage();
            BitmapImage image4 = new BitmapImage();
            deck.reset();
            deck.shuffle();

            Card placeholder = new BlackJack.Card();
            for (int x = 0; x < 2; x++)
            {
                placeholder = deck.deal();
                pcards.Add(placeholder);
                placeholder = deck.deal();
                dcards.Add(placeholder);
            }
            string pngsource = "/CardPNG/" + dcards[1].getPNG() +".png";
            image1.BeginInit();
            image1.UriSource = new Uri("/CardPNG/back.png", UriKind.Relative);
            image1.EndInit();
            this.D1Image.Source = image1;
            image2.BeginInit();
            image2.UriSource = new Uri(pngsource, UriKind.Relative);
            image2.EndInit();
            this.D2Image.Source = image2;
            pngsource = "/CardPNG/" + pcards[0].getPNG() + ".png";
            image3.BeginInit();
            image3.UriSource = new Uri(pngsource, UriKind.Relative);
            image3.EndInit();
            this.P1Image.Source = image3;
            pngsource = "/CardPNG/" + pcards[1].getPNG() + ".png";
            image4.BeginInit();
            image4.UriSource = new Uri(pngsource, UriKind.Relative);
            image4.EndInit();
            this.P2Image.Source = image4;

        }
        #endregion

        private void Stay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hit_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}

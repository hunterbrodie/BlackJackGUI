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
using System.Threading;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : UserControl
    {
        public Deck deck = new Deck();
        public List<Card> pcards = new List<Card>();
        public List<Card> dcards = new List<Card>();
        public int cardnum;
        public int dcardnum;
        public List<Image> pImage = new List<Image>();
        public List<Image> dImage = new List<Image>();
        #region Main constructer
        public Game()
        {
            InitializeComponent();
        }
        #endregion
        #region Startup
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            #region creating image arrays
            pImage.Add(this.P1Image);
            pImage.Add(this.P2Image);
            pImage.Add(this.P3Image);
            pImage.Add(this.P4Image);
            pImage.Add(this.P5Image);
            pImage.Add(this.P6Image);

            dImage.Add(this.D1Image);
            dImage.Add(this.D2Image);
            dImage.Add(this.D3Image);
            dImage.Add(this.D4Image);
            dImage.Add(this.D6Image);
            dImage.Add(this.D5Image);
            #endregion
            cardnum = 2;
            dcardnum = 2;
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

            string pngsource2 = "/CardPNG/back.png";
            for (int x = 0; x < 2; x++)
            {
                BitmapImage image1 = new BitmapImage();
                BitmapImage image2 = new BitmapImage();
                string pngsource1 = "/CardPNG/" + pcards[x].getPNG() + ".png";
                image1.BeginInit();
                image1.UriSource = new Uri(pngsource1, UriKind.Relative);
                image1.EndInit();
                pImage[x].Source = image1;
                image2.BeginInit();
                image2.UriSource = new Uri(pngsource2, UriKind.Relative);
                image2.EndInit();
                dImage[x].Source = image2;
                pngsource2 = "/CardPNG/" + dcards[1].getPNG() + ".png";
            }
            
            if (pcards[0].value + pcards[1].value == 21)
            {
                //player blackjack
                Title.Text = "You Got BlackJack";
                EndGameButtons endGameButtons = new EndGameButtons();
                ButtonGrid.ColumnDefinitions.Clear();
                ButtonGrid.Children.Add(endGameButtons);
                BitmapImage image = new BitmapImage();
                string pngsource = "/CardPNG/" + dcards[0].getPNG() + ".png";
                image.BeginInit();
                image.UriSource = new Uri(pngsource, UriKind.Relative);
                image.EndInit();
                dImage[0].Source = image;
            }
            if (dcards[0].value + dcards[1].value == 21)
            {
                //dealer blackjack
                Title.Text = "Dealer Got BlackJack";
                EndGameButtons endGameButtons = new EndGameButtons();
                ButtonGrid.ColumnDefinitions.Clear();
                ButtonGrid.Children.Add(endGameButtons);
                BitmapImage image = new BitmapImage();
                string pngsource = "/CardPNG/" + dcards[0].getPNG() + ".png";
                image.BeginInit();
                image.UriSource = new Uri(pngsource, UriKind.Relative);
                image.EndInit();
                dImage[0].Source = image;
            }
        }
        #endregion

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            bool busted = false;
            if (cardnum < 6)
            {
                BitmapImage image = new BitmapImage();
                cardnum++;
                Card card = new Card();
                card = deck.deal();
                pcards.Add(card);

                string pngsource = "/CardPNG/" + pcards[cardnum - 1].getPNG() + ".png";
                image.BeginInit();
                image.UriSource = new Uri(pngsource, UriKind.Relative);
                image.EndInit();
                pImage[cardnum - 1].Source = image;
                busted = pbustcheck(busted);
            }
            if (busted == true)
            {
                BitmapImage image = new BitmapImage();
                Title.Text = "You Went Bust";
                EndGameButtons endGameButtons = new EndGameButtons();
                ButtonGrid.ColumnDefinitions.Clear();
                ButtonGrid.Children.Add(endGameButtons);
                string pngsource = "/CardPNG/" + dcards[0].getPNG() + ".png";
                image.BeginInit();
                image.UriSource = new Uri(pngsource, UriKind.Relative);
                image.EndInit();
                dImage[0].Source = image;
            }
        }

        private void Stay_Click(object sender, RoutedEventArgs e)
        {
            string pngsource1 = "";
            bool busted = false;
            while (dtotalval() < 17)
            {
                dcards.Add(deck.deal());
                dcardnum++;
                pngsource1 = "/CardPNG/" + dcards[dcardnum - 1].getPNG() + ".png";
                BitmapImage image1 = new BitmapImage(new Uri(pngsource1, UriKind.Relative));
                dImage[dcardnum - 1].Source = image1;
            }
            busted = dbustcheck(busted);
            if (busted == true)
            {
                Title.Text = "Dealer Went Bust";
            }
            else
            {
                if (ptotalval() > dtotalval())
                {
                    Title.Text = "You Won";
                }
                else if (ptotalval() < dtotalval())
                {
                    Title.Text = "Dealer Won";
                }
                else
                {
                    Title.Text = "You Tied";
                }
            }
            EndGameButtons endGameButtons = new EndGameButtons();
            ButtonGrid.ColumnDefinitions.Clear();
            ButtonGrid.Children.Add(endGameButtons);
            BitmapImage image = new BitmapImage();
            string pngsource = "/CardPNG/" + dcards[0].getPNG() + ".png";
            image.BeginInit();
            image.UriSource = new Uri(pngsource, UriKind.Relative);
            image.EndInit();
            dImage[0].Source = image;
        }

        public bool pbustcheck(bool busted)
        {
            int total = ptotalval();

            if (total > 21)
            {
                busted = true;
            }

            return busted;
        }

        public bool dbustcheck(bool busted)
        {
            int total = dtotalval();

            if (total > 21)
            {
                busted = true;
            }

            return busted;
        }

        public int ptotalval()
        {
            int total = 0;
            bool acesnum = false;
            for (int x = 0; x < pcards.Count(); x++)
            {
                if (pcards[x].value == 1)
                {
                    acesnum = true;
                }
                if (pcards[x].value > 10)
                {
                    total += 10;
                }
                else
                {
                    total += pcards[x].value;
                }
            }

            if (acesnum && (total - 1) < 11)
            {
                total += 10;
            }

            return total;
        }

        public int dtotalval()
        {
            int total = 0;
            bool acesnum = false;
            for (int x = 0; x < dcards.Count(); x++)
            {
                if (dcards[x].value == 1)
                {
                    acesnum = true;
                }
                if (dcards[x].value > 10)
                {
                    total += 10;
                }
                else
                {
                    total += dcards[x].value;
                }
            }

            if (acesnum && (total - 1) < 11)
            {
                total += 10;
            }

            return total;
        }

    }
}

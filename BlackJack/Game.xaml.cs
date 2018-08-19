﻿using System;
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
            }
            if (dcards[0].value + dcards[1].value == 21)
            {
                //dealer blackjack
            }
        }
        #endregion

        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            bool busted = false;
            if (cardnum < 6)
            {
                cardnum++;
                BitmapImage image = new BitmapImage();
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
                BustedUC bustedUC = new BustedUC();
                (this.Parent as Grid).Children.Add(bustedUC);
                ((TextBlock)bustedUC.FindName("text")).Text = "You Went Bust";
                (this.Parent as Grid).Children.Remove(this);
            }
        }

        private void Stay_Click(object sender, RoutedEventArgs e)
        {
            EndGame endGame = new EndGame();
            bool busted = false;
            while (dtotalval() < 17)
            {
                dcards.Add(deck.deal());
            }
            busted = dbustcheck(busted);
            if (busted == true)
            {
                BustedUC bustedUC = new BustedUC();
                (this.Parent as Grid).Children.Add(bustedUC);
                ((TextBlock)bustedUC.FindName("text")).Text = "Dealer Went Bust";
                (this.Parent as Grid).Children.Remove(this);
            }
            else
            {
                if (ptotalval() > dtotalval())
                {
                    ((TextBlock)endGame.FindName("text")).Text = "You Won";
                }
                else
                {
                    ((TextBlock)endGame.FindName("text")).Text = "Dealer Won";
                }
                (this.Parent as Grid).Children.Add(endGame);
                ((TextBlock)endGame.FindName("youhad")).Text = "You Had: " + ptotalval().ToString();
                ((TextBlock)endGame.FindName("dealerhad")).Text = "Dealer Had: " + dtotalval().ToString();
                (this.Parent as Grid).Children.Remove(this);
            }
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
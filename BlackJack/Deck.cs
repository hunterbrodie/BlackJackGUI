using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    
    public class Deck
    {
        Random rand = new Random();
        public  List<Card> cards = new List<Card>();

        public  void reset()
        {
            String suitph;
            for (int x = 0; x < 4; x++)
            {
                switch (x)
                {
                    case 0:
                        suitph = "Spades";
                        break;
                    case 1:
                        suitph = "Clubs";
                        break;
                    case 2:
                        suitph = "Hearts";
                        break;
                    case 3:
                        suitph = "Diamonds";
                        break;
                    default:
                        suitph = "null";
                        break;
                }
                for (int y = 1; y < 14; y++)
                {
                    Card card = new Card();
                    card.setSuit(suitph);
                    card.setValue(y);
                    cards.Add(card);
                }
            }
        }
        public  void shuffle()
        {
            Random rand = new Random();

            Card phold;

            for (int x = 0; x < 52; x++)
            {
                int x1 = rand.Next(0, 52);
                int x2 = rand.Next(0, 52);

                phold = cards[x1];
                cards[x1] = cards[x2];
                cards[x2] = phold;
            }
        }
        public  Card deal()
        {
            Card placeholder = new Card();

            placeholder = cards[0];
            cards.RemoveAt(0);

            return placeholder;
        }

    }

}

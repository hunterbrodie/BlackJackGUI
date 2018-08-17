using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public class Card
    {
        public string valuestr;
        public int value;
        public string suit;
        
        public string getname()
        {
            valuestr = value.ToString();
            switch (value)
            {
                case 1:
                    valuestr = "Ace";
                    break;
                case 11:
                    valuestr = "Jack";
                    break;
                case 12:
                    valuestr = "Queen";
                    break;
                case 13:
                    valuestr = "King";
                    break;
            }

            string name = valuestr + " of " + suit;

            return name;
        }
        public void setSuit(string suitName)
        {
            suit = suitName;
        }
        public void setValue(int valueNum)
        {
            value = valueNum;
        }
        public string getPNG()
        {
            string xsuit = "";
            string valuestr = value.ToString();

            switch (value)
            {
                case 1:
                    valuestr = "A";
                    break;
                case 11:
                    valuestr = "J";
                    break;
                case 12:
                    valuestr = "Q";
                    break;
                case 13:
                    valuestr = "K";
                    break;
            }
            switch (suit)
            {
                case "Spades":
                    xsuit = "S";
                    break;
                case "Clubs":
                    xsuit = "C";
                    break;
                case "Diamonds":
                    xsuit = "D";
                    break;
                case "Hearts":
                    xsuit = "H";
                    break;
            }

            return valuestr + xsuit;
        }



    }
}
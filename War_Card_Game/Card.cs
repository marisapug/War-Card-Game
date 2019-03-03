using System;
namespace War_Card_Game
{
    class Card
    {
        string rank;
        string suit;

        // CONSTRUCTOR 1
        public Card()
        {
            this.rank = null;
            this.suit = null;
        }

        // CONSTRUCTOR 2
        public Card(String r, String s)
        {
            this.rank = r;
            this.suit = s;
        }

        // GETTERS
        public string GetRank()
        {
            return this.rank;
        }

        public string GetSuit()
        {
            return this.suit;
        }

    }

}

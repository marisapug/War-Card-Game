using System;
using System.Collections;
using System.Collections.Generic;

namespace War_Card_Game
{
    class Deck { 
        List<Card> cardDeck = new List<Card>();
    
        // CONSTRUCTOR
        public Deck()
        {
            string[] possibleRanks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            string[] possibleSuits = { "spades", "clubs", "hearts", "diamonds" };
            for (int i = 0; i < possibleRanks.Length; i++)
            {
                for (int j = 0; j < possibleSuits.Length; j++)
                {
                    Card c = new Card(possibleRanks[i], possibleSuits[j]);
                    cardDeck.Add(c);
                }
            }
        }

        // GETTER
        public List<Card> Get_Deck()
        {
            return this.cardDeck;
        }

        // Helper function for Shuffle
        public void SwapCards(int n, int m)
        {
            Card c1 = cardDeck[n];
            Card c2 = cardDeck[m];
            Card temp = c2;
            this.cardDeck[m] = c1;
            this.cardDeck[n] = temp;
        }

        // Shuffles the deck
        public void Shuffle()
        {
            Random rand = new Random();
            for (int i = 0; i < (this.cardDeck.Count)/2; i++)
            {
                int random_n = rand.Next(0, this.cardDeck.Count);
                int random_m = rand.Next(0, this.cardDeck.Count);
                SwapCards(random_n, random_m);
            }
        }

    }
}

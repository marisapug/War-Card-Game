using System;
using System.Collections;
using System.Collections.Generic;

namespace War_Card_Game
{
    class Player
    {
        string playerName;
        List<Card> playerDeck = new List<Card>();

        // CONSTRUCTOR
        public Player(string n)
        {
            this.playerName = n;
            Console.WriteLine("Welcome " + this.playerName + "!");
        }

        // GETTERS
        public string GetPlayerName()
        {
            return this.playerName;
        }

        public int GetDeckSize()
        {
            return this.playerDeck.Count;
        }

        // Adds a card to the player's personal deck
        public void AddToDeck(Card c)
        {
            this.playerDeck.Add(c);
        }

        // Prints the player's entire personal deck
        // Used for debugging
        public void PrintDeck()
        {
            for (int i = 0; i < playerDeck.Count; i++)
            {
                Console.WriteLine(playerDeck[i].GetRank() + " of " + playerDeck[i].GetSuit());
            }
        }

        // Draws a card from the player's personal deck
        // Removes the card from player_deck, prints, and returns it
        public Card DrawCard()
        {
            Card drawing = this.playerDeck[0];
            this.playerDeck.RemoveAt(0);
            Console.WriteLine(this.playerName + "'s card is " + drawing.GetRank() + " of " + drawing.GetSuit());
            return drawing;
        }

        // Draws a face-down card during War
        public Card DrawFaceDown()
        {
            Card drawing = this.playerDeck[0];
            this.playerDeck.RemoveAt(0);
            return drawing;
        }

        // Adds multiple cards to the player's personal deck
        public void GiveJackpot(List<Card> jackpot)
        {
            this.playerDeck.AddRange(jackpot);
        }

    }
}

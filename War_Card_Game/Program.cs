using System;
using System.Collections;
using System.Collections.Generic;

namespace War_Card_Game
{
    class Game
    {
        public Player[] players = new Player[2];
        public Dictionary<string,int> card_ranks = new Dictionary<string,int>();
        public Deck deck = new Deck();

        // CONSTRUCTOR
        public Game(){
            Console.Write("What is your name?");
            string your_name = Console.ReadLine();
            this.players[0] = new Player("Computer"); // Feel free to customize these arguments to personalize your game!
            this.players[1] = new Player(your_name);
            this.card_ranks.Add("2", 1);
            this.card_ranks.Add("3", 2);
            this.card_ranks.Add("4", 3);
            this.card_ranks.Add("5", 4);
            this.card_ranks.Add("6", 5);
            this.card_ranks.Add("7", 6);
            this.card_ranks.Add("8", 7);
            this.card_ranks.Add("9", 8);
            this.card_ranks.Add("10", 9);
            this.card_ranks.Add("Jack", 10);
            this.card_ranks.Add("Queen", 11);
            this.card_ranks.Add("King", 12);
            this.card_ranks.Add("Ace", 13);
        }

        // Deals 26 "random" cards to each player
        public void DealCards()
        {
            this.deck.Shuffle();
            for (int i = 0; i < this.deck.Get_Deck().Count; i++)
            {
                if ((i % 2) == 0)
                {
                    this.players[0].AddToDeck(this.deck.Get_Deck()[i]);
                }
                else this.players[1].AddToDeck(this.deck.Get_Deck()[i]);
            }
        }

        // Called to prompt players to draw their cards
        public Card[] DrawCards()
        {
            Console.Write("Enter any key to draw a card.");
            string input = Console.ReadLine();
            Card[] current_draws = new Card[2];
            if (input != null)
            {
                current_draws[1] = this.players[1].DrawCard();
            }
            Console.Write("Now I will draw a card...");
            current_draws[0] = this.players[0].DrawCard();
            return current_draws;
        }

        // Compares two cards and returns the higher of the two
        public Card GetHigherCard(Card c1, Card c2)
        {
            string rank1 = c1.GetRank();
            string rank2 = c2.GetRank();
            if (this.card_ranks[rank1] > this.card_ranks[rank2])
            {
                return c1;
            }
            else if (this.card_ranks[rank1] < this.card_ranks[rank2])
            {
                return c2;
            }
            else
            {
                return new Card(); // "dummy" null card
            }
        }

        // If both players turn over a card with the same rank, it is war!
        // This is a recursive function when the face-up cards are also the same rank.
        public void War(Card c1, Card c2, List<Card> jackpot)
        {
            Console.Write("WAR!");
            Console.WriteLine("First, we will both draw two cards face down.");
            Card[] face_down = DrawFaceDown();
            jackpot.Add(face_down[0]);
            jackpot.Add(face_down[1]);
            Console.WriteLine("Done! Now, we will draw two cards face up.. Whoever has the highest card wins this round.");
            Card[] face_up = DrawCards();
            Card winner = GetHigherCard(face_up[0], face_up[1]);
            jackpot.Add(face_up[0]);
            jackpot.Add(face_up[1]);
            if (winner == face_up[1])
            {
                Console.WriteLine(this.players[1].GetPlayerName() + " wins this round!");
                Console.WriteLine(this.players[1].GetPlayerName() + " gets " + jackpot.Count + " cards!");
                this.players[1].GiveJackpot(jackpot);
            }
            else if (winner == face_up[0])
            {
                Console.WriteLine(this.players[0].GetPlayerName() + " wins this round!");
                Console.WriteLine(this.players[0].GetPlayerName() + " gets " + jackpot.Count + " cards!");
                this.players[0].GiveJackpot(jackpot);
            }
            else
            {
                War(face_up[0], face_up[1], jackpot);
            }

        }

        // Called during War when the players must draw their cards face-down
        public Card[] DrawFaceDown()
        {
            Console.Write("Enter any key to draw your face-down card.");
            string input = Console.ReadLine();
            Card[] current_draws = new Card[2];
            if (input != null)
            {
                current_draws[1] = this.players[1].DrawFaceDown();
            }
            current_draws[0] = this.players[0].DrawFaceDown();
            return current_draws;
        }

        // The logic for the general setup of the game
        // Loops until one player possesses the entire Deck
        public void PlayGame()
        {
            Card[] current_draws = DrawCards();
            Card winner = GetHigherCard(current_draws[0], current_draws[1]);
            List<Card> my_jack = new List<Card>();
            my_jack.Add(current_draws[0]);
            my_jack.Add(current_draws[1]);
            if (winner == current_draws[1])
            {
                Console.WriteLine(this.players[1].GetPlayerName() + " wins this round!");
                this.players[1].GiveJackpot(my_jack);
            }
            else if (winner == current_draws[0])
            {
                Console.WriteLine(this.players[0].GetPlayerName() + " wins this round!");
                this.players[0].GiveJackpot(my_jack);
            }
            else
            {
                War(current_draws[0], current_draws[1], my_jack);
            }
            Console.WriteLine(this.players[0].GetPlayerName() + " has " + this.players[0].GetDeckSize() + " cards in their deck.");
            Console.WriteLine(this.players[1].GetPlayerName() + " has " + this.players[1].GetDeckSize() + " cards in their deck.");
            Console.WriteLine(Environment.NewLine);
        }

        // MAIN
        public static void Main(string[] args)
        {
            Game g = new Game();
            g.DealCards();
            while ((g.players[0].GetDeckSize() < 52) && (g.players[1].GetDeckSize() < 52))
            {
                g.PlayGame();
            }
            if (g.players[0].GetDeckSize() == 52)
            {
                Console.WriteLine(g.players[0].GetPlayerName() + " wins!");
            }
            else
            {
                Console.WriteLine(g.players[1].GetPlayerName() + " wins!");
            }
        }
    }
}

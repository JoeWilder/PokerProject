/*******************************************
Program:  DeckOfCards.cs
Purpose: To store data about a deck
Author:  Joe Wilder, Ty Rivera, Colin Capelo, Alex Kennedy
Date: Feb 9th, 2022
********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerProject
{
	class DeckOfCards
	{
		List<Card> deck = new List<Card>(); // store 52 cards in a deck
		int cardCount = 0; // Start on card 0, continue until card 51

		/* fill a deck with cards */
		public void GenerateCards()
		{
			deck.Clear();
			for (int x = 0; x <= 12; x++)
			{
				for (int y = 0; y < 4; y++)
				{
					Card card = new Card(Card.Ranks[x], Card.Suits[y]);
					deck.Add(card);
				}
			}
		}

		/* print all cards in the deck */
		public void PrintDeck()
		{
			foreach (Card card in deck)
			{
				Console.WriteLine(card.DisplayCard());
			}
		}

		/* Randomize order of all cards in the deck using Fisher-Yates algorithm */
		public void ShuffleCards()
		{
			Random rng = new Random();
			int n = deck.Count;
			while (n > 1)
			{
				n--;
				int k = rng.Next(n + 1);
				Card value = deck[k];
				deck[k] = deck[n];
				deck[n] = value;
			}
		}

		/* Print a new card from the deck */
		public void DealACard()
        {
			Card card = deck[cardCount];
			cardCount++;
			Console.WriteLine("Dealing a new card: " + card.DisplayCard());
        }
	}
}

/*******************************************
Program:  Card.cs
Purpose: To store data about a card
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
    class Card
    {
        string rank; // card rank
        string suite; // card suite

        /* card constructor */
        public Card(string rank, string suite)
        {
            this.rank = rank;
            this.suite = suite;
        }

        private static string[] ranks = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", // Array of all card ranks
	    "Nine", "Ten", "Jack", "Queen", "King" };

        private static string[] suits = { "Diamonds", "Hearts", "Spades", "Clubs" }; // Array of all card suits

        /* get card suit */
        public static string[] Suits { get => suits; }

        /*  get card rank */
        public static string[] Ranks { get => ranks; }


        /* Print a card */
        public string DisplayCard()
        {
            return rank.ToString() + " " + suite;
        }
    }
}

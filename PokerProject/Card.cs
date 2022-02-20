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
        string suit; // card suite
        int value; // assign a numeric value to each card
        string path; // path to image file
        int suitID; // assign a numeric value to each suit

        /* card constructor */
        public Card(string rank, string suit, string path)
        {
            this.rank = rank;
            this.suit = suit;
            this.path = path;
            if (rank == "ace")
            {
                value = 1;
            }
            else if (rank == "jack")
            {
                value = 11;
            }
            else if (rank == "queen")
            {
                value = 12;
            }
            else if (rank == "king")
            {
                value = 13;
            }
            else
            {
                value = int.Parse(rank);
            }

            if (suit == "diamonds")
            {
                suitID = 1;
            }
            else if (suit == "hearts")
            {
                suitID = 2;
            }
            else if (suit == "spades")
            {
                suitID = 3;
            }
            else
            {
                suitID = 4;
            }
        }

        private static string[] ranks = { "ace", "2", "3", "4", "5", "6", "7", "8", // Array of all card ranks
	    "9", "10", "jack", "queen", "king" };

        private static string[] suits = { "diamonds", "hearts", "spades", "clubs" }; // Array of all card suits

        /* get card suit */
        public static string[] Suits { get => suits; }

        /*  get card rank */
        public static string[] Ranks { get => ranks; }


        /* Print a card */
        public string DisplayCard()
        {
            return rank.ToString() + " " + suit;
        }

        /* Get path to the card's image */
        public string GetPath()
        {
            return path;
        }

        /* Get rank of card */
        public string GetRank()
        {
            return rank;
        }

        /* Get suit of card */
        public string GetSuit()
        {
            return suit;
        }

        /* Get value of card */
        public int GetValue()
        {
            return value;
        }

        /* Get suit id of card */
        public int GetSuitID()
        {
            return suitID;
        }
    }
}

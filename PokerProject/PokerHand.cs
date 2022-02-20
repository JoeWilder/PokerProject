/*******************************************
Program:  PokerHand.cs
Purpose: To store data and evaluate a hand of 5 cards
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
    class PokerHand
    {

        Card[] hand = new Card[5]; // store cards in an array
        int handValue = 0; // how valuable the hand is


        /* Fill hand array using a constructor */
        public PokerHand(Card card1, Card card2, Card card3, Card card4, Card card5)
        {
            hand[0] = card1;
            hand[1] = card2;
            hand[2] = card3;
            hand[3] = card4;
            hand[4] = card5;
        }

        /* Sort the hand from lowest rank to highest rank */
        public void SortHandByRank()
        {
            int i, j, min_j;
            for (i = 0; i < hand.Length; i++)
            {
                min_j = i;
                for (j = i+1; j < hand.Length; j++)
                {
                    if (hand[j].GetValue() < hand[min_j].GetValue())
                    {
                        min_j = j;
                    }
                }
                Card temp = hand[i];
                hand[i] = hand[min_j];
                hand[min_j] = temp;
            }
        }

        /* Group suits together */
        public void SortHandBySuit()
        {
            int i, j, min_j;
            for (i = 0; i < hand.Length; i++)
            {
                min_j = i;
                for (j = i + 1; j < hand.Length; j++)
                {
                    if (hand[j].GetSuitID() < hand[min_j].GetSuitID())
                    {
                        min_j = j;
                    }
                }
                Card temp = hand[i];
                hand[i] = hand[min_j];
                hand[min_j] = temp;
            }
        }


        /* Check if hand has 5 cards with the same suit */
        public Boolean Flush()
        {
            SortHandBySuit();
            if (hand[0].GetSuit() == hand[4].GetSuit())
            {
                return true;
            }
            return false;
        }


        /* Check if hand has four cards with the same rank */
        public Boolean FourOfAKind()
        {
            SortHandByRank();
            if (hand[0].GetRank() == hand[1].GetRank() && hand[1].GetRank() == hand[2].GetRank() &&
                hand[2].GetRank() == hand[3].GetRank())
            {
                return true;
            }
            if (hand[1].GetRank() == hand[2].GetRank() &&
                hand[2].GetRank() == hand[3].GetRank() && hand[3].GetRank() == hand[4].GetRank())
            {
                return true;
            }
            return false;
        }


        /* Check if the hand can be arranged so that the rank increases by 1 on each sequential card */
        public Boolean isStraight()
        {
            SortHandByRank();
            if (hand[0].GetValue() == hand[1].GetValue() + 1)
            {
                if (hand[1].GetValue() == hand[2].GetValue() + 1)
                {
                    if (hand[2].GetValue() == hand[3].GetValue() + 1)
                    {
                        if (hand[3].GetValue() == hand[4].GetValue() + 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }


        /* Check if the hand has a three of a kind and a two of a kind */
        public Boolean FullHouse()
        {
            SortHandBySuit();
            if (hand[0].GetRank() == hand[1].GetRank() && hand[1].GetRank() == hand[2].GetRank() &&
                hand[3].GetRank() == hand[4].GetRank())
            {
                return true;
            }
            if (hand[0].GetRank() == hand[1].GetRank() && hand[2].GetRank() == hand[3].GetRank() &&
                hand[3].GetRank() == hand[4].GetRank())
            {
                return true;
            }
            return false;
        }


        /* Check if the hand has 3 cards of the same rank */
        public Boolean ThreeOfAKind()
        {

            SortHandByRank();

            if (hand[0].GetRank() == hand[1].GetRank() &&
                 hand[1].GetRank() == hand[2].GetRank())
            {
                return true;
            }

            if (hand[1].GetRank() == hand[2].GetRank() &&
                 hand[2].GetRank() == hand[3].GetRank())
            {
                return true;
            }

            if (hand[2].GetRank() == hand[3].GetRank() &&
                 hand[3].GetRank() == hand[4].GetRank())
            {
                return true;
            }

            return false;

        }

        /* Check if the hand has two pairs of card with the same rank */
        public Boolean TwoPairs()
        {

            SortHandByRank();

            if (hand[0].GetRank() == hand[1].GetRank() &&
                 hand[2].GetRank() == hand[3].GetRank())
            {
                return true;
            }

            if (hand[0].GetRank() == hand[1].GetRank() &&
                 hand[3].GetRank() == hand[4].GetRank())
            {
                return true;
            }

            if (hand[1].GetRank() == hand[2].GetRank() &&
                 hand[3].GetRank() == hand[4].GetRank())
            {
                return true;
            }

            return false;
        }


        /* Check if hand has a pair of cards with the same rank */
        public Boolean Pair()
        {
            SortHandByRank();

            if (hand[0].GetRank() == hand[1].GetRank()) { return true; }

            if (hand[1].GetRank() == hand[2].GetRank()) { return true; }

            if (hand[2].GetRank() == hand[3].GetRank()) { return true; }

            if (hand[3].GetRank() == hand[4].GetRank()) { return true; }

            return false;
        }


        /* Get a card from the deck given its index */
        public Card GetCardByIndex(int i)
        {
            return hand[i];
        }


        /* Evaluate the hand and determine the value of the hand */
        public String ValidateHand()
        {
            if (Flush())
            {
                setHandValue(6);
                return "Flush!";
            }
            else if (FourOfAKind())
            {
                setHandValue(5);
                return "Four of a kind!";
            }
            else if (FullHouse())
            {
                setHandValue(4);
                return "Full house!";
            }
            else if (ThreeOfAKind())
            {
                setHandValue(3);
                return "Three of a kind!";
            }
            else if (TwoPairs())
            {
                setHandValue(2);
                return "Two pairs!";
            }
            else if (Pair())
            {
                setHandValue(1);
                return "One pair!";
            }
            else
            {
                setHandValue(0);
                return "";
            }
        }


        /* Set the value of the hand */
        public void setHandValue(int val)
        {
            handValue = val;
        }


        /* Get the value of the hand */
        public int getHandValue()
        {
            return handValue;
        }
    }
}

/*******************************************
Program:  Poker.cs
Purpose: Driver code
Author:  Joe Wilder, Ty Rivera, Colin Capelo, Alex Kennedy
Date: Feb 9th, 2022
********************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerProject
{
    static class Poker
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DeckOfCards deck = new DeckOfCards();
            deck.GenerateCards();
            deck.PrintDeck();
            deck.ShuffleCards();
            deck.PrintDeck();
            deck.DealACard();
            deck.DealACard();
            deck.DealACard();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}

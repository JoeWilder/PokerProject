/*******************************************
Program:  PokerForm.cs
Purpose: Manage form events
Author:  Joe Wilder, Ty Rivera, Colin Capelo, Alex Kennedy
Date: Feb 9th, 2022
********************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerProject
{
    public partial class PokerForm : Form
    {
        DeckOfCards deck; // create a deck
        PokerHand hand1; // player 1 hand
        PokerHand hand2; // player 2 hand


        public PokerForm()
        {
            InitializeComponent();
            deck = new DeckOfCards();
        }


        /* On form load, populate the deck */
        private void PokerForm_Load(object sender, EventArgs e)
        {
            deck.GenerateCards();
            deck.ShuffleCards();
        }


        /* Deal each player a new hand */
        private void dealCardsButton_Click(object sender, EventArgs e)
        {
            Hand1Label.Text = "";
            Hand2Label.Text = "";
            WinLabel.Text = "";

            hand1 = new PokerHand(deck.DealACard(), deck.DealACard(), deck.DealACard(), deck.DealACard(), deck.DealACard());
            hand2 = new PokerHand(deck.DealACard(), deck.DealACard(), deck.DealACard(), deck.DealACard(), deck.DealACard());

            cardBox1.Image = (Image)Properties.Resources.ResourceManager.GetObject(hand1.GetCardByIndex(0).GetPath());
            cardBox2.Image = (Image)Properties.Resources.ResourceManager.GetObject(hand1.GetCardByIndex(1).GetPath());
            cardBox3.Image = (Image)Properties.Resources.ResourceManager.GetObject(hand1.GetCardByIndex(2).GetPath());
            cardBox4.Image = (Image)Properties.Resources.ResourceManager.GetObject(hand1.GetCardByIndex(3).GetPath());
            cardBox5.Image = (Image)Properties.Resources.ResourceManager.GetObject(hand1.GetCardByIndex(4).GetPath());


            cardBox6.Image = (Image)Properties.Resources.ResourceManager.GetObject(hand2.GetCardByIndex(0).GetPath());
            cardBox7.Image = (Image)Properties.Resources.ResourceManager.GetObject(hand2.GetCardByIndex(1).GetPath());
            cardBox8.Image = (Image)Properties.Resources.ResourceManager.GetObject(hand2.GetCardByIndex(2).GetPath());
            cardBox9.Image = (Image)Properties.Resources.ResourceManager.GetObject(hand2.GetCardByIndex(3).GetPath());
            cardBox10.Image = (Image)Properties.Resources.ResourceManager.GetObject(hand2.GetCardByIndex(4).GetPath());
        }

       
        /* Evaluate hands on button click */
        private void validateHandButton_Click(object sender, EventArgs e)
        {
            Hand1Label.Text = hand1.ValidateHand();
            Hand2Label.Text = hand2.ValidateHand();
            if (hand1.getHandValue() > hand2.getHandValue())
            {
                WinLabel.Text = "Player 1 has a better hand!";
            }
            else if (hand2.getHandValue() > hand1.getHandValue())
            {
                WinLabel.Text = "Player 2 has a better hand!";
            }
            else if (hand1.getHandValue() == hand2.getHandValue() && hand1.getHandValue() != 0)
            {
                WinLabel.Text = "Player 1 and 2 have an equal hand!";
            }
            else
            {
                WinLabel.Text = "";
            }
        }
    }
}

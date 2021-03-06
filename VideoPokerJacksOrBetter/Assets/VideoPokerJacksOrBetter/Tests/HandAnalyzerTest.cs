﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class HandAnalyzerTest
    {
        private HandAnalyzer _handAnalyzer;

        [SetUp]
        public void Setup()
        {
            _handAnalyzer = new HandAnalyzer();
        }  

        [Test]
        public void TestGetRank_IsJacksOrBetter_Jecks()
        {
            //JACK - CLUBS
            Card card1 = new Card(new Suit(Suit.CLUBS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));
            //JACK - SPADES
            Card card4 = new Card(new Suit(Suit.SPADES, Suit.SPADES_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));

            //EIGHT - SPADES
            Card card3 = new Card(new Suit(Suit.SPADES, Suit.SPADES_IMG_NAME), new CardsRank(CardsRank.EIGHT, CardsRank.EIGHT_IMG_NAME));
            //ACE - HEARTS
            Card card2 = new Card(new Suit(Suit.HEARTS, Suit.HEARTS_IMG_NAME), new CardsRank(CardsRank.ACE, CardsRank.ACE_IMG_NAME));
            //TEN - HEARTS
            Card card5 = new Card(new Suit(Suit.HEARTS, Suit.HEARTS_IMG_NAME), new CardsRank(CardsRank.TEN, CardsRank.TEN_IMG_NAME));      

            List<Card> cardsHand = new List<Card>();
            cardsHand.Add(card1);
            cardsHand.Add(card2);
            cardsHand.Add(card3);
            cardsHand.Add(card4);
            cardsHand.Add(card5);

            int winCombination = _handAnalyzer.GetRank(cardsHand);
            int expectedWin = (int)HandRank.JACKS_OR_BETTER;

            Assert.True(winCombination == expectedWin, "expected win combination = "+ expectedWin + ", actual = " + winCombination);
        }

        [Test]
        public void TestGetRank_IsJacksOrBetter_False()
        {
            //JACK - CLUBS
            Card card1 = new Card(new Suit(Suit.CLUBS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));

            //EIGHT - SPADES
            Card card3 = new Card(new Suit(Suit.SPADES, Suit.SPADES_IMG_NAME), new CardsRank(CardsRank.EIGHT, CardsRank.EIGHT_IMG_NAME));
            //EIGHT - CLUBS
            Card card5 = new Card(new Suit(Suit.CLUBS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.EIGHT, CardsRank.EIGHT_IMG_NAME));
           
            //ACE - HEARTS
            Card card2 = new Card(new Suit(Suit.HEARTS, Suit.HEARTS_IMG_NAME), new CardsRank(CardsRank.ACE, CardsRank.ACE_IMG_NAME));
            //TEN - HEARTS
            Card card4 = new Card(new Suit(Suit.HEARTS, Suit.HEARTS_IMG_NAME), new CardsRank(CardsRank.TEN, CardsRank.TEN_IMG_NAME));

            List<Card> cardsHand = new List<Card>();
            cardsHand.Add(card1);
            cardsHand.Add(card2);
            cardsHand.Add(card3);
            cardsHand.Add(card4);
            cardsHand.Add(card5);

            int winCombination = _handAnalyzer.GetRank(cardsHand);
            int expectedWin = (int)HandAnalyzer.LOSE_HAND;

            Assert.True(winCombination == expectedWin, "expected win combination = " + expectedWin + ", actual = " + winCombination);
        }

        [Test]
        public void TestGetRank_IsJacksOrBetter_Kings()
        {
            //KING - CLUBS
            Card card1 = new Card(new Suit(Suit.CLUBS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.KING, CardsRank.KING_IMG_NAME));
            //KING - SPADES
            Card card5 = new Card(new Suit(Suit.SPADES, Suit.SPADES_IMG_NAME), new CardsRank(CardsRank.KING, CardsRank.KING_IMG_NAME));

            //EIGHT - SPADES
            Card card3 = new Card(new Suit(Suit.SPADES, Suit.SPADES_IMG_NAME), new CardsRank(CardsRank.EIGHT, CardsRank.EIGHT_IMG_NAME));
            //ACE - HEARTS
            Card card2 = new Card(new Suit(Suit.HEARTS, Suit.HEARTS_IMG_NAME), new CardsRank(CardsRank.ACE, CardsRank.ACE_IMG_NAME));
            //TEN - HEARTS
            Card card4 = new Card(new Suit(Suit.HEARTS, Suit.HEARTS_IMG_NAME), new CardsRank(CardsRank.TEN, CardsRank.TEN_IMG_NAME));

            List<Card> cardsHand = new List<Card>();
            cardsHand.Add(card1);
            cardsHand.Add(card2);
            cardsHand.Add(card3);
            cardsHand.Add(card4);
            cardsHand.Add(card5);

            int winCombination = _handAnalyzer.GetRank(cardsHand);
            int expectedWin = (int)HandRank.JACKS_OR_BETTER;

            Assert.True(winCombination == expectedWin, "expected win combination = " + expectedWin + ", actual = " + winCombination);
        }

        [Test]
        public void TestGetRank_IsTwoPair_JecksAndKings()
        {
            //JACK - CLUBS
            Card card1 = new Card(new Suit(Suit.CLUBS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));
            //JACK - SPADES
            Card card4 = new Card(new Suit(Suit.SPADES, Suit.SPADES_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));

            //KING - CLUBS
            Card card2 = new Card(new Suit(Suit.CLUBS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.KING, CardsRank.KING_IMG_NAME));
            //KING - SPADES
            Card card5 = new Card(new Suit(Suit.SPADES, Suit.SPADES_IMG_NAME), new CardsRank(CardsRank.KING, CardsRank.KING_IMG_NAME));

            //TEN - HEARTS
            Card card3 = new Card(new Suit(Suit.HEARTS, Suit.HEARTS_IMG_NAME), new CardsRank(CardsRank.TEN, CardsRank.TEN_IMG_NAME));

            List<Card> cardsHand = new List<Card>();
            cardsHand.Add(card1);
            cardsHand.Add(card2);
            cardsHand.Add(card3);
            cardsHand.Add(card4);
            cardsHand.Add(card5);

            int winCombination = _handAnalyzer.GetRank(cardsHand);
            int expectedWin = (int)HandRank.TWO_PAIR;

            Assert.True(winCombination == expectedWin, "expected win combination = " + expectedWin + ", actual = " + winCombination);
        }

        [Test]
        public void TestGetRank_IsThreeOfKind_Jecks()
        {
            //----Three same rank-----
            //JACK - CLUBS
            Card card1 = new Card(new Suit(Suit.CLUBS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));
            //JACK - SPADES
            Card card4 = new Card(new Suit(Suit.SPADES, Suit.SPADES_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));
            //JACK - HEARTS
            Card card2 = new Card(new Suit(Suit.HEARTS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));

            //----Two different rank (otherwise its FULL_HOUSE)
            //ACE - HEARTS
            Card card5 = new Card(new Suit(Suit.HEARTS, Suit.HEARTS_IMG_NAME), new CardsRank(CardsRank.ACE, CardsRank.ACE_IMG_NAME));
            //TEN - HEARTS
            Card card3 = new Card(new Suit(Suit.HEARTS, Suit.HEARTS_IMG_NAME), new CardsRank(CardsRank.TEN, CardsRank.TEN_IMG_NAME));

            List<Card> cardsHand = new List<Card>();
            cardsHand.Add(card1);
            cardsHand.Add(card2);
            cardsHand.Add(card3);
            cardsHand.Add(card4);
            cardsHand.Add(card5);

            int winCombination = _handAnalyzer.GetRank(cardsHand);
            int expectedWin = (int)HandRank.THREE_OF_A_KIND;

            Assert.True(winCombination == expectedWin, "expected win combination = " + expectedWin + ", actual = " + winCombination);
        }

        [Test]
        public void TestGetRank_IsStraight()
        {
            //----------------Five consecutive cards(7 - 8 - 9 - 10 - Jack) of any mixed suits
            //SEVEN - DIAMONDS
            Card card2 = new Card(new Suit(Suit.DIAMONDS, Suit.SPADES_IMG_NAME), new CardsRank(CardsRank.SEVEN, CardsRank.SEVEN_IMG_NAME));
            //EIGHT - SPADES
            Card card3 = new Card(new Suit(Suit.SPADES, Suit.SPADES_IMG_NAME), new CardsRank(CardsRank.EIGHT, CardsRank.EIGHT_IMG_NAME));
            //NINE - DIAMONDS
            Card card5 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.NINE, CardsRank.NINE_IMG_NAME));
            //TEN - HEARTS
            Card card4 = new Card(new Suit(Suit.HEARTS, Suit.HEARTS_IMG_NAME), new CardsRank(CardsRank.TEN, CardsRank.TEN_IMG_NAME));
            //JACK - CLUBS
            Card card1 = new Card(new Suit(Suit.CLUBS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));

            List<Card> cardsHand = new List<Card>();
            cardsHand.Add(card1);
            cardsHand.Add(card2);
            cardsHand.Add(card3);
            cardsHand.Add(card4);
            cardsHand.Add(card5);

            int winCombination = _handAnalyzer.GetRank(cardsHand);
            int expectedWin = (int)HandRank.STRAIGHT;

            Assert.True(winCombination == expectedWin, "expected win combination = " + expectedWin + ", actual = " + winCombination);
        }

        [Test]
        public void TestGetRank_IsFlush()
        {
            //Any five cards of the SAME SUIT
            //TWO - DIAMONDS
            Card card2 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.TWO, CardsRank.TWO_IMG_NAME));
            //EIGHT - DIAMONDS
            Card card3 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.EIGHT, CardsRank.EIGHT_IMG_NAME));
            //QUEEN - DIAMONDS
            Card card5 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.QUEEN, CardsRank.QUEEN_IMG_NAME));
            //TEN - DIAMONDS
            Card card4 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.TEN, CardsRank.TEN_IMG_NAME));
            //JACK - DIAMONDS
            Card card1 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));

            List<Card> cardsHand = new List<Card>();
            cardsHand.Add(card1);
            cardsHand.Add(card2);
            cardsHand.Add(card3);
            cardsHand.Add(card4);
            cardsHand.Add(card5);

            int winCombination = _handAnalyzer.GetRank(cardsHand);
            int expectedWin = (int)HandRank.FLUSH;

            Assert.True(winCombination == expectedWin, "expected win combination = " + expectedWin + ", actual = " + winCombination);
        }

        [Test]
        public void TestGetRank_IsFullHouse_3Jecks2Tens()
        {
            //----Three same rank-----
            //JACK - CLUBS
            Card card1 = new Card(new Suit(Suit.CLUBS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));
            //JACK - SPADES
            Card card4 = new Card(new Suit(Suit.SPADES, Suit.SPADES_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));
            //JACK - HEARTS
            Card card2 = new Card(new Suit(Suit.HEARTS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));

            //----Pair---------------
            //TEN - HEARTS
            Card card5 = new Card(new Suit(Suit.CLUBS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.TEN, CardsRank.TEN_IMG_NAME));
            //TEN - HEARTS
            Card card3 = new Card(new Suit(Suit.HEARTS, Suit.HEARTS_IMG_NAME), new CardsRank(CardsRank.TEN, CardsRank.TEN_IMG_NAME));

            List<Card> cardsHand = new List<Card>();
            cardsHand.Add(card1);
            cardsHand.Add(card2);
            cardsHand.Add(card3);
            cardsHand.Add(card4);
            cardsHand.Add(card5);

            int winCombination = _handAnalyzer.GetRank(cardsHand);
            int expectedWin = (int)HandRank.FULL_HOUSE;

            Assert.True(winCombination == expectedWin, "expected win combination = " + expectedWin + ", actual = " + winCombination);
        }

        [Test]
        public void TestGetRank_IsFourOfKind_Jacks()
        {
            //JACK - CLUBS
            Card card1 = new Card(new Suit(Suit.CLUBS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));
            //JACK - SPADES
            Card card4 = new Card(new Suit(Suit.SPADES, Suit.SPADES_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));
            //JACK - HEARTS
            Card card2 = new Card(new Suit(Suit.HEARTS, Suit.CLUBS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));
            //JACK - DIAMONDS
            Card card5 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));
            
            //TEN - HEARTS
            Card card3 = new Card(new Suit(Suit.HEARTS, Suit.HEARTS_IMG_NAME), new CardsRank(CardsRank.TEN, CardsRank.TEN_IMG_NAME));

            List<Card> cardsHand = new List<Card>();
            cardsHand.Add(card1);
            cardsHand.Add(card2);
            cardsHand.Add(card3);
            cardsHand.Add(card4);
            cardsHand.Add(card5);

            int winCombination = _handAnalyzer.GetRank(cardsHand);
            int expectedWin = (int)HandRank.FOUR_OF_A_KIND;

            Assert.True(winCombination == expectedWin, "expected win combination = " + expectedWin + ", actual = " + winCombination);
        }

        [Test]
        public void TestGetRank_IsStraightFlush_6High()
        {
            //Five consecutive cards up to king high of the same suit.
            //TWO - DIAMONDS
            Card card2 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.TWO, CardsRank.TWO_IMG_NAME));
            //THREE - DIAMONDS
            Card card3 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.THREE, CardsRank.THREE_IMG_NAME));
            //FOUR - DIAMONDS
            Card card5 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.FOUR, CardsRank.FOUR_IMG_NAME));
            //FIVE - DIAMONDS
            Card card4 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.FIVE, CardsRank.FIVE_IMG_NAME));
            //SIX - DIAMONDS
            Card card1 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.SIX, CardsRank.SIX_IMG_NAME));

            List<Card> cardsHand = new List<Card>();
            cardsHand.Add(card1);
            cardsHand.Add(card2);
            cardsHand.Add(card3);
            cardsHand.Add(card4);
            cardsHand.Add(card5);

            int winCombination = _handAnalyzer.GetRank(cardsHand);
            int expectedWin = (int)HandRank.STRAIGHT_FLUSH;

            Assert.True(winCombination == expectedWin, "expected win combination = " + expectedWin + ", actual = " + winCombination);
        }

        [Test]
        public void TestGetRank_IsStraightFlush_KingHigh()
        {
            //Five consecutive cards up to king high of the same suit.
            //NINE - DIAMONDS
            Card card2 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.NINE, CardsRank.NINE_IMG_NAME));
            //TEN - DIAMONDS
            Card card3 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.TEN, CardsRank.TEN_IMG_NAME));
            //JACK - DIAMONDS
            Card card5 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));
            //QUEEN - DIAMONDS
            Card card4 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.QUEEN, CardsRank.QUEEN_IMG_NAME));
            //KING - DIAMONDS
            Card card1 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.KING, CardsRank.KING_IMG_NAME));

            List<Card> cardsHand = new List<Card>();
            cardsHand.Add(card1);
            cardsHand.Add(card2);
            cardsHand.Add(card3);
            cardsHand.Add(card4);
            cardsHand.Add(card5);

            int winCombination = _handAnalyzer.GetRank(cardsHand);
            int expectedWin = (int)HandRank.STRAIGHT_FLUSH;

            Assert.True(winCombination == expectedWin, "expected win combination = " + expectedWin + ", actual = " + winCombination);
        }

        [Test]
        public void TestGetRank_IsRoyalFlush()
        {
            //Five consecutive cards up to king high of the same suit.
            //TEN - DIAMONDS
            Card card3 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.TEN, CardsRank.TEN_IMG_NAME));
            //JACK - DIAMONDS
            Card card5 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));
            //QUEEN - DIAMONDS
            Card card4 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.QUEEN, CardsRank.QUEEN_IMG_NAME));
            //KING - DIAMONDS
            Card card1 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.KING, CardsRank.KING_IMG_NAME));
            //ACE - DIAMONDS
            Card card2 = new Card(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME), new CardsRank(CardsRank.ACE, CardsRank.ACE_IMG_NAME));

            List<Card> cardsHand = new List<Card>();
            cardsHand.Add(card1);
            cardsHand.Add(card2);
            cardsHand.Add(card3);
            cardsHand.Add(card4);
            cardsHand.Add(card5);

            int winCombination = _handAnalyzer.GetRank(cardsHand);
            int expectedWin = (int)HandRank.ROYAL_FLUSH;

            Assert.True(winCombination == expectedWin, "expected win combination = " + expectedWin + ", actual = " + winCombination);
        }


        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator HandAnalyzerTestWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}

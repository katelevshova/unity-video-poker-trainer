
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardsDeck 
{
    private static string CLASS_NAME = typeof(CardsDeck).ToString();

    public static CardsDeck _instance = null;

    public List<Card> cardsList;
    public List<CardsRank> rankList;
    public List<Suit> suitList;

    public const int DECK_SIZE = 52;

    private CardsDeck()
    {
        InitRankList();
        InitSuitList();
        InitAllCards();
        Shuffle();
    }

    public static CardsDeck Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CardsDeck();
            }
            return _instance;
        }
    }

    private void InitSuitList()
    {
        suitList = new List<Suit>();

        suitList.Add(new Suit(Suit.CLUBS, Suit.CLUBS_IMG_NAME));
        suitList.Add(new Suit(Suit.SPADES, Suit.SPADES_IMG_NAME));
        suitList.Add(new Suit(Suit.HEARTS, Suit.HEARTS_IMG_NAME));
        suitList.Add(new Suit(Suit.DIAMONDS, Suit.DIAMONDS_IMG_NAME));

        DebugUtil.Instance.PrintD(CLASS_NAME, "InitSuitList", "-------------------------------------------------------------");
        foreach (Suit suit in suitList)
        {
            DebugUtil.Instance.PrintD(CLASS_NAME, "InitSuitList", "suit.name= " + suit.name + ", suit.imgName= " + suit.imgName);
        }
    }

    private void InitRankList()
    {
        rankList = new List<CardsRank>();

        rankList.Add(new CardsRank(CardsRank.ACE, CardsRank.ACE_IMG_NAME));
        rankList.Add(new CardsRank(CardsRank.TWO, CardsRank.TWO_IMG_NAME));
        rankList.Add(new CardsRank(CardsRank.THREE, CardsRank.THREE_IMG_NAME));
        rankList.Add(new CardsRank(CardsRank.FOUR, CardsRank.FOUR_IMG_NAME));
        rankList.Add(new CardsRank(CardsRank.FIVE, CardsRank.FIVE_IMG_NAME));
        rankList.Add(new CardsRank(CardsRank.SIX, CardsRank.SIX_IMG_NAME));
        rankList.Add(new CardsRank(CardsRank.SEVEN, CardsRank.SEVEN_IMG_NAME));
        rankList.Add(new CardsRank(CardsRank.EIGHT, CardsRank.EIGHT_IMG_NAME));
        rankList.Add(new CardsRank(CardsRank.NINE, CardsRank.NINE_IMG_NAME));
        rankList.Add(new CardsRank(CardsRank.TEN, CardsRank.TEN_IMG_NAME));
        rankList.Add(new CardsRank(CardsRank.JACK, CardsRank.JACK_IMG_NAME));
        rankList.Add(new CardsRank(CardsRank.QUEEN, CardsRank.QUEEN_IMG_NAME));
        rankList.Add(new CardsRank(CardsRank.KING, CardsRank.KING_IMG_NAME));

        DebugUtil.Instance.PrintD(CLASS_NAME, "InitRankList", "-------------------------------------------------------------");
        foreach (CardsRank rank in rankList)
        {
            DebugUtil.Instance.PrintD(CLASS_NAME, "InitRankList", "rank.name= " + rank.name + ", rank.imgName= " + rank.imgName + ", rank._value= " + rank.Value());
        }
    }

    private void InitAllCards()
    {
        cardsList = new List<Card>();

        int amount = 1;

        DebugUtil.Instance.PrintD(CLASS_NAME, "InitAllCards", "-------------------------------------------------------------");

        foreach (Suit suit in suitList)
        {
            foreach (CardsRank rank in rankList)
            {
                Card card = new Card(suit, rank);
                card.id = amount;
                cardsList.Add(card);
                DebugUtil.Instance.PrintD(CLASS_NAME, "InitAllCards", card.ToString());

                amount++;
            }
        }

        if(amount < DECK_SIZE -1)
        {
            throw new Exception("There must be 52 cards in a deck! check InitRankList and InitSuitList  ");
        }
    }

    public void Shuffle()
    {
        for (int i = 0; i < DECK_SIZE; i++)
        {
            Card temp = cardsList[i];
            int randomIndex = Random.Range(i, cardsList.Count);
            cardsList[i] = cardsList[randomIndex];
            cardsList[randomIndex] = temp;
        }

        foreach(Card card in cardsList)
        {
            DebugUtil.Instance.PrintD(CLASS_NAME, "Shuffle", "imgFileName= " + card.imgFileName);
        }
    }

    public List<Card> Deal(int dealSize)
    {
        List<Card> returnCards = new List<Card>();

        for (int i = 0; i < dealSize; i++)
        {
            Card card = cardsList[i];
            returnCards.Add(card);
            cardsList.RemoveAt(i);
        }
        return returnCards;
    }

    public Card GetNewCard()
    {
        Card newCard = cardsList[0];
        cardsList.RemoveAt(0);

        return newCard;
    }

    public void PrintCards(List<Card> cards)
    {
        DebugUtil.Instance.PrintD(CLASS_NAME, "PrintCards", "_______________________________");

        foreach (Card card in cards)
        {
            DebugUtil.Instance.PrintD(CLASS_NAME, "PrintCards", card.ToString());
        }
    }

    public List<Card> GetCopy(List<Card> cards)
    {
        List<Card> copy = new List<Card>();

        foreach (var card in cards)
        {
            copy.Add((Card)card.Clone());
        }

        return copy;
    }

    public List<Card> GetReplacedHand(List<Card> cards)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            if (!cards[i].isHeld)
            {
                Card newCard = GameManagerScript.Instance.cardsDeck.GetNewCard();
                DebugUtil.Instance.PrintD(CLASS_NAME, "GetReplacedHand", "replacing CARD " + cards[i].imgFileName + " by NEW CARD " + newCard.imgFileName);
                cards[i] = newCard;
            }
        }

        return cards;
    }
}

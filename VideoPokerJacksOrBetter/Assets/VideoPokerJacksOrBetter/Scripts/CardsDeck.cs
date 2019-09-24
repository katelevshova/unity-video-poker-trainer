
using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardsDeck : MonoBehaviour
{
    private static string CLASS_NAME = typeof(CardsDeck).ToString();
    public List<Card> cardsList;
    public List<Rank> rankList;
    public List<Suit> suitList;

    public const int DECK_SIZE = 52;


    // Start is called before the first frame update
    void Start()
    {
        InitRankList();
        InitSuitList();
        InitAllCards();
        Shuffle();
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
        rankList = new List<Rank>();

        rankList.Add(new Rank(Rank.ACE, Rank.ACE_IMG_NAME));
        rankList.Add(new Rank(Rank.TWO, Rank.TWO_IMG_NAME));
        rankList.Add(new Rank(Rank.THREE, Rank.THREE_IMG_NAME));
        rankList.Add(new Rank(Rank.FOUR, Rank.FOUR_IMG_NAME));
        rankList.Add(new Rank(Rank.FIVE, Rank.FIVE_IMG_NAME));
        rankList.Add(new Rank(Rank.SIX, Rank.SIX_IMG_NAME));
        rankList.Add(new Rank(Rank.SEVEN, Rank.SEVEN_IMG_NAME));
        rankList.Add(new Rank(Rank.EIGHT, Rank.EIGHT_IMG_NAME));
        rankList.Add(new Rank(Rank.NINE, Rank.NINE_IMG_NAME));
        rankList.Add(new Rank(Rank.TEN, Rank.TEN_IMG_NAME));
        rankList.Add(new Rank(Rank.JACK, Rank.JACK_IMG_NAME));
        rankList.Add(new Rank(Rank.QUEEN, Rank.QUEEN_IMG_NAME));
        rankList.Add(new Rank(Rank.KING, Rank.KING_IMG_NAME));

        DebugUtil.Instance.PrintD(CLASS_NAME, "InitRankList", "-------------------------------------------------------------");
        foreach (Rank rank in rankList)
        {
            DebugUtil.Instance.PrintD(CLASS_NAME, "InitRankList", "rank.name= " + rank.name + ", rank.imgName= " + rank.imgName);
        }
    }

    private void InitAllCards()
    {
        cardsList = new List<Card>();

        int amount = 1;

        DebugUtil.Instance.PrintD(CLASS_NAME, "InitAllCards", "-------------------------------------------------------------");

        foreach (Suit suit in suitList)
        {
            foreach (Rank rank in rankList)
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
 }

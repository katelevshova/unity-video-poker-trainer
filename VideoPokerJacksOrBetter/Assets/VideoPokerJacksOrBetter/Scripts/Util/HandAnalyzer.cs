using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnalyzer
{
    private static string CLASS_NAME = typeof(HandAnalyzer).ToString();
    public const int LOSE_HAND = -1;

    private bool isHandFormStraight = false;
    private bool isHandFormFlush = false;

    private List<Card> cardsHand;
    private List<Card> copyHand;

    private Dictionary<int, int> sameRankStats;

    public int GetRank(List<Card> cards)
    {
        cardsHand = cards;

        //COPY and SORT
        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "PRINT SCREEN HAND ");
        CardsDeck.Instance.PrintCards(cardsHand);

        copyHand = CardsDeck.Instance.GetCopy(cardsHand);
        copyHand.Sort();

        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "PRINT SORTED HAND ");
        CardsDeck.Instance.PrintCards(copyHand);

        //ROYAL_FLUSH
        bool isRoyalFlush = IsRoyalFlush();
        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "for ROYAL_FLUSH= " + isRoyalFlush);
        if (isRoyalFlush)
            return (int)HandRank.ROYAL_FLUSH;

        //STRAIGHT_FLUSH
        bool isStraightFlush = IsStraightFlush();
        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "for STRAIGHT_FLUSH= " + isStraightFlush);
        if (isStraightFlush)
            return (int)HandRank.STRAIGHT_FLUSH;

        sameRankStats = new Dictionary<int, int>(); //example: key= rank.value, value= 3 - simple counter

        //FOUR_OF_A_KIND
        bool isFourOfKind = IsFourOfAKind();
        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "for FOUR_OF_A_KIND= " + isFourOfKind);
        if (isFourOfKind)
            return (int)HandRank.FOUR_OF_A_KIND;

        //FULL_HOUSE
        // check if had "three of a kind" and a pair
        bool isFullHouse = (sameRankStats.ContainsValue(3) && sameRankStats.ContainsValue(2));
        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "for FULL_HOUSE= " + isFullHouse);
        if (isFullHouse)
            return (int)HandRank.FULL_HOUSE;

        //FLUSH
        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "for FLUSH= " + isHandFormFlush);
        if (isHandFormFlush)
            return (int)HandRank.FLUSH;

        //STRAIGHT
        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "for STRAIGHT= " + isHandFormStraight);
        if (isHandFormStraight)
            return (int)HandRank.STRAIGHT;

        //THREE_OF_A_KIND
        //Three cards of one kind (same rank) and two other cards different rank
        bool isThreeOfKind = (sameRankStats.ContainsValue(3));
        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "for THREE_OF_A_KIND= " + isThreeOfKind);
        if (isThreeOfKind)
            return (int)HandRank.THREE_OF_A_KIND;

        //TWO_PAIR
        bool isTwoPair = IsTwoPair();
        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "for TWO_PAIR= " + isTwoPair);
        if (isTwoPair)
            return (int)HandRank.TWO_PAIR;

        //JACKS_OR_BETTER
        bool isJacksOrBetter = IsJacksOrBetter();
        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "for JACKS_OR_BETTER= " + isJacksOrBetter);
        if (isJacksOrBetter)
            return (int)HandRank.JACKS_OR_BETTER;

        return -1; // Return ID of winning hand combination, or - 1 if losing 
    }

    /**
     * The best possible hand. Consists of Ten, Jack, Queen, King and Ace of the same suit.
     * (ace-high straight of one suit)
     */
    private bool IsRoyalFlush ()
    {
        //1. CHECK if 5 cards of the same suit - check flush

        isHandFormFlush = IsFlush();

        if (!isHandFormFlush)
            return false;

        //3. CHECK if form straight for sorted hand
        isHandFormStraight = IsStraight();

        if (!isHandFormStraight)
            return false;

        //4. CHECK if last card is ACE for sorted hand
        bool isAce = (copyHand[copyHand.Count-1].rank.Id() == (int)CardsRank.IDs.Ace);

        return (isHandFormFlush && isHandFormStraight && isAce);
    }

    /*
     * Five consecutive cards up to king high of the same suit.
     */
    private bool IsStraightFlush()
    {
        //1. CHECK if 5 cards of the same suit - check flush

        isHandFormFlush = IsFlush();

        if (!isHandFormFlush)
            return false;

        //3. CHECK if form straight for sorted hand
        isHandFormStraight = IsStraight();

        if (!isHandFormStraight)
            return false;

        //4. CHECK if last card IS NOT ACE for sorted hand
        bool isNotAce = (copyHand[copyHand.Count - 1].rank.Id() != (int)CardsRank.IDs.Ace);

        return (isHandFormFlush && isHandFormStraight && isNotAce);

    }

    /*
     * Four cards of the same value (same rank).
     */
    private bool IsFourOfAKind()
    {
        /*
        sameRankCounter = 0;

        //use sorted hand, Q-Q-Q-Q-A or 2-10-10-10-10
        for (int i = 0; i < copyHand.Count; i++)
        {
            if (i != copyHand.Count - 1)
            {
                if (copyHand[i].rank.Value() == copyHand[i + 1].rank.Value())
                {
                    sameRankCounter++;
                }
            }
        }

        return (sameRankCounter == 4); */


        foreach (Card card in copyHand)
        {
            if (sameRankStats.ContainsKey(card.rank.Value()))
            {
                sameRankStats[card.rank.Value()] += 1; 
            }
            else
            {
                sameRankStats.Add(card.rank.Value(), 1);
            }
        }

        return sameRankStats.ContainsValue(4);
    }

    /*
     * Any five cards of the same suit.
     */
    private bool IsFlush()
    {
        for (int i = 0; i < copyHand.Count; i++)
        {
            if (i != copyHand.Count - 1)
            {
                if(copyHand[i].suit.name != copyHand[i+1].suit.name)
                {
                    return false;
                }
            }
        }
        return true;
    }

    /*
     * Five consecutive cards (7-8-9-10-Jack) of any mixed suits
     */
    private bool IsStraight()
    {
        // use sorted copy
        for (int i = 0; i < copyHand.Count; i++)
        {
            if (i != copyHand.Count - 1)
            {
                if (copyHand[i].rank.Value() != copyHand[i + 1].rank.Value() - 1)
                {
                    return false;
                }
            }
        }
        return true;
    }

    /*
     *  Two cards of one rank and another two cards of one rank (for example, 3-3 and 6-6).
     */
    private bool IsTwoPair()
    {
        int counterTwoes = 0;
        foreach (var item in sameRankStats)
        {
            if(item.Value == 2)
            {
                counterTwoes++;
            }
        }

        return (counterTwoes == 2);
    }

    /*
     * Often the lowest paying hand. Any single pair that is jacks or higher wins
     * (Jack-Jack, Queen-Queen, King-King, Ace-Ace).
     */
    private bool IsJacksOrBetter()
    {
        foreach (var item in sameRankStats)
        {
            if (item.Value == 2 && item.Key >= (int)CardsRank.Values.Jack)
                return true;
        }

        return false;
    }

 }

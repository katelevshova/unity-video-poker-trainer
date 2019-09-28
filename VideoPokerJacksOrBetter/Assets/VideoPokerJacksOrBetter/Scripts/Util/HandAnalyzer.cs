using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnalyzer
{
    private static string CLASS_NAME = typeof(HandAnalyzer).ToString();
    public const int LOSE_HAND = -1;

    private static bool isHandFormStraight = false;
    private static bool isHandFormFlush = false;

    private static List<Card> cardsHand;
    private static List<Card> copyHand;

    public static int GetRank(List<Card> cards)
    {
        cardsHand = cards;

        //COPY and SORT
        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "PRINT SCREEN HAND ");
        CardsDeck.PrintCards(cardsHand);

        copyHand = CardsDeck.GetCopy(cardsHand);
        copyHand.Sort();

        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "PRINT SORTED HAND ");
        CardsDeck.PrintCards(copyHand);

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

        //FOUR_OF_A_KIND
        bool isFourOfKind = IsFourOfAKind();
        DebugUtil.Instance.PrintD(CLASS_NAME, "GetRank", "for FOUR_OF_A_KIND= " + isFourOfKind);

        if (isFourOfKind)
            return (int)HandRank.FOUR_OF_A_KIND;

        //FULL_HOUSE

        return -1; // Return ID of winning hand combination, or - 1 if losing 
    }

    /**
     * The best possible hand. Consists of Ten, Jack, Queen, King and Ace of the same suit.
     * (ace-high straight of one suit)
     */
    private static bool IsRoyalFlush ()
    {
        //1. CHECK if 5 cards of the same suit - check flush

        isHandFormFlush = isFlush();

        if (!isHandFormFlush)
            return false;

        //3. CHECK if form straight for sorted hand
        isHandFormStraight = isStraight();

        if (!isHandFormStraight)
            return false;

        //4. CHECK if last card is ACE for sorted hand
        bool isAce = (copyHand[copyHand.Count-1].rank.Id() == (int)CardsRank.IDs.Ace);


        return (isHandFormFlush && isHandFormStraight && isAce);
    }


    /*
     * Five consecutive cards up to king high of the same suit.
     */
    private static bool IsStraightFlush()
    {
        //1. CHECK if 5 cards of the same suit - check flush

        isHandFormFlush = isFlush();

        if (!isHandFormFlush)
            return false;

        //3. CHECK if form straight for sorted hand
        isHandFormStraight = isStraight();

        if (!isHandFormStraight)
            return false;

        //4. CHECK if last card IS NOT ACE for sorted hand
        bool isNotAce = (copyHand[copyHand.Count - 1].rank.Id() != (int)CardsRank.IDs.Ace);

        return (isHandFormFlush && isHandFormStraight && isNotAce);

    }

    /*
     * Four cards of the same value (same rank).
     */
    private static bool IsFourOfAKind()
    {
        int counter = 0;

        //use sorted hand, Q-Q-Q-Q-A or 2-10-10-10-10
        for (int i = 0; i < copyHand.Count; i++)
        {
            if (i != copyHand.Count - 1)
            {
                if (copyHand[i].rank.Value() == copyHand[i + 1].rank.Value())
                {
                    counter++;
                }
            }
        }

        return (counter == 4);
    }

    /*
     * Three of a kind and one pair.
     */
    private static int CheckFullHouse()
    {
        return (int)HandRank.FULL_HOUSE;
    }

    /*
     * Any five cards of the same suit.
     */
    private static bool isFlush()
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
    private static bool isStraight()
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
     *  Three cards of one kind (same rank) and two other cards different rank
     */
    private static int CheckThreeOfAKind()
    {
        return (int)HandRank.THREE_OF_A_KIND;
    }

    /*
     *  Two cards of one rank and another two cards of one rank (for example, 3-3 and 6-6).
     */
    private static int CheckTwoPair()
    {
        return (int)HandRank.TWO_PAIR;
    }

    /*
     * Often the lowest paying hand. Any single pair that is jacks or higher wins
     * (Jack-Jack, Queen-Queen, King-King, Ace-Ace).
     */
    private static int CheckJacksOrBetter()
    {
        return (int)HandRank.JACKS_OR_BETTER;
    }
 }

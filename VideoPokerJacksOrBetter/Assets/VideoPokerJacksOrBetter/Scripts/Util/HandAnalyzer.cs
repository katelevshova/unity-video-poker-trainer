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

    public static int GetRank(List<Card> cards)
    {
        cardsHand = cards;

        isRoyalFlush();

        return -1; // Return ID of winning hand combination, or - 1 if losing 
    }

    /**
     * The best possible hand. Consists of Ten, Jack, Queen, King and Ace of the same suit.
     * (ace-high straight of one suit)
     */
    private static bool isRoyalFlush ()
    {
        //1. CHECK if 5 cards of the same suit - check flush

        isHandFormFlush = isFlush();

        if (!isHandFormFlush)
            return false;

        //2. SORT
        DebugUtil.Instance.PrintD(CLASS_NAME, "isRoyalFlush", "PRINT SCREEN HAND ");
        CardsDeck.PrintCards(cardsHand);

        List<Card> copiedHand = CardsDeck.GetCopy(cardsHand);
        copiedHand.Sort();

        DebugUtil.Instance.PrintD(CLASS_NAME, "isRoyalFlush", "PRINT SORTED HAND ");
        CardsDeck.PrintCards(copiedHand);

        //3. CHECK if form straight
        isHandFormStraight = isStraight();

        if (!isHandFormStraight)
            return false;

        //4. CHECK if last card is ACE
        bool isAce = (copiedHand[copiedHand.Count-1].rank.Id() == (int)CardsRank.IDs.Ace);


        return (isHandFormFlush && isHandFormStraight && isAce);
    }


    /*
     * Five consecutive cards up to king high of the same suit.
     */
    private static int StraightFlush()
    {
        return (int)HandRank.STRAIGHT_FLUSH;
    }

    /*
     * Four cards of the same value (same rank).
     */
    private static int CheckFourOfAKind()
    {
        return (int)HandRank.FOUR_OF_A_KIND;
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
        for (int i = 0; i < cardsHand.Count; i++)
        {
            if (i != cardsHand.Count - 1)
            {
                if(cardsHand[i].suit.name != cardsHand[i+1].suit.name)
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

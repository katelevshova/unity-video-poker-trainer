using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnalyzer
{
    public static int GetRank(List<Card> cards)
    {


        return -1; // Return ID of winning hand combination, or - 1 if losing 
    }

    /**
     * The best possible hand. Consists of Ten, Jack, Queen, King and Ace of the same suit.
     * (ace-high straight of one suit)
     */
    private static int CheckRoyalFlush ()
    {
        return (int)HandRank.ROYAL_FLUSH;
    }

    /*
     * Five consecutive cards up to king high of the same suit.
     */
    private static int CheckStraightFlush()
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
    private static int CheckFlush()
    {
        return (int)HandRank.FLUSH;
    }

    /*
     * Five consecutive cards (7-8-9-10-Jack) of any mixed suits
     */
    private static int CheckStraight()
    {
        return (int)HandRank.STRAIGHT;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnalyzer
{
    static int GetRank(List<Card> cards)
    {


        return -1; // Return ID of winning hand combination, or - 1 if losing 
    }

    /**
     * The best possible hand. Consists of Ten, Jack, Queen, King and Ace of the same suit.
     * (ace-high straight of one suit)
     */
    private static bool IsRoyalFlush ()
    {
        return true;
    }

    /*
     * Five consecutive cards up to king high of the same suit.
     */
    private static bool IsStraightFlush()
    {
        return true;
    }

    /*
     * Four cards of the same value (same rank).
     */
    private static bool IsFourOfAKind()
    {
        return true;
    }

    /*
     * Three of a kind and one pair.
     */
    private static bool IsFullHouse()
    {
        return true;
    }

    /*
     * Any five cards of the same suit.
     */
    private static bool IsFlush()
    {
        return true;
    }

    /*
     * Five consecutive cards (7-8-9-10-Jack) of any mixed suits
     */
    private static bool IsStraight()
    {
        return true;
    }

    /*
     *  Three cards of one kind (same rank) and two other cards different rank
     */
    private static bool IsThreeOfAKind()
    {
        return true;
    }

    /*
     *  Two cards of one rank and another two cards of one rank (for example, 3-3 and 6-6).
     */
    private static bool IsTwoPair()
    {
        return true;
    }

    /*
     * Often the lowest paying hand. Any single pair that is jacks or higher wins
     * (Jack-Jack, Queen-Queen, King-King, Ace-Ace).
     */
    private static bool IsJacksOrBetter()
    {
        return true;
    }
 }

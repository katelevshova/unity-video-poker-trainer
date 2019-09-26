using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayoutTableModel
{
    private static string CLASS_NAME = typeof(GameManagerScript).ToString();
    public Dictionary<int, PayoutRow> payouts;

    public PayoutTableModel()
    {
        DebugUtil.Instance.PrintD(CLASS_NAME, "Constructor");

        payouts = new Dictionary<int, PayoutRow>();


        PayoutRow royalFlush = new PayoutRow(HandNameConstants.ROYAL_FLUSH, 250, 500, 750, 1000, 4000);
        payouts.Add(1, royalFlush);

        PayoutRow straightFlush = new PayoutRow(HandNameConstants.STRAIGHT_FLUSH, 50, 100, 150, 200, 250);
        payouts.Add(2, straightFlush);

        PayoutRow fourOfKind = new PayoutRow(HandNameConstants.FOUR_OF_A_KIND, 25, 50, 75, 100, 125);
        payouts.Add(3, fourOfKind);

        PayoutRow fullHouse = new PayoutRow(HandNameConstants.FULL_HOUSE, 9, 18, 27, 36, 45);
        payouts.Add(4, fullHouse);

        PayoutRow flush = new PayoutRow(HandNameConstants.FLUSH, 6, 12, 18, 24, 30);
        payouts.Add(5, flush);

        PayoutRow straight = new PayoutRow(HandNameConstants.STRAIGHT, 4, 8, 12, 16, 20);
        payouts.Add(6, straight);

        PayoutRow threeOfKind = new PayoutRow(HandNameConstants.THREE_OF_A_KIND, 3, 6, 9, 12, 15);
        payouts.Add(7, threeOfKind);

        PayoutRow twoPair = new PayoutRow(HandNameConstants.TWO_PAIR, 2, 4, 6, 8, 10);
        payouts.Add(8, twoPair);

        PayoutRow jacksOrBetter = new PayoutRow(HandNameConstants.JACKS_OR_BETTER, 1, 2, 3, 4, 5);
        payouts.Add(9, jacksOrBetter);
    }
}

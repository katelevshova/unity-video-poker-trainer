using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayoutTableModel
{
    private static string CLASS_NAME = typeof(GameManagerScript).ToString();
    public Dictionary<string, PayoutRow> payouts;

    public PayoutTableModel()
    {
        DebugUtil.Instance.PrintD(CLASS_NAME, "Constructor");

        payouts = new Dictionary<string, PayoutRow>();


        PayoutRow royalFlush = new PayoutRow(250, 500, 750, 1000, 4000);
        payouts.Add(HandNameConstants.ROYAL_FLUSH, royalFlush);

        PayoutRow straightFlush = new PayoutRow(50, 100, 150, 200, 250);
        payouts.Add(HandNameConstants.STRAIGHT_FLUSH, straightFlush);

        PayoutRow fourOfKind = new PayoutRow(25, 50, 75, 100, 125);
        payouts.Add(HandNameConstants.FOUR_OF_A_KIND, fourOfKind);

        PayoutRow fullHouse = new PayoutRow(9, 18, 27, 36, 45);
        payouts.Add(HandNameConstants.FULL_HOUSE, fullHouse);

        PayoutRow flush = new PayoutRow(6, 12, 18, 24, 30);
        payouts.Add(HandNameConstants.FLUSH, flush);

        PayoutRow straight = new PayoutRow(4, 8, 12, 16, 20);
        payouts.Add(HandNameConstants.STRAIGHT, straight);

        PayoutRow threeOfKind = new PayoutRow(3, 6, 9, 12, 15);
        payouts.Add(HandNameConstants.THREE_OF_A_KIND, threeOfKind);

        PayoutRow twoPair = new PayoutRow(2, 4, 6, 8, 10);
        payouts.Add(HandNameConstants.TWO_PAIR, twoPair);

        PayoutRow jacksOrBetter = new PayoutRow(1, 2, 3, 4, 5);
        payouts.Add(HandNameConstants.JACKS_OR_BETTER, jacksOrBetter);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceInfo : MonoBehaviour
{
    public const int CREDITS_START_AMOUNT = 100;
    public const int BET_MAX = 5;

    public int creditsAmount = CREDITS_START_AMOUNT;
    public int winLossAmount = 0;
    public int betAmount = BET_MAX;

    public TMPro.TextMeshProUGUI txtCreditsValue;
    public TMPro.TextMeshProUGUI txtWinLossValue;
    public TMPro.TextMeshProUGUI txtBetValue;
    
    public void UpdateBalanceInfoFirstDeal()
    {
        creditsAmount = creditsAmount - betAmount;
        UpdateTextFiledInfo();
    }

    public void UpdateBalanceInfoWin()
    {
        creditsAmount = creditsAmount + winLossAmount;
        UpdateTextFiledInfo();
    }

    public void UpdateTextFiledInfo()
    {
        txtCreditsValue.text = creditsAmount.ToString();
        txtWinLossValue.text = winLossAmount.ToString();
        txtBetValue.text = betAmount.ToString();
    }
}

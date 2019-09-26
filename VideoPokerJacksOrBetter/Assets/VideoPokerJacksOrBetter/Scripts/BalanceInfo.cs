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
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateBalanceInfo()
    {
        creditsAmount = creditsAmount + winLossAmount - betAmount;
        UpdateTextFiledInfo();
    }

    public void UpdateTextFiledInfo()
    {
        txtCreditsValue.text = creditsAmount.ToString();
        txtWinLossValue.text = winLossAmount.ToString();
        txtBetValue.text = betAmount.ToString();
    }
}

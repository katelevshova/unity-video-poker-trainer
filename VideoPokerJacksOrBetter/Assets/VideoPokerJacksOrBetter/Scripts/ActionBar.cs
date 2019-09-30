using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    private static string CLASS_NAME = typeof(ActionBar).ToString();
    public Button btnDeal;
    public Button btnAddBet;
    public Button btnRemoveBet;
    [SerializeField]
    private TMPro.TextMeshProUGUI txtBet;

    // Start is called before the first frame update
    void Start()
    {
        if (btnDeal == null)
        {
            throw new Exception("Initialize btnDeal, drag it from Hierarchy window");
        }

        if (btnAddBet == null)
        {
            throw new Exception("Initialize btnAddBet, drag it from Hierarchy window");
        }

        if (btnRemoveBet == null)
        {
            throw new Exception("Initialize btnRemoveBet, drag it from Hierarchy window");
        }

        if (txtBet == null)
        {
            throw new Exception("Initialize txtBet, drag it from Hierarchy window");
        }

        SetBet(GameManagerScript.Instance.balanceInfo.betAmount);
    }

    public void AddBetBtn_OnCLick_Handler()
    {
        if(GameManagerScript.Instance.balanceInfo.betAmount < BalanceInfo.BET_MAX)
        {
            GameManagerScript.Instance.balanceInfo.betAmount++;
            SetBet(GameManagerScript.Instance.balanceInfo.betAmount);
            GameManagerScript.Instance.balanceInfo.UpdateTextFiledInfo();
        }
        DebugConsole.Instance.PrintD(CLASS_NAME, "AddBetBtn_OnCLick_Handler", "betAmount=" + GameManagerScript.Instance.balanceInfo.betAmount);
    }

    public void RemoveBetBtn_OnCLick_Handler()
    {
        if (GameManagerScript.Instance.balanceInfo.betAmount > 1)
        {
            GameManagerScript.Instance.balanceInfo.betAmount--;
            SetBet(GameManagerScript.Instance.balanceInfo.betAmount);
            GameManagerScript.Instance.balanceInfo.UpdateTextFiledInfo();
        }
        DebugConsole.Instance.PrintD(CLASS_NAME, "RemoveBetBtn_OnCLick_Handler", "betAmount=" + GameManagerScript.Instance.balanceInfo.betAmount);
    }

    public void SetBet(int bet)
    {
        txtBet.text = bet.ToString();
    }
}

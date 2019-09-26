using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance;
    private static string CLASS_NAME = typeof(GameManagerScript).ToString();

   
    public string gameState = GameStates.INIT;

    public PayoutTable payoutTable;
    public TMPro.TextMeshProUGUI txtMessage;
    public CardsContainer cardsContainer;
    public CardsDeck cardsDeck;
    public BalanceInfo balanceInfo;
    public ActionBar actionBar;
   

    public void Awake()
    {
        //This is a common approach to handling a class with a reference to itself.
        //If instance variable doesn't exist, assign this object to it
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        //Otherwise, if the instance variable does exist, but it isn't this object, destroy this object.
        //This is useful so that we cannot have more than one of this object in a scene at a time.
        else if (Instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DebugUtil.Instance.PrintD(CLASS_NAME, "Start");

        if (payoutTable == null)
        {
            throw new Exception("Initialize payoutTable, drag PayoutTable from Hierarchy window");
        }

        if (cardsContainer == null)
        {
            throw new Exception("Initialize cardsContainer, drag CardsContainer from Hierarchy window");
        }

        if (cardsDeck == null)
        {
            throw new Exception("Initialize cardsDeck, drag CardsDeck from Hierarchy window");
        }

        if (actionBar == null)
        {
            throw new Exception("Initialize actionBar, drag ActionBarVerticalLG from Hierarchy window");
        }

        if (txtMessage == null)
        {
            throw new Exception("Initialize txtMessage, drag it from Hierarchy window");
        }

        if (balanceInfo == null)
        {
            throw new Exception("Initialize balanceInfo, drag it from Hierarchy window");
        }

        UpdateGameState(GameStates.INIT);

    }

    public void UpdateGameState(string state)
    {
        gameState = state;

        switch(gameState)
        {
            case GameStates.INIT:
                DebugUtil.Instance.PrintD(CLASS_NAME, "UpdateGameState", "=============INIT=================");
                txtMessage.text = "Press DEAL button to START a game ";       // localize it later
                balanceInfo.UpdateTextFiledInfo();
                break;
            case GameStates.FIRST_DEAL:
                DebugUtil.Instance.PrintD(CLASS_NAME, "UpdateGameState", "=============FIRST_DEAL=================");
                List<Card> firstHand = cardsDeck.Deal(CardsContainer.HAND_SIZE);
                HandAnalyzer.GetRank(firstHand);
                cardsContainer.SetFullHand(firstHand, true);
                txtMessage.text = "Select any card to HOLD and make a second DEAL";
                balanceInfo.UpdateBalanceInfo();
                break;
        }
    }
   
    //START ----------- Button click handlers -------------------------------
    public void DealBtn_OnCLick_Handler()
    {
        DebugUtil.Instance.PrintD(CLASS_NAME, "DealBtn_OnCLick_Handler");
        UpdateGameState(GameStates.FIRST_DEAL);
    }
    //END ----------- Button click handlers -------------------------------
}

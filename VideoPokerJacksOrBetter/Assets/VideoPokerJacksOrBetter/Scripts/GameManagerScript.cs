using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
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
    public List<Card> currentHand;
    public int combinationRank = HandAnalyzer.LOSE_HAND;

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
        DebugConsole.Instance.PrintD(CLASS_NAME, "Start");

        if (payoutTable == null)
        {
            throw new Exception("Initialize payoutTable, drag PayoutTable from Hierarchy window");
        }

        if (cardsContainer == null)
        {
            throw new Exception("Initialize cardsContainer, drag CardsContainer from Hierarchy window");
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
                DebugConsole.Instance.PrintD(CLASS_NAME, "UpdateGameState", "=============INIT=================");
                cardsDeck = CardsDeck.Instance;
                txtMessage.text = "Press DEAL button to START a game ";       // localize it later
                balanceInfo.UpdateTextFiledInfo();
                break;
            case GameStates.FIRST_DEAL:
                DebugConsole.Instance.PrintD(CLASS_NAME, "UpdateGameState", "=============FIRST_DEAL=================");
                currentHand = new List<Card>();
                currentHand = cardsDeck.Deal(CardsContainer.HAND_SIZE);
                cardsContainer.SetFullHand(currentHand);
                txtMessage.text = "Select any card to HOLD and make a second DEAL";
                balanceInfo.UpdateBalanceInfoFirstDeal();
                break;
            case GameStates.SECOND_DEAL:
                DebugConsole.Instance.PrintD(CLASS_NAME, "UpdateGameState", "=============SECOND_DEAL=================");
                
                //get rank from a hand which includes held cards
                currentHand = cardsDeck.GetReplacedHand(currentHand);
                cardsContainer.UpdateCardsFaceSide(currentHand);
                cardsContainer.DisableAllCardButtons();
                HandAnalyzer handAnalyzer = new HandAnalyzer();
                combinationRank = handAnalyzer.GetRank(currentHand);
                if(combinationRank == HandAnalyzer.LOSE_HAND)
                    UpdateGameState(GameStates.LOST);
                else
                    UpdateGameState(GameStates.WIN);
                break;
            case GameStates.WIN:
                DebugConsole.Instance.PrintD(CLASS_NAME, "UpdateGameState", "=============WIN=================");
                txtMessage.text = "Congratulations! You won. Choose BET size and DEAL to start again.";
                balanceInfo.winLossAmount += payoutTable.GetPayout(combinationRank, balanceInfo.betAmount);
                balanceInfo.UpdateBalanceInfoWin();
                break;
            case GameStates.LOST:
                DebugConsole.Instance.PrintD(CLASS_NAME, "UpdateGameState", "=============LOST=================");
                //update txtMessage, win amount and credits
                txtMessage.text = "You lost your bet. Choose BET size and DEAL to start again.";
                break;
        }
    }
   
    //START ----------- Button click handlers -------------------------------
    public void DealBtn_OnCLick_Handler()
    {
        DebugConsole.Instance.PrintD(CLASS_NAME, "DealBtn_OnCLick_Handler");

        switch (gameState)
        {
            case GameStates.INIT:
                UpdateGameState(GameStates.FIRST_DEAL);
                break;
            case GameStates.FIRST_DEAL:
                UpdateGameState(GameStates.SECOND_DEAL);
                break;
            case GameStates.WIN:
            case GameStates.LOST:
                UpdateGameState(GameStates.FIRST_DEAL);
                break;
        }
    }

    public void DebugBtn_OnCLick_Handler()
    {
        DebugConsole.Instance.PrintD(CLASS_NAME, "DebugBtn_OnCLick_Handler");
        DebugConsole.Instance.SetConsoleVisivility();
    }
    //END ----------- Button click handlers -------------------------------
}

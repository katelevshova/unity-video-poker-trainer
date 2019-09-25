using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance;
    private static string CLASS_NAME = typeof(GameManagerScript).ToString();

    public const int CREDITS_START_AMOUNT = 100;
    public const int BET_MAX = 5;
    public int creditsCurrent = CREDITS_START_AMOUNT;
    public int betCurrent = BET_MAX;
    public PayoutTable payoutTable;
    public CardsContainer cardsContainer;
    public CardsDeck cardsDeck;
    public ActionBar actionBar;
    public string gameState = GameStates.INIT;

    public TMPro.TextMeshProUGUI txtMessage;

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

        UpdateGameState(GameStates.INIT);

    }

    public void UpdateGameState(string state)
    {
        gameState = state;

        switch(gameState)
        {
            case GameStates.INIT:
                Initialize();
                break;
            case GameStates.FIRST_DEAL:
                cardsContainer.SetFullHand(cardsDeck.Deal(CardsContainer.HAND_SIZE), true);
                txtMessage.text = "Select any card to HOLD and make a second DEAL";
                break;
        }
    }

    private void Initialize()
    {
        DebugUtil.Instance.PrintD(CLASS_NAME, "Initialize", "==============================");
        txtMessage.text = "Press DEAL button to START a game ";       // localize it later
    }

    //START ----------- Button click handlers -------------------------------
    public void DealBtn_OnCLick_Handler()
    {
        DebugUtil.Instance.PrintD(CLASS_NAME, "DealBtn_OnCLick_Handler");
        UpdateGameState(GameStates.FIRST_DEAL);
    }
    //END ----------- Button click handlers -------------------------------
}

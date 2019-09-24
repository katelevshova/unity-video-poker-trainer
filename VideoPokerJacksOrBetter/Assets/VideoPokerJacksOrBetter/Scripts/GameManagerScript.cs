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
    public string gameState = GameStates.INIT;

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
            DebugUtil.Instance.PrintD(CLASS_NAME, "Start", "Initialize payoutTable, drag PayoutTable from Hierarchy window");
            throw new Exception("Initialize payoutTable, drag PayoutTable from Hierarchy window");
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
        }
    }

    private void Initialize()
    {
        DebugUtil.Instance.PrintD(CLASS_NAME, "Initialize");
    }

}

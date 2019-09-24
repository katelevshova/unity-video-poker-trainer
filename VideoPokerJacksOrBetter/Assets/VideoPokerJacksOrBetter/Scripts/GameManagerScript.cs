using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance;
    private static string CLASS_NAME = typeof(GameManagerScript).ToString();

    public PayoutTable payoutTable;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

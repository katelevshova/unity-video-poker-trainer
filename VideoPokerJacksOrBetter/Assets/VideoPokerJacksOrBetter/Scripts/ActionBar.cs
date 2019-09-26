using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBar : MonoBehaviour
{
    public Button btnDeal;

    // Start is called before the first frame update
    void Start()
    {
        if (btnDeal == null)
        {
            throw new Exception("Initialize btnDeal, drag it from Hierarchy window");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

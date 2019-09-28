using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    private static string CLASS_NAME = typeof(CardButton).ToString();
    public string spriteName = ""; //card_back

    public Card card;
    private Image image;
    private Button button;
    private TMPro.TextMeshProUGUI txtHold;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] allTransforms = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in allTransforms)
        {
            if (child.gameObject.name == "Button")
            {
                image = child.gameObject.GetComponent<Image>();
                button = child.gameObject.GetComponent<Button>();
            }
            if (child.gameObject.name == "txtHold")
            {
                txtHold = child.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            }
        }

        txtHold.text = "";
        SetEnableButton(false);
        
    }
    
    //TODO: remove possible not necessary parameter
    public void ShowFaceSide(Boolean flag)
    {
        //if(flag)
       // {
            card.isFaceSide = true;

            Sprite sprite = Resources.Load<Sprite>("Sprites/Cards/" + card.imgFileName);
            image.sprite = sprite;
            DebugUtil.Instance.PrintD(CLASS_NAME, "ShowFaceSide", "spriteName= " + image.sprite.name);

            txtHold.text = "";
            SetEnableButton(true);
       // }

    }

    public void CardBtn_OnCLick_Handler()
    {
        DebugUtil.Instance.PrintD(CLASS_NAME, "CardBtn_OnCLick_Handler", "gameState= " + GameManagerScript.Instance.gameState);

        if(GameManagerScript.Instance.gameState == GameStates.FIRST_DEAL)
        {
            //TODO: hold a card here
            txtHold.text = "HOLD";
            SetEnableButton(false);
        }

        /*
        switch (GameManagerScript.Instance.gameState)
        {
            case GameStates.FIRST_DEAL:
                //TODO: hold a card here
                txtHold.text = "HOLD";
                break;
           case GameStates.SECOND_DEAL:
            case GameStates.WIN:
            case GameStates.LOST:
                SetEnableButton(false);   
                break;    
        }
    */
    }

    public void SetEnableButton(bool flag)
    {
        button.interactable = flag;
    }

    private void HoldCard()
    {

    }
}

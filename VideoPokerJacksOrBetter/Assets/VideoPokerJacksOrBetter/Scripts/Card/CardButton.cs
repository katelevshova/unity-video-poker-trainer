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
    public bool isSpriteReplaced = false;

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
    
    public void ShowFaceSide()
    {
        //DebugUtil.Instance.PrintD(CLASS_NAME, "ShowFaceSide");
        card.isFaceSide = true;
        UpdateImageSprite();
        txtHold.text = "";
        SetEnableButton(true);
    }

    public void UpdateImageSprite()
    {
        Sprite sprite = Resources.Load<Sprite>("Sprites/Cards/" + card.imgFileName);
        image.sprite = sprite;
        DebugUtil.Instance.PrintD(CLASS_NAME, "ShowFaceSide", "spriteName= " + image.sprite.name);
    }

    public void CardBtn_OnCLick_Handler()
    {
        DebugUtil.Instance.PrintD(CLASS_NAME, "CardBtn_OnCLick_Handler", "gameState= " + GameManagerScript.Instance.gameState);

        if(GameManagerScript.Instance.gameState == GameStates.FIRST_DEAL)
        {
            txtHold.text = "HOLD";
            SetEnableButton(false);

            card.isHeld = true;
        }
    }

    public void SetEnableButton(bool flag)
    {
        button.interactable = flag;
    }

}   


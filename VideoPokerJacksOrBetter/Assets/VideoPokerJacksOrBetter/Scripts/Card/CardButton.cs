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
    private TMPro.TextMeshProUGUI txtHold;

    // Start is called before the first frame update
    void Start()
    {
        // get all children of ActorsContainer including disabled
        Transform[] allTransforms = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in allTransforms)
        {
            if (child.gameObject.name == "Button")
            {
                image = child.gameObject.GetComponent<Image>();
            }
            if (child.gameObject.name == "txtHold")
            {
                txtHold = child.gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            }
        }

        txtHold.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowFaceSide(Boolean flag)
    {
        //if(flag)
       // {
            card.isFaceSide = true;

            Sprite sprite = Resources.Load<Sprite>("Sprites/Cards/" + card.imgFileName);
            image.sprite = sprite;
            DebugUtil.Instance.PrintD(CLASS_NAME, "ShowFaceSide", "spriteName= " + image.sprite.name);
       // }

    }
}

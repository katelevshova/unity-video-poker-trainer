using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsContainer : MonoBehaviour
{
    private static string CLASS_NAME = typeof(CardsContainer).ToString();
    public List<CardButton> cardButtons;
    private List<Card> cardHand;

    public const int HAND_SIZE = 5;
                
    // Start is called before the first frame update
    void Start()
    {
        if (cardButtons == null)
        {
            throw new Exception("Initialize cardButtons in CardsContainer");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFullHand(List<Card> cards, bool isGameStarted)
    {
        if(cardHand != null)
        {
            cardHand.Clear();
        }

        cardHand = cards;
        int cardNumber = 0; //total 5 cards

        foreach(CardButton cardBtn in cardButtons)
        {
            cardBtn.card = cardHand[cardNumber];
            DebugUtil.Instance.PrintD(CLASS_NAME, "SetFullHand", "cardBtn.name= " + cardBtn.name + ", cardBtn.imgFileName= " + cardBtn.card.imgFileName);

            cardBtn.ShowFaceSide(isGameStarted);

            cardNumber++;
        }
    }
}

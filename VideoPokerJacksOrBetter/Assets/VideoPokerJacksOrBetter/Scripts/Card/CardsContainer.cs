using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsContainer : MonoBehaviour
{
    private static string CLASS_NAME = typeof(CardsContainer).ToString();
    public List<CardButton> cardButtons;
    public const int HAND_SIZE = 5;

    // Start is called before the first frame update
    void Start()
    {
        if (cardButtons.Count == 0)
        {
            throw new Exception("Initialize cardButtons in CardsContainer");
        }
    }

    public void SetFullHand(List<Card> cards)
    {
        if(cards != null)
        {
            int cardNumber = 0; //total 5 cards

            foreach(CardButton cardBtn in cardButtons)
            {
                cardBtn.card = cards[cardNumber];
                cardBtn.isSpriteReplaced = false;
                DebugUtil.Instance.PrintD(CLASS_NAME, "SetFullHand", "cardBtn.name= " + cardBtn.name + ", cardBtn.imgFileName= " + cardBtn.card.imgFileName);

                cardBtn.ShowFaceSide();

                cardNumber++;
            }
        }
    }

    public void DisableAllCardButtons()
    {
        DebugUtil.Instance.PrintD(CLASS_NAME, "DisableAllCardButtons");
        foreach (CardButton cardBtn in cardButtons)
        {
            cardBtn.SetEnableButton(false);
        }
    }

    public void UpdateCardsFaceSide(List<Card> cards)
    {

        foreach (Card card in cards)
        {
            if (!card.isHeld)
            {
                for (int i = 0; i < HAND_SIZE; i++)
                {
                    if (!cardButtons[i].card.isHeld && !cardButtons[i].isSpriteReplaced)
                    {
                        cardButtons[i].card = card;
                        cardButtons[i].UpdateImageSprite();
                        cardButtons[i].isSpriteReplaced = true;
                        break;
                    }
                }

            }


        }
    }
}

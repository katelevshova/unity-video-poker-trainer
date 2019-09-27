using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card: IComparable, ICloneable
{
    private static string CLASS_NAME = typeof(Card).ToString();
  

    public int id = 0; // from 1-52 
    public Suit suit;  
    public CardsRank rank;  
    public bool isHeld = false;
    public bool isFaceSide = false;  
    public string imgFileName = "";

    public Card(Suit _suit, CardsRank _rank)
    {
        suit = _suit;
        rank = _rank;
        imgFileName = "img_card_" + suit.imgName + rank.imgName;
        
    }

    public object Clone()
    {
        return new Card(this.suit, this.rank)
        {
            id = this.id,
            isHeld = this.isHeld,
            isFaceSide = this.isFaceSide,
            imgFileName = this.imgFileName
        };
    }

    public int CompareTo(object obj)
    {
        if (obj == null)
            return 1;

        Card otherCard = (Card)obj;

        if (this.rank.Value() > otherCard.rank.Value())
            return 1;
        if (this.rank.Value() < otherCard.rank.Value())
            return -1;
        else
            return 0;
    }

    override  
    public string ToString()
    {
        string info = "id= " + id +
                    ", suit= " + suit.name +
                    ", rankName= " + rank.name +
                    ", rankValue= " + rank.Value() +
                    ", rankId= " + rank.Id() +
                    ", isHeld= " + isHeld +
                    ", isFaceSide= " + isFaceSide +
                    ", imgFileName= " + imgFileName;
        return info;
    }


}


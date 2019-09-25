using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card 
{
    private static string CLASS_NAME = typeof(Card).ToString();
  

    public int id = 0; // from 1-52 
    public Suit suit;  // Club=c, Diamond=d, Heart=h, Spade=s
    public Rank rank;  // Ace=1, One=1, ... King = 13}
    public bool isHeld = false;
    public bool isFaceSide = false;  
    public string imgFileName = "";

    public Card(Suit _suit, Rank _rank)
    {
        suit = _suit;
        rank = _rank;
        imgFileName = "img_card_" + suit.imgName + rank.imgName;
        
    }

    override  
    public string ToString()
    {
        string info = "id= " + id +
                    ", suit= " + suit.name +
                    ", rank= " + rank.name +
                    ", isHeld= " + isHeld +
                    ", isFaceSide= " + isFaceSide +
                    ", imgFileName= " + imgFileName;
        return info;
    }
}


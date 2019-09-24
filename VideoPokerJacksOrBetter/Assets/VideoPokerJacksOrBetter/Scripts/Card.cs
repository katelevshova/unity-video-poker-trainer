using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private static string CLASS_NAME = typeof(Card).ToString();
    public const int DECK_SIZE = 52;

    public int id = 0; // from 1-52 
    public Suit suit;  // Club=c, Diamond=d, Heart=h, Spade=s
    public Rank rank;  // Ace=1, One=1, ... King = 13}
    public bool isHeld = false;
    public bool isFaceSide = false;  
    public string imgFileName = "";

    public void Start()
    {
        Image img = gameObject.GetComponent(typeof(Image)) as Image;
        imgFileName = img.sprite.name;

        DebugUtil.Instance.PrintD(CLASS_NAME, "Start", "CARD INFO: " + ToString());
    }

    override  
    public string ToString()
    {
        string info = "id= " + id +
                    ", suit= " + suit +
                    ", rank= " + rank +
                    ", isHeld= " + isHeld +
                    ", isFaceSide= " + isFaceSide +
                    ", imgFileName= " + imgFileName;
        return info;
    }
}


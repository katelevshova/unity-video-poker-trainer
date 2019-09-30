using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsRank
{
    public const string ACE = "ACE";
    public const string TWO = "TWO";
    public const string THREE = "THREE";
    public const string FOUR = "FOUR";
    public const string FIVE = "FIVE";
    public const string SIX = "SIX";
    public const string SEVEN = "SEVEN";
    public const string EIGHT = "EIGHT";
    public const string NINE = "NINE";
    public const string TEN = "TEN";
    public const string JACK = "JACK";
    public const string QUEEN = "QUEEN";
    public const string KING = "KING";

    public const string ACE_IMG_NAME = "01";
    public const string TWO_IMG_NAME = "02";
    public const string THREE_IMG_NAME = "03";
    public const string FOUR_IMG_NAME = "04";
    public const string FIVE_IMG_NAME = "05";
    public const string SIX_IMG_NAME = "06";
    public const string SEVEN_IMG_NAME = "07";
    public const string EIGHT_IMG_NAME = "08";

    public const string NINE_IMG_NAME = "09";
    public const string TEN_IMG_NAME = "10";
    public const string JACK_IMG_NAME = "11";
    public const string QUEEN_IMG_NAME = "12";
    public const string KING_IMG_NAME = "13";

    public string name;
    public string imgName;
    private int _id;
    private int _value;

    // related to names of image files
    public enum IDs
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    // from lowest to highest card
    public enum Values
    {
        Two = 2,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace = 14
    }

    public CardsRank(string pName, string pImgName)
    {
        name = pName;
        imgName = pImgName;
        _id = int.Parse(imgName);
       

        if (name == ACE)
        {
            _value = (int)Values.Ace;
        }
        else
        {
            _value = _id;
        }
    }

    public int Id()
    {
        return _id;
    }

    public int Value()
    {
        return _value;
    }
}


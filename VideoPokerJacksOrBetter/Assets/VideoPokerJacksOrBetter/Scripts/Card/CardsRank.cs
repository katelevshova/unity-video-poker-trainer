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

    public CardsRank(string _name, string _imgName)
    {
        name = _name;
        imgName = _imgName;
    }
 }

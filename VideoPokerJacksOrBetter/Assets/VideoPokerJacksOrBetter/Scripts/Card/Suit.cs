using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suit 
{
   public const string HEARTS = "HEARTS";
   public const string DIAMONDS = "DIAMONDS";
   public const string CLUBS = "CLUBS";
   public const string SPADES = "SPADES";

   public const string HEARTS_IMG_NAME = "h";
   public const string DIAMONDS_IMG_NAME = "d";
   public const string CLUBS_IMG_NAME = "c";
   public const string SPADES_IMG_NAME = "s";
   
   public string name;
   public string imgName;

   public Suit(string _name, string _imgName)
   {
       name = _name;
       imgName = _imgName;
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PayoutRow 
{
   //public string handName = "";
   public int coin1 = 0;
   public int coin2 = 0;
   public int coin3 = 0;
   public int coin4 = 0;
   public int coin5 = 0;

   public PayoutRow(int bet1, int bet2, int bet3, int bet4, int bet5)
   {
        coin1 = bet1;
        coin2 = bet2;
        coin3 = bet3;
        coin4 = bet4;
        coin5 = bet5;
    }

}

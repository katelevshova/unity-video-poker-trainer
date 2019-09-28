using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class PayoutTable : MonoBehaviour
{
    private static string CLASS_NAME = typeof(PayoutTable).ToString();

    public const string HAND_COLUMN = "Hands";
    public const string COIN_1_COLUMN = "Coin_1";
    public const string COIN_2_COLUMN = "Coin_2";
    public const string COIN_3_COLUMN = "Coin_3";
    public const string COIN_4_COLUMN = "Coin_4";
    public const string COIN_5_COLUMN = "Coin_5";

    private PayoutTableModel payoutTableModel = null;


    // Start is called before the first frame update
    void Start()
    {
        DebugUtil.Instance.PrintD(CLASS_NAME, "Start");
        payoutTableModel = new PayoutTableModel();

        Transform[] allTransforms = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in allTransforms)
        {
            if( child.gameObject.name == HAND_COLUMN ||
                child.gameObject.name == COIN_1_COLUMN ||
                child.gameObject.name == COIN_2_COLUMN ||
                child.gameObject.name == COIN_3_COLUMN ||
                child.gameObject.name == COIN_4_COLUMN ||
                child.gameObject.name == COIN_5_COLUMN )
            {
                InitColumn(child.gameObject.name, child.GetComponentsInChildren<Transform>(true));
            }
        }
    }

    private void InitColumn(string columnName, Transform[] transforms)
    {
        foreach (Transform txtChild in transforms)
        {
            string searchLabel = "txtMP_Element_";
            string goName = txtChild.gameObject.name;

            if (goName.Contains(searchLabel))
            {
                string handNumberString = Regex.Match(goName, @"\d+").Value;
                int handNumber = int.Parse(handNumberString);

                TMPro.TextMeshProUGUI txt = txtChild.gameObject.GetComponent<TMPro.TextMeshProUGUI>();

                txt.text = GetElementText(columnName, handNumber);
            }
        }
    }

    private string GetElementText(string columnName, int handNumber)
    {
        switch (columnName)
        {
            case HAND_COLUMN:
                return payoutTableModel.payouts[handNumber].handName;
            case COIN_1_COLUMN:
                return payoutTableModel.payouts[handNumber].coin1.ToString();
            case COIN_2_COLUMN:
                return payoutTableModel.payouts[handNumber].coin2.ToString();
            case COIN_3_COLUMN:
                return payoutTableModel.payouts[handNumber].coin3.ToString();
            case COIN_4_COLUMN:
                return payoutTableModel.payouts[handNumber].coin4.ToString();
            case COIN_5_COLUMN:
                return payoutTableModel.payouts[handNumber].coin5.ToString();
        }

        return "undef";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetPayout(int handNumber, int bet)
    {
        switch (bet)
        {
            case 1:
                return payoutTableModel.payouts[handNumber].coin1;
            case 2:
                return payoutTableModel.payouts[handNumber].coin2;
            case 3:
                return payoutTableModel.payouts[handNumber].coin3;
            case 4:
                return payoutTableModel.payouts[handNumber].coin4;
            case 5:
                return payoutTableModel.payouts[handNumber].coin5;
        }

        return 0;
    }
}

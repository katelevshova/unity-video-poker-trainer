using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class PayoutTable : MonoBehaviour
{
    private static string CLASS_NAME = typeof(PayoutTable).ToString();
    private PayoutTableModel payoutTableModel;

    // Start is called before the first frame update
    void Start()
    {
        DebugUtil.Instance.PrintD(CLASS_NAME, "Start");
        payoutTableModel = new PayoutTableModel();


        Transform[] allTransforms = GetComponentsInChildren<Transform>(true);

        foreach (Transform child in allTransforms)
        {
                if (child.gameObject.name == "Hands")
                {
                    Transform[] handTransforms = child.GetComponentsInChildren<Transform>(true);

                    foreach (Transform handChild in handTransforms)
                    {
                        string searchLabel = "txtMP_Element_";
                        string goName = handChild.gameObject.name;

                        if(goName.Contains(searchLabel))
                        {
                            string handNumberString = Regex.Match(goName, @"\d+").Value;
                            int handNumber = int.Parse(handNumberString);

                            TMPro.TextMeshProUGUI txt = handChild.gameObject.GetComponent<TMPro.TextMeshProUGUI>();

                           txt.text=  payoutTableModel.payouts[handNumber].handName;



                        }
                    }
                }

                if (child.gameObject.name == "Coin_1")
                {
                    Transform[] handTransforms = child.GetComponentsInChildren<Transform>(true);

                    foreach (Transform handChild in handTransforms)
                    {
                        string searchLabel = "txtMP_Element_";
                        string goName = handChild.gameObject.name;

                        if (goName.Contains(searchLabel))
                        {
                            string handNumberString = Regex.Match(goName, @"\d+").Value;
                            int handNumber = int.Parse(handNumberString);

                            TMPro.TextMeshProUGUI txt = handChild.gameObject.GetComponent<TMPro.TextMeshProUGUI>();

                            txt.text = payoutTableModel.payouts[handNumber].coin1.ToString();



                        }
                    }
                }
            }
    }

    private void InitColumn(string columnName, Transform child)
    {
        if (child.gameObject.name == columnName)
        {
            Transform[] handTransforms = child.GetComponentsInChildren<Transform>(true);

            foreach (Transform txtChild in handTransforms)
            {
                string searchLabel = "txtMP_Element_";
                string goName = txtChild.gameObject.name;

                if (goName.Contains(searchLabel))
                {
                    string handNumberString = Regex.Match(goName, @"\d+").Value;
                    int handNumber = int.Parse(handNumberString);

                    TMPro.TextMeshProUGUI txt = txtChild.gameObject.GetComponent<TMPro.TextMeshProUGUI>();

                    txt.text = GetElementText(columnName, handNumber);//payoutTableModel.payouts[handNumber].handName;
                }
            }
        }
    }

    private string GetElementText(string columnName, int handNumber)
    {
        switch(columnName)
        {
            case "Hand":
                return payoutTableModel.payouts[handNumber].handName;
            case "Coin1":
                return payoutTableModel.payouts[handNumber].coin1.ToString();
            case "Coin2":
                return payoutTableModel.payouts[handNumber].coin2.ToString();
            case "Coin3":
                return payoutTableModel.payouts[handNumber].coin3.ToString();
            case "Coin4":
                return payoutTableModel.payouts[handNumber].coin4.ToString();
            case "Coin5":
                return payoutTableModel.payouts[handNumber].coin5.ToString();
        }

        return "undefined";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
                Transform[] handTransforms = GetComponentsInChildren<Transform>(true);

                foreach (Transform handChild in handTransforms)
                {
                    string searchLabel = "txtMP_Element_";
                    string goName = handChild.gameObject.name;

                    if(goName.Contains(searchLabel))
                    {
                        // int counter  int counter

                        //   int start = goName.IndexOf(searchLabel) + searchLabel.Length;
                        //   int end = goName.Length;
                        //string goNameNumberStr = goName.Substring(start, end - start);

                        //char lastChar = goName[goName.Length - 1];

                        string handNumberString = Regex.Match(goName, @"\d+").Value;
                        int handNumber = int.Parse(handNumberString);


                        TMPro.TextMeshProUGUI txt = handChild.gameObject.GetComponent<TMPro.TextMeshProUGUI>();

                       // int hand = ;

                       // string payoutValue = payoutTableModel.payouts[0];

                       // txt.text = payoutValue;

                        // txt.text = payoutTableModel.payouts[];
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

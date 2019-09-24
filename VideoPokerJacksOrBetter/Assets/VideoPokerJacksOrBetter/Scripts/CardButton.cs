using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardButton : MonoBehaviour
{
    private static string CLASS_NAME = typeof(CardButton).ToString();
    public string spriteName = ""; //card_back

    public Card card;

    // Start is called before the first frame update
    void Start()
    {
        Image img = gameObject.GetComponent(typeof(Image)) as Image;
        spriteName = img.sprite.name;

        DebugUtil.Instance.PrintD(CLASS_NAME, "Start", "spriteName= " + spriteName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

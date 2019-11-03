using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invScript : MonoBehaviour
{
    public Sprite switchTo;
    public Image spr;
    UIscript uS;
    public Items boolToChange;
    private void Start()
    {
        uS = GameObject.Find("Canvas/God Jesus").GetComponent<UIscript>();
    }

    public void switchSprite()
    {
        spr.sprite = switchTo;
        uS.showInv();
    }
}

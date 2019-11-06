using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class useItemScript : MonoBehaviour
{
    public GameObject itemToEnable;
    public bool crystal, cog, lever;
    playerScript pS;
    UIscript godScript;

    private void Start()
    {
        pS = GameObject.Find("Player").GetComponent<playerScript>();
        godScript = GameObject.Find("God Jesus").GetComponent<UIscript>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(pS.interact))
            {
                if(crystal == true)
                {
                    if(pS.hasCrystal == true)
                    {
                        godScript.crystalDone = true;
                        itemToEnable.SetActive(true);
                    }
                    else
                    {
                        pS.dialogueText.text = "It looks like something's supposed to go here...";
                        Invoke("endText", 5);
                    }
                }
                if (cog == true)
                {
                    if(pS.hasCog == true)
                    {
                        godScript.cogDone = true;
                        itemToEnable.SetActive(true);
                    }
                    else
                    {
                        pS.dialogueText.text = "Something's missing...";
                        Invoke("endText", 5);
                    }
                }
                if (lever == true)
                {
                    if(pS.hasLever == true)
                    {
                        godScript.leverDone = true;
                        itemToEnable.SetActive(true);
                    }
                    else
                    {
                        pS.dialogueText.text = "There's a slot here...";
                        Invoke("endText", 5);
                    }
                }
            }
        }
    }

    void endText()
    {
        pS.dialogueText.text = "";
    }
}

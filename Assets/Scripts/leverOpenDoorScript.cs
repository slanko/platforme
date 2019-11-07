using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leverOpenDoorScript : MonoBehaviour
{
    Animator anim;
    public Animator anim2;
    UIscript uS;
    playerScript pS;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        uS = GameObject.Find("God Jesus").GetComponent<UIscript>();
        pS = GameObject.Find("Player").GetComponent<playerScript>();
    }

    private void Update()
    {
        if (uS.crystalDone == true && uS.cogDone == true && uS.leverDone == true)
        {
            anim.SetBool("ready2go", true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(pS.interact))
            {
                anim.SetTrigger("activate");
                if (uS.crystalDone == true && uS.cogDone == true && uS.leverDone == true)
                {
                    anim2.SetTrigger("activate");
                }
                else
                {
                    Invoke("saySomething", 3);
                }
            }
        }
    }
    

    void saySomething()
    {
        pS.dialogueText.text = "Maybe there's more to it than that...";
        Invoke("endText", 5);
    }

    void endText()
    {
        pS.dialogueText.text = "";
    }
}

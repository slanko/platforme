using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    playerScript pS;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        pS = GameObject.Find("Player").GetComponent<playerScript>();
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(pS.interact))
            {
                if (pS.hasKey1 == true && pS.hasKey2 == true && pS.hasKey3 == true)
                {
                    anim.SetTrigger("activate");
                }
            }
        }
    }
}

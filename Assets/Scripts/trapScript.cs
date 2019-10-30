using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapScript : MonoBehaviour
{
    playerScript pS;
    Animator anim;
    bool sprung = false;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        pS = GameObject.Find("Player").GetComponent<playerScript>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (pS.isCrouching == false)
            {
                if (sprung == false)
                {
                    anim.SetTrigger("Spring");
                    sprung = true;
                }
            }
        }
    }

    public void resetSpring()
    {
        sprung = false;
    }
}

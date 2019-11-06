using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioHelper : MonoBehaviour
{
    playerScript pS;
    // Start is called before the first frame update
    void Start()
    {
        pS = GameObject.Find("Player").GetComponent<playerScript>();
    }
    public void PlayFootStepSound()
    {
        pS.aud.PlayOneShot(pS.footSteps[Random.Range(0, pS.footSteps.Length)]);
    }

}

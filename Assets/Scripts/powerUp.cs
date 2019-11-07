using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour
{
    UIscript uS;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        uS = GameObject.Find("God Jesus").GetComponent<UIscript>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(uS.crystalDone == true)
        {
            rend.material = uS.lightMat;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nonCamFollow : MonoBehaviour
{
    public GameObject followTarget, camObject;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = followTarget.transform.position;
        transform.rotation = camObject.transform.rotation;
    }
}

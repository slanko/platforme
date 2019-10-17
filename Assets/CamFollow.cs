using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject followTarget;
    public float lerpSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(new Vector3(0, -3, 0));
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(new Vector3(0, 3, 0));
        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, followTarget.transform.position.x, lerpSpeed * Time.deltaTime), Mathf.Lerp(transform.position.y, followTarget.transform.position.y, lerpSpeed * Time.deltaTime), Mathf.Lerp(transform.position.z, followTarget.transform.position.z, lerpSpeed * Time.deltaTime));
        //transform.rotation = new Quaternion(0, Mathf.Lerp(transform.rotation.y, followTarget.transform.rotation.y, lerpSpeed * Time.deltaTime), 0, 0);
    }
}

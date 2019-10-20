using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject followTarget, myCam;
    public float lerpSpeed, camSensitivity;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * camSensitivity );
        myCam.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), 0, 0) * -camSensitivity);
        myCam.transform.Translate(new Vector3(0, Input.GetAxis("Mouse Y") * -0.1f));
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, followTarget.transform.position.x, lerpSpeed * Time.deltaTime), Mathf.Lerp(transform.position.y, followTarget.transform.position.y, lerpSpeed * Time.deltaTime), Mathf.Lerp(transform.position.z, followTarget.transform.position.z, lerpSpeed * Time.deltaTime));
        //transform.rotation = new Quaternion(0, Mathf.Lerp(transform.rotation.y, followTarget.transform.rotation.y, lerpSpeed * Time.deltaTime), 0, 0);
    }
}

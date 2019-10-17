using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public GameObject cameraObject, cameraSorter;
    Animator anim;
    Rigidbody rb;
    public KeyCode forward, backward, left, right, jump;
    public float wantedSpeed, currentSpeed;
    public Quaternion wantedDirection, camDirection;
    public Vector3 debugEulerAngles;
    public float accel, decel, camSpeed;

    // Start is called before the first frame update
    void Start()
    {
        wantedDirection = transform.rotation;
        rb = GetComponent<Rigidbody>();
        anim = GameObject.Find(transform.name + "/dipshitrigged").GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(forward))
        {
            wantedDirection = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(backward))
        {
            wantedDirection = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey(left))
        {
            wantedDirection = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey(right))
        {
            wantedDirection = Quaternion.Euler(0, 90, 0);
        }
        if(Input.GetKey(forward) && Input.GetKey(right))
        {
            wantedDirection = Quaternion.Euler(0, 45, 0);
        }
        if (Input.GetKey(backward) && Input.GetKey(right))
        {
            wantedDirection = Quaternion.Euler(0, 135, 0);
        }
        if (Input.GetKey(backward) && Input.GetKey(left))
        {
            wantedDirection = Quaternion.Euler(0, 225, 0);
        }
        if (Input.GetKey(forward) && Input.GetKey(left))
        {
            wantedDirection = Quaternion.Euler(0, 315, 0);
        }
        if (Input.GetKey(forward) == false && Input.GetKey(backward) == false && Input.GetKey(left) == false && Input.GetKey(right) == false)
        {
        //decelerate
        }
        else
        {
            wantedDirection = Quaternion.Euler(0, wantedDirection.eulerAngles.y + cameraObject.transform.rotation.eulerAngles.y, 0);
            transform.Translate(Vector3.forward * .1f);
        }
        //camDirection = Quaternion.Euler(cameraObject.transform.rotation);

        transform.rotation = (Quaternion.Slerp(transform.rotation, wantedDirection, Time.deltaTime * camSpeed));

        debugEulerAngles = wantedDirection.eulerAngles;
    }
}


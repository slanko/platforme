using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public GameObject cameraObject, animatorDude;
    Animator anim;
    Rigidbody rb;
    public KeyCode forward, backward, left, right, jump;
    public float wantedSpeed, currentSpeed;
    public Quaternion wantedDirection;
    public float accel, decel;
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
            wantedSpeed = 0.1f;
            wantedDirection = new Quaternion(0, 0, 0, 0);
        }
        if (Input.GetKey(backward))
        {
            wantedSpeed = -0.1f;
            wantedDirection = new Quaternion(0, 180, 0, 0);
        }
        if (Input.GetKey(left))
        {
            wantedSpeed = -0.1f;
            wantedDirection = new Quaternion(0, 180, 0, 0);
        }

        if (Input.GetKey(forward) == false && Input.GetKey(backward) == false && Input.GetKey(left) == false && Input.GetKey(right) == false)
        {
            //currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime * decel);
            currentSpeed = 0f;
        }

        wantedDirection = new Quaternion(wantedDirection.x, wantedDirection.y + cameraObject.transform.rotation.y, wantedDirection.z, wantedDirection.w);
        currentSpeed = Mathf.Lerp(currentSpeed, wantedSpeed, Time.deltaTime * accel);

        animatorDude.transform.rotation = (Quaternion.Lerp(transform.rotation, wantedDirection, Time.deltaTime * 1f));

        transform.Translate(new Vector3(0, 0, currentSpeed));
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallJumperScript : MonoBehaviour
{
    public GameObject parentObject;
    Rigidbody rb;
    public Vector3 direction;
    public float wallJumpForce;
    playerScript pS;

    private void Start()
    {
        rb = parentObject.GetComponent<Rigidbody>();
        pS = parentObject.GetComponent<playerScript>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            if (Input.GetKeyDown(pS.jump))
            {
                rb.AddForce(direction * wallJumpForce, ForceMode.Impulse);
            }
        }
    }
}

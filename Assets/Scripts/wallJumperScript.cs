using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallJumperScript : MonoBehaviour
{
    playerScript pS;
    Animator anim;
    [Tooltip("Player GameObject.")]
    public GameObject parentObject;
    Rigidbody rb;
    [Tooltip("Directional stuff. Check it to jump right, uncheck to jump left.")]
    public bool leftOrRight;
    bool jumped = false;


    private void Start()
    {
        rb = parentObject.GetComponent<Rigidbody>();
        pS = parentObject.GetComponent<playerScript>();
        anim = GameObject.Find(parentObject.transform.name + "/dipshitrigged").GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            if(jumped == false)
            {
                if (Input.GetKeyDown(pS.jump))
                {
                    if (leftOrRight == true)
                    {
                        rb.AddForce(parentObject.transform.right * pS.wallJumpForce, ForceMode.VelocityChange);
                    }
                    else
                    {
                        rb.AddForce((parentObject.transform.right * -1) * pS.wallJumpForce, ForceMode.VelocityChange);
                    }
                    rb.AddForce(Vector3.up * pS.wallJumpUpForce, ForceMode.Impulse);
                    anim.SetTrigger("jump");
                    jumped = true;
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Wall")
            {
                jumped = false;
            }
    }
}

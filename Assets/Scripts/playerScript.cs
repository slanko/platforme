using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    CapsuleCollider cap;
    public GameObject cameraObject, cameraSorter;
    public float camSpeed;
    public KeyCode forward, backward, left, right, jump, crouch;
    public float jumpForce;
    float movementSpeed;
    public float runSpeed, crouchSpeed;
    Quaternion wantedDirection, camDirection;
    Vector3 debugEulerAngles;
    [Header("Wall jump force values")]
    public float wallJumpForce;
    public float wallJumpUpForce;
    Vector3 resetPos;
    checkpointScript check;

    // Start is called before the first frame update
    void Start()
    {
        cap = GetComponent<CapsuleCollider>();
        wantedDirection = transform.rotation;
        rb = GetComponent<Rigidbody>();
        anim = GameObject.Find(transform.name + "/dipshitrigged").GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Resetto();
        }
        if (Input.GetKey(crouch))
        {
            anim.SetBool("crouching", true);
            movementSpeed = crouchSpeed;
            cap.height = 0.7733587f;
            cap.center = new Vector3(0, -0.6126326f, 0);
        }
        else
        {
            anim.SetBool("crouching", false);
            movementSpeed = runSpeed;
            cap.height = 1.619178f;
            cap.center = new Vector3(0, -0.1904109f, 0);
        }
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
            anim.SetBool("running", false);
        }
        else
        {
            wantedDirection = Quaternion.Euler(0, wantedDirection.eulerAngles.y + cameraObject.transform.rotation.eulerAngles.y, 0);
            transform.Translate(Vector3.forward * movementSpeed * 0.1f);
            anim.SetBool("running", true);
        }
        //camDirection = Quaternion.Euler(cameraObject.transform.rotation);

        transform.rotation = (Quaternion.Slerp(transform.rotation, wantedDirection, Time.deltaTime * camSpeed));

        debugEulerAngles = wantedDirection.eulerAngles;
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            if (Input.GetKeyDown(jump))
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                anim.SetTrigger("jump");
            }
            anim.SetBool("inAir", false);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            anim.SetBool("inAir", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            check = other.GetComponent<checkpointScript>();
            resetPos = check.playerPos.transform.position;
        }
    }

    void Resetto()
    {
        transform.position = resetPos;
        rb.velocity = new Vector3(0, 0, 0);
    }
}


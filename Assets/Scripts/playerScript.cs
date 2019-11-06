using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Items { Key1, Key2, Key3, Lever, Cog, Crystal, Candle}

public class playerScript : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    CapsuleCollider cap;
    public GameObject cameraObject, cameraSorter;
    public float camSpeed;
    [Header ("Controls")]
    public KeyCode forward;
    public KeyCode backward, left, right, jump, crouch, altCrouch, interact;
    public float jumpForce;
    float movementSpeed;
    public float runSpeed, crouchSpeed;
    public bool isCrouching = false;
    Quaternion wantedDirection, camDirection;
    Vector3 debugEulerAngles;
    [Header("Wall jump force values")]
    public float wallJumpForce;
    public float wallJumpUpForce;
    Vector3 resetPos = new Vector3(0, 1, 0);
    checkpointScript check;
    bool jumpCheck = true;
    public bool grounded;
    [Header("Death Ragdoll")]
    public GameObject ragdoll;
    public bool movementSmooth;
    public bool leaveCorpses;
    [Header("Inventory Booleans")]
    public bool hasCog;
    [Space]
    public bool hasCrystal, hasLever, hasKey1, hasKey2, hasKey3, hasCandle;
    invScript currentItem;
    [Header("Audio")]
    public AudioSource aud;
    public AudioClip[] footSteps, crouchFootSteps;
    [Header("Dialogue")]
    public GameObject textCanvas;
    public GameObject billboardCamera;
    public Text dialogueText;

    //TIME STUFF
    public float timer;
    public Text timeDisplay;
    bool finished = false;

    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        cap = GetComponent<CapsuleCollider>();
        wantedDirection = transform.rotation;
        rb = GetComponent<Rigidbody>();
        anim = GameObject.Find(transform.name + "/rabbitrigged").GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        timer = 0;
        finished = false;
        dialogueText.text = "";
    }

    private void Update()
    {
        if(finished == false)
        {
            timer = timer + Time.deltaTime;
            timeDisplay.text = "time: " + timer.ToString("F2");
        }
        textCanvas.transform.LookAt(billboardCamera.transform.position);
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            Resetto();
        }
        if(Input.GetKey(KeyCode.LeftAlt) && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKey(crouch) || Input.GetKey(altCrouch))
        {
            if(grounded == true)
            {
                anim.SetBool("crouching", true);
                movementSpeed = crouchSpeed;
                cap.height = 0.7733587f;
                cap.center = new Vector3(0, -0.6126326f, 0);
                isCrouching = true;
            }
        }
        else
        {
            if (grounded == true)
            {
                anim.SetBool("crouching", false);
                movementSpeed = runSpeed;
                cap.height = 1.619178f;
                cap.center = new Vector3(0, -0.1904109f, 0);
                isCrouching = false;
            }

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
        if(movementSmooth == false)
        {
            if (grounded == true)
            {
                transform.rotation = wantedDirection;
            }
            else
            {
                transform.rotation = (Quaternion.Slerp(transform.rotation, wantedDirection, Time.deltaTime * camSpeed));
            }
        }
        else
        {
            transform.rotation = (Quaternion.Slerp(transform.rotation, wantedDirection, Time.deltaTime * camSpeed));
        }

        debugEulerAngles = wantedDirection.eulerAngles;
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            grounded = true;
            if (Input.GetKeyDown(jump))
            {
                if(jumpCheck == true)
                {
                    rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                    anim.SetTrigger("jump");
                    jumpCheck = false;
                }
            }
            anim.SetBool("inAir", false);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            anim.SetBool("inAir", true);
            jumpCheck = true;
            grounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Hazard")
        {
            if(leaveCorpses == true)
            {
                Instantiate(ragdoll, transform.position, transform.rotation);
            }
            Resetto();
        }
        if(other.gameObject.tag == "Resetter")
        {
            Resetto();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Checkpoint")
        {
            check = other.GetComponent<checkpointScript>();
            resetPos = check.playerPos.transform.position;
        }
        if(other.gameObject.tag == "FinishLine")
        {
            finished = true;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            if (Input.GetKeyDown(interact))
            {
                currentItem = other.GetComponent<invScript>();
                doStuff(currentItem.boolToChange);
                currentItem.switchSprite();
                Destroy(other.gameObject);
            }
        }
    }

    void doStuff(Items itemName)
    {
        switch (itemName)
        {
            case Items.Key1:
                hasKey1 = true;
                break;
            case Items.Key2:
                hasKey2 = true;
                break;
            case Items.Key3:
                hasKey3 = true;
                break;
            case Items.Lever:
                hasLever = true;
                break;
            case Items.Cog:
                hasCog = true;
                break;
            case Items.Crystal:
                hasCrystal = true;
                break;
            case Items.Candle:
                hasCandle = true;
                break;
        }
    }

    void Resetto()
    {
        transform.position = resetPos;
        rb.velocity = new Vector3(0, 0, 0);
    }
}


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIscript : MonoBehaviour
{
    public GameObject optionsMenu, invMenu;
    Animator optionsAnim, invAnim;
    public KeyCode options, inventory;
    Toggle moveToggle, corpseToggle;

    playerScript pS;
    // Start is called before the first frame update
    void Start()
    {
        optionsAnim = optionsMenu.GetComponent<Animator>();
        invAnim = invMenu.GetComponent<Animator>();
        pS = GameObject.Find("Player").GetComponent<playerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(options))
        {
                if (optionsAnim.GetBool("optionsMenu") == false)
                {
                    optionsAnim.SetBool("optionsMenu", true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    optionsAnim.SetBool("optionsMenu", false);
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
        }
        if (Input.GetKeyDown(inventory))
        {
                if (invAnim.GetBool("InventoryMenu") == false)
                {
                    invAnim.SetBool("InventoryMenu", true);
                }
                else
                {
                    invAnim.SetBool("InventoryMenu", false);
                }
        }
    }
    public void toggleCorpses()
    {
        if(pS.leaveCorpses == true)
        {
            pS.leaveCorpses = false;
        }
        else
        {
            pS.leaveCorpses = true;
        }
    }

    public void toggleMovement()
    {
        if (pS.movementSmooth == true)
        {
            pS.movementSmooth = false;
        }
        else
        {
            pS.movementSmooth = true;
        }
    }
}

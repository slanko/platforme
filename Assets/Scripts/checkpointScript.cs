using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpointScript : MonoBehaviour
{
    public GameObject playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find(transform.name + "/PlayerPos");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

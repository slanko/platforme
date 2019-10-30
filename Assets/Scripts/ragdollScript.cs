using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ragdollScript : MonoBehaviour
{
    Rigidbody rb;
    public float randomMin, randomMax, flingForce;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(randomMin, randomMax), Random.Range(randomMin, randomMax), Random.Range(randomMin, randomMax)) * flingForce, ForceMode.Impulse);
    }
}

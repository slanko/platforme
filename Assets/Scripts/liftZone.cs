using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liftZone : MonoBehaviour
{
    public float liftForce;
    private void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.AddForce(Vector3.up * liftForce, ForceMode.Acceleration);
        }
    }
}

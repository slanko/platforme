using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchScript : MonoBehaviour
{
    Animator anim;
    ParticleSystem partSys;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        partSys = GameObject.Find(transform.name + "/Particle System").GetComponent<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerLight")
        {
            anim.SetTrigger("turnOn");
            partSys.Play();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnOff : MonoBehaviour
{
    public float firstDelay;
    public float onDelay;
    public float offDelay;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        Invoke("OnFire", firstDelay);
    }

    void Update()
    {
        
    }

    void OnFire()
    {
        anim.SetBool("isFire", true);
        GetComponent<BoxCollider2D>().enabled = true;
        Invoke("OffFire", offDelay);
    }

    void OffFire()
    {
        anim.SetBool("isFire", false);
        GetComponent<BoxCollider2D>().enabled = false;
        Invoke("OnFire", onDelay);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float moveSpeed;
    public int dirChanger = 1;
    public float distance;

    void Start()
    {
        
    }

    void Update()
    {
        Elevator();
    }

    void Elevator()
    {
        if (transform.position.y < 0 || transform.position.y > 5)
        {
            if (transform.position.y < 0)
                dirChanger = 1;
            else if (transform.position.y > distance)
                dirChanger = -1;
        }

        Vector3 moveVelocity = new Vector3(0, moveSpeed * dirChanger, 0) * Time.deltaTime;
        this.transform.position += moveVelocity;
    }
}

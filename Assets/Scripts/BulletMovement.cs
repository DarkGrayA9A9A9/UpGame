using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float moveSpeed;
    public float bulletMaintainTime;

    void Awake()
    {
        Invoke("DestroyBullet", bulletMaintainTime);
    }

    void Update()
    {
        Vector3 moveVelocity = new Vector3(moveSpeed, 0, 0) * Time.deltaTime;
        this.transform.position += moveVelocity;
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

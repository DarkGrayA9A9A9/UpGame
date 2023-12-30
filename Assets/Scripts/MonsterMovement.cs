using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    public float moveSpeed;
    public int moveDir = -1;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move();
        CheckPlatform();
    }

    private void Move()
    {
        Vector3 moveVelocity = new Vector3(moveSpeed, 0, 0) * moveDir * Time.deltaTime;
        this.transform.position += moveVelocity;

        if (moveDir == 1)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    private void CheckPlatform()
    {
        Vector2 frontVec = new Vector2(rigid.position.x + (moveDir * 0.5f), rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(1, 0, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rayHit.collider == null)
        {
            moveDir *= -1;
        }
    }
}

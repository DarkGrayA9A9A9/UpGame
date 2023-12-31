using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    float h;
    public float moveSpeed;
    public float jumpPower;
    public bool isJump;
    // public bool isDoubleJump;
    public float knockBack;
    public float knockBackUp;
    public bool stun;
    public float stunTime;
    public float failTime;
    public string[] failText;
    public int failCnt;
    public float inAir;
    public bool failed;

    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;
    AudioSource audioSource;
    public Text subtitleText;
    public Text failCntText;
    public GameObject subtitle;
    public GameObject pauseMenu;

    public AudioClip jumpSound;

    public GameManager gameManager;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (!stun && gameManager.playing)
        {
            Jump();
            Move();
            PauseMenu();
            AnimationChanger();
            InAir();
            Landing();
        } 
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJump)
            {
                audioSource.PlayOneShot(jumpSound);
                isJump = true;
                anim.SetBool("isJump", true);
                rigid.velocity = Vector2.zero;
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
            /*
            else if (!isDoubleJump)
            {
                audioSource.PlayOneShot(jumpSound);
                isDoubleJump = true;
                anim.SetBool("isDoubleJump", true);
                rigid.velocity = Vector2.zero;
                rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
            */
        }
    }

    void Move()
    {
        h = Input.GetAxisRaw("Horizontal");
        Vector3 moveVelocity = new Vector3(h, 0, 0) * moveSpeed * Time.deltaTime;
        this.transform.position += moveVelocity;
    }

    void InAir()
    {
        if (isJump && rigid.velocity.y < 0)
        {
            inAir += Time.deltaTime;
            FailCheck();
        }
        else
        {
            inAir = 0;
        }
    }

    void AnimationChanger()
    {
        if (Input.GetButton("Horizontal"))
        {
            anim.SetBool("isMove", true);
        }
        else
        {
            anim.SetBool("isMove", false);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }
        if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }
    }
    
    void Landing()
    {
        Debug.DrawRay(rigid.position, Vector3.down, new Color(1, 0, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));

        if (rayHit.collider != null)
        {
            if(rayHit.distance <= 0.51f && isJump)
            {
                isJump = false;
                // isDoubleJump = false;
                anim.SetBool("isJump", false);
                // anim.SetBool("isDoubleJump", false);
                failed = false;
            }
        }

        if (rayHit.collider == null)
        {
            isJump = true;
            anim.SetBool("isJump", true);
        }
    }

    void FailCheck()
    {
        if (inAir > failTime && !failed)
        {
            failed = true;
            Fail();
        }
    }

    void Fail()
    {
        Debug.Log("¶³¾îÁü");
        failCnt++;
        failCntText.text = "Fail : " + failCnt.ToString();

        int n = Random.Range(0, 5);

        subtitleText.text = failText[n];
        subtitle.SetActive(true);

        Invoke("SubtitleOff", 3);
    }

    void SubtitleOff()
    {
        subtitle.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.transform.position.x < this.transform.position.x)
            {
                stun = true;
                rigid.velocity = Vector2.zero;
                rigid.AddForce(Vector2.right * knockBack, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.up * knockBackUp, ForceMode2D.Impulse);
                anim.SetTrigger("isHit");
                Invoke("StunEnd", stunTime);
            }
            else
            {
                stun = true;
                rigid.velocity = Vector2.zero;
                rigid.AddForce(Vector2.left * knockBack, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.up * knockBackUp, ForceMode2D.Impulse);
                anim.SetTrigger("isHit");
                Invoke("StunEnd", stunTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TrapL")
        {
            stun = true;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.left * knockBack, ForceMode2D.Impulse);
            rigid.AddForce(Vector2.up * knockBackUp, ForceMode2D.Impulse);
            Invoke("StunEnd", stunTime);
            anim.SetTrigger("isHit");
        }

        if (collision.gameObject.tag == "TrapR")
        {
            stun = true;
            rigid.velocity = Vector2.zero;
            rigid.AddForce(Vector2.right * knockBack, ForceMode2D.Impulse);
            rigid.AddForce(Vector2.up * knockBackUp, ForceMode2D.Impulse);
            Invoke("StunEnd", stunTime);
            anim.SetTrigger("isHit");
        }

        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.transform.position.x < this.transform.position.x)
            {
                stun = true;
                rigid.velocity = Vector2.zero;
                rigid.AddForce(Vector2.right * knockBack, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.up * knockBackUp, ForceMode2D.Impulse);
                anim.SetTrigger("isHit");
                Invoke("StunEnd", stunTime);
            }
            else
            {
                stun = true;
                rigid.velocity = Vector2.zero;
                rigid.AddForce(Vector2.left * knockBack, ForceMode2D.Impulse);
                rigid.AddForce(Vector2.up * knockBackUp, ForceMode2D.Impulse);
                anim.SetTrigger("isHit");
                Invoke("StunEnd", stunTime);
            }
        }
    }

    void StunEnd()
    {
        stun = false;
    }

    void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.playing = false;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
    }
}

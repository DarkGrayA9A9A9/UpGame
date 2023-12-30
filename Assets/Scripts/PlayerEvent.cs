using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEvent : MonoBehaviour
{
    
    public Vector2 playerRevivePosition;

    Rigidbody2D rigid;
    public PlayerMovement player;
    public GameManager gameManager;

    public Text playTimeTxt;
    public Text failCntTxt;
    public GameObject clear;
    public GameObject playTime;
    public GameObject failcnt;
    public GameObject goToTitle;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        //player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        Reposition();
        Fast();
    }

    void Reposition()
    {
        if (Input.GetKeyDown(KeyCode.R) && rigid.velocity.y >= 0)
        {
            rigid.velocity = Vector2.zero;
            this.transform.position = playerRevivePosition;
        }
    }

    void Fast()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Time.timeScale = 4;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            Time.timeScale = 0;
            gameManager.playing = false;
            Invoke("Clear", 1);
            Invoke("ClearTime", 2);
            Invoke("FailCount", 3);
            Invoke("GoToTitle", 5);
        }
    }

    void Clear()
    {
        clear.SetActive(true);
    }

    void ClearTime()
    {
        playTimeTxt.text = "Clear Time : " + string.Format("{0:00}", gameManager.hour) + ":" + string.Format("{0:00}", gameManager.minute) + ":" + string.Format("{0:00}", gameManager.second);
        playTime.SetActive(true);
    }

    void FailCount()
    {
        failCntTxt.text = "Fail : " + player.failCnt.ToString();
        failcnt.SetActive(true);
    }

    void GoToTitle()
    {
        goToTitle.SetActive(true);
    }
}

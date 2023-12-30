using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public GameObject title;
    public GameObject option;
    public GameObject pause;

    public PlayerMovement player;
    public GameObject _player;

    public bool pauseOption = false;

    public GameManager gameManager;

    void Awake()
    {
        Time.timeScale = 0;
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        gameManager.playing = true;
        Debug.Log("게임 시작");
        Time.timeScale = 1;
        title.SetActive(false);
        pause.SetActive(false);
    }

    public void OptionButton()
    {
        Debug.Log("옵션");
        option.SetActive(true);
        title.SetActive(false);
    }
    
    public void ExitButton()
    {
        Debug.Log("게임 종료");
        Application.Quit();
    }

    public void BackButton()
    {
        if (!pauseOption)
        {
            Debug.Log("뒤로가기");
            title.SetActive(true);
            option.SetActive(false);
        }
        else
        {
            Debug.Log("뒤로가기");
            pause.SetActive(true);
            option.SetActive(false);
            pauseOption = false;
        }
    }

    public void PuaseOptionButton()
    {
        Debug.Log("일시정지 옵션");
        option.SetActive(true);
        pause.SetActive(false);
        pauseOption = true;
    }

    public void TitleButton()
    {
        Time.timeScale = 0;
        Debug.Log("타이틀로");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

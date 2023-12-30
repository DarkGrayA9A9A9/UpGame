using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool playing = false;
    public float playTime;
    public int hour;
    public int minute;
    public int second;

    public Text playTimeText;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        if (playing)
            PlayTime();
    }

    void PlayTime()
    {
        playTime += Time.deltaTime;

        hour = (int)(playTime / 3600);
        minute = (int)((playTime - (hour * 3600)) / 60);
        second = (int)(playTime % 60);
        playTimeText.text = string.Format("{0:00}", hour) + ":" + string.Format("{0:00}", minute) + ":" + string.Format("{0:00}", second);
    }
}

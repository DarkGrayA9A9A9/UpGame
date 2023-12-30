using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioMixer MasterMixer;
    public Slider bgmSlider;
    public Slider seSlider;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BGMControl()
    {
        float sound = bgmSlider.value;
        MasterMixer.SetFloat("BGM", sound);
    }

    public void SEControl()
    {
        float sound = seSlider.value;
        MasterMixer.SetFloat("SE", sound);
    }
}

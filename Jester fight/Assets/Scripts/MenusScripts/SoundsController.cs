using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundsController : MonoBehaviour
{
    public AudioClip[] auCl;
    private AudioSource auSo;
    Slider SoundsSlider;
    private int controlNum = 0;

    private void Start()
    {
        auSo = GetComponent<AudioSource>();
        SoundsSlider = GetComponent<Slider>();
        
    }


    private void Update()
    {
        if(!auSo.isPlaying)
        {
            PlayNextSound();
            
        }
        ControlViocePower();
        auSo.volume = SoundsSlider.value;
    }

    public void PlayNextSound()
    {
        AudioClip nextClip = auCl[controlNum];
        auSo.clip = nextClip;
        auSo.Play();
        controlNum = (controlNum + 1) % auCl.Length;
    }

    public void SetMaximumVoicePoint(int vPointMax)
    {
        SoundsSlider.maxValue = vPointMax;
        SoundsSlider.value = vPointMax;
    } 

    public void SetVoicePoint(int vPoint)
    {
        SoundsSlider.value = vPoint;
    }

    public void ControlViocePower()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            SoundsSlider.value -= 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SoundsSlider.value += 0.1f;
        }
        if(SoundsSlider.value < 0)
        {
            SoundsSlider.value = 0;
        }
        if (SoundsSlider.value > 100)
        {
            SoundsSlider.value = 100;
        }
    }
}

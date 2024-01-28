using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyisPlaying : MonoBehaviour
{
    

    public AudioSource aSource;
    private float number = 1;


    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        
    }

    private void Update()
    {
        aSource.volume = number;
        if (!aSource.isPlaying)
        {
            aSource.Play();
            
        }
        VoiceController();
        Debug.Log(number);
    }

    private void VoiceController()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            number -= 0.1f;
        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            number += 0.1f;
        }
        if(number < 0)
        {
            number = 0;
        }
        else if(number > 1)
        {
            number = 1;
        }
    }
}

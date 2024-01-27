using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : MonoBehaviour
{
    public JesterMovement jesterMovement;
    public JesterMeter jesterMeter;


    public GameObject BANANA_PEEL;
    public GameObject BOMB;
    public GameObject RAKE;

    public string item = "BOMB";
    public string facing = "right";


    // Start is called before the first frame update
    void Awake()
    {
        jesterMovement = GetComponent<JesterMovement>();
        jesterMeter = GetComponent<JesterMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

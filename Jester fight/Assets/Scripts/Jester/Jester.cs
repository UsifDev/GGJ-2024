using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : MonoBehaviour
{
    public JesterItem jesterItem;
    public JesterMovement jesterMovement;
    public JesterMeter jesterMeter;


    // Start is called before the first frame update
    void Awake()
    {
        jesterItem = GetComponent<JesterItem>();
        jesterMovement = GetComponent<JesterMovement>();
        jesterMeter = GetComponent<JesterMeter>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

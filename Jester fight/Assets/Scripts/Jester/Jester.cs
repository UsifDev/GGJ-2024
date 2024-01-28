using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jester : MonoBehaviour
{
    public JesterMovement jesterMovement;
    public JesterThrowItem jesterThrowItem;


    public GameObject BANANA_PEEL;
    public GameObject BOMB;
    public GameObject RAKE;
    public GameObject BALL;

    public string item = "BOMB";
    public string facing = "right";

    public float amusemeter;

    public bool PickUpItem(string pItem)
    {
        if(item == "")
        {
            item = pItem;
            return true;
        }
        return false;
    }

    public void ModMeter(float val)
    {
        amusemeter += val;
        if(amusemeter < 0) 
        { 
            amusemeter = 0; 
        }
        if(amusemeter > 100)
        {
            amusemeter = 100;
        }
    }


    // Start is called before the first frame update
    void Awake()
    {
        jesterMovement = GetComponent<JesterMovement>();
        jesterThrowItem = GetComponent<JesterThrowItem>();
        amusemeter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        jesterThrowItem.Throw();
        jesterMovement.UpdateMove();
    }
}
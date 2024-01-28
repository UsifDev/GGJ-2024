using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string type; // BOMB, BANANA_PEEL, RAKE, BALL
    public bool isPickUp; // true if can be picked up, if not it's a trap
    public float actTimer; // when this is 0, the item activates
    public bool trapSet; // if the item is set as a trap(for jester) or not. It will make it stop on the ground
    public float itemTimer; // timer for despawning

    public GameObject jester_obj;

    public float amuse_m;

    public Rigidbody2D rb;

    // Sets attributes for an item that spawned
    public void SetSpawned()
    {
        isPickUp = true;
        itemTimer = 8f;
    }


    // Sets attributes for an item that was thrown
    public void SetThrown(float actTimer, Vector2 v2)
    {
        this.actTimer = actTimer;
        isPickUp = false;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = v2;
        itemTimer = 15f;
    }


    private float DecreaseTimer(float t)
    {
        if (t > 0)
        {
            t -= Time.deltaTime;
        }
        if (t <= 0)
        {
            t = 0;
        }
        return t;
    }

    private void DecreaseTimers()
    {
        if(!isPickUp && !trapSet)
        {
            actTimer = DecreaseTimer(actTimer);
            if(actTimer <= 0) 
            {
                trapSet = true;
            }
        }
        itemTimer = DecreaseTimer(itemTimer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            Jester jester = collision.gameObject.GetComponent<Jester>();
            Debug.Log(jester.gameObject.transform);
            if (isPickUp)
            {
                if (jester.PickUpItem(type))
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                if (trapSet)
                {
                    // decrease amus-o-meter of jester that touched
                    jester.ModMeter(-(amuse_m / 2));
                    Jester[] jesters = FindObjectsOfType<Jester>();
                    if (jester == jesters[0])
                    {
                        jesters[1].ModMeter(amuse_m);
                    }
                    else
                    {
                        jesters[0].ModMeter(amuse_m);
                    }
                    Destroy(gameObject);
                }
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        DecreaseTimers();
        if(itemTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}

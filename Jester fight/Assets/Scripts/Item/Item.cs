using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string type; // BOMB, BANANA_PEEL, RAKE, BALL
    public bool isPickUp; // true if can be picked up, if not it's a trap
    public float actTimer; // when this is 0, the item activates also for it's owner
    public string owner; // name of the jester that threw this. null if just spawned.
    public bool trapSet; // if the item is set as a trap(for jester) or not. It will make it stop on the ground

    public Rigidbody2D rb;

    // Sets attributes for an item that spawned
    public void SetSpawned()
    {
        isPickUp = true;
    }


    // Sets attributes for an item that was thrown
    public void SetThrown(string owner, float actTimer, Vector2 v2)
    {
        this.owner = owner;
        this.actTimer = actTimer;
        isPickUp = false;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = v2;
    }

    private void DecreaseTimer()
    {
        if(!isPickUp)
        {
            if(actTimer > 0)
            {
                actTimer -= Time.deltaTime;
            }
            if(actTimer <= 0)
            {
                actTimer = 0;

            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        DecreaseTimer();
    }
}

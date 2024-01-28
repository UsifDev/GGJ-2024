using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterThrowItem : MonoBehaviour
{
    private Jester jester;
    private Rigidbody2D rb;
    private string jName;

    private void Awake()
    {
        jester = GetComponent<Jester>();
        rb = GetComponent<Rigidbody2D>();
        jName = gameObject.name;
    }


    // Calculate item velocity
    private Vector2 getItemVel()
    {
        float throwVel = 0;
        if(jester.facing == "right")
        {
            throwVel = 15f;
        }
        else if (jester.facing == "left")
        {
            throwVel = -15f;
        }
        return new Vector2(rb.velocity.x + throwVel, 0f);
    }

    // Make the item thrown
    public void Throw()
    {
        float button = Input.GetAxis(jName + "T");
        if (button != 0)
        {
            if (jester != null)
            {
                if (jester.item != "")
                {
                    GameObject newItem = null;
                    switch (jester.item)
                    {
                        case "BOMB": newItem = Instantiate(jester.BOMB, rb.position, Quaternion.identity); break;
                        case "BANANA PEEL": newItem = Instantiate(jester.BANANA_PEEL, rb.position, Quaternion.identity); break;
                        case "RAKE": newItem = Instantiate(jester.RAKE, rb.position, Quaternion.identity); break;
                    }

                    Item item = newItem.GetComponent<Item>();

                    item.SetThrown(this.tag, 1f, getItemVel());

                    jester.item = "";
                }
            }
        }
    }

}

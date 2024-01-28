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
        rb = jester.GetComponent<Rigidbody2D>();
        jName = gameObject.name;
    }


    // Calculate item velocity
    private Vector2 getItemVel()
    {
        float throwVel = 0;
        if(jester.facing == "right")
        {
            throwVel = 30f;
        }
        else if (jester.facing == "left")
        {
            throwVel = -30f;
        }
        return new Vector2(throwVel, 0f);
    }

    private Vector2 getItemPos()
    {
        Vector2 res;
        if (jester.facing == "right")
        {
            res = new Vector2(rb.position.x + 10f, 0f);
        }
        else
        {
            res = new Vector2(rb.position.x - 10f, 0f);
        }
        return res;
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



                    Vector2 pos = getItemPos();
                    switch (jester.item)
                    {
                        case "BOMB": newItem = Instantiate(jester.BOMB, rb.position, Quaternion.identity); break;
                        case "BANANA_PEEL": newItem = Instantiate(jester.BANANA_PEEL, rb.position, Quaternion.identity); break;
                        case "RAKE": newItem = Instantiate(jester.RAKE, rb.position, Quaternion.identity); break;
                        case "BALL": newItem = Instantiate(jester.BALL, rb.position, Quaternion.identity); break;
                    }

                    Item item = newItem.GetComponent<Item>();

                    item.SetThrown(1f, getItemVel());

                    jester.item = "";
                }
            }
        }
    }

}

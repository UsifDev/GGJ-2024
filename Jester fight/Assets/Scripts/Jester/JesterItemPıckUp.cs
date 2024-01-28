using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JesterItemPıckUp : MonoBehaviour
{
    public LayerMask itemLayer;
    public Jester jester;

    // Start is called before the first frame update
    void Awake()
    {
        jester = GetComponent<Jester>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == itemLayer)
        {
            // If jester doesnt have any items then pick up the collided item
            if(jester.item == "")
            {
                jester.item = collision.gameObject.tag;
                Destroy(collision.gameObject.transform.parent.gameObject);
            }
        }
    }
}

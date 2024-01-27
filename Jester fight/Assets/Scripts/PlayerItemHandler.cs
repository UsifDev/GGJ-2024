using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemHandler : MonoBehaviour
{
    public LayerMask itemLayer;
    private Item itemHeld = Item.NONE;
    private int itemCount = 0;
    public enum Item
    {
        NONE, BANANA, RAKE, BALL, BOMB 
    };
    
    public void UseItem(Item item)
    {
        if(item == Item.NONE)
        {
            //maybe some message or feedback to display
            return;
        }
        
        switch(item)
        {
            case Item.BANANA:
                //logic to change state, animation etc.
            break;
            case Item.RAKE:

            break;
            case Item.BALL:

            break;
            case Item.BOMB:

            break;
        }

        itemCount--;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == itemLayer)
        {
            if(itemCount == 0)
            {
                itemHeld = nameToEnum(collision.gameObject.name);
            }
            itemCount++;
            Destroy(collision.gameObject.transform.parent.gameObject);
            // add UI/logic/sound etc.
        }
    }

    private Item nameToEnum(string name)
    {
        switch(name)
        {
            case "Banana":
                return Item.BANANA;
            break;
            case "Rake":
                return Item.RAKE;
            break;
            case "Ball":
                return Item.BALL;
            break;
            case "Bomb":
                return Item.BOMB;
            break;
            default:
                return Item.NONE;
            break;
        }
    }
}

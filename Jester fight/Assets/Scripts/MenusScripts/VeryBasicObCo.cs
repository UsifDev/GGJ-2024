using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeryBasicObCo : MonoBehaviour
{
    public GameObject pos1;
    public GameObject pos2;
    public GameObject ob;
    

    private void Update()
    {
        if(ob.transform.position == pos1.transform.position)
        {
            ToLeft();
        }
        else //if(ob.transform.position == pos2.transform.position)
        {
            ToRight();
        }
    }

    private void ToRight()
    {
        ob.transform.position += new Vector3(-0.5f * Time.deltaTime, 0f, 0f);

    }

    private void ToLeft()
    {
        ob.transform.position += new Vector3(0.5f * Time.deltaTime, 0f, 0f);
    }
}

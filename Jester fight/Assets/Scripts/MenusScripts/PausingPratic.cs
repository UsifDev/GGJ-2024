using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausingPratic : MonoBehaviour
{
    public Image greenP;
    public Image redP;
    bool man = true;

    private void Start()
    {
        greenP.color = Color.green;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (man)
            {
                openRedLight();
                man = false;
            }
            else
            {
                openGreenLight();
                man = true;
            }
        }
    }

    public void openRedLight()
    {
            redP.color = Color.red;
            greenP.color = new Color(0, 0.45f, 0, 1);
        
    }
    public void openGreenLight()
    {
        greenP.color = Color.green;
        redP.color = new Color(0.45f, 0, 0, 1);
    }

}

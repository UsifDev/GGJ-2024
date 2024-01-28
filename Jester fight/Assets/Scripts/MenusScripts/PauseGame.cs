using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseScreen;
    bool checker = true;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(checker)
            {
                PausingFunc();
                checker = false;
            }

            else
            {
                Continue();
                checker = true;
            }

            Debug.Log(checker);
        }
    }
    public void PausingFunc()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0;
        
    }

    public void Continue()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void ExitTheGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}

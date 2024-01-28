using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonSceneLoader : MonoBehaviour
{
    public GameObject FirstButtons;
    public GameObject SecondButtons;
    public Image im;
    public GameObject otherVoice;
    public GameObject sa1;
    public GameObject sa2;
    
    public void PlayButton(string sceneName)
    {
        //SceneManager.LoadScene(sceneName);
        sa1.SetActive(true);
        sa2.SetActive(false);
    }

    public void ExitButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void OptionButton()
    {
        
        SecondButtons.SetActive(true);
        FirstButtons.SetActive(false);
        im.color = new Color(0, 0, 0 , 0.4f);
        otherVoice.SetActive(false);
    }
    public void BackToMainMenu()
    {
        SecondButtons.SetActive(false);
        FirstButtons.SetActive(true);
        otherVoice.SetActive(true);
    }

    public void BackToMainMenu2()
    {
        sa1.SetActive(false);
        sa2.SetActive(true);
    }
}

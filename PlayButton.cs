using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayButton : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Progetto_Gruppo_MickeyMike"); 
        

    }

    public void OnQuitButton()
    {
        Application.Quit();

    }

}

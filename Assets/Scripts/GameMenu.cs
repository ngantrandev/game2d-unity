using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
   
    public void StartGame()
    {
        SceneManager.LoadScene(1); // load first level
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

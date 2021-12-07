using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//new Main Menu scrip
public class resume : MonoBehaviour
{
    
    // Loads scenes for level1, mainmenu, and resume based on user input.

    public void GoToResume()
    {
        SceneManager.LoadScene(4);
    }

    public void GoToMainmenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(3);
    }
   
   
}

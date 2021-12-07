using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//new Main Menu scrip
public class MainMenu : MonoBehaviour
{

    // Declares Text field for player username.
    public Text playerDisplay;

    private void Start(){

        print("Mainmenu has loaded");

        // If user is loggedIn then the Players username will be displayed.

        if(DBManager.LoggedIn)
        {
            playerDisplay.text = "Player: "+ DBManager.username;
        }

    }

    public void GoToRegister()
    {
        // Loads Register Scene

        SceneManager.LoadScene(1);
        print("Register Scene Loaded");
    }

    public void GoToLogin()
    {
        // Loads Login Scene

        SceneManager.LoadScene(2);
    }

    public void GoToGame()
    {
        // Loads level1 Scene

        SceneManager.LoadScene(3);
    }
   
}

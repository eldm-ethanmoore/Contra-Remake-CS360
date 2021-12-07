using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{

    // Declares user input fields, submition button, and testing variable of type string.

    public InputField nameField;
    public InputField passwordField;
    public string TestUserNameIntegrationTest;
    public Button submitButton;

    public void CallRegister() {

        // Creates CoRoutine for Register function.

        StartCoroutine(Register());
    }

    IEnumerator Register()
    {

        // Indexes user input via php script that interfaces with MAMP database.

        TestUserNameIntegrationTest = "Username Indexed: "+nameField.text+" Password Indexed: "+passwordField.text;
        WWWForm form =new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/register.php", form);
        yield return www;
        if(www.text == "0")
        {
            Debug.Log("User created successfully "+TestUserNameIntegrationTest);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else 
        {
            Debug.Log("User creation failed.Error #" + www.text);
        }

    }

    public void VerifyInput()
    {
      
        // Requires user input for username and password to be at least 8 characters.

        submitButton.interactable = (nameField.text.Length >=8 && passwordField.text.Length >=8);
    }
}

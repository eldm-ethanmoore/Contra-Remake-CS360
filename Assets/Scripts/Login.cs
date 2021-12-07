using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    // Declares fields and button to submit field data.

    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin() {

        // CoRoutine for the LoginPlayer function.

        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {

        // Checks user input via php script that interfaces with MAMP database.

        WWWForm form =new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;
        if(www.text[0] == '0')
        {
            DBManager.username =nameField.text;
            DBManager.score =int.Parse(www.text.Split('\t')[1]);
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
        else 
        {
            Debug.Log("User login failed. Error #" + www.text);
        }
    }

    public void VerifyInput()
    {

        // Requires that the length of Password and Username is above 8 characters.

        submitButton.interactable = (nameField.text.Length >=8 && passwordField.text.Length >=8);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DBManager
{

    // Declares username and score vars

    public static string username;
    public static int score;

    // Getter for if user is loggedIn

    public static bool LoggedIn { get {return username!=null;  } }

    // LogOut sets username to null

    public static void LogOut() {
        username = null;
    }
}

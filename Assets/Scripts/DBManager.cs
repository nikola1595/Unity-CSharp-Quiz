using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DBManager
{



    public static string username;
    public static string password;
    public static int score;
    public int userid;


    
    








    public static bool LoggedIn
    {
        get
        {
            return username != null;
        }
    }

    public static void LoggedOut()
    {
        username = null;
    }
}

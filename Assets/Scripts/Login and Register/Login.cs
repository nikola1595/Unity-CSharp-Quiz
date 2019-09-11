using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;





public class Login : MonoBehaviour
{
 

    public InputField username;
    public InputField password;
    

    public Button submitButton;

    public string usernameid;

    public void CallLogin()
    {
        StartCoroutine(UserLogin());
    }

    IEnumerator UserLogin()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);
        
        WWW usernameid = new WWW("http://localhost:4433/Zickvi/register.php", form);
        yield return usernameid;

        if (usernameid.text == "0")
        {
            Debug.Log("User login failed. Error number #  " + usernameid.text);
        }
        else
        {
            DBManager.username = username.text;
            DBManager.password = password.text;

            

            Debug.Log("User loggin  sucessful.");
            username.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            SceneManager.LoadScene(1);
        }

        
/*
        WWW score = new WWW("http://localhost:4433/Zickvi/register.php");
        yield return score;

        */
  
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }
            if(password.GetComponent<InputField>().isFocused)
            {
                submitButton.GetComponent<InputField>().Select();
            }
        } 
    }


    public void VerificationInput()
    {
        submitButton.interactable = (username.text.Length >= 5  && password.text.Length >= 6 );
    }



    

  
}



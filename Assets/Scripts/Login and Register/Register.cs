using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Text.RegularExpressions;
using System.IO;
using UnityEngine.Networking;

public class Register : MonoBehaviour
{
   
    public Button submitButton;


    public InputField username;
    public InputField email;
    public InputField password;
    public InputField confirmPass;
  


    public void CallRegister()
    {
        StartCoroutine(Registration());
    }


    IEnumerator Registration()
    {

        WWWForm form = new WWWForm();
        form.AddField("username", username.text);
        form.AddField("password", password.text);
        form.AddField("email", email.text);

        
        WWW www = new WWW("http://localhost:4433/Zickvi/register.php", form);
        yield return www;// kad dobijemo informacije nazad od php-a, nastavice dalje sa kodom.

        if (www.text == "0")
        {
            Debug.Log("User created successfully.");
            username.GetComponent<InputField>().text = "";
            email.GetComponent<InputField>().text = "";
            password.GetComponent<InputField>().text = "";
            confirmPass.GetComponent<InputField>().text = "";
            // SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creation failed. Error number #  " + www.text);
        }
    }


    public void VerificationInput()
    {
        submitButton.interactable = (username.text.Length >= 5 && email.text.Contains("@") && email.text.Contains(".") &&
        password.text.Length >= 6 && password.text == confirmPass.text);
    }




    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (username.GetComponent<InputField>().isFocused)
            {
                email.GetComponent<InputField>().Select();
            }

            if (email.GetComponent<InputField>().isFocused)
            {
                password.GetComponent<InputField>().Select();
            }

            if (password.GetComponent<InputField>().isFocused)
            {
                confirmPass.GetComponent<InputField>().Select();
            }



        }


    }


}
        
       

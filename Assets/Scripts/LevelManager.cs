using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Transform mainMenu, leaderboard;


    public Text userDisplay;


    public void Start()
    {
        if (DBManager.LoggedIn)
        {
            userDisplay.text = "Player:  " + DBManager.username;
        }

    }
   

    public void LoadGame()
    {
        
        SceneManager.LoadScene(2);
    }
    
   public void QuitGame()
    {
        Application.Quit();
    }




    

    public void Leaderboard(bool clicked)
    {
        if(clicked == true)
        {
            leaderboard.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(false);
            SceneManager.LoadScene(3);
        }
        else
        {
            leaderboard.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(true);
        }
    }
    public void ReturnButton()
    {
        SceneManager.LoadScene(1);
    }
    
        
    
}

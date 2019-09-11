using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

using UnityEngine.Networking;

[Serializable]
public class PlayerData
{

    public string username;
    public int score;


    /*public PlayerData(string username, int score)
    {
        this.username = username;
        this.score = score;
    }*/

}


public class Scoreboard : MonoBehaviour
{
    [Header("SCORE DISPLAY")]
    public GameObject scoreObject;
    public GameObject scoreRoot;
    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI scoreDisplay;

    


    public string jsonData = "";
    public string content;

    IEnumerator Start()
    {

        /*   string getPlayersUrl = "http://localhost:4433/Zickvi/leaderboards.php";
           using (UnityWebRequest www = UnityWebRequest.Get(getPlayersUrl))
           {
               yield return www.Send();
               if(www.isNetworkError || www.isHttpError)
               {
                   Debug.Log(www.error);
               }
               else
               {
                   if(www.isDone)
                   {
                       string jsonResult = System.Text.Encoding.UTF8.GetString(www.downloadHandler.data);
                       Debug.Log(jsonResult);
                       PlayerData[] leaderboard = JsonConvert.DeserializeObject<PlayerData[]>(jsonResult);

                   }
               }
           }
           */
        WWW leaderboardData = new WWW("http://localhost:4433/Zickvi/leaderboards.php");
        yield return leaderboardData;
        // Debug.Log(leaderboardData.text);
        if (string.IsNullOrEmpty(leaderboardData.error))
        {
            //jsonData = leaderboardData.text;
            //  jsonData = "{\"Leaderboard\":"+leaderboardData.text+"}";
            jsonData = leaderboardData.text;
            Debug.Log(jsonData);
        }

        content = "{\"Leaderboard\":" + jsonData + "}";

        var ctn = "{\"Leaderboard\":" + jsonData + "}";

        PlayerData result = new PlayerData();

            List<RootObject> players = new List<RootObject>();
        // RootObject result = JsonUtility.FromJson<RootObject>(content);
        // OVAJ RootObject result = JsonUtility.FromJson<RootObject>(content);
        result = JsonUtility.FromJson<PlayerData>(ctn);
        //var result = JsonConvert.DeserializeObject<RootObject>(content);
        Debug.Log(result);
        //var usernames = result.Players.Select(p => p.username).ToList();
        //var scores = result.Players.Select(p => p.score).ToList();

        //var usernames = result.Players.Select(p => p.username).ToList();

        //Debug.Log(usernames[0]);
        //Debug.Log(scores[0]);

        if (result != null)
        {
            /*
            for (int i = 0; i < 10; i++)
            {

                var username = result.Players[i].username;
                var score = result.Players[i].score;

                var usernames = result.Players.Select(p => p.username).ToList();
                var scores = result.Players.Select(p => p.score).ToList();

                Debug.Log("debug");

                
                Debug.Log(usernames);
                Debug.Log(scores);
            }*/

        }

        
        
        


        // File.WriteAllText(Application.dataPath + "/Assets/Resources/leaderboard", content);
    }

    [Serializable]
    public class RootObject
    {
        public  List<PlayerData> Players { get; set; }
        //public PlayerData[] leaderboard = null;

    }

    public void CallJson()
    {
        Debug.Log("nesto");
        StartCoroutine(Start());
        StartCoroutine(StartList());

    }


    

    public IEnumerator StartList()
    {
        while (scoreRoot.transform.childCount > 0)
        {
            Destroy(scoreRoot.transform.GetChild(0).gameObject);
            yield return null;
        }

        // List<RootObject> players = new List<RootObject>();
        List<PlayerData> playerScore = new List<PlayerData>();
        foreach (var line in playerScore)
        {

            nameDisplay.text = line.username;
            scoreDisplay.text = line.score.ToString();

            
            GameObject instantiatedScore = Instantiate(scoreObject, scoreRoot.transform);

            instantiatedScore.SetActive(true);
            instantiatedScore.transform.SetParent(scoreRoot.transform);

            //playerScore.Add(new PlayerData(line.username, line.score));

          //  nameDisplay.text = line.username;
           // scoreDisplay.text = line.score.ToString();


        }

        
        /*       public static string LoadJsonAsResource(string path)
       {
           string jsonFilePath = path.Replace(".json", "");
           TextAsset loadedJsonfile = Resources.Load<TextAsset>(jsonFilePath);
           return loadedJsonfile.text;
       }*/

       
      /*  List<PlayerData> GetScore()
        {
            List<PlayerData> players = new List<PlayerData>();

            for (int i = 1; i < 20; i++)
            {
                if (players == null)
                {
                    players.Add(PlayerData(nameDisplay.text, int.Parse(scoreDisplay.text)));
                }
                else
                {
                    break;
                }

            }

            return players;

        }*/

    }


}
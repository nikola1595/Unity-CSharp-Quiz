using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using TMPro;





[System.Serializable]
public class LeaderboardList
{
    public List<Player> leaderboard = new List<Player>();
}



[System.Serializable]
public class Player
{
    public string username;
    public int score;


    public Player(string username, int score)
    {
        this.username = username;
        this.score = score;
    }

}



public class Leaderboard : MonoBehaviour
{
    [Header("SCORE DISPLAY")]
    public GameObject scoreObject;
    public GameObject scoreRoot;
    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI scoreDisplay;



   public LeaderboardList LeaderboardList = new LeaderboardList();

    public string jsonData;

    public Player playerScore;

    void Start()
    {
       // playerScore = JsonUtility.FromJson<Player>(Leaderboard.LoadJsonFromFile("Leaderboard.json",false));
        
    }
    

    

    

    static Leaderboard scoreBoard;
    //  public int scoreCount = 10;

    public void CallScore()
    {
        StartCoroutine(RequestCorutine());
    }

    public void CallStart()
    {
        StartCoroutine(StartList());
    }

    public IEnumerator StartList()
    {
        while (scoreRoot.transform.childCount > 0)
        {
            Destroy(scoreRoot.transform.GetChild(0).gameObject);
            yield return null;
        }


        List<Player> playerScore = GetScore();
        foreach (Player line in playerScore)
        {

            nameDisplay.text = line.username;
            scoreDisplay.text = line.score.ToString();


            GameObject instantiatedScore = Instantiate(scoreObject, scoreRoot.transform);

            instantiatedScore.SetActive(true);
            instantiatedScore.transform.SetParent(scoreRoot.transform);

            playerScore.Add(new Player(line.username, line.score));

            Debug.Log(line.username);
            Debug.Log(line.score);

        

        }
    }


    // Start is called before the first frame update
    IEnumerator RequestCorutine()
    {
        scoreBoard = this;
        WWW leaderboardData = new WWW("http://localhost:4433/Zickvi/leaderboards.php");
        yield return leaderboardData;

        if (string.IsNullOrEmpty(leaderboardData.error))
        {
           // jsonData = leaderboardData.text;
            jsonData ="{" + "Leaderboard"+":"+ leaderboardData.text+"}";
            //jsonData = System.Text.Encoding.UTF8.GetString(leaderboardData.bytes, 3, leaderboardData.bytes.Length - 3);
        }



       

        File.WriteAllText(Application.dataPath + "/Leaderboard.json ", jsonData);
        


        //string jsonString = File.ReadAllText(Application.dataPath + "/Leaderboard.json");

        // Debug.Log(GetScores("uros", 12));


/*
        string json = JsonUtility.ToJson(jsonString);
        Debug.Log(jsonString);
       */ 
        TextAsset asset = Resources.Load("Leaderboard") as TextAsset;
        if (asset != null)
        {
            LeaderboardList = JsonUtility.FromJson<LeaderboardList>(asset.text);
            foreach (Player play in LeaderboardList.leaderboard)
            {
                print(play.username);
                print(play.score);
            }
        }
        else
        {
            print("Asset is null");
        }
/*
        Player loadedPlayerData = JsonUtility.FromJson<Player>(json);

        Debug.Log(loadedPlayerData.username);
        Debug.Log(loadedPlayerData.score);*/
      //  Debug.Log("username" + loadedPlayerData.username);
        //Debug.Log("score" + loadedPlayerData.score);
    }

    public static string LoadJsonFromFile(string path, bool isResource)
    {
        if(isResource)
        {
            return LoadJsonAsResource(path);
        }
        else
        {
            return LoadJsonASExternalResource(path);
        }
    }


    public static string LoadJsonAsResource(string path)
    {
        string jsonFilePath = path.Replace(".json", "");
        TextAsset loadedJsonfile = Resources.Load<TextAsset>(jsonFilePath);
        return loadedJsonfile.text;
    }

    public static string LoadJsonASExternalResource(string path)
    {
        path = Application.persistentDataPath +"/"+ path;
        if(!File.Exists(path))
        {
            return null;
        }

        StreamReader stream = new StreamReader(path);
        string response = "";
        while(!stream.EndOfStream)
        {
            response += stream.ReadLine();
        }
        return response;
    }


    // Update is called once per frame
    void Update()
    {

    }


    private void Awake()
    {
        if (DBManager.username == null)
        {
            SceneManager.LoadScene(0);
        }



        
/*
        DBManager.username = nameDisplay.text;
        DBManager.score = int.Parse(scoreDisplay.text);

        nameDisplay.text = "Player: " + DBManager.username;
        scoreDisplay.text = "Score: " + DBManager.score;

    */
    }
    /*
    JsonData GetScores(string username, int score)
    {
        for(int i = 0; i< jsonData[score]; i++)
        {
            if (DataJson[score][i]["username"].ToString() == username || int.Parse(DataJson[score][i]["score"].ToString()) == score)
                return DataJson[score][i];
        }
        return null;
    }
    
    */

    public  List<Player> GetScore()
    {
        List<Player> playerScores = new List<Player>();
        
        for (int i = 0; i < 20;i++)
        {
            if (playerScores == null)
            {
                playerScores.Add(new Player(nameDisplay.text, int.Parse(scoreDisplay.text)));
            }
            else
            {
                break;
            }
            
        }

        return playerScores;
    }
}






 

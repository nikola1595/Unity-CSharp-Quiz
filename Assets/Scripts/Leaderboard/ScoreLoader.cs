using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLoader : MonoBehaviour
{
    public List<PlayerData> players;



    void Awake()
    {
        players = new List<PlayerData>();
       //LoadPlayer("Leaderboard.json");
        //LoadPlayer("Leaderboard.json");

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*

    public void LoadPlayer(string path)
    {
        string loadPlayer = Scoreboard.LoadJsonAsResource(path);
        //Debug.Log(loadPlayer);
        PlayerData playerLine = JsonUtility.FromJson<PlayerData>(loadPlayer);
        players.Add(playerLine);
    }
    */
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System;

public class GameUtility
{
    public const float ResolutionDelayTime = 1;
    public const string SavePrefKey = "Game_Highscore_Value";

    public const string FileName = "Q";

    public static string fileDirectory
    {
        get
        {
            return Application.dataPath + "/";
        }
    }
}

[Serializable()]
public class GameData
{



    public Question[] Questions = new Question[0];
    public GameData() { }

    public static void Write(GameData data,string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GameData));
        using (Stream stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, data);
        }

    }


    public static GameData Fetch (string filePath)
    {
        return Fetch(out bool result,filePath);
    }

    public static GameData Fetch(out bool result, string filePath)
    {
        if(!File.Exists(filePath))
        {
            result = false;
            return new GameData();
        }

        XmlSerializer deserilizer = new XmlSerializer(typeof(GameData));
        using (Stream stream = new FileStream(filePath, FileMode.Open))
        {
            var data = (GameData)deserilizer.Deserialize(stream);
            result = true;
            return data;
        }
    }
}


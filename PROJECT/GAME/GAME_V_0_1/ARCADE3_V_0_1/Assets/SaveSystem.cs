using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    //TEMP SAVE PLAYER DATA
    public static void SaveScore(Player player)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ScoreData.Arcade3";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("ScoreData Saved At " + path);
    }


    //SAVE NEW HIGH SCORE DATA
    public static void SaveNewHighScore(HighScore HighScore)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/HighScoreData.Arcade3";
        FileStream stream = new FileStream(path, FileMode.Create);

        HighScoreData data = new HighScoreData(HighScore);

        formatter.Serialize(stream, data);
        stream.Close();
        Debug.Log("HighScoreData Saved At " + path);
    }

    //LOAD HIGH SCORE DATA
    public static HighScoreData LoadHighScore()
    {
        string path = Application.persistentDataPath + "/HighScoreData.Arcade3";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HighScoreData data = formatter.Deserialize(stream) as HighScoreData;

            stream.Close();
            Debug.Log("HighScoreData Savefile Loaded From " + path);
            return data;
        }
        else
        {
            Debug.LogError("HighScoreData Savefile Missing From " + path);
            return null;

        }
    }

    //LOAD TEMP PLAYERS DATA
    public static PlayerData LoadScore()
    {
        string path = Application.persistentDataPath + "/ScoreData.Arcade3";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
            Debug.Log("ScoreData Savefile Loaded From " + path);
            return data;
        }
        else
        {
            Debug.LogError("ScoreData Savefile Missing From " + path);
            return null;

        }
    }
}

using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    //TEMP SAVE PLAYER DATA
    public static void SaveScore(Player player)
    {
        //Creates Formatter to take data
        BinaryFormatter formatter = new BinaryFormatter();
        //Location to save file. "" File name and extention. "persistentDataPath" windows - c:\User\###\Appdata\localLow\DefaultCompany\
        string path = Application.persistentDataPath + "/ScoreData.Arcade3";
        //Creates the new file in the "path"
        FileStream stream = new FileStream(path, FileMode.Create);
        //Takes the data
        PlayerData data = new PlayerData(player);
        //Take data and file and serialize them to save the data to file.
        formatter.Serialize(stream, data);
        //Closes the saved file
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
        //Loads the files location
        string path = Application.persistentDataPath + "/ScoreData.Arcade3";
        if (File.Exists(path))
        {
            //If there is a file there, create the formatter
            BinaryFormatter formatter = new BinaryFormatter();
            //Open the file in the location
            FileStream stream = new FileStream(path, FileMode.Open);
            //Deserialize, take data from file
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            //Closes the saved file
            stream.Close();
            Debug.Log("ScoreData Savefile Loaded From " + path);
            //data is then returned to activation location and the data can be taken from the veriables. 
            return data;
        }
        else
        {
            //No file in location.
            Debug.LogError("ScoreData Savefile Missing From " + path);
            return null;

        }
    }
}

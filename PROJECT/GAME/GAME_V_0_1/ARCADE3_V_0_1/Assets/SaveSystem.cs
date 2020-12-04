using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{
    public static void SaveScore(PointsSystem points)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/ScoreData.Arcade3";
        FileStream stream = new FileStream(path, FileMode.Create);

        PointsData data = new PointsData(points);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PointsData LoadScore()
    {
        string path = Application.persistentDataPath + "/ScoreData.Arcade3";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PointsData data = formatter.Deserialize(stream) as PointsData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Savefile Missing" + path);
            return null;

        }
    }
}

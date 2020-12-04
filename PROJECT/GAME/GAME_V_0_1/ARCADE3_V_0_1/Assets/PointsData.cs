using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PointsData
{
    public string PlayerName;
    public int Score;
    public string HighScoreName;
    public int HighScore;

    //PlayerChar
    //HighScoreChar
    //
    public PointsData (PointsSystem points)
    {
        //PlayerName = //playerData.cs
        //Score = //playerData.cs
        HighScoreName = "TestDummby";
        HighScore = 99999;

    }
}

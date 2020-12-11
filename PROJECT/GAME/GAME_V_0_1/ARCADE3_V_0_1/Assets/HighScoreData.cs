using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreData
{
    public string HighScorePlayerName;
    public int HighScoreInt;
    //Model


    public HighScoreData(HighScore HighScore)
    {
        HighScorePlayerName = HighScore.HighScorePlayerName;
        HighScoreInt = HighScore.HighScoreInt;

    }


}

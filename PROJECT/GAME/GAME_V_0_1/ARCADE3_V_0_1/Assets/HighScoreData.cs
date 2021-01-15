using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreData
{
    public string HighScorePlayerName;
    public int HighScoreInt;
    //Model
    enum Tex
    {
        Tex1,
        Tex2,
        Tex3,
        Tex4
    }

    public HighScoreData(HighScore HighScore)
    {
        HighScorePlayerName = HighScore.HighScorePlayerName;
        HighScoreInt = HighScore.HighScoreInt;

    }


}

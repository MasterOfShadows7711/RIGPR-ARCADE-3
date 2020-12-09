using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PlayerData 
{
    public string PlayerName;
    public int Score;

    public PlayerData(PointsSystem points)
    {
        //DUMMY TEST
        PlayerName = "DUMMY TEST";
        Score = 9999;
        
    }
}

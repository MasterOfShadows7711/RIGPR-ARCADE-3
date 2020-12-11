using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public string HighScorePlayerName;
    public int HighScoreInt;

    Text MyText;


    // Start is called before the first frame update
    void Awake()
    {
        //SaveSystem.SaveNewHighScore(this); DEBUG ONLY
        HighScoreData data = SaveSystem.LoadHighScore();
        HighScorePlayerName = data.HighScorePlayerName;
        HighScoreInt = data.HighScoreInt;
        MyText = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        MyText.text = "High Score: " + HighScorePlayerName + " " + HighScoreInt;
    }
}

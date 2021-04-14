using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    bool CoinLoaded = false;

    //public Animator Transition;

    // Start is called before the first frame update
    void Start()
    {
        GameStart();
        //FindObjectOfType<Player>().PlayerName = "";
        //FindObjectOfType<Player>().Score = 1000;

        //SaveSystem.SaveScore(FindObjectOfType<Player>());

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKey)
        {
            FindObjectOfType<LevelTransision>().LevelChange();



        }
    }

    public void GameStart()
    {
        //CoinLoaded = true;
        

    }    
}



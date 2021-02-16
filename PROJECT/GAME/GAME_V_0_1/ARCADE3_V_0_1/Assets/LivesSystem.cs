using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesSystem : MonoBehaviour
{
    public static bool GameOver = false;
    public static int lives = 3;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {






        if (lives == 0)
        {
            GameOver = true;

            SaveSystem.SaveScore(GetComponent<Player>());

        }


    }
}

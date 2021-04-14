using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesSystem : MonoBehaviour
{
    public Animator HeartUI;
    
    public static bool DebugGameOver = false;
    public static int lives = 3;
    
    public Image Heart_3;
    public Image Heart_2;
    public Image Heart_1;
    public Image GameOver;
    // Start is called before the first frame update
    void Start()
    {
        GameOver.enabled = false;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.End))
        {
            lives--;
            //Debug.Log("Lives count " + lives);
        }


        if (lives == 3)
        {
            //Debug.Log("Lives count " + lives);

        }
        if (lives == 2)
        {
            //Debug.Log("Lives count " + lives);
            StartCoroutine(RemoveHeart3());
            

            Heart_3.enabled = false;
        }
        if (lives == 1)
        {
            StartCoroutine(RemoveHeart2());
            
            Heart_2.enabled = false;

        }
        if (lives == 0)
        {
            
            StartCoroutine(RemoveHeart1());
            

            Heart_1.enabled = false;
            DebugGameOver = true;
            GameOver.enabled = true;

            FindObjectOfType<Player>().Score = 0;
            SaveSystem.SaveScore(FindObjectOfType<Player>());
            FindObjectOfType<Player>().enabled = false;
            DelayTimerFunc();
            FindObjectOfType<LevelTransision>().MainMenu();

        }


    }


    IEnumerator RemoveHeart3()
    {
        HeartUI.SetTrigger("LiveLost");
        yield return new WaitForSeconds(1.5f);
    }
    IEnumerator RemoveHeart2()
    {
        HeartUI.SetTrigger("LiveLost");
        yield return new WaitForSeconds(1.5f);
    }
    IEnumerator RemoveHeart1()
    {
        HeartUI.SetTrigger("LiveLost");
        yield return new WaitForSeconds(1.5f);
    }

    public void DelayTimerFunc()
    {

        StartCoroutine(DelayTimer());

    }

    IEnumerator DelayTimer()
    {
        yield return new WaitForSeconds(5);
    }

}

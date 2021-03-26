using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesSystem : MonoBehaviour
{
    public Animator HeartUI;
    
    public static bool GameOver = false;
    public static int lives = 3;
    
    public Image Heart_3;
    public Image Heart_2;
    public Image Heart_1;
    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.End))
        {
            lives--;
            Debug.Log("Lives count " + lives);
        }


        if (lives == 3)
        {
            //Debug.Log("Lives count " + lives);

        }
        else if (lives == 2)
        {
            Debug.Log("Lives count " + lives);
            StartCoroutine(RemoveHeart3());

            Heart_3.enabled = false;
        }
        else if (lives == 1)
        {
            StartCoroutine(RemoveHeart2());
            Heart_2.enabled = false;

        }
        else if (lives == 0)
        {
            GetComponent<Player>().enabled = false;
            StartCoroutine(RemoveHeart1());

            Heart_1.enabled = false;
            GameOver = true;

            //SaveSystem.SaveScore(GetComponent<Player>());

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
}

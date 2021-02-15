using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;

    public AudioClip BackgroundMusic;
    private AudioSource Source;
    
    void Start()
    {
        Source = GetComponent<AudioSource>();
        Source.Play();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) //To Pause the game
        {
            Debug.Log("ESC pressed");
            if (Paused)
            {
                
                Resume();
                Paused = false;

            }
            else 
            {   
                Pause();
                Paused = true;
            }
            
        }
        


    }
    void Pause()
    {
        //PauseUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;

    }

    void Resume()
    {
        //PauseUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }
}

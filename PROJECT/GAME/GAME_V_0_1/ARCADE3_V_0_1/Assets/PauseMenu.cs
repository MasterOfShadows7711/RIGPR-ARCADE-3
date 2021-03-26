using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool Paused = false;

    public AudioClip BackgroundMusic;
    private AudioSource Source;
    public Text PausedText;
    public Text GameOverDebugText;
    public Text PlayerPosText;
    public Text BlockPosText;
    public Text PlayerLivesText;
    public Text ToQuitText;

    public Image UIBacking0;
    public Image UIBacking1;
    public Image UIBacking2;
    public Image UIBacking3;
    public Image UIBacking4;

    void Start()
    {
        Paused = false;

        UIBacking0.enabled = false;
        UIBacking1.enabled = false;
        UIBacking2.enabled = false;
        UIBacking3.enabled = false;
        UIBacking4.enabled = false;

        PausedText.enabled = false;
        PlayerPosText.enabled = false;
        BlockPosText.enabled = false;
        GameOverDebugText.enabled = false;
        PlayerLivesText.enabled = false;
        ToQuitText.enabled = false;

        Source = GetComponent<AudioSource>();
        Source.Play();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerPosText.text = "Player Pos: " + FindObjectOfType<Player>().transform.position;
        //BlockPosText.text = "Block Pos: " + FindObjectOfType<Tetris>().transform.position;
        GameOverDebugText.text = "GameOver Status: " + LivesSystem.GameOver;
        PlayerLivesText.text = "Player Lives: " + LivesSystem.lives;

        if (Input.GetKeyDown(KeyCode.Escape)) //To Pause the game
        {
            Debug.Log("ESC pressed");
            if (Paused)
            {
                
                Resume();
                //Paused = false;

            }
            else 
            {
                //TextFlash();
                Pause();
                
                //Paused = true;
            }
            
        }
        if (Paused && Input.GetKeyDown(KeyCode.F1))
        {
            Application.Quit();
        }

    }

    void Pause()
    {
        UIBacking0.enabled = true;
        UIBacking1.enabled = true;
        UIBacking2.enabled = true;
        UIBacking3.enabled = true;
        UIBacking4.enabled = true;
        PausedText.enabled = true;
        PlayerPosText.enabled = true;
        BlockPosText.enabled = true;
        GameOverDebugText.enabled =true;
        PlayerLivesText.enabled = true;
        ToQuitText.enabled = true;
        Time.timeScale = 0f;
        Paused = true;
    }

    void Resume()
    {
        UIBacking0.enabled = false;
        UIBacking1.enabled = false;
        UIBacking2.enabled = false;
        UIBacking3.enabled = false;
        UIBacking4.enabled = false;
        PausedText.enabled = false;
        PlayerPosText.enabled = false;
        BlockPosText.enabled = false;
        GameOverDebugText.enabled = false;
        PlayerLivesText.enabled = false;
        ToQuitText.enabled = false;
        Time.timeScale = 1f;
        Paused = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransision : MonoBehaviour
{
    public Animator Transition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelChange()
    {
        //CoinLoaded = true;
        StartCoroutine(LoadNextLevel());

    }

    public void LevelChangeBoss()
    {
        StartCoroutine(LoadBOSSLevel());

    }
    public void MainMenu()
    {
        StartCoroutine(MainMenuLoader());

    }

    public void LevelDebugRoom()
    {
        StartCoroutine(LoadDebugRoom());

    }

    IEnumerator LoadDebugRoom()
    {
        Transition.SetTrigger("LevelStart");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(5);

    }


    IEnumerator LoadBOSSLevel()
    {
        Transition.SetTrigger("LevelStart");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(4);

    }

    IEnumerator LoadNextLevel()
    {
        Transition.SetTrigger("LevelStart");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);

    }

    IEnumerator MainMenuLoader()
    {
        yield return new WaitForSeconds(5);
        Transition.SetTrigger("LevelStart");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);

    }

}

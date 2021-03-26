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

    IEnumerator LoadNextLevel()
    {
        Transition.SetTrigger("LevelStart");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);

    }

}

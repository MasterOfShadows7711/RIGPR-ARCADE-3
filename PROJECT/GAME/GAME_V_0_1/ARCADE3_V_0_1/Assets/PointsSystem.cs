using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointsSystem : MonoBehaviour
{
    public Text PointsUI;

    public int Points;

    public void Start()
    {
        DelayTimerFunc();

        Points = FindObjectOfType<Player>().Score;

    }

    public void Update()
    {
        
        PointsUI.text = "" + Points;

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

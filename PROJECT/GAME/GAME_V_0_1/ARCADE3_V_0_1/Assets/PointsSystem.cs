using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{
    public void Save()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("SAVE");
            SaveSystem.SaveScore(this);
        }
    }       
}

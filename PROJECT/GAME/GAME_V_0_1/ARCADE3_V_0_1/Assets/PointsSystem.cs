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
        Points = 10000;

    }

    public void Update()
    {

        PointsUI.text = "" + Points;

    }


}

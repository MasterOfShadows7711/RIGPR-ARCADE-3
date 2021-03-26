using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombCountDownTimer : MonoBehaviour
{
    //public GameObject[] CanvasForBomb;
    public Text BombTime;
    int RoundedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RoundedTime = Mathf.RoundToInt(FindObjectOfType<ThrownObject>().BombDetinationTime);
        BombTime.text = "" + RoundedTime;//FindObjectOfType<ThrownObject>().BombDetinationTime;
        Vector3 TimePos = Camera.main.WorldToScreenPoint(this.transform.position);
        BombTime.transform.position = TimePos;
    }
}

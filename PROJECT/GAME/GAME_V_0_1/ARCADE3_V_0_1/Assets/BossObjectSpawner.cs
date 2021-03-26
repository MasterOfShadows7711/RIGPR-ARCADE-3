using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObjectSpawner : MonoBehaviour
{
    public GameObject[] Throw_Objects;
    public GameObject[] Throw_Bomb;
    float PlayerX;
    float PlayerY;
    float ThrowHightY;
    float ThrowDistanceX;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = GetComponent<Boss>().transform.position;
        PlayerX = FindObjectOfType<Player>().transform.position.x;
        PlayerY = FindObjectOfType<Player>().transform.position.y;

        ThrowHightY = PlayerY * 2;
        ThrowDistanceX = transform.position.x - PlayerX;

    }

    public void ThrowObject()
    {
        Instantiate(Throw_Objects[Random.Range(0, Throw_Objects.Length)], transform.position = FindObjectOfType<Boss>().transform.position, transform.rotation = FindObjectOfType<Boss>().transform.rotation);

        //Vector2 thrownDirection = FindObjectOfType<Player>().transform.position;
        //FindObjectOfType<ThrownObject>().Setup(thrownDirection);
        FindObjectOfType<ThrownObject>().Setup();


    }

    public void ThrowBomb()
    {
        Instantiate(Throw_Bomb[Random.Range(0, Throw_Bomb.Length)], transform.position = FindObjectOfType<Boss>().transform.position, transform.rotation = FindObjectOfType<Boss>().transform.rotation);

        //Vector2 thrownDirection = FindObjectOfType<Player>().transform.position;
        //FindObjectOfType<ThrownObject>().Setup(thrownDirection);
        FindObjectOfType<ThrownObject>().Setup();


    }

}

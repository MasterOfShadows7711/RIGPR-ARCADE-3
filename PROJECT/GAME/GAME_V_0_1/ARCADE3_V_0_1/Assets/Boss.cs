using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss : MonoBehaviour
{
    int thrownTotel;
    private float PreviousThrowTime;
    public float ThrowSpeed;
    public bool Floor1;
    public bool Floor2;
    public bool BossFloor;
    public bool NewGame; 

    // Start is called before the first frame update
    void Start()
    {
        //NewGame = false;
        PlayerData data = SaveSystem.LoadScore();
        FindObjectOfType<Player>().PlayerName = data.PlayerName;
        FindObjectOfType<Player>().Score = data.Score;
        FindObjectOfType<PointsSystem>().Points = FindObjectOfType<Player>().Score;
        Debug.LogError("  " + FindObjectOfType<Player>().Score + "  " + data.Score);
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        FindObjectOfType<Player>().transform.position = position;

        ThrowSpeed = 3;
        thrownTotel = 0;
        BossFloor = false;
        Floor1 = false;
        Floor2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Objet name " + FindObjectOfType<ThrownObject>().Objname);

        if (Time.time - PreviousThrowTime > ThrowSpeed)
        {
            Debug.Log("AutoThrow Pass");
            if (thrownTotel == 10 || thrownTotel == 20 || thrownTotel == 30 || thrownTotel == 40 || thrownTotel == 50)
            {
                //BOMB
                Debug.Log("Objet name " + FindObjectOfType<ThrownObject>().Objname);
                FindObjectOfType<BossObjectSpawner>().ThrowBomb();
                thrownTotel++;
                ThrowSpeed -= .5f;
            }
            //if (thrownTotel == 0)
            //{
            //    //NON IN SCENE
            //    FindObjectOfType<BossObjectSpawner>().ThrowObject();
            //    Debug.Log("Objet name " + FindObjectOfType<ThrownObject>().Objname);
            //    thrownTotel++;
            //}
            if (!FindObjectOfType<ThrownObject>())
            {
                FindObjectOfType<BossObjectSpawner>().ThrowObject();
                Debug.Log("Objet name " + FindObjectOfType<ThrownObject>().Objname);
                thrownTotel++;
            }
            else if (FindObjectOfType<ThrownObject>().Objname != "Bomb Variant(Clone)")
            {
                Debug.Log("Objet name " + FindObjectOfType<ThrownObject>().Objname);
                FindObjectOfType<BossObjectSpawner>().ThrowObject();
                thrownTotel++;

            }
            
            

            PreviousThrowTime = Time.time;
        }
    }
}

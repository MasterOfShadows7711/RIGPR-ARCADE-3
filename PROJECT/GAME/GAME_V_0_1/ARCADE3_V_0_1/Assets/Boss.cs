using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    int thrownTotel;

    // Start is called before the first frame update
    void Start()
    {
        thrownTotel = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (thrownTotel == 10)
            {
                FindObjectOfType<BossObjectSpawner>().ThrowBomb();
                thrownTotel++;
            }
            else
            {
                FindObjectOfType<BossObjectSpawner>().ThrowObject();
                thrownTotel++;
            }
            
        }
    }
}

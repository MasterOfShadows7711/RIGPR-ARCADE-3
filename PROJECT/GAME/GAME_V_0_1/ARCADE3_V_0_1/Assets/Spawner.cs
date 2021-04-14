using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Blocks;
    int MaxBlocks;
    public float FallSpeed;


    // Start is called before the first frame update
    void Start()
    {
        FallSpeed = 50;
        MaxBlocks = 0;
        NewBlock();
    }

    // Update is called once per frame
    public void NewBlock()
    {
        MaxBlocks++;
        if (MaxBlocks >= 49)
        {
            Destroy(this);
        }
        else
        {
            Instantiate(Blocks[Random.Range(0, Blocks.Length)], transform.position, transform.rotation);
            FallSpeed -= 0.5f;

        }
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Blocks;


    // Start is called before the first frame update
    void Start()
    {
        NewBlock();
    }

    // Update is called once per frame
    public void NewBlock()
    {
        //
        Instantiate(Blocks[Random.Range(0, Blocks.Length)],transform.position, transform.rotation);
    }


}

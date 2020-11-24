using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris : MonoBehaviour
{
    // Grid to hold Tetris blocks 
    public int Columns, Rows;
    public float ColumnSpace, RowSpace;


    //Start location for the object
    public float XStart, YStart, ZStart;


    //The Tetris shapes
    public GameObject Square; //find Shape in menu
    public GameObject Triangle; //find Shape in menu
    public GameObject Hexagon; //find Shape in menu

    //Fall System
    //Dose time incress with points
    private float PreviousFallTime;
    public float FallingTime = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //spawner Creates a grid of blocks, one for each type. 
        //for (int i = 0; i < Columns * Rows; i++)
        //{
        //    Instantiate(Square, new Vector3(XStart + (ColumnSpace * (i % Columns)),YStart + (-RowSpace * (i / Columns)), ZStart), Quaternion.identity);
        //    Instantiate(Triangle, new Vector3(XStart + (ColumnSpace * (i % Columns)), YStart + (-RowSpace * (i / Columns)), ZStart), Quaternion.Euler(-90,0,0));
        //    Instantiate(Hexagon, new Vector3(XStart + (ColumnSpace * (i % Columns)), YStart + (-RowSpace * (i / Columns)), ZStart), Quaternion.identity);
        //}

        
    }

    // Update is called once per frame
    void Update()
    {
        //Controls
        // A Left
        // D Right
        // Space DROP

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Rotate(0, 0, 90);
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Rotate(0, 0, -90);
        }



        //Fall area
        if (Time.time - PreviousFallTime > (Input.GetKey(KeyCode.Space) ? FallingTime / 10 : FallingTime))
        {
            transform.position += new Vector3(0, -1, 0);
            PreviousFallTime = Time.time;
        }


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris : MonoBehaviour
{
    // Grid to hold Tetris blocks 
    //public int Columns, Rows;
    //public float ColumnSpace, RowSpace;

    //New grid system 25/11/20
    //public static int GridHight = 10;
    //public static int GridWidth = 10;
    //public static int GridDepht = 5;
    public static int SetShapesX = 0;
    public static int SetShapesY = 0;

    private static Transform[,] SetShapes = new Transform[SetShapesX, SetShapesY];

    //Start location for the object
    //public float XStart, YStart, ZStart;


    //The Tetris shapes
    //public GameObject Square; //find Shape in menu
    //public GameObject Triangle; //find Shape in menu
    //public GameObject Hexagon; //find Shape in menu

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
        // Q Rotate AntiClockwise
        // E Rotate Clockwise

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!GridCheck())
                transform.position -= new Vector3(-1, 0, 0);
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!GridCheck())
                transform.position -= new Vector3(1, 0, 0);
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
        if (Time.time - PreviousFallTime > (Input.GetKey(KeyCode.Space) ? FallingTime / 10 : FallingTime)) //If Space is pressed move block 10* faster.
        {
            transform.position += new Vector3(0, -1, 0);
            if (!GridCheck())
            {
                transform.position -= new Vector3(0, -1, 0);
                this.enabled = false;
                FindObjectOfType<Spawner>().NewBlock();
            }

            PreviousFallTime = Time.time;
        }

        void ShapesInGrid()
        { 

        }

        bool GridCheck()
        {
            //foreach  (Transform Shapes in transform)
            //{
                //int GridX = Mathf.RoundToInt(Shapes.transform.position.x); //Rounds the X Position to an Int 
                //int GridY = Mathf.RoundToInt(Shapes.transform.position.y); //Rounds the Y Position to an Int 
                //int GridZ = Mathf.RoundToInt(Shapes.transform.position.z); //Rounds the Y Position to an Int 


                //if (GridX < 0 || GridX >=GridWidth || GridY < 0 || GridY >= GridHight || GridZ < 0 ||GridZ >=GridDepht) //Is shapes X axis in the grid, Is shapes Y axis in the grid
                if (transform.position.x <= -5 || transform.position.x >= 5 || transform.position.y <= -1)
                {
                    return false;
                }

            //}

            return true; // If the shape is not out side
        }
    }
}

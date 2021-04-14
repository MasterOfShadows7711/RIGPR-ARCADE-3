using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetris : MonoBehaviour
{
    // Grid to hold Tetris blocks 
    //public int Columns, Rows;
    //public float ColumnSpace, RowSpace;

    //New grid system Not used
    //public static int GridHight = 10;
    //public static int GridWidth = 10;
    //public static int GridDepht = 5;
    //public static float SetShapesX = 15.0f;
    //public static float SetShapesY = 50.0f;
    //public static float SetShapesZ = 5.0f;

    //public Vector3[] SetShapes = new Vector3[50];

    int i = 1;

    public string Objname;

    //int FallSpeed;


    //Vector3[] SetShaps = new Vector3[50];


    //Start location for the object
    //public float XStart, YStart, ZStart;


    //The Tetris shapes
    //public GameObject Square; //find Shape in menu
    //public GameObject Triangle; //find Shape in menu
    //public GameObject Hexagon; //find Shape in menu

    //Fall System
    //Dose time incress with points
    private float PreviousFallTime;
    public float FallingTime = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        //StorageArray.SetShapes[0].x = 999;
        //StorageArray.SetShapes[0].y = 999;
        //StorageArray.SetShapes[0].z = 999;

        //spawner Creates a grid of blocks, one for each type. Used for Debug.
        //for (int i = 0; i < Columns * Rows; i++)
        //{
        //    Instantiate(Square, new Vector3(XStart + (ColumnSpace * (i % Columns)),YStart + (-RowSpace * (i / Columns)), ZStart), Quaternion.identity);
        //    Instantiate(Triangle, new Vector3(XStart + (ColumnSpace * (i % Columns)), YStart + (-RowSpace * (i / Columns)), ZStart), Quaternion.Euler(-90,0,0));
        //    Instantiate(Hexagon, new Vector3(XStart + (ColumnSpace * (i % Columns)), YStart + (-RowSpace * (i / Columns)), ZStart), Quaternion.identity);
        //}


        //GameObject Array = GameObject.Find("StorageArrayObject");
        //StorageArray BlockNum = Array.GetComponent<StorageArray>();
        //StorageArray.BlockCount

        Objname = gameObject.name;

        FindObjectOfType<StorageArray>().BlockCount++;

        if (Objname == "BOX(Clone)")
        {
            transform.Rotate(-90, 0, 0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        float TrackingX = 0;
        int TrackingXReturn = 0;
        float TrackingXQuartered;
        //float TrackingXReturnSplit = 0;
        //Controls
        // A Left
        // D Right
        // Space DROP
        // Q Rotate AntiClockwise
        // E Rotate Clockwise

        //PLAYER TRACKING

        if (Objname == "BOX(Clone)")
        {
            //transform.Rotate(-90, 0, 0);
        }


        if (FindObjectOfType<Player>().transform.position.y >= 10)
        {
            
            SaveSystem.SaveScore(FindObjectOfType<Player>());

            FindObjectOfType<LevelTransision>().LevelChangeBoss();

        }


        if (transform.position.y >= FindObjectOfType<Spawner>().transform.position.y / 2)
        {
            //Debug.Log("TRACKING PRE HIGHT LIMIT");
            TrackingX = FindObjectOfType<Player>().transform.position.x;
            TrackingXReturn = Mathf.RoundToInt(TrackingX);
            TrackingXQuartered = Mathf.Round(TrackingX * 2) / 2;
            //TrackingXReturnSplit = TrackingXReturn / 4;
            //Debug.Log("TRACKING PRE HIGHT LIMIT ");

            //for (int i = TrackingXReturn; i < -1 || i > -5; i--)
            //{
            if ((TrackingXReturn < 5) && (TrackingXReturn > -5))
            {
                if (transform.position.x == TrackingXReturn)
                {

                }
                if (transform.position.x == TrackingXQuartered)
                {

                }
                else if (transform.position.x != TrackingXReturn)
                {
                    
                    if (TrackingXQuartered <= transform.position.x)
                    {
                        //Debug.Log("Returned - " + TrackingXQuartered);
                        transform.position += new Vector3(-0.25f, 0, 0);

                    }
                    else if (TrackingXQuartered >= transform.position.x)
                    {
                        //Debug.Log("Returned + " + TrackingXQuartered);
                        transform.position += new Vector3(0.25f, 0, 0);
                    }

                }
            }
            //else if ((TrackingXReturn > 1) && (TrackingXReturn < 5))
            //{
            //    if (transform.position.x == TrackingXReturn)
            //    {

            //    }
            //    else if (transform.position.x != TrackingXReturn)
            //    {
            //        if (TrackingXReturn <= transform.position.x)
            //        {
            //            //Debug.Log("Returned - " + TrackingXReturn);
            //            transform.position += new Vector3(-0.5f, 0, 0);

            //        }
            //        else if (TrackingXReturn >= transform.position.x)
            //        {
            //            //Debug.Log("Returned + " + TrackingXReturn);
            //            transform.position += new Vector3(0.5f, 0, 0);
            //        }
            //    }
            //}
            //else if (TrackingXReturn == 0)
            //{
                
            //}
            //else if ((TrackingXReturn > -0.5) && (TrackingXReturn < 0))
            //{
            //    //Debug.Log("Returned + " + TrackingXReturn);
            //    transform.position += new Vector3(0.5f, 0, 0);
            //}
            //else if ((TrackingXReturn > 0) && (TrackingXReturn < 0.5))
            //{
            //    transform.position -= new Vector3(0.5f, 0, 0);
            //}
        }
        else if (transform.position.y == FindObjectOfType<Spawner>().transform.position.y / 2)
        {
            Debug.Log("NO LONGER TRACKING");
        }

        //if (Input.GetKeyDown(KeyCode.A)) //DEBUG ONLY
        //{
        //    transform.position += new Vector3(-0.5f, 0, 0);
        //    if (!GridCheck())
        //        transform.position -= new Vector3(-0.5f, 0, 0);
            
        //}
        //else if (Input.GetKeyDown(KeyCode.D)) //DEBUG ONLY
        //{
        //    transform.position += new Vector3(0.5f, 0, 0);
        //    if (!GridCheck())
        //        transform.position -= new Vector3(0.5f, 0, 0);
        //}
        //else if (Input.GetKeyDown(KeyCode.E)) //DEBUG ONLY
        //{
        //    transform.Rotate(0, 0, 90);
        //}
        //else if (Input.GetKeyDown(KeyCode.Q)) //DEBUG ONLY
        //{
        //    transform.Rotate(0, 0, -90);
        //}
        //else if (Input.GetKeyDown(KeyCode.Return)) //For debug only
        //{
        //    //SaveSystem.SaveScore(this);
        //}

        //Fall area
        if (Time.time - PreviousFallTime > (Input.GetKey(KeyCode.S) ? FallingTime / FindObjectOfType<Spawner>().FallSpeed : FallingTime)) //If Space is pressed move block 10* faster.
        {
            Debug.Log("FallSpeed  " + FindObjectOfType<Spawner>().FallSpeed);
            transform.position += new Vector3(0, -0.5f, 0);
            if (!GridCheck())
            {
                transform.position -= new Vector3(0, -0.5f, 0);
                //ShapesInGrid();
                ////SetShapes[i] = transform.position;
                StorageArray.StorageArrayFunction(FindObjectOfType<StorageArray>().BlockCount, transform.position);
                //Debug.Log("Dose the Array work?" + StorageArray.SetShapes[i] + transform.position);

                //Debug.Log("FallArea - Failed Gridcheck()" +gameObject.name + transform.position);
                FindObjectOfType<Player>().Score -= 10;
                this.enabled = false;
                FindObjectOfType<Spawner>().transform.position += new Vector3 (0, 0.5f, 0);
                FindObjectOfType<Spawner>().NewBlock();
            }

            else if (!ShapesInGrid())
            {
                transform.position -= new Vector3(0, -0.5f, 0);
                //ShapesInGrid();
                StorageArray.StorageArrayFunction(FindObjectOfType<StorageArray>().BlockCount, transform.position);
                Debug.Log("BlockCount_" + FindObjectOfType<StorageArray>().BlockCount);
                //Debug.Log("FallArea -  has failed ShapesInGrid()" + transform.position);
                FindObjectOfType<Player>().Score -= 10;
                this.enabled = false;
                FindObjectOfType<Spawner>().transform.position += new Vector3(0, 0.5f, 0);
                FindObjectOfType<Spawner>().NewBlock();
            }

            PreviousFallTime = Time.time;
        }

        bool ShapesInGrid()
        {
            //float GridX = Shapes.x;//Mathf.RoundToInt(Shapes.transform.position.x); //Rounds the X Position to an Int
            // Vector3 ShapesX = transform.position;
            //float ShapesY = transform.position.y;
            //float ShapesZ = transform.position.z;
            //float GridY = Shapes.y;//Mathf.RoundToInt(Shapes.transform.position.y); //Rounds the Y Position to an Int 
            //float GridZ = Shapes.z;//Mathf.RoundToInt(Shapes.transform.position.z); //Rounds the Y Position to an Int 
            //int i = 0;
            //SetShapes[i] = transform.position;
            //i++;
            //SetShapes[ShapesX];
            //transform.position;
            //Debug.Log("ShapesInGrid()_");
            for (int i = 1; i < 50; i++)
            {
                if (transform.position.x == StorageArray.SetShapes[i].x && transform.position.y == StorageArray.SetShapes[i].y && transform.position.z == StorageArray.SetShapes[i].z)
                {
                    //Debug.Log("ShapesInGrid()_ New Shape in Set shape." + transform.position);
                    //transform.position -= new Vector3(0, -0.5f, 0);
                    return false;
                }
            }

            return true;
        }

        bool GridCheck()
        {
            //foreach (Transform Shapes in transform)
            //{
            //    int GridX = Mathf.RoundToInt(Shapes.transform.position.x); //Rounds the X Position to an Int 
            //    int GridY = Mathf.RoundToInt(Shapes.transform.position.y); //Rounds the Y Position to an Int 
            //    int GridZ = Mathf.RoundToInt(Shapes.transform.position.z); //Rounds the Y Position to an Int 
            //    if (GridX < 0 || GridX >=GridWidth || GridY < 0 || GridY >= GridHight || GridZ < 0 ||GridZ >=GridDepht) //Is shapes X axis in the grid, Is shapes Y axis in the grid
            //    if (SetShapes[GridX, GridY] != null)
            //    {
            //        return false;
            //    }
            //}

            if (transform.position.x <= -5 || transform.position.x >= 5 || transform.position.y <= -0.5)
            {
                //Debug.Log("GridCheck() has tried to exit grid." + transform.position);
                return false;
            }
            return true; // If the shape is not out side
        }
    }
}

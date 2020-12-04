using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageArray : MonoBehaviour
{

    public static Vector3[] SetShapes = new Vector3[50];
    public int ArrayCurrentShape = 0;
    //int ArrayCurrentPos = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        //Vector3 ShapePosition = new Vector3(0,0,0);
    }

    void Update()
    {
        ArrayCurrentShape = 0;
    }

    public static void StorageArrayFunction(int ArrayCurrentShape, Vector3 position)
    {
        //Debug.Log("StorageArrayFunction()");
        for (int i = 0; i < ArrayCurrentShape; i++)
        {
            //Debug.Log("" + Transform,position)
            SetShapes[ArrayCurrentShape] = position;
            Debug.Log("StorageArrayFunction()_" +SetShapes[ArrayCurrentShape] + ArrayCurrentShape + position);
            Debug.Log("StorageArrayFunction()_TEST0" + SetShapes[0] + ArrayCurrentShape + position);
            Debug.Log("StorageArrayFunction()_TEST1" + SetShapes[1] + ArrayCurrentShape + position);
            Debug.Log("StorageArrayFunction()_TEST2" + SetShapes[2] + ArrayCurrentShape + position);
            //ArrayCurrentShape++;
        }
        //ArrayCurrentShape++;

    }
}

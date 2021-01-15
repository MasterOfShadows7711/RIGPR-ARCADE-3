using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string PlayerName;
    public int Score;
    public float[] position;
    bool HasJumped = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            
            transform.position += new Vector3(-1.5f, 0, 0) * Time.deltaTime;
            if (transform.rotation.eulerAngles.y == 90)
            {

            }
            else if (transform.rotation.eulerAngles.y != 90)
            {
                transform.Rotate(0, 90, 0);
            }
            if (!GridCheckPlayer())
            {
                transform.position -= new Vector3(-1.5f, 0, 0) * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1.5f, 0, 0) * Time.deltaTime;
            if (transform.rotation.eulerAngles.y == -90)
            {

            }
            else if (transform.rotation.eulerAngles.y != -90)
            {
                transform.Rotate(0, -90, 0);
            }
            if (!GridCheckPlayer())
            {
                transform.position -= new Vector3(1.5f, 0, 0) * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("SPACE KEY PRESSED");
            //if (!HasJumped)
            //{
                transform.position += new Vector3(0, 3, 0) * Time.deltaTime;
                //HasJumped = true;
            //}
        }
        //else if (GridCheckPlayer())
        //{
        //    HasJumped = true;
        //}

        if (!Input.GetKey(KeyCode.Space))
        {
            transform.position -= new Vector3(0, 2, 0) * Time.deltaTime;
            if (!GridCheckPlayer())
            {
                transform.position += new Vector3(0, 2, 0) * Time.deltaTime;
            }
            if (!ShapesInGridPlayer())
            {
                transform.position += new Vector3(0, 2, 0) * Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return)) //For debug only
        {
            SaveSystem.SaveScore(this);
        }
        if (Input.GetKeyDown(KeyCode.Backspace)) //For debug only
        {
            PlayerData data = SaveSystem.LoadScore();
            PlayerName = data.PlayerName;
            Score = data.Score;
            Vector3 position;
            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];
            transform.position = position;

        }

        //PLAYER AREA 
        if (!GridCheckPlayer())
        {
            //HasJumped = false;
            
        }
        if (!ShapesInGridPlayer())
        {
            Debug.Log("ShapesInGridPlayer()_ PLAYER HIT SHAPE");
            if (transform.rotation.eulerAngles.y == 90)
            {
                transform.position += new Vector3(1.5f, 0, 0) * Time.deltaTime;
            }
            if (transform.rotation.eulerAngles.y != 90)
            {
                transform.position += new Vector3(-1.5f, 0, 0) * Time.deltaTime;
            }
        }





        bool GridCheckPlayer()
        {
            if (transform.position.x <= -5 || transform.position.x >= 5 || transform.position.y <= -0.1)
            {
                Debug.Log("GridCheckPlayer() _ Player has tried to exit grid." + transform.position);
                return false;
            }
            return true; // If the shape is not out side
        }

        bool ShapesInGridPlayer()
        {
            Debug.Log("ShapesInGridPlayer()_");
            for (int i = 1; i < 50; i++)
            {
                if (transform.position.x == StorageArray.SetShapes[i].x && transform.position.y == StorageArray.SetShapes[i].y && transform.position.z == StorageArray.SetShapes[i].z)
                {
                    Debug.Log("ShapesInGridPlayer()_ Player In Shape." + transform.position);
                    //transform.position -= new Vector3(0, -0.5f, 0);
                    return false;
                }
            }
            Debug.Log("ShapesInGridPlayer()_ Return True");
            return true;
        }
    }
}

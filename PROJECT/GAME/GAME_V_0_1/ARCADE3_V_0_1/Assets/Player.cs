using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(-0.5f, 0, 0);
            if (!GridCheckPlayer())
                transform.position -= new Vector3(-0.5f, 0, 0);

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(0.5f, 0, 0);
            if (!GridCheckPlayer())
                transform.position -= new Vector3(0.5f, 0, 0);
        }
        //else if (Input.GetKeyDown(KeyCode.E))
        //{
        //    transform.Rotate(0, 0, 90);
        //}
        //else if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    transform.Rotate(0, 0, -90);
        //}
        else if (Input.GetKeyDown(KeyCode.Return)) //For debug only
        {
            //SaveSystem.SaveScore(this);
        }

        bool GridCheckPlayer()
        {
            if (transform.position.x <= -5 || transform.position.x >= 5 || transform.position.y <= -0.5)
            {
                Debug.Log("GridCheckPlayer() _ Player has tried to exit grid." + transform.position);
                return false;
            }
            return true; // If the shape is not out side
        }
    }
}

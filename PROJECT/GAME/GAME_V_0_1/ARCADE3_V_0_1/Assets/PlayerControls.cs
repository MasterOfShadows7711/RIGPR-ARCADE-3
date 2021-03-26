using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //public void Controls()
    //{
    //    if (Input.GetKey(KeyCode.A))
    //    {

    //        transform.position += new Vector3(-1.5f, 0, 0) * Time.deltaTime;

    //        if (transform.rotation.eulerAngles.y == 90)
    //        {

    //        }
    //        else
    //        {
    //            transform.Rotate(0, 90, 0);
    //        }
    //        if (!GridCheckPlayer())
    //        {
    //            transform.position -= new Vector3(-1.5f, 0, 0) * Time.deltaTime;
    //        }
    //    }

    //    if (Input.GetKey(KeyCode.D))
    //    {
    //        transform.position += new Vector3(1.5f, 0, 0) * Time.deltaTime;

    //        if (transform.rotation.eulerAngles.y == 180)
    //        {
    //            //transform.Rotate(0, -90, 0);
    //        }
    //        else
    //        {
    //            transform.Rotate(0, 90, 0);
    //        }
    //        if (!GridCheckPlayer())
    //        {
    //            transform.position -= new Vector3(1.5f, 0, 0) * Time.deltaTime;
    //        }
    //    }

    //    if (Input.GetKey(KeyCode.S))
    //    {
    //        if (transform.rotation.eulerAngles.y == 0)
    //        {

    //        }
    //        else
    //        {
    //            transform.Rotate(0, 90, 0);
    //        }
    //        //if (!GridCheckPlayer())
    //        //{
    //        //    transform.position -= new Vector3(1.5f, 0, 0) * Time.deltaTime;
    //        //}
    //    }

    //    if (IsOnground() && Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Debug.Log("SPACE KEY PRESSED");
    //        Source.PlayOneShot(JumpSound, 1f);
    //        rbPlayer.AddForce(Vector3.up * JumpAmount, ForceMode.Impulse);
    //    }


    //    //if (!Input.GetKey(KeyCode.Space))
    //    //{
    //    //    //transform.position -= new Vector3(0, 2, 0) * Time.deltaTime;
    //    //    if (!GridCheckPlayer())
    //    //    {
    //    //        transform.position += new Vector3(0, 2, 0) * Time.deltaTime;
    //    //    }
    //    //    if (!ShapesInGridPlayer())
    //    //    {
    //    //        transform.position += new Vector3(0, 2, 0) * Time.deltaTime;
    //    //    }
    //    //}
    //    if (Input.GetKeyDown(KeyCode.Return)) //For debug only
    //    {
    //        SaveSystem.SaveScore(this);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Backspace)) //For debug only
    //    {
    //        PlayerData data = SaveSystem.LoadScore();
    //        PlayerName = data.PlayerName;
    //        Score = data.Score;
    //        Vector3 position;
    //        position.x = data.position[0];
    //        position.y = data.position[1];
    //        position.z = data.position[2];
    //        transform.position = position;

    //    }


    //}

}

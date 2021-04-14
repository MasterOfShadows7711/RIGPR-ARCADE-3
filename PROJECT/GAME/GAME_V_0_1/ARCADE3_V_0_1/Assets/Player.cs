using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public string PlayerName;
    public int Score;
    public float[] position;
    bool HasJumped = false;

    public AudioClip RunSound;
    public AudioClip JumpSound;
    //public AudioClip ;
    //public AudioClip ;
    private AudioSource Source;

    private Rigidbody rbPlayer;
    //public BoxCollider PlayerCol;
    public CapsuleCollider PlayerCol;
    public LayerMask Ground;
    public float JumpAmount = 3;

    public Animator Jump;

    // Start is called before the first frame update
    void Start()
    {
        Score = 10000;
        Source = GetComponent<AudioSource>();

        rbPlayer = GetComponent<Rigidbody>();
        //PlayerCol = GetComponent <BoxCollider>();
        PlayerCol = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jump.ResetTrigger("JUMP");

        if (Input.GetKey(KeyCode.A))
        {
            
            transform.position += new Vector3(-1.5f, 0, 0) * Time.deltaTime;
            
            if (transform.rotation.eulerAngles.y == 90)
            {

            }
            else
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
            
            if (transform.rotation.eulerAngles.y == 270)
            {
                //transform.Rotate(0, 90, 0);
            }
            else
            {
                transform.Rotate(0, 90, 0);
            }
            if (!GridCheckPlayer())
            {
                transform.position -= new Vector3(1.5f, 0, 0) * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.S))
        {
            if (transform.rotation.eulerAngles.y == 0)
            {
                
            }
            else
            {
                //transform.Rotate(0, 90, 0);
            }
            
        }

        if (IsOnground() && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE KEY PRESSED");
            Source.PlayOneShot(JumpSound,1f);
            //Jump.StartPlayback();
            rbPlayer.AddForce(Vector3.up * JumpAmount, ForceMode.Impulse);
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
    }

    bool GridCheckPlayer()
    {
        if (transform.position.x <= -5 || transform.position.x >= 5 || transform.position.y <= -5 || transform.position.z <= 3.5)
        {
            Debug.Log("GridCheckPlayer() _ Player has tried to exit grid." + transform.position);
            return false;
        }
        return true; // If the shape is not out side
    }

    public bool IsOnground()
    {
        return Physics.CheckCapsule(PlayerCol.bounds.center, new Vector3(PlayerCol.bounds.center.x, PlayerCol.bounds.min.y, PlayerCol.bounds.center.z), PlayerCol.radius * .8f, Ground);
        

    }
}

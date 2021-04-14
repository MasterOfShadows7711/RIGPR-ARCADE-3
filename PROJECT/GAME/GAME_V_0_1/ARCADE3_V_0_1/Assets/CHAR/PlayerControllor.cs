using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllor : MonoBehaviour
{
    public Animator Char;

    // Start is called before the first frame update
    void Start()
    {
        Char = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (FindObjectOfType<ThrownObject>().Objname == "Bomb Variant(Clone)") 
        //{
        //    if (FindObjectOfType<Player>().GetComponent<CapsuleCollider>().bounds.Intersects(FindObjectOfType<ThrownObject>().GetComponent<SphereCollider>().bounds))
        //    {
        //        Debug.LogWarning("!!!!KICKED");
        //        Char.SetBool("Kick", true);

        //    }
        //    else
        //    {
        //        //Char.SetBool("Kick", false);
        //    }
                
        //}
        //else
        //{
        //    Char.SetBool("Kick", false);

        //}

        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D))) 
        {
            //Debug.LogError("A PASS GOT KEY");
            Char.SetBool("IsWalking", true);

        }
        else
        {
            Char.SetBool("IsWalking", false);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Char.SetBool("HasJumped", true);
        }
        else
        {
            Char.SetBool("HasJumped", false);

        }

    }
}

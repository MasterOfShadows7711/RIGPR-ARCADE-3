using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownObject : MonoBehaviour
{
    public GameObject[] ApplePS;
    public GameObject[] BannanaPS;
    public GameObject[] CherryPS;
    public GameObject[] BombPS;
    protected float MoveAnimation;
    public SphereCollider ThrownObejctCollider;
    private AudioSource Source;
    public AudioClip ThrowSound;
    public LayerMask Ground;

    public float BombDetinationTime =  15f;

    //public GameObject Apple;
    //public ParticleSystem ApplePS; //Red-dark red

    //public ParticleSystem BannanaPS; //Yellow - white
    //public GameObject Bannana;

    //public ParticleSystem CherryPS; // green - red
    //public GameObject Cherry;
    
    //public GameObject Bomb;
    //public ParticleSystem BombPS; // Ornage - red

    public string Objname;

    Vector3 playerPos;
    Vector3 BossPos;

    Vector3 FinalPos;


    public void Setup()
    {
        //ApplePS.Play(false);
        //BannanaPS.Play(false);
        //CherryPS.Play(false);
        //BombPS.Play(false);

        Objname = gameObject.name;

        BossPos = FindObjectOfType<Boss>().transform.position;
        playerPos = FindObjectOfType<Player>().transform.position;
        ThrownObejctCollider = GetComponent<SphereCollider>();
        DelayCapsuleCollider();
        //GetComponent<ParticleSystem>().Stop(true);

    }

    public void Update()
    {

        FinalPos = transform.position;

        if (Objname == "Bomb Variant(Clone)")
        {
            BombDetinationTime -= Time.deltaTime;
            Debug.Log("" + BombDetinationTime);
            if (BombDetinationTime <= 0.0f)
            {
                Instantiate(BombPS[Random.Range(0, BombPS.Length)], transform.position, transform.rotation);
                Destroy(gameObject);
            }

        }

        if (!IsOnground())
        {
            MoveAnimation += Time.deltaTime;
            //MoveAnimation = MoveAnimation % 5f;

            transform.position = ParabolaMaths.V3Parabola(BossPos, playerPos * 1f, 5f, MoveAnimation / 5f);
            transform.Rotate(0, 90 * Time.deltaTime, 90 * Time.deltaTime);
        }
        
        if (IsOnground())
        {
            //Debug.Log("" + BombDetinationTime);
            ThrownObjectDamage();

            if (Objname == "Apple(Clone)")
            {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
                //Debug.LogWarning("Apple IF Pass");
                Instantiate(ApplePS[Random.Range(0, ApplePS.Length)], transform.position, transform.rotation);
                Destroy(this);
                Destroy(gameObject);
            }
            if (Objname == "Cherry(Clone)")
            {
                //Debug.LogWarning("Cherry IF Pass");
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
                Instantiate(CherryPS[Random.Range(0, CherryPS.Length)], transform.position, transform.rotation);
                Destroy(this);
                Destroy(gameObject);
            }
            if (Objname == "Bananas(Clone)")
            {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
                Instantiate(BannanaPS[Random.Range(0, BannanaPS.Length)], transform.position, transform.rotation);
                Destroy(this);
                Destroy(gameObject);
            }
            if (Objname == "Bomb Variant(Clone)")
            {
                

            }
            

        }

        if (transform.position.x <= -15 || transform.position.x >= 25 || transform.position.y <= -5 || transform.position.z >= 15)
        {
            Destroy(gameObject);
        }
    }

    public void ThrownObjectDamage()
    {
        if (GetComponent<SphereCollider>().bounds.Intersects(FindObjectOfType<Player>().GetComponent<CapsuleCollider>().bounds))
        {
            if (Objname == "Bomb Variant(Clone)")
            {


                //if (GetComponent<SphereCollider>().bounds.Intersects(FindObjectOfType<BossFloor2>().GetComponent<BoxCollider>().bounds))
                //{ Boss First floor

                //}

                //if (GetComponent<SphereCollider>().bounds.Intersects(FindObjectOfType<BossFloor1>().GetComponent<BoxCollider>().bounds))
                //{ 2nd


                //}

                //if (GetComponent<SphereCollider>().bounds.Intersects(FindObjectOfType<BossFloor0>().GetComponent<BoxCollider>().bounds))
                //{ 3rd

                //}

                if (GetComponent<SphereCollider>().bounds.Intersects(FindObjectOfType<Boss>().GetComponent<CapsuleCollider>().bounds))
                {
                    //Boss them self

                }

            }
            else
            {
                LivesSystem.lives--;
                Destroy(gameObject);
            }
                
        }

    }

    private bool IsOnground()
    {
        return Physics.CheckSphere(ThrownObejctCollider.bounds.center, GetComponent<SphereCollider>().bounds.extents.x, Ground);
    }

    public void DelayCapsuleCollider()
    {
        
        StartCoroutine(CapsuleColliderTimer());

    }
    public void DetroyTimerFunc()
    {
        
        StartCoroutine(DetroyTimer());

    }
    IEnumerator CapsuleColliderTimer()
    {
        //Source.PlayOneShot(ThrowSound, 1f);
        GetComponent<SphereCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        GetComponent<SphereCollider>().enabled = true;

    }
    IEnumerator DetroyTimer()
    {
        yield return new WaitForSeconds(5);
    }



}

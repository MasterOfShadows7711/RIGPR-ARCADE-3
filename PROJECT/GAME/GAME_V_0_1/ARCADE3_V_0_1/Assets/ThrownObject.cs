using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownObject : MonoBehaviour
{
    public GameObject Object;
    protected float MoveAnimation;
    public SphereCollider ThrownObejctCollider;
    private AudioSource Source;
    public AudioClip ThrowSound;
    public LayerMask Ground;

    public GameObject Apple;
    public ParticleSystem ApplePS; //Red-dark red

    public ParticleSystem BannanaPS; //Yellow - white
    public GameObject Bannana;

    public ParticleSystem CherryPS; // green - red
    public GameObject Cherry;
    
    public GameObject Bomb;
    public ParticleSystem BombPS; // Ornage - red

    public string Objname;

    Vector3 playerPos;
    Vector3 BossPos;

    Vector3 FinalPos;


    public void Setup()
    {
        ApplePS.Play(false);
        BannanaPS.Play(false);
        CherryPS.Play(false);
        BombPS.Play(false);

        Objname = gameObject.name;

        BossPos = FindObjectOfType<Boss>().transform.position;
        playerPos = FindObjectOfType<Player>().transform.position;
        ThrownObejctCollider = GetComponent<SphereCollider>();
        DelayCapsuleCollider();
        //GetComponent<ParticleSystem>().Stop(true);

    }

    private void Update()
    {
        ThrownObjectDamage();

        FinalPos = transform.position;


        if (!IsOnground())
        {
            MoveAnimation += Time.deltaTime;
            //MoveAnimation = MoveAnimation % 5f;

            transform.position = ParabolaMaths.V3Parabola(BossPos, playerPos * 1f, 5f, MoveAnimation / 5f);
            transform.Rotate(0, 90 * Time.deltaTime, 90 * Time.deltaTime);
        }
        
        if (IsOnground())
        {

            Apple = GameObject.Find("Apple(Clone)");
            Cherry = GameObject.Find("Cherry(Clone)");
            Bannana = GameObject.Find("Bananas(Clone)");
            Bomb = GameObject.Find("Bomb(Clone)");
            Debug.Log("Apple value " + Apple); 
            Debug.Log("cherry value " + Cherry); 
            Debug.Log("banna value " + Bannana); 
            Debug.Log("bomb value " + Bomb); 
            //ApplePS.transform.position = playerPos;
            //BannanaPS.transform.position = playerPos;
            //CherryPS.transform.position = playerPos;
            //BombPS.transform.position = playerPos;

            if (Objname == "Apple(Clone)")
            {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
                //Debug.LogWarning("Apple IF Pass");
                ApplePS.transform.position = FinalPos;
                Debug.LogWarning("Apple IF Pass" + ApplePS.transform.position);

                ApplePS.Play(true);
                //DetroyTimerFunc();
                //Destroy(gameObject);
            }
            if (Objname == "Cherry(Clone)")
            {
                //Debug.LogWarning("Cherry IF Pass");
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
                CherryPS.transform.position = FinalPos;
                Debug.LogWarning("Cherry IF Pass" + CherryPS.transform.position);
                CherryPS.Play();
                //DetroyTimerFunc();
                //Destroy(gameObject);
            }
            if (Objname == "Bananas(Clone)")
            {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
                //Debug.LogWarning("Banna IF Pass");
                BannanaPS.transform.position = FinalPos;
                Debug.LogWarning("Banna IF Pass" + BannanaPS.transform.position);

                BannanaPS.Play();
                //DetroyTimerFunc();
               // Destroy(gameObject);
            }
            if (Objname == "Bomb(Clone)")
            {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<SphereCollider>().enabled = false;
                //Debug.LogWarning("Bomb IF Pass");
                BombPS.transform.position = FinalPos;
                Debug.LogWarning("Bomb IF Pass" + BombPS.transform.position);

                BombPS.Play();
                DetroyTimerFunc();
                Destroy(gameObject);
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

            LivesSystem.lives--;
            Destroy(gameObject);
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
        yield return new WaitForSeconds(1.5f);
        GetComponent<SphereCollider>().enabled = true;

    }
    IEnumerator DetroyTimer()
    {
        yield return new WaitForSeconds(5);
    }



}

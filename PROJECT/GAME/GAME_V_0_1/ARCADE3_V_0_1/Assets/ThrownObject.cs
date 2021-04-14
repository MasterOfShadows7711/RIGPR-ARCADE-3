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

    //public bool Floor1;
    //public bool Floor2;
    //public bool BossFloor;

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
        DelaySphereCollider();
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
                DestructionDetection();

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
                
            }
            else
            {
                FindObjectOfType<Player>().Score -= 1000;
                LivesSystem.lives--;
                Destroy(gameObject);
            }
                
        }

    }

    public void DestructionDetection()
    {        
        //Debug.Log("DESTUCTION FUNC TRUGGERED");
        //Debug.Log("Boss name " + FindObjectOfType<BossFloor>().Objname);

        if (!FindObjectOfType<Boss>().BossFloor)
        {
            if (GetComponent<SphereCollider>().bounds.Intersects(FindObjectOfType<Boss>().GetComponent<CapsuleCollider>().bounds))
            {
                FindObjectOfType<Player>().Score += 1000;
                Debug.Log("Boss destroy");
                Instantiate(BombPS[Random.Range(0, BombPS.Length)], transform.position, transform.rotation);
                Destroy(FindObjectOfType<Boss>());
                SaveSystem.SaveScore(FindObjectOfType<Player>());

                PlayerData data = SaveSystem.LoadScore();
                FindObjectOfType<Player>().Score = data.Score;
                if (FindObjectOfType<Player>().Score >= FindObjectOfType<HighScore>().HighScoreInt)
                {
                    
                    FindObjectOfType<Player>().PlayerName = data.PlayerName;
                    FindObjectOfType<Player>().Score = data.Score;
                    FindObjectOfType<HighScore>().HighScorePlayerName = FindObjectOfType<Player>().PlayerName;
                    FindObjectOfType<HighScore>().HighScoreInt = FindObjectOfType<Player>().Score;



                    SaveSystem.SaveNewHighScore(FindObjectOfType<HighScore>());
                    Debug.LogError("  " + FindObjectOfType<Player>().Score + "  " + data.Score);

                }

                if (FindObjectOfType<Player>().Score != FindObjectOfType<HighScore>().HighScoreInt)
                {
                    FindObjectOfType<Player>().PlayerName = data.PlayerName;
                    FindObjectOfType<Player>().Score = data.Score;


                }


                Destroy(GameObject.Find("Boss_Char"));
                Destroy(gameObject);

            }
            else
            {


            }

        }
        else if (FindObjectOfType<Boss>().BossFloor)
        {

        }

        if (!FindObjectOfType<Boss>().Floor2)
        {
            if (GetComponent<SphereCollider>().bounds.Intersects(FindObjectOfType<BossFloor>().GetComponent<BoxCollider>().bounds))
            {
                if (FindObjectOfType<BossFloor>().Objname == "BossFloor2")
                {
                    FindObjectOfType<Player>().Score += 500;
                    Debug.Log("BossFloor2 destroy");
                    Instantiate(BombPS[Random.Range(0, BombPS.Length)], transform.position, transform.rotation);
                    Destroy(FindObjectOfType<BossFloor>());
                    Destroy(GameObject.Find("BossFloor2"));
                    FindObjectOfType<Boss>().ThrowSpeed = 1;
                    FindObjectOfType<Boss>().Floor2 = true;
                    Destroy(gameObject);
                }
                else
                {

                }
                

            }
            else if (!GetComponent<SphereCollider>().bounds.Intersects(FindObjectOfType<BossFloor>().GetComponent<BoxCollider>().bounds))
            {


            }

        }
        else if (!FindObjectOfType<Boss>().Floor2)
        {


        }
        

        

        if (!FindObjectOfType<Boss>().Floor1)
        {
            if (GetComponent<SphereCollider>().bounds.Intersects(FindObjectOfType<BossFloor>().GetComponent<BoxCollider>().bounds))
            {
                if (FindObjectOfType<BossFloor>().Objname == "BossFloor1")
                {
                    FindObjectOfType<Player>().Score += 500;
                    Debug.Log("BossFloor1 destroy");
                    Instantiate(BombPS[Random.Range(0, BombPS.Length)], transform.position, transform.rotation);
                    Destroy(FindObjectOfType<BossFloor>());
                    Destroy(GameObject.Find("BossFloor1"));
                    FindObjectOfType<Boss>().ThrowSpeed = 2;
                    FindObjectOfType<Boss>().Floor1 = true;
                    Destroy(gameObject);

                }
                else
                {

                }
                


            }
            else if (!GetComponent<SphereCollider>().bounds.Intersects(FindObjectOfType<BossFloor>().GetComponent<BoxCollider>().bounds))
            {

            }

        }
        else if (!FindObjectOfType<Boss>().Floor1)
        {


        }
        //Debug.Log("Boss name " + FindObjectOfType<BossFloor>().Objname);
    }
    

    private bool IsOnground()
    {
        return Physics.CheckSphere(ThrownObejctCollider.bounds.center, GetComponent<SphereCollider>().bounds.extents.x, Ground);
    }

    public void DelaySphereCollider()
    {
        
        StartCoroutine(SphereColliderTimer());

    }
    public void DetroyTimerFunc()
    {
        
        StartCoroutine(DetroyTimer());

    }
    IEnumerator SphereColliderTimer()
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

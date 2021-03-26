using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticalSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetroyTimerFunc();
       


    }

    public void DetroyTimerFunc()
    {

        StartCoroutine(DetroyTimer());

    }

    IEnumerator DetroyTimer()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }

}

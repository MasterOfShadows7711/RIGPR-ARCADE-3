using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureChanger : MonoBehaviour
{
    public GameObject Bomb;
    public Texture[] textures;
    private Renderer BombRender;
    private int TextArrayInt;


    // Start is called before the first frame update
    void Start()
    {
        BombRender = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
        TextArrayInt = Random.Range(0, textures.Length);
        BombRender.material.mainTexture = textures[TextArrayInt];
        SwapTimerFunc();
        TextArrayInt = Random.Range(0, textures.Length);
        BombRender.material.mainTexture = textures[TextArrayInt];
        SwapTimerFunc();

    }


    public void SwapTimerFunc()
    {

        StartCoroutine(SwapTimer());

    }

    IEnumerator SwapTimer()
    {
        yield return new WaitForSeconds(0.4f);
    }


}

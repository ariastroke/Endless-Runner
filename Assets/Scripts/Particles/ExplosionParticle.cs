using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionParticle : MonoBehaviour
{

    private float timer;
    private SpriteRenderer sr;
    private Color oldColor;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        oldColor = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * 2f;
        oldColor.a -= Time.deltaTime * 2f;
        sr.color = oldColor;
        if(timer > 1f){
            Destroy(gameObject);
        }
    }
}

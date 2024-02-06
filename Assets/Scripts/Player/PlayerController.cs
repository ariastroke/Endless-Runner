using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rigidbody;

    private bool CanJump;
    public GameObject ExplosionParticle;
    public GameObject LandExplosionParticle;

    public float AllowedOffset;

    private float MyX;

    // Start is called before the first frame update
    void Start()
    {
        CanJump = true;
        rigidbody = GetComponent<Rigidbody2D>();
        MyX = transform.position.x;
    }

    public void TouchingGround(bool value){
        bool OldVal = CanJump;
        CanJump = value;
        if(!OldVal && CanJump){
            Instantiate(LandExplosionParticle, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > MyX){
            transform.position = new Vector2(MyX, transform.position.y);
        }
        if(rigidbody.velocity.x > 0){
            rigidbody.velocity = new Vector2(0, 0);
            CanJump = true;
        }

        if(Input.GetKeyDown("space") && CanJump){
            rigidbody.AddForce(new Vector2(0, 27f), ForceMode2D.Impulse);
        } 
        if(Input.GetKey("space")){
            rigidbody.gravityScale = 5f;
        }else{
            rigidbody.gravityScale = 10f;
        }

        if(transform.position.x < MyX - AllowedOffset || transform.position.x > MyX + AllowedOffset){
            Instantiate(ExplosionParticle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
        float stretch = Mathf.Log(Mathf.Abs(rigidbody.velocity.y + 0.001f), 10);
        if(stretch > 0 && rigidbody.velocity.y > 0)
            transform.localScale = new Vector2(1 - stretch * 0.3f, 1 + stretch * 0.3f);
        else
            transform.localScale = new Vector2(1, 1);
    }
}

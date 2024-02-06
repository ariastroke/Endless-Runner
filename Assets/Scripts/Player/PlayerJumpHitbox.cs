using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpHitbox : MonoBehaviour
{

    private GameObject Player;
    [SerializeField] private List<GameObject> Chunks;

    void Start(){
        Player = transform.parent.gameObject;
    }

    void Update(){
        bool GroundTouch = (Chunks.Count > 0);
        Player.GetComponent<PlayerController>().TouchingGround(GroundTouch);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Ground"){
            Chunks.Add(other.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Ground"){
            Chunks.Remove(other.gameObject);
        }
    }
}

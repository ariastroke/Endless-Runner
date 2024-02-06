using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private GameObject Particle;

    [SerializeField] private float OffsetX;
    [SerializeField] private float OffsetY;

    [SerializeField] private float SpeedX;
    [SerializeField] private float MinSpeedY;
    [SerializeField] private float MaxSpeedY;

    [SerializeField] private float SpreadX;
    [SerializeField] private float SpreadY;

    [SerializeField] private float Quantity;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Quantity; i++){
            GameObject current = Instantiate(Particle, transform.position + new Vector3(OffsetX + Random.Range(-SpreadX, SpreadX), OffsetY + Random.Range(-SpreadY, SpreadY), 0), transform.rotation);
            current.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-SpeedX, SpeedX), Random.Range(MinSpeedY, MaxSpeedY));
        }
        Destroy(gameObject);
    }
}

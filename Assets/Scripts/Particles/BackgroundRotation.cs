using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRotation : MonoBehaviour
{
    private float timer;

    public float OffsetX;
    public float OffsetY;
    public float OffsetZ;

    public float SpeedX;
    public float SpeedY;
    public float SpeedZ;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.rotation = Quaternion.Euler(timer * SpeedX + OffsetX, timer * SpeedY + OffsetY, timer * SpeedZ + OffsetZ);
    }
}

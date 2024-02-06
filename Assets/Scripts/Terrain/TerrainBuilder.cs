using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainBuilder : MonoBehaviour
{

    [SerializeField] private GameObject[] TerrainTemplates;
    [SerializeField] private GameObject StartTerrain;
    [SerializeField] private float SpawnX;
    [SerializeField] private float SpawnY;

    [SerializeField] private float NextBlockX;

    private GameObject LastGenerated;

    public int Score;
    private float Timer;

    private float Speed;

    public void GenerateNext(){
        LastGenerated = Instantiate(TerrainTemplates[Random.Range(0, TerrainTemplates.Length)], new Vector2(SpawnX, SpawnY), transform.rotation);
        LastGenerated.GetComponent<TerrainBlock>().Speed = Speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        Speed = 0.2f;
        LastGenerated = Instantiate(StartTerrain, new Vector2(0, SpawnY), transform.rotation);
        LastGenerated.GetComponent<TerrainBlock>().Speed = Speed;
        LastGenerated = Instantiate(StartTerrain, new Vector2(12, SpawnY), transform.rotation);
        LastGenerated.GetComponent<TerrainBlock>().Speed = Speed;
        Score = 0;
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(LastGenerated.transform.position.x < NextBlockX){
            GenerateNext();
        }
        Timer += Time.deltaTime;
        if(Timer > 1){
            Timer = 0f;
            Score += 1;
            Speed += 0.005f;
        }
    }
}

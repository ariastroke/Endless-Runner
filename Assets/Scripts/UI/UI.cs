using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour, IData
{
    public TerrainBuilder Game;
    public GameObject Player;

    public GameObject GameOverScreen;

    private int HighScore;

    public TextMeshProUGUI MyScore_Display;
    public TextMeshProUGUI HighScore_Display;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SaveData(ref GameData data){
        data.HighScore = this.HighScore;
    }

    public void LoadData(GameData data){
        this.HighScore = data.HighScore;
    }

    // Update is called once per frame
    void Update()
    {
        if(Player != null){
            MyScore_Display.text = $"Puntuación: {Game.Score}";
            if(Game.Score > HighScore)
                HighScore = Game.Score;
            HighScore_Display.text = $"Puntuación Máxima: {HighScore}";
        }else{
            GameOverScreen.SetActive(true);
        }
    }
}

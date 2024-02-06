using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public static DataManager instance { get; private set; }
    private GameData gameData;

    private List<IData> DataPersistenceObjects;

    [SerializeField] private string FileName;
    private FileManager fileManager;

    private void Awake(){
        instance = this;
    }

    // Donde se guarda y carga el juego
    private void Start(){
        fileManager = new FileManager(Application.persistentDataPath, FileName);
        DataPersistenceObjects = FindAllSaveableData();
        LoadGame();
    }

    private void OnDestroy(){
        SaveGame();
    }

    // Metodos para guardar y cargar
    public void NewGame(){
        this.gameData = new GameData();
    }

    public void LoadGame(){

        gameData = fileManager.Load();

        if(this.gameData == null)
            NewGame();

        foreach(IData DataItem in DataPersistenceObjects){
            DataItem.LoadData(gameData);
        }
    }

    public void SaveGame(){
        foreach(IData DataItem in DataPersistenceObjects){
            DataItem.SaveData(ref gameData);
        }

        fileManager.Save(gameData);
    }

    private List<IData> FindAllSaveableData(){

        IEnumerable<IData> dataObjects = FindObjectsOfType<MonoBehaviour>().OfType<IData>();

        return new List<IData>(dataObjects);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileManager
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileManager(string c_DirPath, string c_FileName){
        dataDirPath  = c_DirPath;
        dataFileName = c_FileName;
    }

    public GameData Load(){
        string FullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if(File.Exists(FullPath)){
            try{
                string LoadableData = "";

                using (FileStream stream = new FileStream(FullPath, FileMode.Open)){
                    using(StreamReader reader = new StreamReader(stream)){
                        LoadableData = reader.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<GameData>(LoadableData);
            }catch (Exception e){
                Debug.LogError("Error loading save data \n" + e );
            }
        }
        return loadedData;
    }

    public void Save(GameData data){
        string FullPath = Path.Combine(dataDirPath, dataFileName);
        try{
            Directory.CreateDirectory(Path.GetDirectoryName(FullPath));

            string StorableData = JsonUtility.ToJson(data);

            using (FileStream stream = new FileStream(FullPath, FileMode.Create)){
                using(StreamWriter writer = new StreamWriter(stream)){
                    writer.Write(StorableData);
                }
            }
        }catch (Exception e){
            Debug.LogError("Error saving game \n" + e );
        }
    }
}

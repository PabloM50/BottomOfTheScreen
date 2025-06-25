using System;
using UnityEngine;
using System.Linq;
using System.Collections.Generic;

using System.IO;

public class DataPersistenceManager : MonoBehaviour
{

    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameData;

    [SerializeField] private List<IDataPersistence> dataPersistencesObjects = new List<IDataPersistence>();
    private FileDataHandler dataHandler;

    public static DataPersistenceManager instance {get; private set;}

    private void Awake() {
        if(instance != null) {
            Debug.LogError("Found more than one Data Persistence Manager in the scene.");
        }
        instance = this;
    }

    void Start()
    {

        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistencesObjects = FindAllDataPersistenceObjects();
        
        
        LoadGame();
    }

    public void NewGame() {
        this.gameData = new GameData();
    }

    public void LoadGame() {
        // TODO - Load any saved data from file
        this.gameData = dataHandler.Load();

        // create new gameData if there is no data from file
        if(this.gameData == null) {
            Debug.Log("No data. Initialazing data to defaults");
            NewGame();
        }

        // TODO - push this data to all other scripts with IDataPersistance
        foreach(IDataPersistence dataPersistenceObj in dataPersistencesObjects) {
            dataPersistenceObj.LoadData(gameData);
        }
    }


    public void SaveGame() {
        // TODO - pass the GameData to other scripts so the fill it

        foreach(IDataPersistence dataPersistenceObj in dataPersistencesObjects) {
            dataPersistenceObj.SaveData(ref gameData);
        }

        
        // TODO - save that data fileDataHandler.cs

        dataHandler.Save(gameData);
        
    }

    void OnApplicationQuit() {
        SaveGame();
    }






    private List<IDataPersistence> FindAllDataPersistenceObjects() {
        // FindObjectsofType takes in an optional boolean to include inactive gameobjects
        // Must be MonoBeheviour
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsByType<MonoBehaviour>(
        FindObjectsSortMode.None  // faster than sorting by InstanceID
    )
            .OfType<IDataPersistence>();

        

        return new List<IDataPersistence>(dataPersistenceObjects);
    }



    #region UNITY GUI REQUIRMENTS
    public string GetPath() {
         
        
        return Path.Combine(Application.persistentDataPath, fileName);
    }

    #endregion

}

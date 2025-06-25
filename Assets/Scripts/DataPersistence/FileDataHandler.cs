using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;

public class FileDataHandler 
{
      
    private string dataDirPath = "";

    private string dataFileName = "";


    public FileDataHandler(string dataDirPath, string dataFileName) {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }



    public GameData Load() {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;
        if(File.Exists(fullPath)) {
            try 
            {
                // Load the serialized data from the file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                // deserialize the data from Json back into the C# object
                loadedData = JsonConvert.DeserializeObject<GameData>(dataToLoad);

            }
            catch (Exception e) 
            {
                Debug.LogError("Error occured when trying to load data from file: " + fullPath + "\n" + e);
            }

        }
        return loadedData;
    }


    public void Save(GameData data) {
        string fullPath = Path.Combine(dataDirPath, dataFileName);


        try {
            // Create directory
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));


            string dataToStore = JsonConvert.SerializeObject(data);


            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream)) 
                {
                    writer.Write(dataToStore);
                }
            }
            Debug.Log(fullPath);

        }
        catch(Exception e) {
            Debug.LogError("Error trying to save data: " + fullPath + "\n" + e);
        }
    }


    public string GetPath() {
        return Path.Combine(dataDirPath, dataFileName);
    }
}

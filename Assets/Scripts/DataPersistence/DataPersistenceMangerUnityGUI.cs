using UnityEngine;
using UnityEditor;
using System.IO;



[CustomEditor(typeof(DataPersistenceManager))]
public class DataPersistenceMangerUnityGUI : Editor
{   
    
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        DataPersistenceManager manager = (DataPersistenceManager)target;


        
        GUILayout.Space(10);
        

        if (GUILayout.Button("Delete Save")) {
            string fullPath = manager.GetPath();


            if (File.Exists(fullPath)) {
                File.Delete(fullPath);
                Debug.Log("File deleted: " + fullPath);
            }
            else {
                Debug.LogWarning("File not found at: " + fullPath);
            }

        }
        
    }
}

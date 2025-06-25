using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(CollectablesManager))]
public class CollectablesManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
       DrawDefaultInspector();

        CollectablesManager manager = (CollectablesManager)target;
        List<Collectable> collectables = manager.GetCollectables();

        EditorGUILayout.Space();

        if (GUILayout.Button("Renumber Collectables"))
        {
            for (int i = 0; i < collectables.Count; i++)
            {
                Collectable collectable = collectables[i];
                if (collectable != null)
                {
                    // change id
                    
                    collectable.SetID(i);
                    
                    EditorUtility.SetDirty(collectable);
                }
            }

            AssetDatabase.SaveAssets();
            Debug.Log("Collectables renumbered.");
    
        }

    }
}
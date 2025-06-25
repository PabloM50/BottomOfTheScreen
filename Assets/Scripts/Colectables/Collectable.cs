using System;
using System.Data;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;



[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Collectable", order = 1)]
[Serializable]
public class Collectable : ScriptableObject
{
    public string Name;

    // ID must be sorted
    [SerializeField] private int ID;
    public bool SetID(int newID) {
        if(newID >= 0) {
            ID = newID;
            return true;
        }
        return false;
    }
    public int GetID() {
        return ID;
    }

    public Sprite Sprite;

    
    public float Probability;


    [SerializeField] private bool Collected = false;
    public void Unlock() {
        Debug.Log("Collected " + Name);
        Collected = true;
    }

    public bool IsCollected() {
        return Collected;
    }
}

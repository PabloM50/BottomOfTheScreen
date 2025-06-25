using UnityEngine;
using System.Collections.Generic;
using System;
using NUnit.Framework.Constraints;





public class CollectablesManager : MonoBehaviour, IDataPersistence
{

   

    [SerializeField] private List<Collectable> _collectables = new List<Collectable>();
    [SerializeField] float totalWeight = 0f;

    public static event Action<Collectable> OnRandomCollectableCollected;

    void Start()
    {
        CalculateTotalWeight();
    }


    private void CalculateTotalWeight() {
        foreach (Collectable item in _collectables) {

            if(!item.IsCollected()) {
                totalWeight += item.Probability;
            }
            
        }
    }
    public Collectable GetRandomCollectable() {
        
        float randomValue =UnityEngine.Random.Range(0f, 1f);
        
        float cumulative = 0;

        foreach (Collectable item in _collectables)
        {
            cumulative += item.Probability;
            if (randomValue < cumulative && !item.IsCollected()) {
                item.Unlock();
                OnRandomCollectableCollected?.Invoke(item);
                totalWeight -= item.Probability;
                return item;
            }
                
        }
        
        Debug.Log("No luck");

        return null;

        
    }


    public List<Collectable> GetCollectables() {
        
        return _collectables;
    }



    public virtual void LoadData(GameData data) {
        Debug.Log(data);
        
        Debug.Log(data.upgrade);
        ColectableInfo colectableInfo;
        
        int len = _collectables.Count;
        
        for(int i = 0; i < len; i++) {
            colectableInfo = null;

            if(data.collectables_.Collectables.TryGetValue(_collectables[i].GetID(), out colectableInfo)) {
                if(colectableInfo.collected) 
                {
                    // if id numbering changes this should also change
                
                    _collectables[colectableInfo.ID].Unlock();
                }
            }
            else {
                
                colectableInfo = new ColectableInfo();
                
                colectableInfo.ID = _collectables[i].GetID();
                colectableInfo.collected = _collectables[i].IsCollected();

                data.collectables_.Collectables[_collectables[i].GetID()] = colectableInfo;
            }

        }
        
    }

    public virtual void SaveData(ref GameData data) {
        
        
        
        int len = _collectables.Count;

        for(int i = 0; i < len; i++) {

            ColectableInfo colectableInfo = new ColectableInfo();

            colectableInfo.ID = _collectables[i].GetID();
            colectableInfo.collected = _collectables[i].IsCollected();


            data.collectables_.Collectables[_collectables[i].GetID()] = colectableInfo;

         
        }

        

    }
}

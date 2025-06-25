using UnityEngine;
using System.Collections.Generic;


public class CollectablesFiller : MonoBehaviour
{


    [SerializeField] private CollectablesManager _collectablesManager;

    [SerializeField] private List<Collectable> _collectables = new List<Collectable>();

    [SerializeField] private List<CollectableCard> _cards = new List<CollectableCard>();

    [SerializeField] private CollectableCard _cardPrefab;
    [SerializeField] private Transform _cardParent;


    void Start() {
        _collectables = _collectablesManager.GetCollectables();
        FillCards();
    }
    
    void FillCards() {
        int len = _collectables.Count;
        
        for(int i = 0; i < len; i++) {
            _cards.Add(GenerateCard(_collectables[i])) ;
        }
    }
    
    CollectableCard GenerateCard(Collectable collectable) {
        CollectableCard card = Instantiate(_cardPrefab, _cardParent);
        Debug.Log(collectable.Name);

        card.Initialize(collectable);
        
        return card;
    }



    #region Handling event
    private void OnEnable()
    {
        CollectablesManager.OnRandomCollectableCollected += OnCollected;
        
    }

    private void OnDisable()
    {
        CollectablesManager.OnRandomCollectableCollected -= OnCollected;
    }


    public void OnCollected(Collectable collectable) {
        // unlock card 
        // ID must be sorted
        _cards[collectable.GetID()].Unlock();
    }
    
    #endregion


}

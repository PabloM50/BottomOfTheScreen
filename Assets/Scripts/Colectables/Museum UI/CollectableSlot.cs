using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CollectableSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private Collectable _collectable;
    

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop called");
        GameObject dropped = eventData.pointerDrag;

        CollectableCard collectableCard = dropped.GetComponent<CollectableCard>();
        Debug.Log(collectableCard.collectable.Name);
        //if (collectableCard.collectable.Name == _collectable.Name) {

        DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
        draggableItem.SetParent(this.transform);
        // }
    }


}

using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    private Transform parentAfterDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {

        Debug.Log("Start dragging");

        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root.GetChild(0)); // because root its canvases and first child is the MainCanvas
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Debug.Log("End Dragging");
    } 
}

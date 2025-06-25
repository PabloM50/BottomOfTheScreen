using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private UnityEngine.UI.Image image;
    private Transform Parent;
    

    public void OnBeginDrag(PointerEventData eventData)
    {

        Debug.Log("Start dragging");

        Parent = transform.parent;
        transform.SetParent(transform.root.GetChild(0)); // because root its canvases and first child is the MainCanvas
        transform.SetAsLastSibling();
        
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End Dragging");

        transform.SetParent(Parent);
        
        image.raycastTarget = true;
        
    }




    public void SetParent(Transform transform)
    {
        Parent = transform;
    }
}

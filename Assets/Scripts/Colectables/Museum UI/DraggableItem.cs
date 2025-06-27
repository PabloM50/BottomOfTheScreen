using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private UnityEngine.UI.Image image;
    private Transform Parent;
    [SerializeField] private CanvasGroup canvasGroup; // cant be done with canvas group
    

    public void OnBeginDrag(PointerEventData eventData)
    {

        Debug.Log("Start dragging");

        Parent = transform.parent;
        transform.SetParent(transform.root.GetChild(0)); // because root its canvases and first child is the MainCanvas
        transform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;
       
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        Debug.Log("End Dragging");

        transform.SetParent(Parent);
        Debug.Log(Parent);
        
        
        
    }




    public void SetNewParent(Transform transform)
    {
        Parent = transform;
    }
}

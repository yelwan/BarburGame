using UnityEngine;
using System;
using System.Collections;
public class DragAndDrop : MonoBehaviour
{
   
    private Vector3 offset;
    [SerializeField] bool IsDraggable;
    private bool hasBeenDropped = false;
    [SerializeField] InputManager input;
    private bool canDrag = true;
    private void Awake () {
        input.RegisterToInputEvents(HandleMouseEvent);
    }
    public  Action<Vector3> DropDelegate;
    private void HandleMouseEvent(MouseInputs NewMouseInputs, Vector3 MousePosition)
    {

        if (!IsDraggable || hasBeenDropped || !canDrag ) return;
        
        if (NewMouseInputs == MouseInputs.OnMouseDown)
        {
            offset = transform.position - MousePosition;

        }
        if (NewMouseInputs == MouseInputs.OnMouseDrag)
        {
         transform.position = MousePosition + offset;

        }
        if (NewMouseInputs== MouseInputs.OnMouseUp)
        {

            if (!hasBeenDropped)
            {
                DropDelegate?.Invoke(MousePosition + offset);
                hasBeenDropped = true;
                IsDraggable = false;
            }
        }

        }
    private void StartDragging(Vector3 mousePosition)
    {
        IsDraggable = true;
    }

    private void StopDragging()
    {
        IsDraggable = false;
    }

    public void EnableDrag(bool enable)
    {
        canDrag = enable;
    }

    public void StartObjectCreationCoroutine(float delaySeconds)
    {
        StartCoroutine(ObjectCreationCoroutine(delaySeconds));
    }

    private IEnumerator ObjectCreationCoroutine(float delaySeconds)
    {
        EnableDrag(false); // Disable dragging during coroutine delay
        yield return new WaitForSeconds(delaySeconds);
        EnableDrag(true); // Re-enable dragging after delay
    }
}



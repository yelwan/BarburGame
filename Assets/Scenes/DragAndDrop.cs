using UnityEngine;
using System;
public class DragAndDrop : MonoBehaviour
{
   
    private Vector3 offset;
    [SerializeField] bool IsDraggable;
    [SerializeField] InputManager input;
    private void Awake () {
        input.RegisterToInputEvents(HandleMouseEvent);
    }
    public  Action<Vector3> DropDelegate;
    private void HandleMouseEvent(MouseInputs NewMouseInputs, Vector3 MousePosition)
    {
        if (!IsDraggable) return;
        
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
            DropDelegate?.Invoke(MousePosition);
        }
    }
}

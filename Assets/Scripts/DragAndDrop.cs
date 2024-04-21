using UnityEngine;
using System;
using System.Collections;
public class DragAndDrop : MonoBehaviour
{
   
    private Vector3 offset;
    [SerializeField] bool IsDraggable;
    private bool hasBeenDropped = false;
    [SerializeField] InputManager input;
    
    private void Awake () {
        input.RegisterToInputEvents(HandleMouseEvent);
    }
    public  Action<Vector3> DropDelegate;
    private void HandleMouseEvent(MouseInputs NewMouseInputs, Vector3 MousePosition)
    {
        if (!IsDraggable || hasBeenDropped ) return;
        
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
}

using UnityEngine;
using System;
using System.Collections;
public class DragAndDrop : MonoBehaviour
{
   
    private Vector3 offset;
    public bool IsDragging = false;
    public bool IsDraggable;
    public bool hasBeenDropped = false;
    [SerializeField] InputManager input;
    [SerializeField] AudioSource DropSound;

    private void Awake () {
        input.RegisterToInputEvents(HandleMouseEvent);
    }
    public  Action<Vector3> DropDelegate;
    private void HandleMouseEvent(MouseInputs NewMouseInputs, Vector3 MousePosition)
    {

        if (!IsDraggable || hasBeenDropped) return;
        
        if (NewMouseInputs == MouseInputs.OnMouseDown)
        {
            offset = transform.position - MousePosition;
            IsDragging = true;

        }
        if (NewMouseInputs == MouseInputs.OnMouseDrag)
        {
         transform.position = MousePosition + offset;
            IsDragging = true;

        }
        if (NewMouseInputs== MouseInputs.OnMouseUp)
        {

            if (!hasBeenDropped)
            {
                IsDragging = false;
                DropDelegate?.Invoke(MousePosition + offset);
                hasBeenDropped = true;
                DropSound.Play();
                IsDraggable = false;
            }
        }

    }
}



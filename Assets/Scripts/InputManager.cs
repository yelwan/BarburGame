using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MouseInputs
{
     OnMouseUp,
     OnMouseDown,
     OnMouseDrag
}

public class InputManager : MonoBehaviour
{
    private bool MouseDownFirst= false;
    public delegate void MouseEvent(MouseInputs NewMouseInputs, Vector3 MousePosition);

    MouseEvent mouseEvent;
    public void SetMouseDownFirst (bool i_MouseDownFirst)
    {
       MouseDownFirst = i_MouseDownFirst;
        
        if (MouseDownFirst)
        {
            OnMouseDown();
        }
        else
        {
            OnMouseUp();
        }
    }
    private void Update ()
    {
        if (!MouseDownFirst) return;
        mouseEvent?.Invoke(MouseInputs.OnMouseDrag, Input.mousePosition);
    }
    public void RegisterToInputEvents(MouseEvent i_mouseCallback)
    {
        mouseEvent += i_mouseCallback;
    }
    private void OnMouseDown ()
    {
        MouseDownFirst = true;
        mouseEvent?.Invoke(MouseInputs.OnMouseDown, Input.mousePosition);
    }
    private void OnMouseUp ()
    {
        MouseDownFirst = false;
        mouseEvent?.Invoke(MouseInputs.OnMouseUp,Input.mousePosition);
    }
   

}

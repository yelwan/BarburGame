

using System.Collections;
using UnityEngine;

public enum MouseInputs
{
    OnMouseUp,
    OnMouseDown,
    OnMouseDrag
}

public class InputManager : MonoBehaviour
{
    [SerializeField] Camera cam;
    private bool isCreatable = true;
    public bool isDragging = false;
    private bool mouseDownFirst = false;
    public delegate void MouseEvent(MouseInputs NewMouseInputs, Vector3 MousePosition);
    public MouseEvent mouseEvent;

    private void Update()
    {
        if (!mouseDownFirst) return;

        mouseEvent?.Invoke(MouseInputs.OnMouseDrag, GetMouseWorldPosition());
    }

    private Vector3 GetMouseWorldPosition()
    {
        return cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));
    }

    public void SetMouseDownFirst(bool isMouseDownFirst)
    {
        mouseDownFirst = isMouseDownFirst;

        if (mouseDownFirst)
        {
            OnMouseDown();
        }
        else
        {
            OnMouseUp();
        }
    }

    private void OnMouseDown()
    {
        isDragging = true;
        if (!isCreatable) return;

        mouseDownFirst = true;
        mouseEvent?.Invoke(MouseInputs.OnMouseDown, GetMouseWorldPosition());
    }

    private void OnMouseUp()
    {

        mouseDownFirst = false;
        mouseEvent?.Invoke(MouseInputs.OnMouseUp, GetMouseWorldPosition());
    }

    public void RegisterToInputEvents(MouseEvent i_mouseCallback)
    {
        mouseEvent += i_mouseCallback;
    }

public void SetIsCreatable(bool value)
{
    isCreatable = value;
}
}

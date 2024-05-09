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
    [SerializeField] Camera cam;
    Vector3 mouseWorldPosition => cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cam.nearClipPlane));

    private bool MouseDownFirst = false;
    private bool IsCreatable = true;
    public delegate void MouseEvent(MouseInputs NewMouseInputs, Vector3 MousePosition);

    MouseEvent mouseEvent;
    public void SetMouseDownFirst(bool i_MouseDownFirst)
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
    private void Update()
    {
        if (!MouseDownFirst) return;
        mouseEvent?.Invoke(MouseInputs.OnMouseDrag, mouseWorldPosition);
    }
    public void RegisterToInputEvents(MouseEvent i_mouseCallback)
    {
        mouseEvent += i_mouseCallback;
    }
    private void OnMouseDown()
    {
        if (!IsCreatable) return;
        MouseDownFirst = true;
        mouseEvent?.Invoke(MouseInputs.OnMouseDown, mouseWorldPosition);
    }
    private void OnMouseUp()
    {
        MouseDownFirst = false;
        mouseEvent?.Invoke(MouseInputs.OnMouseUp, mouseWorldPosition);
        StartObjectCreationCoroutine(3f);
    }
    public void StartObjectCreationCoroutine(float delaySeconds)
    {
        StartCoroutine(ObjectCreationCoroutine(delaySeconds));
    }

    private IEnumerator ObjectCreationCoroutine(float delaySeconds)
    {
        IsCreatable = false;
        yield return new WaitForSeconds(delaySeconds);
        IsCreatable = true;
    }
}
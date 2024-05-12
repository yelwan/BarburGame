

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum MouseInputs
{
    OnMouseUp,
    OnMouseDown,
    OnMouseDrag
}

public class InputManager : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Text timerText;
    [SerializeField] Renderer tissueRenderer; 
    public bool isDragging = false;
    private bool mouseDownFirst = false;
    private bool isCreatable = true;
    private float timer = 0f;

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
        StartObjectCreationCoroutine(3f);
    }

    private void StartObjectCreationCoroutine(float delaySeconds)
    {
        StartCoroutine(ObjectCreationCoroutine(delaySeconds));
    }

    private IEnumerator ObjectCreationCoroutine(float delaySeconds)
    {
        isCreatable = false;
        timer = delaySeconds;

        while (timer >= 0)
        {
            UpdateTimerText();
            UpdateTissueColor();
            yield return new WaitForSeconds(1f);
            timer -= 1;
        }

        isCreatable = true;
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Time Left: " + Mathf.Round(timer).ToString();
        }
    }

    private void UpdateTissueColor()
    {
        if (tissueRenderer != null)
        {
            float darkness = Mathf.Lerp(0f, 1f, 1f - (timer / 3f)); 
            tissueRenderer.material.color = new Color(darkness, darkness, darkness);
        }
    }

    public void RegisterToInputEvents(MouseEvent i_mouseCallback)
    {
        mouseEvent += i_mouseCallback;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public bool IsMouseDown => Input.GetMouseButtonDown(0);

    public bool IsMouseUp => Input.GetMouseButtonUp(0);

    public Vector2 MousePositionScreenSpace => Input.mousePosition;


}

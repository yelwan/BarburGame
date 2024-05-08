using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class dragAndDropCtr : MonoBehaviour
{
    private Vector3 offsetpos;
    [NonSerialized] public bool IsDraggable1 =false;
    private bool hasBeenDropped1 = false;
    public Action<Vector3> DropDelegate;
    

    public void HandleMouse(MouseManager mouseManager, Vector3 mouseWorldPosition)
    {

        if (mouseManager.IsMouseDown)
        {
            offsetpos = transform.position - mouseWorldPosition;
            IsDraggable1 = true;
        }
        if (mouseManager.IsMouseUp)
        {
            if (!hasBeenDropped1)
            {
                hasBeenDropped1 = true;
                IsDraggable1 = false;
            }
        }

    }
}

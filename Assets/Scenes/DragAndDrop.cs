using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// the gameObject must have a body collider or else this class would not function
public class DragAndDrop : MonoBehaviour
{
   
    // create an object of type TissueObject to be able to create an instance of TissueObject
    private TissueObject tissue;
    // create a Vector3 var to store  the difference between the position of the object being dragged and current mouse position.
    Vector3 MousePositionOffset;
    private void Start()
    {
        // initalize it using get componenet from gameObject
        tissue = gameObject.GetComponent<TissueObject>();
    }
    private Vector3 GetMousePosition()
    {
        // this function returns the mouse position on the screen by input using screenworldpoint function
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    // onMouseDown, like  called once the user presses on the mouse
    private void OnMouseDown ()
    {
        MousePositionOffset = transform.position - GetMousePosition();   
    }
    // OnMouseDrag is like Update keeps getting called each frame once the player mouse clicks and changes the position to change the gameObject position. 
    private void OnMouseDrag()
    {
        // set the position of the gameObject as offset + current mouse position
        Vector3 setPos = MousePositionOffset + GetMousePosition();
        if (tissue)
        {
            if (tissue.IsPlacementValid(setPos))
            {
                tissue.MoveTissueObject(setPos);
            }
        }
    }
}
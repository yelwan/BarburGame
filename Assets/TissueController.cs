using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] MouseManager mouseManager;
    [SerializeField] dragAndDropCtr dragAndDropCtrInstance;
    private GameObject collided;
    [SerializeField] CreateTissueObject ObjectType;
    public TissueObject currentTissue;
   // public TissueObject CurrentTissue => currentTissue;
    Vector3 mouseWorldPosition;
   // private TissueObject originalTissue; // To store the original tissue
   // private TissueObject instanceTissue; // To store the original tissue



    void Update()
    {
        mouseWorldPosition = cam.ScreenToWorldPoint(new Vector3(mouseManager.MousePositionScreenSpace.x, mouseManager.MousePositionScreenSpace.y, cam.nearClipPlane));
        dragAndDropCtrInstance.HandleMouse(mouseManager, mouseWorldPosition);
        if (mouseManager.IsMouseDown) onDown();
        onDrag();
        if (mouseManager.IsMouseUp) onUp();
    }

    void onDown()
    {
        Debug.Log("inisde ondown");
        if (currentTissue == null) return;
        Debug.Log("onDown called"); // This will print a message to the console when onDown is called

        // Ensure that ObjectType is properly initialized
         //if (currentTissue == originalTissue)
        
            Debug.Log("onobjecttype called"); // This will print a message to the console when onDown is called

        currentTissue = (ObjectType.InstantiateTissueObject()).GetComponent<TissueObject>();
        currentTissue.transform.position = mouseWorldPosition;// Set to an initial position
          //  currentTissue = newTissue.GetComponent<TissueObject>();
            //currentTissue = instanceTissue;
        
    }




    void onDrag()
    {
        if (currentTissue == null || dragAndDropCtrInstance.IsDraggable1 == false) return;
        Debug.Log("beingdragged");

        currentTissue.transform.position = mouseWorldPosition;
    }

    void onUp()
    {
    }
}

/*
 if (currentTissue == null) return;

        // Temporarily disable the TissueObject's collider
        Collider2D tissueCollider = currentTissue.GetComponent<Collider2D>();
        if (tissueCollider != null)
        {
            tissueCollider.enabled = false;
        }

        // Check if a collider overlaps the position where the object is dropped
        Collider2D hit = Physics2D.OverlapPoint(currentTissue.transform.position);

        // Re-enable the TissueObject's collider
        if (tissueCollider != null)
        {
            tissueCollider.enabled = true;
        }

        if (hit != null)
        {
            Debug.Log("Hit object tag: " + hit.gameObject.tag);
        }

        // Check if the overlapped collider is the correct target
        if (hit != null && hit.gameObject.CompareTag("DropArea"))
        {
            // The object was dropped in the correct position
            Debug.Log("Object dropped in the correct position");
        }
        else
        {
            // The object was not dropped in the correct position
            Debug.Log("Object dropped in the wrong position");
            Destroy(currentTissue.gameObject);

            // Create a new clone of the original tissue and use it as the currentTissue
        }
    }
 */



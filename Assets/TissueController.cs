using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] MouseManager mouseManager;

    TissueObject currentTissue = null;

    public TissueObject CurrentTissue => currentTissue;


    void Update()
    {
        if(mouseManager.IsMouseDown) onDown();
        onDrag();
        if(mouseManager.IsMouseUp) onUp();
    }

    void onDown()
    {
        if (currentTissue != null) return;

        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(mouseManager.MousePositionScreenSpace);
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector3.forward);

        if(hit)
        {
            // get collider and game object from hit
            // get component of your tissue factory
            // if a tissue factory was found, get new tissue and assign to current tissue

        }

    }

    void onUp()
    {
        if (currentTissue == null) return;

        // call the logic that will drop the tissue
    }

    void onDrag()
    {
        if (currentTissue == null) return;

        // move the current around (add offset if needed)
    }



}

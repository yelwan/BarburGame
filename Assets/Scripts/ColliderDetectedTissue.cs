using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetectedTissue : MonoBehaviour
{
    [SerializeField] Renderer tissueRenderer;
    private Color originalColor;
    private Color currentColor;
    private Collider2D myCollider;

    private void Start()
    {
        if (tissueRenderer != null)
        {
            originalColor = tissueRenderer.material.color;
            currentColor = originalColor;
        }
        myCollider = GetComponent<Collider2D>();  // Get the Collider2D component attached to the GameObject
    }

    private void Update()
    {
        DragAndDrop dragAndDrop = GetComponent<DragAndDrop>();
        if (dragAndDrop != null && tissueRenderer != null)
        {
            if (!dragAndDrop.IsDraggable || dragAndDrop.hasBeenDropped)
            {
                currentColor = originalColor;
            }
        }
        tissueRenderer.material.color = currentColor;
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (tissueRenderer != null)
        {
            DragAndDrop dragAndDrop = GetComponent<DragAndDrop>();
            if (dragAndDrop != null)
            {
                // Check if there are any other TissueObject colliders in the same area
                Collider2D[] overlappingColliders = Physics2D.OverlapCircleAll(transform.position, myCollider.bounds.extents.magnitude);

                bool isOverlappingTissueObject = false;
                foreach (Collider2D overlappingCollider in overlappingColliders)
                {
                    if (overlappingCollider != myCollider && overlappingCollider.GetComponent<TissueObject>() != null)
                    {
                        isOverlappingTissueObject = true;
                        break;
                    }
                }

                if (isOverlappingTissueObject)
                {
                    currentColor = Color.red;
                }
                else
                {
                    currentColor = Color.green;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
                currentColor = originalColor;
    }
}

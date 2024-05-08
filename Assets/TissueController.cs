using UnityEngine;

public class TissueController : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] MouseManager mouseManager;

    private TissueObject currentTissue = null;
    private bool hasBeenDropped = false;
    private bool isDraggable = false;

    void Update()
    {
        if (!isDraggable || hasBeenDropped)
            return;

        if (mouseManager.IsMouseDown)
            OnDown();

        if (mouseManager.IsMouseUp)
            OnUp();

        if (isDraggable)
            OnDrag();
    }

    void OnDown()
    {
        if (currentTissue != null)
            return;

        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(mouseManager.MousePositionScreenSpace);
        RaycastHit2D hit = Physics2D.Raycast(mouseWorldPosition, Vector2.zero);

        if (hit.collider != null)
        {
            currentTissue = hit.collider.gameObject.GetComponent<TissueObject>();
            if (currentTissue != null)
                isDraggable = true;
        }
    }

    void OnUp()
    {
        if (currentTissue == null)
            return;

        if (!hasBeenDropped)
        {
            currentTissue.HandleDrop(cam.ScreenToWorldPoint(mouseManager.MousePositionScreenSpace));
            hasBeenDropped = true;
            isDraggable = false;
        }
    }

    void OnDrag()
    {
        if (currentTissue == null)
            return;

        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(mouseManager.MousePositionScreenSpace);
        currentTissue.transform.position = mouseWorldPosition;
    }
}

using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private GameObject createTissueObject;
    private CreateTissueObject createTissue;
    private TissueObject tissue;
    private void Start()
    {
        createTissue = GetComponent<CreateTissueObject>();
        tissue = GetComponent<TissueObject>();
    }

    private void OnMouseDown()
    {
        if (!createTissue.IsTissueObject(gameObject))
        {
            isDragging = true;
            offset = transform.position - GetMouseWorldPosition();
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = GetMouseWorldPosition() + offset;
            createTissueObject = GetComponent<CreateTissueObject>().InstantiateTissueObject();
            if (!createTissue.IsTissueObject(gameObject))
                tissue.MoveTissueObject(newPosition);
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Input.mousePosition;
    }
}

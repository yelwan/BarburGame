using UnityEngine;

public class CreateTissueObject : MonoBehaviour
{
    public GameObject originalPrefab;
    private GameObject temp;
    private GameObject instantiatedObject;
    [SerializeField] InputManager input;
    private void HandleMouseEvent (MouseInputs NewMouseInputs, Vector3 MousePosition)
    {
     if (NewMouseInputs== MouseInputs.OnMouseDown)
        {
            temp = InstantiateTissueObject();
            
            temp.GetComponent<InputManager>().SetMouseDownFirst(true);
        }
     if (NewMouseInputs== MouseInputs.OnMouseUp)
        {
            temp.GetComponent<InputManager>().SetMouseDownFirst(false);
            temp = null;
        }
    }
    private void Start()
    {
        input.RegisterToInputEvents(HandleMouseEvent);
    }
    public GameObject InstantiateTissueObject()
    {
        instantiatedObject = Instantiate(originalPrefab, transform.position, Quaternion.identity);
        return instantiatedObject;
    }

    
}

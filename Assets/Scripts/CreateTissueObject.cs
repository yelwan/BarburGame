using UnityEngine;

public class CreateTissueObject : MonoBehaviour
{
    public GameObject originalPrefab;
    private GameObject i_tissueObject;
    private GameObject instantiatedObject;
    [SerializeField] InputManager input;
    [SerializeField] AudioSource CreationSound;

    private void HandleMouseEvent (MouseInputs NewMouseInputs, Vector3 MousePosition)
    {
        
     if (NewMouseInputs== MouseInputs.OnMouseDown)
        {
            i_tissueObject = InstantiateTissueObject();
            if (i_tissueObject==null) return;
            i_tissueObject.GetComponent<InputManager>().SetMouseDownFirst(true);
           
      }
     if (NewMouseInputs== MouseInputs.OnMouseUp)
        {
             if (i_tissueObject==null) return;
            i_tissueObject.GetComponent<InputManager>().SetMouseDownFirst(false);
            i_tissueObject = null;

        }
    }
    private void Start()
    {
        input.RegisterToInputEvents(HandleMouseEvent);
    }
    public GameObject InstantiateTissueObject()
    {
        CreationSound.Play();
        instantiatedObject = Instantiate(originalPrefab, transform.position, Quaternion.identity);
        return instantiatedObject;
    }

    
}

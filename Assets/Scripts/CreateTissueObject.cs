using UnityEngine;

public class CreateTissueObject : MonoBehaviour
{
    public GameObject originalPrefab;
    private GameObject instantiatedObject;

    public GameObject InstantiateTissueObject()
    {
        instantiatedObject = Instantiate(originalPrefab, transform.position, Quaternion.identity);
        return instantiatedObject;
    }


}

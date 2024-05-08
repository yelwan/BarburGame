using UnityEngine;

public class CreateTissueObject : MonoBehaviour
{
    public GameObject originalPrefab;
    private GameObject instantiatedObject;

    public GameObject InstantiateTissueObject()
    {
        instantiatedObject = Instantiate(new GameObject("t", typeof(TissueObject)), transform.position, Quaternion.identity);
        return instantiatedObject;
    }


}

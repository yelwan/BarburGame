using UnityEngine;

public class CreateTissueObject : MonoBehaviour
{
    public GameObject originalPrefab; // The original prefab to instantiate
    private GameObject instantiatedObject; // Reference to the instantiated object
    private bool hasBeenInstantiated = false; // Flag to track if the prefab has been instantiated

    public GameObject InstantiateTissueObject()
    {
        // Only instantiate if the object hasn't been created yet
        if (!hasBeenInstantiated)
        {
            instantiatedObject = Instantiate(originalPrefab, transform.position, Quaternion.identity);
            instantiatedObject.name = "TissueObject"; // Optionally rename the instantiated object
            hasBeenInstantiated = true;
        }

        return instantiatedObject;
    }

    public bool IsTissueObject(GameObject obj)
    {
        // Check if the provided GameObject is the instantiated "TissueObject"
        return obj == instantiatedObject && instantiatedObject != null;
    }
}

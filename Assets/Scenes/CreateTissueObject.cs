using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTissueObject : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject prefab;
    public bool isMouseUp;
    public GameObject newCube;

    public GameObject InstantiatePrefab()
    {
        prefab = Instantiate(newCube, transform.position, Quaternion.identity);
        return prefab;
    }
    // Update is called once per frame
    private void OnMouseDown()
    {
        isMouseUp = false;
   
    }
}

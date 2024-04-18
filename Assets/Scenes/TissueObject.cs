using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueObject : MonoBehaviour
{
    public  GameObject prefab; 
    private int magnitude;
    private int MaxQuantity;
    private int CurrentQuantity;
    private int minX = 0;
    private int minY = 0;
    private int maxX = 100;
    private int maxY = 100;
    // Start is called before the first frame update
   public void MoveTissueObject(Vector3 pos)
    {
       prefab.transform.position = pos;
    }
 
    public bool IsPlacementValid(Vector3 pos)
    {
        if (pos.x >minX && pos.y > minY && pos.x < maxX && pos.y < maxY) return true;
        return false;
    } 
    private void Start () {
     prefab =  Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
    private void OnMouseDown() {
     prefab =  Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
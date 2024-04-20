using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueObject : MonoBehaviour
{
    
    private int magnitude;
    private int MaxQuantity;
    private int CurrentQuantity;
    private int minX = 0;
    private int minY = 0;
    private int maxX = 100;
    private int maxY = 100;
    // Start is called before the first frame update
   public void MoveTissueObject(Vector3 Pos)
    {
       transform.position = Pos ;
    }
 
    public bool IsPlacementValid(Vector3 pos)
    {
        return pos.x >minX && pos.y > minY && pos.x < maxX && pos.y < maxY;
    } 
    
}
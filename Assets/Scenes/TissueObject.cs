using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueObject : MonoBehaviour
{
    
    private int magnitude;
    private int MaxQuantity;
    private int CurrentQuantity;
    [SerializeField] Vector3 MinBound;
    [SerializeField] DragAndDrop dragAndDrop;
    [SerializeField] Vector3 MaxBound;
    private void Awake ()
    {
        dragAndDrop.DropDelegate += HandleDrop;
    }
    private void HandleDrop (Vector3 Position)
    {
        if (!IsPlacementValid(Position))
        {
            Destroy(gameObject);
        }
    }
    public bool IsPlacementValid(Vector3 pos)
    {
       return pos.x > MinBound.x && pos.y > MinBound.y && pos.x < MaxBound.x && pos.y < MaxBound.y;
    }
    private void OnDrawGizmos()
    {
        Vector3[] points = new Vector3[8]
        {
            MinBound,
            new Vector3(MaxBound.x,MinBound.y,0),
            new Vector3(MaxBound.x,MinBound.y,0),
            MaxBound,
            MaxBound,
            new Vector3(MinBound.x,MaxBound.y,0),
            new Vector3(MinBound.x,MaxBound.y,0),
            MinBound
        };
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawLineList(points);
    }
}

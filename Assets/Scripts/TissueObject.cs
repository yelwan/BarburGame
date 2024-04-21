using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueObject : MonoBehaviour
{
    
    private int magnitude;
    private int MaxQuantity;
    private int CurrentQuantity;
    Vector3 MinBound;
    [SerializeField] DragAndDrop dragAndDrop;
    Vector3 MaxBound;
    private bool valid;
    private void Awake ()
    {
        dragAndDrop.DropDelegate += HandleDrop;
    }
    private void HandleDrop(Vector3 Position)
    {
        if (!IsPlacementValid(Position))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        MinBound = other.bounds.min;
        MaxBound = other.bounds.max;

    }
    public bool IsPlacementValid(Vector3 pos)
    {

        valid = pos.x > MinBound.x && pos.y > MinBound.y && pos.x < MaxBound.x && pos.y < MaxBound.y;
        return valid;

    }
 
}

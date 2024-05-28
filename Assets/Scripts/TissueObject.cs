using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TissueObject : MonoBehaviour
{
    //[SerializeField] FactoryAnimation factory;
    public int magnitude = 5;
    private int MaxQuantity;
    private int CurrentQuantity;
    Vector3 MinBound;
    [SerializeField] DragAndDrop dragAndDrop;
    Vector3 MaxBound;
    private bool valid;
    private Collider2D objectCollider;
    private void Awake ()
    {
        dragAndDrop.DropDelegate += HandleDrop;
        objectCollider = GetComponent<Collider2D>();
    }
    private void HandleDrop(Vector3 Position)
    {
        IsAnotherObjectInCollider();
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
    private void IsAnotherObjectInCollider()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(objectCollider.bounds.center, objectCollider.bounds.size, 0f);

        foreach (Collider2D collider in colliders)
        {
            if (collider != objectCollider)
            {
                TissueObject otherTissue = collider.GetComponent<TissueObject>();
                if (otherTissue != null)
                {
                    Destroy(gameObject);
                }
            }
        }

    }
}

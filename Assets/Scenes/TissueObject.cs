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
        Debug.Log(other.name);
        //insideCollider= other.bounds.Contains(targetTransform.position);
        MinBound = other.bounds.min;
        MaxBound = other.bounds.max;
        Debug.Log(MinBound);

        Debug.Log(MaxBound);

    }
    public bool IsPlacementValid(Vector3 pos)
    {
        Debug.Log("object: "+ pos.x);

        Debug.Log("objecty: " + pos.y);
        valid = pos.x > MinBound.x && pos.y > MinBound.y && pos.x < MaxBound.x && pos.y < MaxBound.y;
        Debug.Log(valid);
        return valid;

    }
    /*  private void OnDrawGizmos()
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
      }*/
}

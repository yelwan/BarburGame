using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// the job of this script is to Instantiate germ prefabs and Initialized variables for GermObject script.
public class GermFactory : MonoBehaviour
{
   
    [SerializeField] GameObject germPrefab;
    float randompos;
    Vector3 spawnPosition;
    public Transform shootingPosition1;
    public Transform shootingPosition2;
    // GermObject objects components
    [SerializeField] Collider2D GermsCloseness;
    [SerializeField] Text germcloseText;
   

    public void createGerm()

    {
        randompos = Random.Range(0, 2);
        if (randompos == 1) { spawnPosition = shootingPosition1.position; }
        else spawnPosition = shootingPosition2.position;
        if (germPrefab != null)
        {
          GameObject germClone =  Instantiate(germPrefab, spawnPosition, Quaternion.identity);
          GermAnimation germAnim =  germClone.GetComponent<GermAnimation>();
          germAnim.factory = this;
          GermObject germObject = germClone.GetComponent<GermObject>();
          germObject.germcloseText = germcloseText;
          germObject.spawningArea = GetComponent<GermCorutineManager>().spawningArea;
          germObject.GermsCloseness = GermsCloseness;
        }
    }
    
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// the job of this script is to Instantiate germ prefabs and Initialized variables for GermObject script.
public class GermFactory : MonoBehaviour
{
   
    [SerializeField] GameObject germPrefab;
    //float randompos;
    float randomX;
    Vector3 spawnPosition;
    [SerializeField] Collider2D spawningAreaCollider;
    // GermObject objects components
    [SerializeField] Collider2D GermsCloseness;
    [SerializeField] Text germcloseText;
   

    public void createGerm()

    {
        
        if (spawningAreaCollider != null)
        {
            Bounds colliderBounds = spawningAreaCollider.bounds;
             randomX = Random.Range(colliderBounds.min.x, colliderBounds.max.x);
            Vector3 spawnPosition = new Vector3(randomX, colliderBounds.max.y, 0f);
        }

        if (germPrefab != null)
        {
          GameObject germClone =  Instantiate(germPrefab, spawnPosition, Quaternion.identity);
          GermAnimation germAnim =  germClone.GetComponent<GermAnimation>();
          germAnim.factory = this;
          GermObject germObject = germClone.GetComponent<GermObject>();
          germObject.germcloseText = germcloseText;
          germObject.spawningArea = GetComponent<GermCorutineManager>().spawningArea;
          germObject.GermsCloseness = GermsCloseness;
        }
    }
    
}
      */
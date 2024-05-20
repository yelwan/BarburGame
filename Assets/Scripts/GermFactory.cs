using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// the job of this script is to Instantiate germ prefabs and Initialized variables for GermObject script.
public class GermFactory : MonoBehaviour
{
   
    [SerializeField] GameObject germPrefab;
    int randompos;
    Vector3 spawnPosition;
    public Transform []shootingPosition;
    // GermObject objects components
    [SerializeField] Collider2D GermsCloseness;
    [SerializeField] Text germcloseText;
    [SerializeField] int maxMagnitude;




    public void createGerm()

    {
        randompos = Random.Range(1, maxMagnitude);
         spawnPosition = shootingPosition[randompos].position;
        if (germPrefab != null)
        {
          GameObject germClone =  Instantiate(germPrefab, spawnPosition, Quaternion.identity);
          GermAnimation germAnim =  germClone.GetComponent<GermAnimation>();
          germAnim.factory = this;
          GermObject germObject = germClone.GetComponent<GermObject>();
          germObject.germcloseText = germcloseText;
          germObject.spawningArea = GetComponent<GermCorutineManager>().spawningArea;
          germObject.GermsCloseness = GermsCloseness;
          germObject.magnitude = germAnim.germMag = Random.Range(0, maxMagnitude); 
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
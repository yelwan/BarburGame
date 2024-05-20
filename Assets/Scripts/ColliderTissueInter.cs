using UnityEngine;

public class ColliderVsTissue : MonoBehaviour
{
    [SerializeField] GermAnimation germscript;

    private void OnTriggerStay2D(Collider2D collision)
    {
        TissueObject tissueCollider = collision.gameObject.GetComponent<TissueObject>();

        DragAndDrop dragAndDrop = collision.gameObject.GetComponent<DragAndDrop>();

        if (tissueCollider != null && dragAndDrop != null)
        {
            if (!dragAndDrop.IsDragging)
            {
                int germMagnitude = germscript.germMag;
                int tissueMagnitude = tissueCollider.magnitude;
                while (tissueMagnitude > germMagnitude)
                {
                    Destroy(germscript.gameObject);
                    tissueMagnitude -= germMagnitude;
                    if (tissueMagnitude <= 0)
                    {
                        return;
                    }
                }
                
                while (germMagnitude > tissueMagnitude)
                {
                    Destroy(tissueCollider.gameObject);
                    germMagnitude -= tissueMagnitude;
                    if (germMagnitude <= 0)
                    {
                        break;
                    }
                    germscript.germMag = germMagnitude;

                }
                
            }
        }
    }
}

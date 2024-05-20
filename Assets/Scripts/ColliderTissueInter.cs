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
                    tissueMagnitude -= germMagnitude;
                    if (tissueMagnitude <= 0)
                    {
                        break;
                    }
                }
                tissueCollider.magnitude = tissueMagnitude;
                if (tissueMagnitude <= 0)
                {
                    Destroy(tissueCollider.gameObject);
                }
                while (germMagnitude > tissueMagnitude)
                {
                    germMagnitude -= tissueMagnitude;
                    if (germMagnitude <= 0)
                    {
                        break;
                    }
                }
                germscript.germMag = germMagnitude;
                if (germMagnitude <= 0)
                {
                    Destroy(germscript.gameObject);
                }
            }
        }
    }
}

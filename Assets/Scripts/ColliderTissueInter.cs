using UnityEngine;

public class ColliderTissueInter : MonoBehaviour
{
    [SerializeField] GermObject germscript;
    


    private void OnTriggerStay2D(Collider2D collision)
    {
        TissueObject tissueCollider = collision.gameObject.GetComponent<TissueObject>();

        DragAndDrop dragAndDrop = collision.gameObject.GetComponent<DragAndDrop>();
        GermAnimation germAnim = germscript.GetComponent<GermAnimation>();

        if (tissueCollider != null && dragAndDrop != null)
        {
            if (!dragAndDrop.IsDragging)
            {
                int germMagnitude = germscript.magnitude;
                int tissueMagnitude = tissueCollider.magnitude;

                while (tissueMagnitude > germMagnitude)
                {

                    germscript.TissueWins.Play();
                    Destroy(germscript.gameObject);
                    tissueMagnitude -= germMagnitude;
                    if (tissueMagnitude <= 0)
                    {
                        return;
                    }
                }
                
                while (germMagnitude > tissueMagnitude)
                {

                    germscript.GermWins.Play();
                    Destroy(tissueCollider.gameObject);
                    germMagnitude -= tissueMagnitude;
                    if (germMagnitude <= 0)
                    {
                        break;
                    }
                    germscript.magnitude= germAnim.germMag = germMagnitude;

                }
                
            }
        }
    }
}

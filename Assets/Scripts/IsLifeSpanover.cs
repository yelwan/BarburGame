using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLifeSpanOver : MonoBehaviour
{
    private float lifeSpanCounter = 0f;
    [SerializeField] DragAndDrop dragAndDrop = null;
    [SerializeField] TissueObject tissue = null;
    void Update()
    {
        lifeSpanCounter += Time.deltaTime;
        CheckForLifeSpan();
    }

    private void CheckForLifeSpan()
    {
        if (dragAndDrop == null || tissue==null) return;
        if (dragAndDrop.hasBeenDropped) {

            if (lifeSpanCounter >= 10f)
            {
                Destroy(tissue.gameObject);
            }
        }
    }
}

using UnityEngine;

public class Germ : MonoBehaviour
{
    private int maxMagnitude = 200;


    void Start()
    {
       ApplyRandomContinuousForce(); 
    }

    private void ApplyRandomContinuousForce()
    {
        Rigidbody2D germRigidbody = GetComponent<Rigidbody2D>();

        if (germRigidbody != null)
        {
            germRigidbody.velocity = Random.insideUnitCircle * maxMagnitude / 10f;

        }
    }
}
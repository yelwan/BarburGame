using UnityEngine;
using System.Collections;

public class GermsController : MonoBehaviour
{
    public GameObject germPrefab;
    public Transform shootingPosition;
    private int maxMagnitude = 1000;
    private bool canShoot = true;
    private bool isSpawning = false;

    void Start()
    {
        StartCoroutine(ShootGermsCoroutine());
    }

    IEnumerator ShootGermsCoroutine()
    {
        while (true)
        {
            if (canShoot && !isSpawning)
            {
                isSpawning = true;
                yield return new WaitForSeconds(5f);
                GameObject germ = Instantiate(germPrefab, shootingPosition.position, Quaternion.identity);
                ApplyRandomContinuousForce(germ);
                isSpawning = false; 
            }

            yield return null; 
        }
    }

    private void ApplyRandomContinuousForce(GameObject germ)
    {
        Rigidbody2D germRigidbody = germ.GetComponent<Rigidbody2D>();

        if (germRigidbody != null)
        {
            germRigidbody.velocity = Random.insideUnitCircle * maxMagnitude / 10f; 
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GermsController : MonoBehaviour
{
    public GameObject germPrefab;
    public Transform shootingPosition;
    private bool canShoot = true;
    private bool isSpawning = false;
    [SerializeField] Text countdownTextUI = null;

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
                if (countdownTextUI != null)
                {
                    isSpawning = true;
                    applyCountdownText("5");
                    yield return new WaitForSeconds(1f);
                    applyCountdownText("4");
                    yield return new WaitForSeconds(1f);
                    applyCountdownText("3");
                    yield return new WaitForSeconds(1f);
                    applyCountdownText("2");
                    yield return new WaitForSeconds(1f);
                    applyCountdownText("1");
                    yield return new WaitForSeconds(1f);
                    applyCountdownText("Germ Attack");
                    yield return new WaitForSeconds(1f);
                    Collider2D spawningAreaCollider = GetComponent<Germ>().spawningArea;
                    if (spawningAreaCollider != null)
                    {
                        Bounds colliderBounds = spawningAreaCollider.bounds;
                        float randomX = Random.Range(colliderBounds.min.x, colliderBounds.max.x);
                        Vector3 spawnPosition = new Vector3(randomX, 160.6f, 0f);
                        Instantiate(germPrefab, spawnPosition, Quaternion.identity);
                        isSpawning = false;
                    }
                }
                yield return null;
            }
        }
    }
    void applyCountdownText(string i_text)
    {
        if (countdownTextUI == null) return;
        countdownTextUI.text = i_text;
    }
}
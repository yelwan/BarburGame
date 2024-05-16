using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GermsController : MonoBehaviour
{
    public GameObject germPrefab;
    public Transform shootingPosition1;
    public Transform shootingPosition2;
    private bool canShoot = true;
    private bool isSpawning = false;
    float randompos;
     Vector3 spawnPosition;
    [SerializeField] Text countdownTextUI = null;
    private GameObject currentGerm;

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
                        //Bounds colliderBounds = spawningAreaCollider.bounds;
                         randompos = Random.Range(0, 2);
                        if(randompos==1) spawnPosition=shootingPosition1.position;
                        else spawnPosition=shootingPosition2.position;
                        //spawnPosition = new Vector3(randomX, 160.6f, 0f);
                        GameObject c= Instantiate(germPrefab, spawnPosition, Quaternion.identity);
                        c.GetComponent<GermsController>().germPrefab = germPrefab;
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
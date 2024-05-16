using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateGerm : MonoBehaviour
{
    [SerializeField] Sprite[] AnimSprites;
    [SerializeField] SpriteRenderer germRenderer;
    [SerializeField] GermFactory factory;

    private Sprite currentSprite;
   // public GameObject germPrefab;
    //public Transform shootingPosition1;
    //public Transform shootingPosition2;
    private bool canShoot = true;
    private bool isSpawning = false;
    float randompos;
     Vector3 spawnPosition;
    [SerializeField] Text countdownTextUI = null;
    private int counter;
    public float switchTime = 0.5f; 
    void OnGUI(){
}
    void Start()
    {
        	counter = 0;
        StartCoroutine(ShootGermsCoroutine());
        StartCoroutine("SwitchSprite");
    }
    private IEnumerator SwitchSprite(){
	currentSprite = AnimSprites[counter++ % AnimSprites.Length];
    germRenderer.sprite = currentSprite;
	yield return new WaitForSeconds(switchTime);
	StartCoroutine("SwitchSprite");
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
                   Collider2D spawningAreaCollider = GetComponent<GermObject>().spawningArea;
                    if (spawningAreaCollider != null)
                    {
                        //Bounds colliderBounds = spawningAreaCollider.bounds;
                        // randompos = Random.Range(0, 2);
                        //if(randompos==1) spawnPosition=shootingPosition1.position;
                        //else spawnPosition=shootingPosition2.position;
                        ////spawnPosition = new Vector3(randomX, 160.6f, 0f);
                        //GameObject c = null ;
                        //if (germPrefab != null)
                        //     c = Instantiate(germPrefab, spawnPosition, Quaternion.identity);

                        //if (c != null)
                        //{ c.GetComponent<CreateGerm>().germPrefab = germPrefab; }
                        factory.createGerm();
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
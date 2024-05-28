using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MouthObject : MonoBehaviour
{
    [SerializeField] Collider2D goalCollider = null;
    [SerializeField] Sprite[] healthSprites;
    [SerializeField] SpriteRenderer healthRenderer;
    private Sprite currentSprite;
    private int counter;
    public float switchTime = 0.5f;
    [SerializeField] AudioSource HealthSound;

    public int health = 3;
    private void Update()
    {
        CheckGameOver();
    }
    void Start()
    {

         counter = 0;
        healthRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine("SwitchSprite");
    }
    /*
       
   
}
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GermAnimation germController = collision.gameObject.GetComponent<GermAnimation>();
        if (goalCollider.GetComponent<Collider>()==collision.GetComponent<Collider>())
        {
            if (germController != null)
            {
                health--;
                HealthSound.Play();
                StartCoroutine("SwitchSprite");

            }
        }
     
    }
    

        private IEnumerator SwitchSprite()
        {
            currentSprite = healthSprites[counter++ % healthSprites.Length];
            healthRenderer.sprite = currentSprite;


            yield return new WaitForSeconds(switchTime);
        }
    public bool CheckGameOver()
    {
        if (health <= 0)
        {
           return true;
        }
        else
            return false;
    }
}
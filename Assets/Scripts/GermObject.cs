
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GermObject : MonoBehaviour
{
    [SerializeField] Collider2D GermsCloseness;
     [SerializeField] GameObject originalPrefab;
    [SerializeField] float delayBeforeTextChange = 1.0f;
    [SerializeField] Text germcloseText;
    private bool isInstantiated = false;
    public Collider2D spawningArea;
    public float movementSpeed = 5f;
    private Rigidbody2D rb;
    public int magnitude = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (spawningArea == null)
        {
            Destroy(gameObject);
            return;
        }
        if (!IsInsideSpawningArea(transform.position))
        {
            Destroy(gameObject);
            return;
        }
        rb.velocity = Vector2.down * movementSpeed;
        
    }

    void Update()
    {
        if (!IsInsideSpawningArea(transform.position))
        {
            Destroy(gameObject);
        }
        if (isInstantiated) {
        
        }
    }

    private bool IsInsideSpawningArea(Vector2 position)
    {
        if (spawningArea == null)
            return false;

        float minY = spawningArea.bounds.min.y;
        float maxY = spawningArea.bounds.max.y;
        float minX = spawningArea.bounds.min.x;
        float maxX = spawningArea.bounds.max.y;
        return (position.y >= minY && position.y <= maxY && position.x >= minX && position.x <= maxX);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == GermsCloseness)
        {
            StartCoroutine(ShowGermsCloseText());
        }
    }

    private IEnumerator ShowGermsCloseText()
    {
        yield return new WaitForSeconds(delayBeforeTextChange);
        germcloseText.text = "Germs getting too close, Go Down!";
    }
}


using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GermObject : MonoBehaviour
{
    public Collider2D GermsCloseness;

    [SerializeField] float delayBeforeTextChange = 1.0f;
    [SerializeField] GermAnimation germAnim;
    public Text germcloseText;
    private bool isInstantiated = false;
    public Collider2D spawningArea;
    public float movementSpeed = 5f;
    private Rigidbody2D rb;
    public int magnitude;
    public AudioSource TissueWins;
    public AudioSource GermWins;
    void Start()
    {
        magnitude = germAnim.germMag;

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
        germcloseText.text = "Germs getting close!";
        yield return new WaitForSeconds(3);
        germcloseText.text = "";

    }
}

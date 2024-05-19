using UnityEngine;

public class MouthObject : MonoBehaviour
{
    [SerializeField] Collider2D goalCollider = null;
    public int health = 3;
    private void Update()
    {
        CheckGameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GermAnimation germController = collision.gameObject.GetComponent<GermAnimation>();
        if (goalCollider.GetComponent<Collider>()==collision.GetComponent<Collider>())
        {
            if (germController != null)
            {
                health--;
            }
        }
     
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
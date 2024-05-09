using UnityEngine;

public class MouthClass : MonoBehaviour
{
    public int health = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GermsController germController = collision.gameObject.GetComponent<GermsController>();

        if (germController != null)
        {
            health--;
        }

        if (health <= 0)
        {
            Time.timeScale = 0;
        }
    }
}
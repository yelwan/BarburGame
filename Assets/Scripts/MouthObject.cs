using UnityEngine;

public class MouthObject : MonoBehaviour
{
    public int health = 200;
    private void Update()
    {
        CheckGameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CreateGerm germController = collision.gameObject.GetComponent<CreateGerm>();

        if (germController != null)
        {
            health--;
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
using UnityEngine;

public class RegisterCollider : MonoBehaviour
{
    private void OnEnable()
    {
        ColliderManager.Initialize(); 

        if (ColliderManager.Instance != null)
        {
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                ColliderManager.Instance.RegisterCollider(GetComponent<Collider2D>());
            }
        }

    }

    private void OnDisable()
    {
        if (!this.gameObject.scene.isLoaded) return;
        ColliderManager.Initialize();
        if (ColliderManager.Instance != null)
        {
            Collider2D collider = GetComponent<Collider2D>();
            if (collider != null)
            {
                ColliderManager.Instance.UnregisterCollider(GetComponent<Collider2D>());
            }
        }

    }
}

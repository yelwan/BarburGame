using System.Collections.Generic;
using UnityEngine;

public class ColliderManager : MonoBehaviour
{
    private static ColliderManager _instance;
    public static ColliderManager Instance
    {
        get
        {
            return _instance;
        }
        private set => _instance = value;
    }

    public List<Collider2D> colliders = new List<Collider2D>();
    private void Awake()
    {
        _instance = this;
    }

    public void RegisterCollider(Collider2D collider)
    {
        if (!colliders.Contains(collider))
        {
            colliders.Add(collider);
        }
    }

    public void UnregisterCollider(Collider2D collider)
    {
        if (colliders.Contains(collider))
        {
            colliders.Remove(collider);
        }
    }

    public List<Collider2D> GetColliders()
    {
        return colliders;
    }


    public static void Initialize()
    {
        if (Instance == null)
        {
            var colliderManagerObject = new GameObject("ColliderManager");
            Instance = colliderManagerObject.AddComponent<ColliderManager>();
        }
    }

}
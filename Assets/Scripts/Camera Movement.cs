using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float movementSpeed = 30f;
    [SerializeField] Camera camera;
    [SerializeField] Collider2D collider;
    private void Update()
    {
        float inputY = Input.GetAxis("Vertical");
        Vector3 targetPosition = camera.transform.position + Vector3.up * inputY * movementSpeed * Time.deltaTime;
        Bounds bounds = collider.bounds;
        float minY = bounds.min.y;
        float maxY = bounds.max.y;
        float clampedY = Mathf.Clamp(targetPosition.y, minY, maxY);
        targetPosition.y = clampedY;
        camera.transform.position = targetPosition;
    }
}
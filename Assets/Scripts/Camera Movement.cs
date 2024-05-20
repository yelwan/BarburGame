using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float movementSpeed = 30f;
    [SerializeField] Camera cam;
    [SerializeField] Collider2D coll;
    private void Update()
    {
        float inputY = Input.GetAxis("Vertical");
        Vector3 targetPosition = cam.transform.position + Vector3.up * inputY * movementSpeed * Time.deltaTime;
        Bounds bounds = coll.bounds;
        float minY = bounds.min.y;
        float maxY = bounds.max.y;
        float clampedY = Mathf.Clamp(targetPosition.y, minY, maxY);
        targetPosition.y = clampedY;
        cam.transform.position = targetPosition;
    }
}
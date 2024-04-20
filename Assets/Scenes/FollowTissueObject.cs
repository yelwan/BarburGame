using UnityEngine;

public class FollowTissueObject : MonoBehaviour
{
    [SerializeField] Transform targetTransform = null;
    [SerializeField] float damping = 0.5f;
    [SerializeField] Vector3 offset;
    private Vector3 followVelocity;

    private void Update()
    {
        if (targetTransform == null) return;

        Vector3 targetPosition = targetTransform.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref followVelocity, damping);
    }
}
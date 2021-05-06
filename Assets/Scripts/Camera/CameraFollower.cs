using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform followed;
    [SerializeField] private Vector3 positionOffset;

    private void LateUpdate()
    {
        if (followed == null) return;
        transform.position = followed.position + positionOffset;
    }
}
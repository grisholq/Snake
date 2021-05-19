using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform followed;
    [SerializeField] private Vector3 positionOffset;

    public Transform Followed { get => followed; set => followed = value; }

    private void LateUpdate()
    {
        if (followed == null) return;
        transform.position = followed.position + positionOffset;
    }
}
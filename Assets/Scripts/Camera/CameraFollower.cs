using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform followed;
    [SerializeField] private Vector3 positionOffset;

    public Transform Followed { get => followed; set => followed = value; }

    private void LateUpdate()
    {
        if (followed == null) return;

        Vector3 newPos = followed.position;

        newPos.x = transform.position.x;
        newPos.y += positionOffset.y;
        newPos.z += positionOffset.z;

        transform.position = newPos;
    }
}
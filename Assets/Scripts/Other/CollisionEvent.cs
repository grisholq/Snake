using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent<Collider> onCollision;

    private void OnTriggerEnter(Collider other)
    {
        onCollision.Invoke(other);
    }
}
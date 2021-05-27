using UnityEngine;
using System;

public class CollisionEvent : MonoBehaviour
{
    public event Action<Collider> CollisionOccured;

    private void OnTriggerEnter(Collider other)
    {
        CollisionOccured(other);
    }
}
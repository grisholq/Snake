using System;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    private new Rigidbody rigidbody;

    public event Action<Collider> OnCollision;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void SetVelocity(Vector3 velocity)
    {
        rigidbody.velocity = velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        OnCollision(other);
    }
}
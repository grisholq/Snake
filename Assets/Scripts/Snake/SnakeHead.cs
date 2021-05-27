using System;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    [SerializeField] private CollisionEvent headCollisionEvent;
    [SerializeField] private CollisionEvent foodCollisionEvent;

    private new Rigidbody rigidbody;
   
    public event Action<Collider> HeadCollision;
    public event Action<Collider> FoodCollision;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        headCollisionEvent.CollisionOccured += OnHeadCollision;
        foodCollisionEvent.CollisionOccured += OnFoodCollision;
    }

    public void SetVelocity(Vector3 velocity)
    {
        rigidbody.velocity = velocity;
    }

    public void OnFoodCollision(Collider other)
    {
        FoodCollision(other);
    }

    public void OnHeadCollision(Collider other)
    {
        HeadCollision(other);
    }
}
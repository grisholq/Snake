using System;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    [SerializeField] private CollisionEvent headCollisionEvent;
    [SerializeField] private CollisionEvent foodCollisionEvent;
    [SerializeField] private CollisionEvent fewerCollisionEvent;

    private new Rigidbody rigidbody;
    private new MeshRenderer meshRenderer;
   
    public event Action<Collider> HeadCollision;
    public event Action<Collider> FoodCollision;
    public event Action<Collider> FewerCollision;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<MeshRenderer>();

        headCollisionEvent.CollisionOccured += OnHeadCollision;
        foodCollisionEvent.CollisionOccured += OnFoodCollision;
        fewerCollisionEvent.CollisionOccured += OnFewerCollision;
    }

    public void SetVelocity(Vector3 velocity)
    {
        rigidbody.velocity = velocity;
    }
    
    public void SetColor(Color color)
    {
        meshRenderer.material.color = color;
    }

    public void OnFoodCollision(Collider other)
    {
        FoodCollision(other);
    }

    public void OnHeadCollision(Collider other)
    {
        HeadCollision(other);
    }
    
    public void OnFewerCollision(Collider other)
    {
        FewerCollision(other);
    }
}
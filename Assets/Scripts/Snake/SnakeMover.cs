using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnakeInput), typeof(SnakeParts))]
public class SnakeMover : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float forwardSpeedDecreace;
    [SerializeField] private float sideSpeed;

    private SnakeParts parts;
    private SnakeInput input;

    private Vector3 velocity;

    private void Awake()
    {
        parts = GetComponent<SnakeParts>();
        input = GetComponent<SnakeInput>();
    }

    private void Update()
    {
        velocity = Vector3.zero;

        MoveForward();

        if (input.IsRightInput)
        {
            MoveSideway(Vector3.right);
        }
        else if (input.IsLeftInput)
        {
            MoveSideway(Vector3.left);
        }

        parts.Head.SetVelocity(velocity);

        MoveChunks();
    }

    private void MoveSideway(Vector3 side)
    {
        velocity += side * sideSpeed;
        velocity -= Vector3.forward * forwardSpeedDecreace;
    }
    
    private void MoveForward()
    {
        velocity += Vector3.forward * forwardSpeed;
    }

    private void MoveChunks()
    {     
        parts.Head.SetVelocity(velocity);

        List<SnakeChunk> chunks = parts.Chunks;

        for (int i = chunks.Count - 1; i >= 0; i--)
        {           
            chunks[i].Move();
        }
    } 
}
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField, Range(1, 20)] private int chunksCount;
    [SerializeField, Range(1, 20)] private float length;

    [SerializeField] private Transform headPrefab;
    [SerializeField] private Transform chunkPrefab;

    [SerializeField] private float forwardSpeed;
    [SerializeField] private float forwardSpeedDecreace;
    [SerializeField] private float sideSpeed;
       
    [SerializeField] private CameraFollower cameraFollower;

    [Header("Chunk Settings")]

    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;

    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    private SnakeHead snakeHead;
    private List<SnakeChunk> snakeChunks;

    private void Awake()
    {
        CreateSnake();
    }

    private void Update()
    {
        ProcessMovement();
    }

    private void ProcessMovement()
    {
        Vector3 velocity = new Vector3();

        velocity += Vector3.forward * forwardSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            velocity += Vector3.left * sideSpeed;
            velocity -= Vector3.forward * forwardSpeedDecreace;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right * sideSpeed;
            velocity -= Vector3.forward * forwardSpeedDecreace;
        }

        snakeHead.SetVelocity(velocity);

        for (int i = snakeChunks.Count - 1; i >= 0; i--)
        {
            snakeChunks[i].Move();
        }
    }

    private void CreateSnake()
    {
        Vector3 headPosition = GetHeadLocalPosition();
        Vector3 delta = new Vector3(0, 0, length / chunksCount);

        snakeHead = GetHead();
        snakeHead.transform.localPosition = GetHeadLocalPosition();

        snakeChunks = new List<SnakeChunk>(chunksCount);

        for (int i = 1; i <= chunksCount; i++)
        {
            SnakeChunk chunk = GetChunk();
            InizializeChunk(chunk);
            chunk.transform.localPosition = headPosition - delta * i;
            snakeChunks.Add(chunk);
        }

        snakeChunks[0].NextChunk = snakeHead.transform;

        for (int i = 1; i < chunksCount; i++)
        {
            snakeChunks[i].NextChunk = snakeChunks[i-1].transform;
        }

        cameraFollower.Followed = snakeHead.transform;
    }

    private void InizializeChunk(SnakeChunk chunk)
    {
        chunk.MinDistance = minDistance;
        chunk.MaxDistance = maxDistance;
        chunk.MinSpeed = minDistance;
        chunk.MaxSpeed = maxSpeed;
    }

    private SnakeHead GetHead()
    {
        return Instantiate(headPrefab, transform).GetComponent<SnakeHead>();
    }

    private SnakeChunk GetChunk()
    {
        return Instantiate(chunkPrefab, transform).GetComponent<SnakeChunk>();
    }

    private Vector3 GetHeadLocalPosition()
    {
        return new Vector3(0, 0, length / 2);
    }     
}
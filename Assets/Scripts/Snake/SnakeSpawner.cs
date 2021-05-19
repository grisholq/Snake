using System.Collections.Generic;
using UnityEngine;

public class SnakeSpawner : MonoBehaviour
{
    [SerializeField, Range(1, 20)] private int chunksCount;
    [SerializeField, Range(1, 20)] private float length;

    [SerializeField] private Transform head;
    [SerializeField] private Transform chunk;

    [SerializeField] private Transform parent;

    [SerializeField] private CameraFollower cameraFollower;

    private void Awake()
    {
        CreateSnake();
    }

    private Snake CreateSnake()
    {
        Snake snake = new GameObject("Snake", typeof(Snake)).GetComponent<Snake>();
        snake.transform.parent = parent;

        Vector3 headPosition = GetHeadLocalPosition();
        Vector3 delta = new Vector3(0, 0, length / chunksCount);

        Transform head = GetHead();
        head.parent = snake.transform;
        head.localPosition = GetHeadLocalPosition();

        List<Transform> chunks = new List<Transform>(chunksCount);       
            
        for (int i = 1; i <= chunksCount; i++)
        {
            Transform chunk = GetChunk();
            chunk.parent = snake.transform;
            chunk.localPosition = headPosition - delta * i;
            chunks.Add(chunk);      
        }

        cameraFollower.Followed = snake.transform;

        return snake;
    }

    private Transform GetHead()
    {
        return Instantiate(head);
    }
    
    private Transform GetChunk()
    {
        return Instantiate(chunk);
    }

    private Vector3 GetHeadLocalPosition()
    {
        return new Vector3(0, 0, length / 2);
    }
}
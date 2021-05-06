using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    
    [SerializeField] private SnakeFactory snakeFactory;
    [SerializeField, Range(1, 20)] private int chunksCount;
    [SerializeField, Range(1, 20)] private float length;
    
    private Transform head;
    private List<Transform> chunks;
    
    private void Awake()
    {       
        CreateSnake();
    }

    private void CreateSnake()
    {
        Vector3 headPosition = GetHeadPosition();

        head = snakeFactory.GetSnakeHead();
        head.localPosition = headPosition;

        chunks = new List<Transform>(chunksCount);

        Vector3 delta = new Vector3(0, 0, length / chunksCount) ;
       
        for (int i = 1; i <= chunksCount; i++)
        {
            Transform chunk = snakeFactory.GetSnakeChunk();
            chunks.Add(chunk);
            chunk.localPosition = headPosition - delta * i;
        }
    }

    private Vector3 GetHeadPosition()
    {
        return new Vector3(0, 0, length / 2);
    }
}
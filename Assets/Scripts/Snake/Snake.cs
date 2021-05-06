using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private Transform snakePartsParent;
    [SerializeField] private Transform snakeHead;
    [SerializeField] private Transform snakeChunk;
    
    [SerializeField, Range(1, 20)] private int snakeChunksCount;
    [SerializeField, Range(1, 20)] private float snakeLength; 
    
    [SerializeField, Range(1, 5)] private float chunkPositionsCount;   
    
    private List<Vector3> chunkPositions;
    private List<Transform> snakeChunks;

    private void Awake()
    {
        snakeChunks = new List<Transform>(snakeChunksCount);
        CreateSnake();
    }

    private void CreateSnake()
    {
        Vector3 headPosition = GetHeadPosition();

        Transform head = Instantiate(snakeHead, snakePartsParent);
        head.localPosition = headPosition;

        Vector3 delta = new Vector3(0, 0, snakeLength / snakeChunksCount) ;

        for (int i = 1; i <= snakeChunksCount; i++)
        {
            Transform chunk = Instantiate(snakeChunk, snakePartsParent);
            snakeChunks.Add(chunk);
            chunk.localPosition = headPosition - delta * i;
        }
    }

    public Vector3 GetHeadPosition()
    {
        return new Vector3(0, 0, snakeLength / 2);
    }
}
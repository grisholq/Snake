using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(SnakeParts))]
public class SnakeCreator : MonoBehaviour
{
    [SerializeField, Range(1, 20)] private int chunksCount;
    [SerializeField, Range(1, 20)] private float snakeLength;

    [SerializeField] ChunkSettings chunkSettings;

    [SerializeField] CameraFollower cameraFollower;

    private SnakePartsFactory factory;
    private SnakeParts parts;

    private void Awake()
    {
        factory = GetComponent<SnakePartsFactory>();
        parts = GetComponent<SnakeParts>();
        CreateSnake();
    }

    private void CreateSnake()
    {
        CreateSnakeHead();
        CreateSnakeChunks();
    }

    private void CreateSnakeHead()
    {
        SnakeHead head = factory.GetHead();
        head.transform.localPosition = GetHeadLocalPosition();
        head.OnCollision += null;
        parts.Head = head;
        cameraFollower.Followed = parts.Head.transform;
    }

    private void CreateSnakeChunks()
    {
        Vector3 start = GetHeadLocalPosition();
        Vector3 delta = new Vector3(0, 0, snakeLength / chunksCount);

        List<SnakeChunk> chunks = new List<SnakeChunk>(chunksCount);

        for (int i = 1; i <= chunksCount; i++)
        {
            SnakeChunk chunk = factory.GetChunk();
            chunk.transform.localPosition = start - delta * i;
            chunks.Add(chunk);
        }

        parts.Chunks = chunks;
        
        InizializeChunks();
    }

    public void InizializeChunks()
    {
        List<SnakeChunk> chunks = parts.Chunks;

        chunks[0].NextChunk = parts.Head.transform;
        chunks[0].ChunkSettings = chunkSettings;

        for (int i = 1; i < chunksCount; i++)
        {
            chunks[i].NextChunk = chunks[i - 1].transform;
            chunks[i].ChunkSettings = chunkSettings;
        }
    }

    private Vector3 GetHeadLocalPosition()
    {
        return new Vector3(0, 0, snakeLength / 2);
    }
}
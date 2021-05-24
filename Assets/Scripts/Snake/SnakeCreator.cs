using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(SnakeData))]
public class SnakeCreator : MonoBehaviour
{
    [SerializeField, Range(1, 20)] private int chunksCount;
    [SerializeField, Range(1, 20)] private float snakeLength;

    [SerializeField] ChunkSettings chunkSettings;

    [SerializeField] CameraFollower cameraFollower;

    private SnakePartsFactory factory;
    private SnakeData data;

    private void Awake()
    {
        factory = GetComponent<SnakePartsFactory>();
        data = GetComponent<SnakeData>();
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
        data.Head = head;
        cameraFollower.Followed = data.Head.transform;
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

        data.Chunks = chunks;
        
        InizializeChunks();
    }

    public void InizializeChunks()
    {
        List<SnakeChunk> chunks = data.Chunks;

        chunks[0].NextChunk = data.Head.transform;
        chunks[0].ChunkSettings = chunkSettings;
        chunks[0].SetChunkColor(data.SnakeColor);

        for (int i = 1; i < chunksCount; i++)
        {
            chunks[i].NextChunk = chunks[i - 1].transform;
            chunks[i].ChunkSettings = chunkSettings;
            chunks[i].SetChunkColor(data.SnakeColor);
        }
    }

    private Vector3 GetHeadLocalPosition()
    {
        return new Vector3(0, 0, snakeLength / 2);
    }
}
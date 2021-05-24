using UnityEngine;

public class SnakeChunk : MonoBehaviour
{
    public Transform NextChunk { get; set; }
    public ChunkSettings ChunkSettings { get; set; }

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();   
    }

    public virtual void Move()
    {
        float distance = Vector3.Distance(transform.position, NextChunk.position);
        float percent = (distance - ChunkSettings.MinDistance) / (ChunkSettings.MaxDistance - ChunkSettings.MinDistance);
        float speed = percent * (ChunkSettings.MinSpeed + ChunkSettings.MaxSpeed);

        speed = Mathf.Clamp(speed, ChunkSettings.MinSpeed, ChunkSettings.MaxSpeed);

        transform.position = Vector3.MoveTowards(transform.position, NextChunk.position, speed * Time.deltaTime);
    }

    public void SetChunkColor(Color color)
    {
        meshRenderer.material.color = color;
    }
}
using UnityEngine;

public class SnakeChunk : MonoBehaviour
{
    public Transform NextChunk { get; set; }
    public ChunkSettings ChunkSettings { get; set; }

    private MeshRenderer meshRenderer;
    private new Rigidbody rigidbody;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void Move()
    {
        /*float distance = Vector3.Distance(transform.position, NextChunk.position);
        float percent = (distance - ChunkSettings.MinDistance) / (ChunkSettings.MaxDistance - ChunkSettings.MinDistance);
        float speed = percent * (ChunkSettings.MinSpeed + ChunkSettings.MaxSpeed);
        speed = Mathf.Clamp(speed, ChunkSettings.MinSpeed, ChunkSettings.MaxSpeed);      
        transform.position = Vector3.MoveTowards(transform.position, NextChunk.position, speed * Time.deltaTime);*/

        Vector3 dir = (NextChunk.transform.position - transform.position).normalized * -1;

        transform.position = NextChunk.position + dir * (ChunkSettings.MinDistance + Random.Range(0, ChunkSettings.MaxDistance));
    }

    public void SetChunkColor(Color color)
    {
        meshRenderer.material.color = color;
    }
}
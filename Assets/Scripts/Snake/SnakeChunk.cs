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
        Vector3 dir = (NextChunk.transform.position - transform.position).normalized * -1;

        transform.position = NextChunk.position + dir * (ChunkSettings.MinDistance + Random.Range(0, ChunkSettings.MaxDistance));
    }

    public void SetColor(Color color)
    {
        meshRenderer.material.color = color;
    }
}
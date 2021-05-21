using UnityEngine;

public class SnakeChunk : MonoBehaviour
{
    public Transform NextChunk { get; set; }
    public float MinDistance { get; set; }
    public float MaxDistance { get; set; }
    public float MinSpeed { get; set; }
    public float MaxSpeed { get; set; }

    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();   
    }

    public virtual void Move()
    {
        float distance = Vector3.Distance(transform.position, NextChunk.position);
        float percent = (distance - MinDistance) / (MaxDistance - MinDistance);
        float speed = percent * (MinSpeed + MaxSpeed);

        speed = Mathf.Clamp(speed, MinSpeed, MaxSpeed);

        transform.position = Vector3.MoveTowards(transform.position, NextChunk.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Checkpoint checkpoint = other.gameObject.GetComponent<Checkpoint>();
        if(checkpoint != null)
        {
            meshRenderer.material.color = Random.ColorHSV();
        }
    }
}
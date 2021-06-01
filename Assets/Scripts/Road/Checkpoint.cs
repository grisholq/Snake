using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Checkpoint : MonoBehaviour
{
    [SerializeField] private Color checkpointColor;
    
    private MeshRenderer meshRenderer;

    public Color CheckpointColor { get => checkpointColor; set => checkpointColor = value; }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = checkpointColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        SnakeChunk chunk = other.GetComponent<SnakeChunk>();
        SnakeHead head = other.GetComponent<SnakeHead>();
        
        if(chunk != null)
        {
            chunk.SetColor(checkpointColor);
        }
        
        if(head != null)
        {
            head.SetColor(checkpointColor);
        }
    }
}
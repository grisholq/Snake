using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Human : MonoBehaviour
{
    [SerializeField] private Color color;

    private MeshRenderer meshRenderer;
    private CapsuleCollider collider;

    public Color Color { get => color; set => color = value; }

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = color;

        collider = GetComponent<CapsuleCollider>();
    }

    public void SetColliderActivity(bool activity)
    {
        collider.enabled = activity;
    }
}
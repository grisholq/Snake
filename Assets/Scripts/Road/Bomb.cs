using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Collider collider;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }

    public void SetColliderActivity(bool activity)
    {
        collider.enabled = activity;
    }
}
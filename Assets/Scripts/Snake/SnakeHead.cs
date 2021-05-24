using System;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{
    private new Rigidbody rigidbody;
   
    public event Action<Collider> OnSafeObjectCollision;
    public event Action<Collider> OnDangerousObjectCollision;
    public event Action<Collider> OnEdibleObjectCollision;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public void SetVelocity(Vector3 velocity)
    {
        rigidbody.velocity = velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<SafeRoadObject>())
        {
            OnSafeObjectCollision.Invoke(other);
        }
        else if (other.gameObject.GetComponent<DangerousRoadObject>())
        {
            OnDangerousObjectCollision.Invoke(other);
        }
        else if (other.gameObject.GetComponent<EdibleRoadObject>())
        {
            OnEdibleObjectCollision.Invoke(other);
        }
    }
}
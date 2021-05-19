using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float sideSpeed;

    public Transform Head { get; set; }
    public List<Transform> Chunks { get; set; }

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * sideSpeed);
        }
            
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * sideSpeed);
        }           
    }     
}
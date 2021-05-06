using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMover : MonoBehaviour
{
    [SerializeField, Range(0, 20)] private float movespeed;
    [SerializeField, Range(0, 10)] private float sidespeed;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * sidespeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * sidespeed * Time.deltaTime);
        }

        transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
    }
}

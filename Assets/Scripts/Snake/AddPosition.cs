using UnityEngine;

public class AddPosition : MonoBehaviour
{
    [SerializeField] private Vector3 addPos;

    private void Update()
    {
        transform.position += addPos * Time.deltaTime;

        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            
        }

        if (Input.GetKey(KeyCode.D))
        {

        }

        if (Input.GetKey(KeyCode.A))
        {

        }

        if (Input.GetKey(KeyCode.S))
        {

        }
    }
}
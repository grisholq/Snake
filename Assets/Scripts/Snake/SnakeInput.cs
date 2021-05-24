using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    public bool IsRightInput { get; set; }
    public bool IsLeftInput { get; set; }

    private void Update()
    {
        IsRightInput = false;
        IsLeftInput = false;

        if (Input.GetKey(KeyCode.A))
        {
            IsLeftInput = true;
            return;
        }
        
        if(Input.GetKey(KeyCode.D))
        {
            IsRightInput = true;
            return;
        }
    }
}
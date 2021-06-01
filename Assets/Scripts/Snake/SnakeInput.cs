using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    public bool IsRightInput { get; set; }
    public bool IsLeftInput { get; set; }

    private void Update()
    {
        IsRightInput = false;
        IsLeftInput = false;

        ProcessKeyboardInput(); 
        ProcessTouchInput();
    }

    private void ProcessKeyboardInput()
    {

        if (Input.GetKey(KeyCode.A))
        {
            IsLeftInput = true;
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            IsRightInput = true;
            return;
        }
    }
    
    private void ProcessTouchInput()
    {
        if (Input.touchCount != 1) return;

        Touch touch = Input.GetTouch(0);
        Resolution resolution = Screen.currentResolution;

        if (touch.position.x < resolution.width / 2)
        {
            IsLeftInput = true;
        }
        else
        {
            IsRightInput = true;
        }
    }
}
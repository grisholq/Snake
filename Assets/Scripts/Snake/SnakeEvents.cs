using UnityEngine;
using UnityEngine.Events;

public class SnakeEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent SnakeDeath;
    [SerializeField] private UnityEvent SnakeFinish;

    public UnityEvent OnSnakeDeath { get => SnakeDeath; set => SnakeDeath = value; }
    public UnityEvent OnSnakeReachFinish { get => SnakeFinish; set => SnakeFinish = value; }

    public void Die()
    {
        SnakeDeath.Invoke();
    }

    public void Finish()
    {
        SnakeFinish.Invoke();
    }
}
using UnityEngine;
using UnityEngine.Events;

public class SnakeEvents : MonoBehaviour
{
    [SerializeField] private UnityEvent onSnakeDeath;
    [SerializeField] private UnityEvent onSnakeReachFinish;

    public UnityEvent OnSnakeDeath { get => onSnakeDeath; set => onSnakeDeath = value; }
    public UnityEvent OnSnakeReachFinish { get => onSnakeReachFinish; set => onSnakeReachFinish = value; }

    public void Die()
    {
        onSnakeDeath.Invoke();
    }

    public void Finish()
    {
        onSnakeReachFinish.Invoke();
    }
}
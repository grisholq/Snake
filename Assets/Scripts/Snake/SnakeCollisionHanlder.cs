using UnityEngine;

[RequireComponent(typeof(SnakeParts), typeof(SnakeEater))]
public class SnakeCollisionHanlder : MonoBehaviour
{
    private SnakeParts parts;
    private SnakeEater eater;

    private void Start()
    {
        parts = GetComponent<SnakeParts>();
        eater = GetComponent<SnakeEater>();
        parts.Head.OnCollision += HandleCollision;
    }

    public void HandleCollision(Collider other)
    {
        Human human = other.gameObject.GetComponent<Human>();

        if (human != null) HandleHuman(human);
    }

    private void HandleHuman(Human human)
    {
        eater.EatByPull(human.transform);
    }
    
    private void HandleCheckpoint(Checkpoint checkpoint)
    {
        
    }

    private void HandleCrystal()
    {

    }
    
    
    
    private void HandleObstacle()
    {

    }
}
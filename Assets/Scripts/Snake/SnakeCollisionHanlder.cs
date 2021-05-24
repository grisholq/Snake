using UnityEngine;

[RequireComponent(typeof(SnakeData), typeof(SnakeEater), typeof(SnakeEvents))]
public class SnakeCollisionHanlder : MonoBehaviour
{
    private SnakeData parts;
    private SnakeEater eater;
    private SnakeEvents events;

    private void Start()
    {
        parts = GetComponent<SnakeData>();
        eater = GetComponent<SnakeEater>();
        events = GetComponent<SnakeEvents>();

        parts.Head.OnDangerousObjectCollision += HandleDangerousCollisions;
        parts.Head.OnEdibleObjectCollision += HandleFoodCollisions;
        parts.Head.OnSafeObjectCollision += HandleSafeCollisions;
    }

    public void HandleDangerousCollisions(Collider other)
    {

    }

    public void HandleSafeCollisions(Collider other)
    {

    }

    public void HandleFoodCollisions(Collider other)
    {
        eater.EatByPull(other.gameObject.transform);
    }

    private void HandleHuman(Human human)
    {
        if (human == null) return;
        human.SetColliderActivity(false);
        eater.EatByPull(human.transform);
    }
    
    private void HandleCheckpoint(Checkpoint checkpoint)
    {
        
    }

    private void HandleCrystal()
    {

    }
     
    private void HandleObstacle(Bomb obstacle)
    {
        if (obstacle == null) return;
        events.Die();
    }

    private void HandleFinish(Finish finish)
    {
        if (finish == null) return;
        events.Finish();
    }
}
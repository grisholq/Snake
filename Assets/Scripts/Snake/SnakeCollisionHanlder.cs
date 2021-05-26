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

        parts.Head.OnCollision += HandleCollisions;
    }

    public void HandleCollisions(Collider other)
    {
        HandleHuman(other.GetComponent<Human>());
        HandleCheckpoint(other.GetComponent<Checkpoint>());
        HandleBomb(other.GetComponent<Bomb>());
        HandleFinish(other.GetComponent<Finish>());
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
     
    private void HandleBomb(Bomb obstacle)
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
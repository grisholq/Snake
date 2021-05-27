using UnityEngine;

[RequireComponent(typeof(SnakeData), typeof(SnakeEater), typeof(SnakeEvents))]
public class SnakeCollisionHanlder : MonoBehaviour
{
    private SnakeData data;
    private SnakeEater eater;
    private SnakeEvents events;

    private void Start()
    {
        data = GetComponent<SnakeData>();
        eater = GetComponent<SnakeEater>();
        events = GetComponent<SnakeEvents>();

        data.Head.HeadCollision += OnHeadCollision;
        data.Head.FoodCollision += OnFoodCollision;
    }

    public void OnFoodCollision(Collider other)
    {
        HandleHuman(other.GetComponent<Human>());
        HandleBomb(other.GetComponent<Bomb>());
        HandleCrystal(other.GetComponent<Crystal>());
    }

    public void OnHeadCollision(Collider other)
    {
        HandleCheckpoint(other.GetComponent<Checkpoint>());
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
        if (checkpoint == null) return;
        Debug.Log("Checkpoint");
    }

    private void HandleCrystal(Crystal crystal)
    {
        if (crystal == null) return;
        Debug.Log("Crystal");
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
        Debug.Log("Finish");
    }
}
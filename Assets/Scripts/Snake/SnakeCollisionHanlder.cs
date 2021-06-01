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
        data.Head.FewerCollision += OnFewerCollision;
    }

    public void OnFoodCollision(Collider other)
    {
        if (data.IsInFewer) return;
        HandleHuman(other.GetComponent<Human>());
        HandleCrystal(other.GetComponent<Crystal>());
    }

    public void OnHeadCollision(Collider other)
    {
        HandleCheckpoint(other.GetComponent<Checkpoint>());
        HandleFinish(other.GetComponent<Finish>());
        HandleBomb(other.GetComponent<Bomb>());
    }
    
    public void OnFewerCollision(Collider other)
    {
        if (!data.IsInFewer) return;
        HandleHuman(other.GetComponent<Human>());
        HandleBomb(other.GetComponent<Bomb>());
        HandleCrystal(other.GetComponent<Crystal>());
    }

    private void HandleHuman(Human human)
    {
        if (human == null) return;

        human.SetColliderActivity(false);

        if (!IsSameColor(human.Color, data.SnakeColor) && !data.IsInFewer)
        {
            events.Die();
            return;
        }
             
        eater.EatByPull(human.transform);
        eater.HumansEaten++;
    }
    
    private void HandleCheckpoint(Checkpoint checkpoint)
    {
        if (checkpoint == null) return;
        data.SnakeColor = checkpoint.CheckpointColor;
    }

    private void HandleCrystal(Crystal crystal)
    {
        if (crystal == null) return;

        eater.EatByPull(crystal.transform);
        eater.CrystalsEaten++;

        if(!data.IsInFewer)
        {
            eater.CrystalsFewerEaten++;
        }      
    }
     
    private void HandleBomb(Bomb bomb)
    {
        if (bomb == null) return;

        if(data.IsInFewer)
        {
            eater.EatByPull(bomb.transform);
            bomb.SetColliderActivity(false);
            return;
        }

        events.Die();
    }

    private void HandleFinish(Finish finish)
    {
        if (finish == null) return;
        events.Finish();
    }

    public bool IsSameColor(Color first, Color second)
    {
        bool equal = true;
        float inaccuracy = 0.01f;

        equal &= Mathf.Abs(first.r - second.r) <= inaccuracy; 
        equal &= Mathf.Abs(first.g - second.g) <= inaccuracy;
        equal &= Mathf.Abs(first.b - second.b) <= inaccuracy;

        return equal;
    }
}
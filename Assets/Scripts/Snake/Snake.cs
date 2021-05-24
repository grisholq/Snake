using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    /*[SerializeField] private SnakeEater eater;


       
    [SerializeField] private CameraFollower cameraFollower;

    

    [SerializeField] private Color snakeColor;


    private LinkedList<Human> humansToEat;

    private void Awake()
    {
        humansToEat = new LinkedList<Human>();
    }

    private void Update()
    {
        ProcessMovement();
        EatHumen();
    }







    private void OnHeadCollision(Collider other)
    {
        Checkpoint checkpoint = other.gameObject.GetComponent<Checkpoint>();
        Human human = other.gameObject.GetComponent<Human>();

        if (checkpoint != null) OnCheckpointEntering(checkpoint);
        if (human != null) OnHumanEntering(human);
    }

    private void OnCheckpointEntering(Checkpoint checkpoint)
    {
        snakeColor = checkpoint.CheckpointColor;
    }

    private void OnHumanEntering(Human human)
    {
        human.SetColliderActivity(false);
        humansToEat.AddLast(human);
    }
    
    private void OnCrystalEntering(Human human)
    {
        human.Destroy();
    }*/
}
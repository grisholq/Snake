using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnakeData))]
public class SnakeEater : MonoBehaviour
{
    [SerializeField] private float pullForce;
    [SerializeField] private float fewerPullForce;
    [SerializeField] private float pullEatRange;

    [SerializeField] private float crystalsToFewer;

    private LinkedList<Transform> pullFood;

    private SnakeData data;

    public int HumansEaten { get; set; }
    public int CrystalsEaten { get; set; }
    public int CrystalsFewerEaten { get; set; }

    private void Start()
    {
        pullFood = new LinkedList<Transform>();
        data = GetComponent<SnakeData>();

        HumansEaten = 0;
        CrystalsEaten = 0;
        CrystalsFewerEaten = 0;
    }

    private void Update()
    {
        UpdatePullFood();

        if(crystalsToFewer == CrystalsFewerEaten)
        {
            CrystalsFewerEaten = 0;
            data.IsInFewer = true;
        }
    }

    public void EatImmediately(Transform food)
    {
        Destroy(food.gameObject);
    }

    public void EatByPull(Transform food)
    {
        pullFood.AddLast(food);
    }

    private void UpdatePullFood()
    {
        if (pullFood.Count == 0) return;

        LinkedListNode<Transform> node = pullFood.First;

        while (node != null)
        {
            Transform food = node.Value;

            float force = data.IsInFewer ? fewerPullForce : pullForce ;
            food.position = Vector3.MoveTowards(food.position, data.Head.transform.position, Time.deltaTime * force);

            float range = Vector3.Distance(food.position, data.Head.transform.position);

            if (range <= pullEatRange)
            {
                node = RemoveNode(node);
                EatImmediately(food); 
                continue;
            }

            node = node.Next;
        }
    }

    private LinkedListNode<Transform> RemoveNode(LinkedListNode<Transform> curr)
    {
        LinkedListNode<Transform> next = curr.Next;
        pullFood.Remove(curr);
        return next;
    }
}
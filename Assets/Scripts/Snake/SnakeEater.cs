using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnakeData))]
public class SnakeEater : MonoBehaviour
{
    [SerializeField] private float pullForce;
    [SerializeField] private float pullEatRange;

    private LinkedList<Transform> pullFood;

    private SnakeData parts;

    private void Start()
    {
        pullFood = new LinkedList<Transform>();
        parts = GetComponent<SnakeData>();
    }

    private void Update()
    {
        UpdatePullFood();
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

            food.position = Vector3.MoveTowards(food.position, parts.Head.transform.position, Time.deltaTime * pullForce);

            float range = Vector3.Distance(food.position, parts.Head.transform.position);

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
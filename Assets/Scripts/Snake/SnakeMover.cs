using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnakeInput), typeof(SnakeData))]
public class SnakeMover : MonoBehaviour
{
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float forwardSpeedDecreace;
    [SerializeField] private float sideSpeed;

    [SerializeField] private float fewerDuration;
    [SerializeField] private float fewerSpeedMultiplier;
    [SerializeField] private float fewerMidleMovespeed;

    private SnakeData data;
    private SnakeInput input;

    private Vector3 velocity;

    private Coroutine fewerCoroutine;

    private void Awake()
    {
        data = GetComponent<SnakeData>();
        input = GetComponent<SnakeInput>();
    }

    private void Update()
    {
        if(data.IsInFewer)
        {
            MoveSnakeInFewer();
        }
        else
        {
            MoveSnake();
        }

        MoveChunks();
    }

    private void MoveSnakeInFewer()
    {
        velocity = Vector3.zero;

        MoveForwardFewer();

        Vector3 position = data.Head.transform.position;
        position.x = Mathf.MoveTowards(position.x, 0, Time.deltaTime * fewerMidleMovespeed);
        data.Head.transform.position = position;

        data.Head.SetVelocity(velocity);

        if (fewerCoroutine == null)
        {
            fewerCoroutine = StartCoroutine(EndFewer());
        }
    }

    private void MoveSnake()
    {
        velocity = Vector3.zero;

        MoveForward();

        if (input.IsRightInput)
        {
            MoveSideway(Vector3.right);
        }
        else if (input.IsLeftInput)
        {
            MoveSideway(Vector3.left);
        }

        data.Head.SetVelocity(velocity);
    }

    private void MoveSideway(Vector3 side)
    {
        velocity += side * sideSpeed;
        velocity -= Vector3.forward * forwardSpeedDecreace;
    }
    
    private void MoveForward()
    {
        velocity += Vector3.forward * forwardSpeed;
    }

    private void MoveForwardFewer()
    {
        velocity += Vector3.forward * forwardSpeed * fewerSpeedMultiplier;
    }

    private void MoveChunks()
    {     
        data.Head.SetVelocity(velocity);

        List<SnakeChunk> chunks = data.Chunks;
        
        for (int i = 0; i < chunks.Count; i++)
        {           
            chunks[i].Move();
        }
    } 

    private IEnumerator EndFewer()
    {
        yield return new WaitForSeconds(fewerDuration);
        data.IsInFewer = false;
    }
}
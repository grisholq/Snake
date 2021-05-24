using System.Collections.Generic;
using UnityEngine;

public class SnakeParts : MonoBehaviour
{
    public SnakeHead Head { get; set; }
    public List<SnakeChunk> Chunks { get; set; }

    private void Awake()
    {
        Chunks = new List<SnakeChunk>();
    }
}
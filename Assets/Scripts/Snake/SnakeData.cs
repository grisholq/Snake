using System.Collections.Generic;
using UnityEngine;

public class SnakeData : MonoBehaviour
{
    [SerializeField] private Color snakeColor;

    public SnakeHead Head { get; set; }
    public List<SnakeChunk> Chunks { get; set; }
    public Color SnakeColor { get => snakeColor; set => snakeColor = value; }

    private void Awake()
    {
        Chunks = new List<SnakeChunk>();
    }
}
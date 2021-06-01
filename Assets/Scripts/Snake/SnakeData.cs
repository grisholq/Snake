using System.Collections.Generic;
using UnityEngine;

public class SnakeData : MonoBehaviour
{
    [SerializeField] private Color snakeColor;
    [SerializeField] private bool isInFewer;

    public SnakeHead Head { get; set; }
    public List<SnakeChunk> Chunks { get; set; }
    public Color SnakeColor { get => snakeColor; set => snakeColor = value; }
    public bool IsInFewer { get => isInFewer; set => isInFewer = value; }
}
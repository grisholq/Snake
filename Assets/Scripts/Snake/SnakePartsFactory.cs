using UnityEngine;

public class SnakePartsFactory : MonoBehaviour
{
    [SerializeField] private Transform headPrefab;
    [SerializeField] private Transform chunkPrefab;

    [SerializeField] private Transform parent;

    public SnakeHead GetHead()
    {
        return Instantiate(headPrefab, transform).GetComponent<SnakeHead>();
    }

    public SnakeChunk GetChunk()
    {
        return Instantiate(chunkPrefab, transform).GetComponent<SnakeChunk>();
    }
}
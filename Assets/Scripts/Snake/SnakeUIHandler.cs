using UnityEngine;
using TMPro;

[RequireComponent(typeof(SnakeEater))]
public class SnakeUIHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text humansText;
    [SerializeField] private TMP_Text crystalsText;

    private SnakeEater eater;

    private void Awake()
    {
        eater = GetComponent<SnakeEater>();
    }

    private void Update()
    {
        humansText.text = eater.HumansEaten.ToString();
        crystalsText.text = eater.CrystalsEaten.ToString();
    }
}
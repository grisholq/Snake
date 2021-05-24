using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject restartButton;

    private void Awake()
    {
        restartButton.SetActive(false); 
    }

    public void FinishLevel()
    {
        restartButton.SetActive(true);
        GlobalTimeManager.Instance.StopTime();     
    }

    public void FailLevel()
    {
        restartButton.SetActive(true);
        GlobalTimeManager.Instance.StopTime();
    }
}
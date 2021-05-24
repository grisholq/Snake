using UnityEngine;

public class GlobalTimeManager : Singleton<GlobalTimeManager>
{
    private float timeScale;
    private float fixedTimeStep;

    private void Awake()
    {
        timeScale = Time.timeScale;
        fixedTimeStep = Time.fixedDeltaTime;
        DontDestroyOnLoad(this.gameObject);
    }

    public void StopTime()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;
    }
    
    public void ResumeTime()
    {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = fixedTimeStep;
    }
}
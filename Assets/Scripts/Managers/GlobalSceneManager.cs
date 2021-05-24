using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalSceneManager : Singleton<GlobalSceneManager>
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadCurrentScene();
        } 
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

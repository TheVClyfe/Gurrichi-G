using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;

    void Awake()
    {
        var objects = FindObjectsOfType<LevelLoader>();
        if(objects.Length > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            StartCoroutine(StartMenuScreenAfterDelay());
        }        
    }

    IEnumerator StartMenuScreenAfterDelay()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene((currentSceneIndex + 1) % SceneManager.sceneCount);
    }

    public void LoadYouLoseScene()
    {
        SceneManager.LoadScene("LoseScreen");
    }
}

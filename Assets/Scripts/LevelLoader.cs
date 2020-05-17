using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(StartMenuScreenAfterDelay());
    }

    IEnumerator StartMenuScreenAfterDelay()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(1);
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    public void LoadNewScene(string nextScene)
    {
        StartCoroutine(LoadScene(nextScene));
    }

    IEnumerator LoadScene(string nextScene)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSecondsRealtime(transitionTime);

        SceneManager.LoadScene(nextScene);

        Debug.Log(nextScene);

        Time.timeScale = 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MVP_Level-A")
        {
            StartCoroutine(LoadScene("Dock"));

        }
        else
        {
            StartCoroutine(LoadScene("MVP_Level-A"));
        }
    }
}

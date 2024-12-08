using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider loadSlider;

    public void LoadNextLevel(string levelToLoad)
    {
        loadingScreen.SetActive(true);
        StartCoroutine(LoadLevelAsync(levelToLoad));
    }
    IEnumerator LoadLevelAsync(string levelToLoad)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(levelToLoad);
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadSlider.value = progressValue;
            yield return null;
        }
    }
}

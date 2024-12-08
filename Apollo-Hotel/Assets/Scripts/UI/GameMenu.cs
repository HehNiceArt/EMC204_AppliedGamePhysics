using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    bool isActive = false;
    void Start()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isActive)
        {
            isActive = !isActive;
            canvas.SetActive(isActive);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isActive)
        {
            isActive = !isActive;
            canvas.SetActive(isActive);
            Time.timeScale = 1;
        }
    }
    public void LevelReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ResumeGame()
    {
        isActive = false;
        canvas.SetActive(isActive);
        Time.timeScale = 1;
    }
}

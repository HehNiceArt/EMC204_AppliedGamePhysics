using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] String levelScene;
    [SerializeField] LoadLevel loadLevel;

    private void Start()
    {
        loadLevel = FindAnyObjectByType<LoadLevel>();
    }
    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(levelScene))
        {
            loadLevel.LoadNextLevel(levelScene);
        }
    }
}
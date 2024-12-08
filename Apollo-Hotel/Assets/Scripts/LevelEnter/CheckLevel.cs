using System.Collections.Generic;
using UnityEngine;

public class CheckLevel : MonoBehaviour
{
    Level level;
    GameObject levelGO;
    [SerializeField] CheckWhichLevel checkWhichLevel;
    private void Start()
    {
        checkWhichLevel = FindObjectOfType<CheckWhichLevel>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("1stLevel") || other.gameObject.CompareTag("2ndLevel") || other.gameObject.CompareTag("3rdLevel") || other.gameObject.CompareTag("4thLevel"))
        {
            level = other.gameObject.GetComponent<Level>();
            levelGO = other.gameObject;
            CheckLevelTag(levelGO);
            level.LoadScene();
        }
    }
    void CheckLevelTag(GameObject obj)
    {
        string levelTag = obj.tag;

        switch (levelTag)
        {
            case "1stLevel":
                checkWhichLevel.CheckLevel(0);
                Debug.Log("Enter 1st Level");
                break;
            case "2ndLevel":
                checkWhichLevel.CheckLevel(1);
                Debug.Log("Enter 2nd Level");
                break;
            case "3rdLevel":
                checkWhichLevel.CheckLevel(2);
                Debug.Log("Enter 3rd Level");
                break;
            case "4thLevel":
                checkWhichLevel.CheckLevel(3);
                Debug.Log("Enter 4th Level");
                break;
            default:
                Debug.LogWarning("No level tag found!");
                return;
        }
    }
}
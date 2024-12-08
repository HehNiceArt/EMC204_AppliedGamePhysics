using UnityEngine;

public class LevelClear : MonoBehaviour
{
    [SerializeField] GameObject[] levelGO;
    [SerializeField] LevelSO levelSO;

    private void Start()
    {
        if (levelSO.isFirstLevel)
        {
            levelGO[0].SetActive(false);
        }
        if (levelSO.isSecondLevel)
        {
            levelGO[1].SetActive(false);
        }
        if (levelSO.isThirdLevel)
        {
            levelGO[2].SetActive(false);
        }
        if (levelSO.isFourthLevel)
        {
            levelGO[3].SetActive(false);
        }
    }
}
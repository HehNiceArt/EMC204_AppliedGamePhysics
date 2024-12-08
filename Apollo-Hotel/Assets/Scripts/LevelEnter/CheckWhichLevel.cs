using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWhichLevel : MonoBehaviour
{
    [SerializeField] LevelSO levelSO;
    public void CheckLevel(int num)
    {
        if (num == 0)
        {
            levelSO.isFirstLevel = true;
        }
        else if (num == 1)
        {
            levelSO.isSecondLevel = true;
        }
        else if (num == 2)
        {
            levelSO.isThirdLevel = true;
        }
        else if (num == 3)
        {
            levelSO.isFourthLevel = true;
        }
    }
}

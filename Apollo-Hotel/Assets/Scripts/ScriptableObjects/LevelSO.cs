using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "LevelSO", order = 0)]
public class LevelSO : ScriptableObject
{
    public bool isFirstLevel = false;
    public bool isSecondLevel = false;
    public bool isThirdLevel = false;
    public bool isFourthLevel = false;
}
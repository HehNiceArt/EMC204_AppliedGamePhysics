using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] KeyItemSO keyItemSO;
    [SerializeField] GameObject ship;
    [SerializeField] GameObject gameOverUI;

    private void Start()
    {
        if (keyItemSO.firstItem == true && keyItemSO.secondItem == true && keyItemSO.thirdItem == true && keyItemSO.fourthItem == true)
        {
            ship.AddComponent<SphereCollider>();
            ship.AddComponent<ShipCollider>();
            SphereCollider sphereCollider = ship.GetComponent<SphereCollider>();
            sphereCollider.isTrigger = true;
            sphereCollider.radius = 6f;
        }
        gameOverUI.SetActive(false);
    }
    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }
}
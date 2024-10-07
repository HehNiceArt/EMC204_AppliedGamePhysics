using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawning : MonoBehaviour
{
    [SerializeField] GameObject platform;
    [SerializeField] public bool isVisible;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] GunShoot gunShoot;

    void Start()
    {
        isVisible = true;
        SpawnArea();
    }

    void Update()
    {
        CheckVisibility();
    }
    void CheckVisibility()
    {
        if (isVisible && gunShoot.bulletinUse && gunShoot.cooldown < 0f)
        {
            platform.SetActive(false);
            isVisible = false;
        }
        if (!gunShoot.bulletinUse && !isVisible)
        {
            SpawnArea();
            isVisible = true;
        }
    }
    public void SpawnArea()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-spawnArea.x / 2, spawnArea.x / 2), platform.transform.position.y);
        platform.transform.position = spawnPosition;
        platform.SetActive(true);
    }
}

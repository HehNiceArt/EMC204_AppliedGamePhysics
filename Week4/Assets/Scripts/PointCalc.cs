using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointCalc : MonoBehaviour
{
    [SerializeField] private GunRaycast gunRaycast;
    [SerializeField] private GunShoot gunShoot;
    [SerializeField] private AreaSpawning areaSpawning;
    [SerializeField] TextMeshProUGUI points;
    [SerializeField] int point;
    [SerializeField] bool hasScored = false;
    // Update is called once per frame
    void Update()
    {
        if (gunShoot.bulletinUse && gunRaycast.dir < 3f)
        {
            if (gunRaycast.dir > 0f && gunRaycast.dir < 1f && !hasScored)
            {
                point += 3;
                hasScored = true;
                UpdateScore();
            }
            else if (gunRaycast.dir > 2f && gunRaycast.dir < 3f && !hasScored)
            {
                point += 1;
                hasScored = true;
                UpdateScore();
            }
        }
        else
        {
            hasScored = false;
        }

    }
    void UpdateScore()
    {
        points.text = point.ToString();
    }
}

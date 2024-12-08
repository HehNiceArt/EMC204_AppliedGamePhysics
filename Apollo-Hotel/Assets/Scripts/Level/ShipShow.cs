using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShow : MonoBehaviour
{
    [SerializeField] GameObject firstTail;
    [SerializeField] GameObject secondTail;
    [SerializeField] GameObject thirdTail;
    [SerializeField] GameObject fourthBody;
    [SerializeField] KeyItemSO keyItemSO;
    void Start()
    {
        firstTail.SetActive(false);
        secondTail.SetActive(false);
        thirdTail.SetActive(false);
        fourthBody.SetActive(false);

        if (keyItemSO.firstItem == true)
        {
            firstTail.SetActive(true);
        }
        if (keyItemSO.secondItem == true)
        {
            secondTail.SetActive(true);
        }
        if (keyItemSO.thirdItem == true)
        {
            thirdTail.SetActive(true);
        }
        if (keyItemSO.fourthItem == true)
        {
            fourthBody.SetActive(true);
        }
    }

}

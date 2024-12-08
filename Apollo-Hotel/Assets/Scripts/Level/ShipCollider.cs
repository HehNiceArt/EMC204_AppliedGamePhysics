using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollider : MonoBehaviour
{
    EndGame endGame;
    private void Start()
    {
        endGame = FindAnyObjectByType<EndGame>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            endGame.GameOver();

        }
    }
}

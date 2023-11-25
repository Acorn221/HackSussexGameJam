using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {

        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // Perform any additional actions, such as increasing the player's score

            // Destroy the coin
            Destroy(gameObject);
        }
    }
}

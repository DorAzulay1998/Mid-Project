using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPickUp : MonoBehaviour
{
    int pointsForMoneyPickUp = 100;
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<ScoreText>().AddToScore(pointsForMoneyPickUp);
            Destroy(gameObject);
        }
    }
}

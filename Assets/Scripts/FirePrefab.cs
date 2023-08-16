using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePrefab : MonoBehaviour
{
    
    float fireSpeed;
    Rigidbody2D rb2d;
    PlayerMovement player;
    float playerDirection;
    
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>();
        fireSpeed = 20f;
        playerDirection = player.transform.localScale.x * fireSpeed;
    }

    void Update()
    {
        rb2d.velocity = new Vector2(playerDirection, 0f);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }
}

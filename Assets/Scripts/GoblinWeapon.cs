using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinWeapon : MonoBehaviour
{
    public float throwingSpeed;
    private GameObject player;
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        throwingSpeed = 10f;
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = player.transform.position - transform.position;
        rb2d.velocity = new Vector2(direction.x, direction.y).normalized * throwingSpeed;
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Platform")
        {
            Destroy(gameObject);
        }
    }
}
